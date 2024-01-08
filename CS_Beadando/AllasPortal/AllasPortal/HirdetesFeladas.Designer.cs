
namespace AllasPortal
{
    partial class HirdetesFeladas
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cbKat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMegnev = new System.Windows.Forms.TextBox();
            this.tbLeir = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tbKulcsszavak = new System.Windows.Forms.TextBox();
            this.nudFizu = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudFizu)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Meghirdet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(146, 326);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Mégse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbKat
            // 
            this.cbKat.FormattingEnabled = true;
            this.cbKat.Location = new System.Drawing.Point(155, 35);
            this.cbKat.Name = "cbKat";
            this.cbKat.Size = new System.Drawing.Size(121, 23);
            this.cbKat.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kategória";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Megnevezés";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fizetés";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rövid leírás";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(320, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Kulcsszavak (vesszővel és szóközzel eválasztva, például: x, y)";
            // 
            // tbMegnev
            // 
            this.tbMegnev.Location = new System.Drawing.Point(155, 74);
            this.tbMegnev.Name = "tbMegnev";
            this.tbMegnev.Size = new System.Drawing.Size(100, 23);
            this.tbMegnev.TabIndex = 9;
            // 
            // tbLeir
            // 
            this.tbLeir.Location = new System.Drawing.Point(155, 142);
            this.tbLeir.Multiline = true;
            this.tbLeir.Name = "tbLeir";
            this.tbLeir.Size = new System.Drawing.Size(245, 86);
            this.tbLeir.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(533, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 55);
            this.button3.TabIndex = 14;
            this.button3.Text = "Hirdetés importálása XML fájlból";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(533, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 55);
            this.button4.TabIndex = 15;
            this.button4.Text = "Hirdetés kiírása XML-be";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(533, 166);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 62);
            this.button5.TabIndex = 16;
            this.button5.Text = "Összes hirdetés kiírása XML-be";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // tbKulcsszavak
            // 
            this.tbKulcsszavak.Location = new System.Drawing.Point(31, 275);
            this.tbKulcsszavak.Name = "tbKulcsszavak";
            this.tbKulcsszavak.Size = new System.Drawing.Size(424, 23);
            this.tbKulcsszavak.TabIndex = 17;
            // 
            // nudFizu
            // 
            this.nudFizu.Location = new System.Drawing.Point(155, 109);
            this.nudFizu.Maximum = new decimal(new int[] {
            1200000,
            0,
            0,
            0});
            this.nudFizu.Minimum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.nudFizu.Name = "nudFizu";
            this.nudFizu.Size = new System.Drawing.Size(120, 23);
            this.nudFizu.TabIndex = 18;
            this.nudFizu.Value = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(281, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ft";
            // 
            // HirdetesFeladas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 372);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudFizu);
            this.Controls.Add(this.tbKulcsszavak);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbLeir);
            this.Controls.Add(this.tbMegnev);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbKat);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "HirdetesFeladas";
            this.Text = "HirdetesFeladas";
            this.Load += new System.EventHandler(this.HirdetesFeladas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudFizu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbKat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMegnev;
        private System.Windows.Forms.TextBox tbLeir;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox tbKulcsszavak;
        private System.Windows.Forms.NumericUpDown nudFizu;
        private System.Windows.Forms.Label label6;
    }
}