using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GLMUtility
{
    public partial class AddFileBox : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedType { get; set; }

        public AddFileBox()
        {
            InitializeComponent();
            typecomboBox.SelectedIndex = 0;
        }

        private void typecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedType = typecomboBox.SelectedIndex;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int fileCount
        {
            set
            {
                filecountlabel.Text = value.ToString();
            }
        }
    }
}
