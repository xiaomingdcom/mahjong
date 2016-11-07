namespace mahjong
{
    partial class Form1_1
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
            this.hupai_yes = new System.Windows.Forms.Button();
            this.hupai_no = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hupai_yes
            // 
            this.hupai_yes.Location = new System.Drawing.Point(48, 56);
            this.hupai_yes.Name = "hupai_yes";
            this.hupai_yes.Size = new System.Drawing.Size(75, 34);
            this.hupai_yes.TabIndex = 0;
            this.hupai_yes.Text = "yes";
            this.hupai_yes.UseVisualStyleBackColor = true;
            this.hupai_yes.Click += new System.EventHandler(this.hupai_yes_Click);
            // 
            // hupai_no
            // 
            this.hupai_no.Location = new System.Drawing.Point(204, 56);
            this.hupai_no.Name = "hupai_no";
            this.hupai_no.Size = new System.Drawing.Size(75, 34);
            this.hupai_no.TabIndex = 1;
            this.hupai_no.Text = "no";
            this.hupai_no.UseVisualStyleBackColor = true;
            this.hupai_no.Click += new System.EventHandler(this.hupai_no_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "是否和牌/碰/杠";
            // 
            // Form1_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 111);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hupai_no);
            this.Controls.Add(this.hupai_yes);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1_1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button hupai_yes;
        private System.Windows.Forms.Button hupai_no;
        private System.Windows.Forms.Label label1;
    }
}