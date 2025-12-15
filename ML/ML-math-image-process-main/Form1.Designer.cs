namespace ML_math_image_process
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnResimYukle = new System.Windows.Forms.Button();
            this.btnGriYap = new System.Windows.Forms.Button();
            this.btnSiyahBeyaz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(77, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 295);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnResimYukle
            // 
            this.btnResimYukle.Location = new System.Drawing.Point(520, 47);
            this.btnResimYukle.Name = "btnResimYukle";
            this.btnResimYukle.Size = new System.Drawing.Size(132, 74);
            this.btnResimYukle.TabIndex = 1;
            this.btnResimYukle.Text = "resim yükle";
            this.btnResimYukle.UseVisualStyleBackColor = true;
            this.btnResimYukle.Click += new System.EventHandler(this.btnResimYukle_Click);
            // 
            // btnGriYap
            // 
            this.btnGriYap.Location = new System.Drawing.Point(520, 169);
            this.btnGriYap.Name = "btnGriYap";
            this.btnGriYap.Size = new System.Drawing.Size(126, 65);
            this.btnGriYap.TabIndex = 2;
            this.btnGriYap.Text = "grileştirme";
            this.btnGriYap.UseVisualStyleBackColor = true;
            this.btnGriYap.Click += new System.EventHandler(this.btnGriYap_Click);
            // 
            // btnSiyahBeyaz
            // 
            this.btnSiyahBeyaz.Location = new System.Drawing.Point(520, 285);
            this.btnSiyahBeyaz.Name = "btnSiyahBeyaz";
            this.btnSiyahBeyaz.Size = new System.Drawing.Size(132, 58);
            this.btnSiyahBeyaz.TabIndex = 3;
            this.btnSiyahBeyaz.Text = "siyah beyaza çevir";
            this.btnSiyahBeyaz.UseVisualStyleBackColor = true;
            this.btnSiyahBeyaz.Click += new System.EventHandler(this.btnSiyahBeyaz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSiyahBeyaz);
            this.Controls.Add(this.btnGriYap);
            this.Controls.Add(this.btnResimYukle);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnResimYukle;
        private System.Windows.Forms.Button btnGriYap;
        private System.Windows.Forms.Button btnSiyahBeyaz;
    }
}

