namespace GLMUtility
{
    partial class AboutBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            labelVersion = new Label();
            labelAuthor = new Label();
            labelVersionNumber = new Label();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            OKButton = new Button();
            SuspendLayout();
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(12, 9);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(48, 15);
            labelVersion.TabIndex = 0;
            labelVersion.Text = "Version:";
            // 
            // labelAuthor
            // 
            labelAuthor.AutoSize = true;
            labelAuthor.Location = new Point(12, 35);
            labelAuthor.Name = "labelAuthor";
            labelAuthor.Size = new Size(81, 15);
            labelAuthor.TabIndex = 1;
            labelAuthor.Text = "Peter McKeon";
            // 
            // labelVersionNumber
            // 
            labelVersionNumber.AutoSize = true;
            labelVersionNumber.Location = new Point(66, 9);
            labelVersionNumber.Name = "labelVersionNumber";
            labelVersionNumber.Size = new Size(31, 15);
            labelVersionNumber.TabIndex = 2;
            labelVersionNumber.Text = "1.0.0";
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Location = new Point(12, 96);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(532, 156);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 78);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 4;
            label1.Text = "3rd Party Licenses:";
            // 
            // OKButton
            // 
            OKButton.Location = new Point(469, 12);
            OKButton.Name = "OKButton";
            OKButton.Size = new Size(75, 23);
            OKButton.TabIndex = 5;
            OKButton.Text = "OK";
            OKButton.UseVisualStyleBackColor = true;
            OKButton.Click += OKButton_Click;
            // 
            // AboutBox
            // 
            AcceptButton = OKButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 264);
            Controls.Add(OKButton);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(labelVersionNumber);
            Controls.Add(labelAuthor);
            Controls.Add(labelVersion);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "About GLMUtility";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelVersion;
        private Label labelAuthor;
        private Label labelVersionNumber;
        private RichTextBox richTextBox1;
        private Label label1;
        private Button OKButton;
    }
}