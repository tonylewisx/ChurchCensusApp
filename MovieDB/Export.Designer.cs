namespace GiftaidDB
{
    partial class export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(export));
            this.l_expfile = new System.Windows.Forms.Label();
            this.e_expfile = new System.Windows.Forms.TextBox();
            this.b_cancel = new System.Windows.Forms.Button();
            this.b_ok = new System.Windows.Forms.Button();
            this.l_shop = new System.Windows.Forms.Label();
            this.c_shop = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // l_expfile
            // 
            this.l_expfile.AutoSize = true;
            this.l_expfile.Location = new System.Drawing.Point(17, 30);
            this.l_expfile.Name = "l_expfile";
            this.l_expfile.Size = new System.Drawing.Size(62, 13);
            this.l_expfile.TabIndex = 0;
            this.l_expfile.Text = "Export File :";
            // 
            // e_expfile
            // 
            this.e_expfile.Location = new System.Drawing.Point(86, 26);
            this.e_expfile.Name = "e_expfile";
            this.e_expfile.Size = new System.Drawing.Size(194, 20);
            this.e_expfile.TabIndex = 1;
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(128, 77);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(78, 27);
            this.b_cancel.TabIndex = 2;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(295, 75);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(76, 26);
            this.b_ok.TabIndex = 3;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // l_shop
            // 
            this.l_shop.AutoSize = true;
            this.l_shop.Location = new System.Drawing.Point(319, 32);
            this.l_shop.Name = "l_shop";
            this.l_shop.Size = new System.Drawing.Size(38, 13);
            this.l_shop.TabIndex = 4;
            this.l_shop.Text = "Shop :";
            // 
            // c_shop
            // 
            this.c_shop.FormattingEnabled = true;
            this.c_shop.Items.AddRange(new object[] {
            "Trowbridge",
            "Tremorfa",
            "Barry",
            "other"});
            this.c_shop.Location = new System.Drawing.Point(363, 28);
            this.c_shop.Name = "c_shop";
            this.c_shop.Size = new System.Drawing.Size(108, 21);
            this.c_shop.TabIndex = 5;
            // 
            // export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 144);
            this.Controls.Add(this.c_shop);
            this.Controls.Add(this.l_shop);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.e_expfile);
            this.Controls.Add(this.l_expfile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "export";
            this.Text = "export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_expfile;
        private System.Windows.Forms.TextBox e_expfile;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Label l_shop;
        private System.Windows.Forms.ComboBox c_shop;
    }
}