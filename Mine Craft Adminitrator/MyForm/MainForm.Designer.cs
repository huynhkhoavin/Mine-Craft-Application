namespace Mine_Craft_Adminitrator
{
    partial class MainForm
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_xml = new System.Windows.Forms.Button();
            this.lb_statusBar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnUpload.Location = new System.Drawing.Point(67, 75);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(150, 50);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload Item";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.upload_Item_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnVerify.Location = new System.Drawing.Point(294, 75);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(150, 50);
            this.btnVerify.TabIndex = 0;
            this.btnVerify.Text = "List Upload Item";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.verify_Item_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button2.Location = new System.Drawing.Point(527, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 50);
            this.button2.TabIndex = 0;
            this.button2.Text = "Log Out";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Log_Out_Click);
            // 
            // btn_xml
            // 
            this.btn_xml.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xml.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btn_xml.Location = new System.Drawing.Point(67, 199);
            this.btn_xml.Name = "btn_xml";
            this.btn_xml.Size = new System.Drawing.Size(150, 50);
            this.btn_xml.TabIndex = 0;
            this.btn_xml.Text = "XML Convert";
            this.btn_xml.UseVisualStyleBackColor = true;
            this.btn_xml.Click += new System.EventHandler(this.xml_Convert);
            // 
            // lb_statusBar
            // 
            this.lb_statusBar.AutoSize = true;
            this.lb_statusBar.ForeColor = System.Drawing.Color.Red;
            this.lb_statusBar.Location = new System.Drawing.Point(34, 631);
            this.lb_statusBar.Name = "lb_statusBar";
            this.lb_statusBar.Size = new System.Drawing.Size(0, 13);
            this.lb_statusBar.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(318, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Upload Item";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 321);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_statusBar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_xml);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnUpload);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_xml;
        private System.Windows.Forms.Label lb_statusBar;
        private System.Windows.Forms.Label label2;
    }
}

