namespace GiftaidDB
{
    partial class Import
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Import));
            this.label1 = new System.Windows.Forms.Label();
            this.e_impfile = new System.Windows.Forms.TextBox();
            this.c_shop = new System.Windows.Forms.ComboBox();
            this.l_shop = new System.Windows.Forms.Label();
            this.b_cancel = new System.Windows.Forms.Button();
            this.b_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Import File :";
            // 
            // e_impfile
            // 
            this.e_impfile.Location = new System.Drawing.Point(89, 23);
            this.e_impfile.Name = "e_impfile";
            this.e_impfile.Size = new System.Drawing.Size(154, 20);
            this.e_impfile.TabIndex = 1;
            // 
            // c_shop
            // 
            this.c_shop.FormattingEnabled = true;
            this.c_shop.Items.AddRange(new object[] {
            "Trowbridge",
            "Tremorfa",
            "Barry",
            "other"});
            this.c_shop.Location = new System.Drawing.Point(325, 24);
            this.c_shop.Name = "c_shop";
            this.c_shop.Size = new System.Drawing.Size(102, 21);
            this.c_shop.TabIndex = 2;
            // 
            // l_shop
            // 
            this.l_shop.AutoSize = true;
            this.l_shop.Location = new System.Drawing.Point(278, 27);
            this.l_shop.Name = "l_shop";
            this.l_shop.Size = new System.Drawing.Size(41, 13);
            this.l_shop.TabIndex = 3;
            this.l_shop.Text = "Shop : ";
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(126, 74);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(93, 28);
            this.b_cancel.TabIndex = 4;
            this.b_cancel.Text = "Cancel";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(294, 74);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(88, 27);
            this.b_ok.TabIndex = 5;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 150);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.l_shop);
            this.Controls.Add(this.c_shop);
            this.Controls.Add(this.e_impfile);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Import";
            this.Text = "Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox e_impfile;
        private System.Windows.Forms.ComboBox c_shop;
        private System.Windows.Forms.Label l_shop;
        private System.Windows.Forms.Button b_cancel;
        private System.Windows.Forms.Button b_ok;
    }
}