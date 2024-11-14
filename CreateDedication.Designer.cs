namespace Royalty_Turbo
{
    partial class CreateDedication
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDedication));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateDed = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textOffiMin = new System.Windows.Forms.TextBox();
            this.dtpDedDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAddDed = new System.Windows.Forms.Button();
            this.texDedCert = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textDedName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 64);
            this.panel1.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(748, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(52, 64);
            this.panel7.TabIndex = 3;
            this.panel7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(239, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "ADD DEDICATION DATA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.dateDed);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textOffiMin);
            this.panel2.Controls.Add(this.dtpDedDate);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.btnAddDed);
            this.panel2.Controls.Add(this.texDedCert);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textDedName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 634);
            this.panel2.TabIndex = 29;
            // 
            // dateDed
            // 
            this.dateDed.Location = new System.Drawing.Point(248, 336);
            this.dateDed.Name = "dateDed";
            this.dateDed.Size = new System.Drawing.Size(412, 26);
            this.dateDed.TabIndex = 88;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(82, 333);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 29);
            this.label5.TabIndex = 87;
            this.label5.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(-3, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 29);
            this.label4.TabIndex = 85;
            this.label4.Text = "Officiating Ministers:";
            // 
            // textOffiMin
            // 
            this.textOffiMin.Location = new System.Drawing.Point(249, 195);
            this.textOffiMin.Multiline = true;
            this.textOffiMin.Name = "textOffiMin";
            this.textOffiMin.Size = new System.Drawing.Size(411, 38);
            this.textOffiMin.TabIndex = 86;
            // 
            // dtpDedDate
            // 
            this.dtpDedDate.Location = new System.Drawing.Point(248, 268);
            this.dtpDedDate.Name = "dtpDedDate";
            this.dtpDedDate.Size = new System.Drawing.Size(412, 26);
            this.dtpDedDate.TabIndex = 84;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label16.Location = new System.Drawing.Point(11, 265);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(206, 29);
            this.label16.TabIndex = 79;
            this.label16.Text = "Dedication Date:";
            // 
            // btnAddDed
            // 
            this.btnAddDed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddDed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddDed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDed.ForeColor = System.Drawing.Color.White;
            this.btnAddDed.Location = new System.Drawing.Point(352, 416);
            this.btnAddDed.Name = "btnAddDed";
            this.btnAddDed.Size = new System.Drawing.Size(117, 44);
            this.btnAddDed.TabIndex = 78;
            this.btnAddDed.Text = "Add";
            this.btnAddDed.UseVisualStyleBackColor = false;
            this.btnAddDed.Click += new System.EventHandler(this.btnAddDed_Click);
            // 
            // texDedCert
            // 
            this.texDedCert.Location = new System.Drawing.Point(249, 119);
            this.texDedCert.Multiline = true;
            this.texDedCert.Name = "texDedCert";
            this.texDedCert.Size = new System.Drawing.Size(411, 38);
            this.texDedCert.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 29);
            this.label1.TabIndex = 54;
            this.label1.Text = "Dedication Name:";
            // 
            // textDedName
            // 
            this.textDedName.Location = new System.Drawing.Point(249, 54);
            this.textDedName.Multiline = true;
            this.textDedName.Name = "textDedName";
            this.textDedName.Size = new System.Drawing.Size(411, 38);
            this.textDedName.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(9, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 29);
            this.label3.TabIndex = 56;
            this.label3.Text = "Certificate Name:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(300, 491);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(205, 119);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 89;
            this.pictureBox5.TabStop = false;
            // 
            // CreateDedication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 698);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateDedication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateDedication";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textOffiMin;
        private System.Windows.Forms.DateTimePicker dtpDedDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAddDed;
        private System.Windows.Forms.TextBox texDedCert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textDedName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateDed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}