namespace Mine_Craft_Adminitrator.MyForm
{
    partial class AlertForm
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
            this.rt_content = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rt_content
            // 
            this.rt_content.Location = new System.Drawing.Point(13, 13);
            this.rt_content.Name = "rt_content";
            this.rt_content.Size = new System.Drawing.Size(317, 486);
            this.rt_content.TabIndex = 0;
            this.rt_content.Text = "";
            // 
            // AlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 511);
            this.Controls.Add(this.rt_content);
            this.Name = "AlertForm";
            this.Text = "AlertForm";
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rt_content;
    }
}