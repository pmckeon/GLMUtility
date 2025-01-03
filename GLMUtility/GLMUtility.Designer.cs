namespace GLMUtility
{
    partial class GLMUtility
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GLMUtility));
            fileListView = new ListView();
            nameHeader = new ColumnHeader();
            modifiedHeader = new ColumnHeader();
            sizeHeader = new ColumnHeader();
            packedHeader = new ColumnHeader();
            flagsHeader = new ColumnHeader();
            mainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newFileMenuItem = new ToolStripMenuItem();
            openFileMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            exitFileMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            addEditMenuItem = new ToolStripMenuItem();
            deleteEditMenuItem = new ToolStripMenuItem();
            extractEditMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            selectAllEditMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutHelpMenuItem = new ToolStripMenuItem();
            maintoolStrip = new ToolStrip();
            newButton = new ToolStripButton();
            openButton = new ToolStripButton();
            addButton = new ToolStripButton();
            extractButton = new ToolStripButton();
            fileContextMenu = new ContextMenuStrip(components);
            extractMenuItem = new ToolStripMenuItem();
            deleteMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            ListViewContextMenu = new ContextMenuStrip(components);
            addMenuItem = new ToolStripMenuItem();
            mainMenu.SuspendLayout();
            maintoolStrip.SuspendLayout();
            fileContextMenu.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            ListViewContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // fileListView
            // 
            fileListView.AllowColumnReorder = true;
            fileListView.AllowDrop = true;
            fileListView.Columns.AddRange(new ColumnHeader[] { nameHeader, modifiedHeader, sizeHeader, packedHeader, flagsHeader });
            fileListView.Dock = DockStyle.Fill;
            fileListView.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileListView.LabelWrap = false;
            fileListView.Location = new Point(0, 98);
            fileListView.Name = "fileListView";
            fileListView.Size = new Size(902, 352);
            fileListView.TabIndex = 1;
            fileListView.UseCompatibleStateImageBehavior = false;
            fileListView.View = View.Details;
            fileListView.ItemDrag += fileListView_ItemDrag;
            fileListView.DragDrop += fileListView_DragDrop;
            fileListView.DragEnter += fileListView_DragEnter;
            fileListView.MouseUp += fileListView_MouseUp;
            // 
            // nameHeader
            // 
            nameHeader.Text = "Name";
            nameHeader.Width = 350;
            // 
            // modifiedHeader
            // 
            modifiedHeader.Text = "Modified";
            modifiedHeader.Width = 150;
            // 
            // sizeHeader
            // 
            sizeHeader.Text = "Size";
            sizeHeader.TextAlign = HorizontalAlignment.Right;
            sizeHeader.Width = 120;
            // 
            // packedHeader
            // 
            packedHeader.Text = "Packed";
            packedHeader.TextAlign = HorizontalAlignment.Right;
            packedHeader.Width = 120;
            // 
            // flagsHeader
            // 
            flagsHeader.Text = "Flags";
            flagsHeader.TextAlign = HorizontalAlignment.Right;
            flagsHeader.Width = 130;
            // 
            // mainMenu
            // 
            mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, helpToolStripMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(902, 24);
            mainMenu.TabIndex = 2;
            mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newFileMenuItem, openFileMenuItem, toolStripSeparator2, exitFileMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // newFileMenuItem
            // 
            newFileMenuItem.Image = (Image)resources.GetObject("newFileMenuItem.Image");
            newFileMenuItem.ImageTransparentColor = Color.Magenta;
            newFileMenuItem.Name = "newFileMenuItem";
            newFileMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            newFileMenuItem.Size = new Size(180, 22);
            newFileMenuItem.Text = "&New";
            newFileMenuItem.Click += newFileMenuItem_Click;
            // 
            // openFileMenuItem
            // 
            openFileMenuItem.Image = (Image)resources.GetObject("openFileMenuItem.Image");
            openFileMenuItem.ImageTransparentColor = Color.Magenta;
            openFileMenuItem.Name = "openFileMenuItem";
            openFileMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openFileMenuItem.Size = new Size(180, 22);
            openFileMenuItem.Text = "&Open";
            openFileMenuItem.Click += openFileMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(177, 6);
            // 
            // exitFileMenuItem
            // 
            exitFileMenuItem.Name = "exitFileMenuItem";
            exitFileMenuItem.Size = new Size(180, 22);
            exitFileMenuItem.Text = "E&xit";
            exitFileMenuItem.Click += exitMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addEditMenuItem, deleteEditMenuItem, extractEditMenuItem, toolStripSeparator4, selectAllEditMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // addEditMenuItem
            // 
            addEditMenuItem.Name = "addEditMenuItem";
            addEditMenuItem.Size = new Size(164, 22);
            addEditMenuItem.Text = "&Add...";
            addEditMenuItem.Click += addMenuItem_Click;
            // 
            // deleteEditMenuItem
            // 
            deleteEditMenuItem.Name = "deleteEditMenuItem";
            deleteEditMenuItem.ShortcutKeys = Keys.Delete;
            deleteEditMenuItem.Size = new Size(164, 22);
            deleteEditMenuItem.Text = "&Delete...";
            deleteEditMenuItem.Click += deleteMenuItem_Click;
            // 
            // extractEditMenuItem
            // 
            extractEditMenuItem.Name = "extractEditMenuItem";
            extractEditMenuItem.Size = new Size(164, 22);
            extractEditMenuItem.Text = "&Extract...";
            extractEditMenuItem.Click += extractMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(161, 6);
            // 
            // selectAllEditMenuItem
            // 
            selectAllEditMenuItem.Name = "selectAllEditMenuItem";
            selectAllEditMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            selectAllEditMenuItem.Size = new Size(164, 22);
            selectAllEditMenuItem.Text = "Select &All";
            selectAllEditMenuItem.Click += selectAllEditMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutHelpMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutHelpMenuItem
            // 
            aboutHelpMenuItem.Name = "aboutHelpMenuItem";
            aboutHelpMenuItem.Size = new Size(116, 22);
            aboutHelpMenuItem.Text = "&About...";
            aboutHelpMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // maintoolStrip
            // 
            maintoolStrip.Items.AddRange(new ToolStripItem[] { newButton, openButton, addButton, extractButton });
            maintoolStrip.Location = new Point(0, 24);
            maintoolStrip.Name = "maintoolStrip";
            maintoolStrip.Size = new Size(902, 74);
            maintoolStrip.TabIndex = 3;
            maintoolStrip.Text = "toolStrip1";
            // 
            // newButton
            // 
            newButton.Image = (Image)resources.GetObject("newButton.Image");
            newButton.ImageScaling = ToolStripItemImageScaling.None;
            newButton.ImageTransparentColor = Color.Magenta;
            newButton.Name = "newButton";
            newButton.Size = new Size(68, 71);
            newButton.Text = "New";
            newButton.TextImageRelation = TextImageRelation.ImageAboveText;
            newButton.Click += newFileMenuItem_Click;
            // 
            // openButton
            // 
            openButton.Image = (Image)resources.GetObject("openButton.Image");
            openButton.ImageScaling = ToolStripItemImageScaling.None;
            openButton.ImageTransparentColor = Color.Magenta;
            openButton.Name = "openButton";
            openButton.Size = new Size(68, 71);
            openButton.Text = "Open";
            openButton.TextImageRelation = TextImageRelation.ImageAboveText;
            openButton.Click += openFileMenuItem_Click;
            // 
            // addButton
            // 
            addButton.Image = (Image)resources.GetObject("addButton.Image");
            addButton.ImageScaling = ToolStripItemImageScaling.None;
            addButton.ImageTransparentColor = Color.Magenta;
            addButton.Name = "addButton";
            addButton.Size = new Size(68, 71);
            addButton.Text = "Add";
            addButton.TextImageRelation = TextImageRelation.ImageAboveText;
            addButton.Click += addMenuItem_Click;
            // 
            // extractButton
            // 
            extractButton.Image = (Image)resources.GetObject("extractButton.Image");
            extractButton.ImageScaling = ToolStripItemImageScaling.None;
            extractButton.ImageTransparentColor = Color.Magenta;
            extractButton.Name = "extractButton";
            extractButton.Size = new Size(68, 71);
            extractButton.Text = "Extract";
            extractButton.TextImageRelation = TextImageRelation.ImageAboveText;
            extractButton.Click += extractMenuItem_Click;
            // 
            // fileContextMenu
            // 
            fileContextMenu.Items.AddRange(new ToolStripItem[] { extractMenuItem, deleteMenuItem });
            fileContextMenu.Name = "fileContextMenu";
            fileContextMenu.Size = new Size(119, 48);
            // 
            // extractMenuItem
            // 
            extractMenuItem.Name = "extractMenuItem";
            extractMenuItem.Size = new Size(118, 22);
            extractMenuItem.Text = "Extract...";
            extractMenuItem.ToolTipText = "Extract the selected files from the archive";
            extractMenuItem.Click += extractMenuItem_Click;
            // 
            // deleteMenuItem
            // 
            deleteMenuItem.Name = "deleteMenuItem";
            deleteMenuItem.Size = new Size(118, 22);
            deleteMenuItem.Text = "Delete...";
            deleteMenuItem.ToolTipText = "Delete the selected files from the archive";
            deleteMenuItem.Click += deleteMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2 });
            contextMenuStrip1.Name = "fileContextMenu";
            contextMenuStrip1.Size = new Size(119, 48);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(118, 22);
            toolStripMenuItem1.Text = "Extract...";
            toolStripMenuItem1.ToolTipText = "Extract the selected items from the archive";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(118, 22);
            toolStripMenuItem2.Text = "Delete...";
            toolStripMenuItem2.ToolTipText = "Delete the selected items";
            // 
            // ListViewContextMenu
            // 
            ListViewContextMenu.Items.AddRange(new ToolStripItem[] { addMenuItem });
            ListViewContextMenu.Name = "ListViewContextMenu";
            ListViewContextMenu.Size = new Size(106, 26);
            // 
            // addMenuItem
            // 
            addMenuItem.Name = "addMenuItem";
            addMenuItem.Size = new Size(105, 22);
            addMenuItem.Text = "Add...";
            addMenuItem.ToolTipText = "Add files to the archive";
            addMenuItem.Click += addMenuItem_Click;
            // 
            // GLMUtility
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 450);
            Controls.Add(fileListView);
            Controls.Add(maintoolStrip);
            Controls.Add(mainMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenu;
            Name = "GLMUtility";
            Text = "GLM Utility";
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            maintoolStrip.ResumeLayout(false);
            maintoolStrip.PerformLayout();
            fileContextMenu.ResumeLayout(false);
            contextMenuStrip1.ResumeLayout(false);
            ListViewContextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView fileListView;
        private ColumnHeader nameHeader;
        private ColumnHeader modifiedHeader;
        private ColumnHeader sizeHeader;
        private MenuStrip mainMenu;
        private ToolStrip maintoolStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newFileMenuItem;
        private ToolStripMenuItem openFileMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem exitFileMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem selectAllEditMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutHelpMenuItem;
        private ColumnHeader flagsHeader;
        private ContextMenuStrip fileContextMenu;
        private ToolStripMenuItem extractMenuItem;
        private ToolStripMenuItem deleteMenuItem;
        private ColumnHeader packedHeader;
        private ToolStripMenuItem addEditMenuItem;
        private ToolStripMenuItem deleteEditMenuItem;
        private ToolStripMenuItem extractEditMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ContextMenuStrip ListViewContextMenu;
        private ToolStripMenuItem addMenuItem;
        private ToolStripButton newButton;
        private ToolStripButton openButton;
        private ToolStripButton addButton;
        private ToolStripButton extractButton;
    }
}
