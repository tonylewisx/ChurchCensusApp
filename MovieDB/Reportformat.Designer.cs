namespace GiftaidDB
{
    partial class Reportformat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reportformat));
            this.but_ok = new System.Windows.Forms.Button();
            this.but_can = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbut_text = new System.Windows.Forms.RadioButton();
            this.rbut_html = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // but_ok
            // 
            this.but_ok.Location = new System.Drawing.Point(111, 121);
            this.but_ok.Name = "but_ok";
            this.but_ok.Size = new System.Drawing.Size(77, 29);
            this.but_ok.TabIndex = 0;
            this.but_ok.Text = "OK";
            this.but_ok.UseVisualStyleBackColor = true;
            this.but_ok.Click += new System.EventHandler(this.button1_Click);
            // 
            // but_can
            // 
            this.but_can.Location = new System.Drawing.Point(233, 122);
            this.but_can.Name = "but_can";
            this.but_can.Size = new System.Drawing.Size(72, 28);
            this.but_can.TabIndex = 1;
            this.but_can.Text = "Cancel";
            this.but_can.UseVisualStyleBackColor = true;
            this.but_can.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "What Format do you wish the Report to be produced ?";
            // 
            // rbut_text
            // 
            this.rbut_text.AutoSize = true;
            this.rbut_text.Location = new System.Drawing.Point(79, 74);
            this.rbut_text.Name = "rbut_text";
            this.rbut_text.Size = new System.Drawing.Size(53, 17);
            this.rbut_text.TabIndex = 3;
            this.rbut_text.TabStop = true;
            this.rbut_text.Text = "TEXT";
            this.rbut_text.UseVisualStyleBackColor = true;
            // 
            // rbut_html
            // 
            this.rbut_html.AutoSize = true;
            this.rbut_html.Location = new System.Drawing.Point(198, 75);
            this.rbut_html.Name = "rbut_html";
            this.rbut_html.Size = new System.Drawing.Size(55, 17);
            this.rbut_html.TabIndex = 4;
            this.rbut_html.TabStop = true;
            this.rbut_html.Text = "HTML";
            this.rbut_html.UseVisualStyleBackColor = true;
            // 
            // Reportformat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 180);
            this.Controls.Add(this.rbut_html);
            this.Controls.Add(this.rbut_text);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_can);
            this.Controls.Add(this.but_ok);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(400, 400);
            this.Name = "Reportformat";
            this.Text = "Reportformat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_ok;
        private System.Windows.Forms.Button but_can;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbut_text;
        private System.Windows.Forms.RadioButton rbut_html;
    }
}