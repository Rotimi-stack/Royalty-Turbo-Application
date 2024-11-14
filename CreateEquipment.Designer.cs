namespace Royalty_Turbo
{
    partial class CreateEquipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateEquipment));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textQty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPurPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPurDate = new System.Windows.Forms.DateTimePicker();
            this.cmbEqupStatus = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnAddEquip = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textEqpBrand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textEquName = new System.Windows.Forms.TextBox();
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(731, 64);
            this.panel1.TabIndex = 27;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(679, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(52, 64);
            this.panel7.TabIndex = 3;
            this.panel7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel7_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(239, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ADD EQUIPMENT DATA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Controls.Add(this.textQty);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textPurPrice);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dtpPurDate);
            this.panel2.Controls.Add(this.cmbEqupStatus);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.btnAddEquip);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textEqpBrand);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textEquName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(731, 644);
            this.panel2.TabIndex = 28;
            // 
            // textQty
            // 
            this.textQty.Location = new System.Drawing.Point(234, 297);
            this.textQty.Multiline = true;
            this.textQty.Name = "textQty";
            this.textQty.Size = new System.Drawing.Size(407, 38);
            this.textQty.TabIndex = 88;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(7, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 29);
            this.label4.TabIndex = 85;
            this.label4.Text = "Purchase Price:";
            // 
            // textPurPrice
            // 
            this.textPurPrice.Location = new System.Drawing.Point(234, 221);
            this.textPurPrice.Multiline = true;
            this.textPurPrice.Name = "textPurPrice";
            this.textPurPrice.Size = new System.Drawing.Size(407, 38);
            this.textPurPrice.TabIndex = 86;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(57, 306);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 29);
            this.label5.TabIndex = 87;
            this.label5.Text = "Quantity:";
            // 
            // dtpPurDate
            // 
            this.dtpPurDate.Location = new System.Drawing.Point(234, 371);
            this.dtpPurDate.Name = "dtpPurDate";
            this.dtpPurDate.Size = new System.Drawing.Size(407, 26);
            this.dtpPurDate.TabIndex = 84;
            // 
            // cmbEqupStatus
            // 
            this.cmbEqupStatus.FormattingEnabled = true;
            this.cmbEqupStatus.Location = new System.Drawing.Point(234, 160);
            this.cmbEqupStatus.Name = "cmbEqupStatus";
            this.cmbEqupStatus.Size = new System.Drawing.Size(407, 28);
            this.cmbEqupStatus.TabIndex = 83;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label16.Location = new System.Drawing.Point(12, 371);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(190, 29);
            this.label16.TabIndex = 79;
            this.label16.Text = "Purchase Date:";
            // 
            // btnAddEquip
            // 
            this.btnAddEquip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddEquip.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddEquip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEquip.ForeColor = System.Drawing.Color.White;
            this.btnAddEquip.Location = new System.Drawing.Point(355, 445);
            this.btnAddEquip.Name = "btnAddEquip";
            this.btnAddEquip.Size = new System.Drawing.Size(117, 44);
            this.btnAddEquip.TabIndex = 78;
            this.btnAddEquip.Text = "Add";
            this.btnAddEquip.UseVisualStyleBackColor = false;
            this.btnAddEquip.Click += new System.EventHandler(this.btnAddEquip_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(47, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 29);
            this.label8.TabIndex = 63;
            this.label8.Text = "Status:";
            // 
            // textEqpBrand
            // 
            this.textEqpBrand.Location = new System.Drawing.Point(234, 87);
            this.textEqpBrand.Multiline = true;
            this.textEqpBrand.Name = "textEqpBrand";
            this.textEqpBrand.Size = new System.Drawing.Size(407, 38);
            this.textEqpBrand.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(5, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 29);
            this.label2.TabIndex = 54;
            this.label2.Text = "Equipment Name:";
            // 
            // textEquName
            // 
            this.textEquName.Location = new System.Drawing.Point(234, 22);
            this.textEquName.Multiline = true;
            this.textEquName.Name = "textEquName";
            this.textEquName.Size = new System.Drawing.Size(407, 38);
            this.textEquName.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(5, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 29);
            this.label3.TabIndex = 56;
            this.label3.Text = "Equipment Brand:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(291, 539);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(225, 83);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 89;
            this.pictureBox5.TabStop = false;
            // 
            // CreateEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 708);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateEquipment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateEquipment";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpPurDate;
        private System.Windows.Forms.ComboBox cmbEqupStatus;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAddEquip;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textEqpBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textEquName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textQty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPurPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}