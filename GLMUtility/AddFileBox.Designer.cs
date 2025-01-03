namespace GLMUtility
{
    partial class AddFileBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addButton = new Button();
            cancelButton = new Button();
            typecomboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            filecountlabel = new Label();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.DialogResult = DialogResult.OK;
            addButton.Location = new Point(209, 12);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 0;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(209, 70);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // typecomboBox
            // 
            typecomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typecomboBox.FormattingEnabled = true;
            typecomboBox.Items.AddRange(new object[] { "Uncompressed", "ZLIB" });
            typecomboBox.Location = new Point(12, 70);
            typecomboBox.Name = "typecomboBox";
            typecomboBox.Size = new Size(121, 23);
            typecomboBox.TabIndex = 2;
            typecomboBox.SelectedIndexChanged += typecomboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 3;
            label1.Text = "Files Count:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 4;
            label2.Text = "Compression:";
            // 
            // filecountlabel
            // 
            filecountlabel.AutoSize = true;
            filecountlabel.Location = new Point(89, 12);
            filecountlabel.Name = "filecountlabel";
            filecountlabel.Size = new Size(31, 15);
            filecountlabel.TabIndex = 5;
            filecountlabel.Text = "0000";
            // 
            // AddFileBox
            // 
            AcceptButton = addButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(306, 113);
            Controls.Add(filecountlabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(typecomboBox);
            Controls.Add(cancelButton);
            Controls.Add(addButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddFileBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add Files";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button addButton;
        private Button cancelButton;
        private ComboBox typecomboBox;
        private Label label1;
        private Label label2;
        private Label filecountlabel;
    }
}