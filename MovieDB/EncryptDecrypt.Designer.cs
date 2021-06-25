namespace GiftaidDB
{
    partial class EncryptDecrypt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EncryptDecrypt));
            this.text_plain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_decenc = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.but_encrypt = new System.Windows.Forms.Button();
            this.but_decrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // text_plain
            // 
            this.text_plain.Location = new System.Drawing.Point(121, 27);
            this.text_plain.Name = "text_plain";
            this.text_plain.Size = new System.Drawing.Size(217, 20);
            this.text_plain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plain Text :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Encrypt / Decrypt :";
            // 
            // text_decenc
            // 
            this.text_decenc.Location = new System.Drawing.Point(119, 66);
            this.text_decenc.Name = "text_decenc";
            this.text_decenc.Size = new System.Drawing.Size(346, 20);
            this.text_decenc.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // but_encrypt
            // 
            this.but_encrypt.Location = new System.Drawing.Point(348, 114);
            this.but_encrypt.Name = "but_encrypt";
            this.but_encrypt.Size = new System.Drawing.Size(107, 32);
            this.but_encrypt.TabIndex = 5;
            this.but_encrypt.Text = "Encrypt";
            this.but_encrypt.UseVisualStyleBackColor = true;
            this.but_encrypt.Click += new System.EventHandler(this.but_encrypt_Click);
            // 
            // but_decrypt
            // 
            this.but_decrypt.Location = new System.Drawing.Point(200, 115);
            this.but_decrypt.Name = "but_decrypt";
            this.but_decrypt.Size = new System.Drawing.Size(107, 32);
            this.but_decrypt.TabIndex = 6;
            this.but_decrypt.Text = "Decrypt";
            this.but_decrypt.UseVisualStyleBackColor = true;
            this.but_decrypt.Click += new System.EventHandler(this.but_decrypt_Click);
            // 
            // EncryptDecrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 169);
            this.Controls.Add(this.but_decrypt);
            this.Controls.Add(this.but_encrypt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_decenc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_plain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EncryptDecrypt";
            this.Text = "Encrypt and Decrypt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_plain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_decenc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button but_encrypt;
        private System.Windows.Forms.Button but_decrypt;
    }
}