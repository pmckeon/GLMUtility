using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GLMUtility
{
    public partial class GLMUtility : Form
    {
        private GLM _glm;
        private Guid _extractGuid;
        private bool _dragItem;

        public GLMUtility()
        {
            InitializeComponent();

            _glm = new GLM();
            _extractGuid = Guid.NewGuid();
            _dragItem = false;

            addEditMenuItem.Enabled = false;
            deleteEditMenuItem.Enabled = false;
            extractEditMenuItem.Enabled = false;
            selectAllEditMenuItem.Enabled = false;
            addButton.Enabled = false;
            extractButton.Enabled = false;
        }

        private void UpdateFileList()
        {
            fileListView.Items.Clear();

            var files = _glm.GetFileList();

            fileListView.BeginUpdate();

            for (int i = 0; i < files.Length; i++)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = files[i].name;
                DateTimeOffset value = DateTimeOffset.FromUnixTimeSeconds((long)files[i].timestamp);
                listItem.SubItems.Add(value.ToString("g"));
                listItem.SubItems.Add(files[i].fileSize.ToString("n0"));
                listItem.SubItems.Add(files[i].length.ToString("n0"));
                string type = _glm.GetFlagName(files[i].flags);
                listItem.SubItems.Add($"{type} ({files[i].flags})");

                fileListView.Items.Add(listItem);
            }

            fileListView.EndUpdate();

            if (fileListView.Items.Count > 0)
            {
                addEditMenuItem.Enabled = true;
                deleteEditMenuItem.Enabled = true;
                extractEditMenuItem.Enabled = true;
                selectAllEditMenuItem.Enabled = true;
                addButton.Enabled = true;
                extractButton.Enabled = true;
            }
            else
            {
                addEditMenuItem.Enabled = false;
                deleteEditMenuItem.Enabled = false;
                extractEditMenuItem.Enabled = false;
                selectAllEditMenuItem.Enabled = false;
                addButton.Enabled = _glm.GetPath() == "" ? false : true;
                extractButton.Enabled = false;
            }
        }

        private void newFileMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog()
            {
                FileName = "New",
                Filter = "Archive files (*.glm)|*.glm",
                Title = "New glm file"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _glm.Open(fileDialog.FileName, true);
                this.Text = fileDialog.FileName;

                UpdateFileList();
            }
        }

        private void openFileMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                FileName = "Select a glm file",
                Filter = "Archive files (*.glm)|*.glm",
                Title = "Open glm file"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                _glm.Open(fileDialog.FileName);
                this.Text = fileDialog.FileName;

                UpdateFileList();
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fileListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (fileListView.GetItemAt(e.X, e.Y) is ListViewItem)
                {
                    fileContextMenu.Show(Cursor.Position);
                }
                else
                {
                    ListViewContextMenu.Show(Cursor.Position);
                }
            }
        }

        private void extractMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ClientGuid = _extractGuid;
            folderBrowserDialog.Description = "Choose the location to extract too";
            folderBrowserDialog.UseDescriptionForTitle = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                if (fileListView.SelectedIndices.Count == 0)
                {
                    foreach (ListViewItem item in fileListView.Items)
                    {
                        _glm.Extract(item.Index, folderBrowserDialog.SelectedPath);
                    }
                }
                else
                {
                    foreach (int item in fileListView.SelectedIndices)
                    {
                        _glm.Extract(item, folderBrowserDialog.SelectedPath);
                    }
                }
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (fileListView.SelectedIndices.Count == 0)
                return;

            var result = MessageBox.Show("Are you sure that you would like to delete the selected files?", "Delete Files",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int[] indices = new int[fileListView.SelectedIndices.Count];
                fileListView.SelectedIndices.CopyTo(indices, 0);
                _glm.Delete(indices);

                UpdateFileList();
            }
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Filter = "All files (*.*)|*.*",
                Title = "Select files to add",
                Multiselect = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                AddFileBox addFileBox = new AddFileBox();
                addFileBox.fileCount = fileDialog.FileNames.Length;

                if (addFileBox.ShowDialog() == DialogResult.OK)
                {
                    _glm.Add(fileDialog.FileNames, addFileBox.SelectedType);

                    UpdateFileList();
                }
            }
        }

        private void selectAllEditMenuItem_Click(object sender, EventArgs e)
        {
            fileListView.BeginUpdate();
            foreach (ListViewItem item in fileListView.Items)
                item.Selected = true;
            fileListView.EndUpdate();
        }

        private void fileListView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                string tempFolder = Path.GetTempPath();
                List<string> files = new List<string>();
                
                foreach (ListViewItem item in fileListView.SelectedItems)
                {
                    _glm.Extract(item.Index, tempFolder);
                    files.Add(tempFolder + item.Text);
                }

                DataObject dataObject = new DataObject(DataFormats.FileDrop, files.ToArray());
                _dragItem = true;
                DoDragDrop(dataObject, DragDropEffects.Copy);
                _dragItem = false;

                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
        }

        private void fileListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data!.GetDataPresent(DataFormats.FileDrop) && _dragItem == false)
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void fileListView_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data!.GetData(DataFormats.FileDrop)!;

            AddFileBox addFileBox = new AddFileBox();
            addFileBox.fileCount = files.Length;

            if (addFileBox.ShowDialog() == DialogResult.OK)
            {
                _glm.Add(files, addFileBox.SelectedType);

                UpdateFileList();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
    }
}