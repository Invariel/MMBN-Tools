namespace Deck_Builder
{
    partial class frm_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_About));
            rtxt_About = new RichTextBox();
            SuspendLayout();
            // 
            // rtxt_About
            // 
            rtxt_About.Dock = DockStyle.Fill;
            rtxt_About.Location = new Point(0, 0);
            rtxt_About.Name = "rtxt_About";
            rtxt_About.Size = new Size(800, 450);
            rtxt_About.TabIndex = 0;
            rtxt_About.Text = resources.GetString("rtxt_About.Text");
            // 
            // frm_About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rtxt_About);
            Name = "frm_About";
            Text = "Mega Man Battle Network Folder Builder - About";
            ResumeLayout(false);
        }

        #endregion

        internal RichTextBox rtxt_About;
    }
}