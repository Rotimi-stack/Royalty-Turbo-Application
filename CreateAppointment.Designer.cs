namespace Royalty_Turbo
{
    partial class CreateAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateAppointment));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textPhoneNo = new System.Windows.Forms.TextBox();
            this.cmbVisStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVisSex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtVisReason = new System.Windows.Forms.TextBox();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAppointTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DateAppointment = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.btnVisAppointmentAdd = new System.Windows.Forms.Button();
            this.texWhomToSee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textVisName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Purple;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.textPhoneNo);
            this.panel2.Controls.Add(this.cmbVisStatus);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cmbVisSex);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtVisReason);
            this.panel2.Controls.Add(this.txtPurpose);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtAppointTime);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.DateAppointment);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.btnVisAppointmentAdd);
            this.panel2.Controls.Add(this.texWhomToSee);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textVisName);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 697);
            this.panel2.TabIndex = 30;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 64);
            this.panel1.TabIndex = 100;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(749, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(49, 64);
            this.panel5.TabIndex = 1;
            this.panel5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(239, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(333, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "ADD APPOINTMENT DATA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(61, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 29);
            this.label9.TabIndex = 98;
            this.label9.Text = "PhoneNo:";
            // 
            // textPhoneNo
            // 
            this.textPhoneNo.Location = new System.Drawing.Point(243, 280);
            this.textPhoneNo.Multiline = true;
            this.textPhoneNo.Name = "textPhoneNo";
            this.textPhoneNo.Size = new System.Drawing.Size(418, 38);
            this.textPhoneNo.TabIndex = 99;
            // 
            // cmbVisStatus
            // 
            this.cmbVisStatus.FormattingEnabled = true;
            this.cmbVisStatus.Location = new System.Drawing.Point(243, 409);
            this.cmbVisStatus.Name = "cmbVisStatus";
            this.cmbVisStatus.Size = new System.Drawing.Size(418, 28);
            this.cmbVisStatus.TabIndex = 97;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(78, 409);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 29);
            this.label8.TabIndex = 96;
            this.label8.Text = "Status:";
            // 
            // cmbVisSex
            // 
            this.cmbVisSex.FormattingEnabled = true;
            this.cmbVisSex.Location = new System.Drawing.Point(243, 165);
            this.cmbVisSex.Name = "cmbVisSex";
            this.cmbVisSex.Size = new System.Drawing.Size(418, 28);
            this.cmbVisSex.TabIndex = 95;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(62, 469);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 29);
            this.label5.TabIndex = 93;
            this.label5.Text = "Reason:";
            // 
            // txtVisReason
            // 
            this.txtVisReason.Location = new System.Drawing.Point(243, 460);
            this.txtVisReason.Multiline = true;
            this.txtVisReason.Name = "txtVisReason";
            this.txtVisReason.Size = new System.Drawing.Size(418, 38);
            this.txtVisReason.TabIndex = 94;
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(243, 346);
            this.txtPurpose.Multiline = true;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(418, 38);
            this.txtPurpose.TabIndex = 92;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(53, 355);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 29);
            this.label7.TabIndex = 91;
            this.label7.Text = "Purpose:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(12, 532);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(233, 29);
            this.label6.TabIndex = 89;
            this.label6.Text = "Appointment Time:";
            // 
            // txtAppointTime
            // 
            this.txtAppointTime.Location = new System.Drawing.Point(247, 529);
            this.txtAppointTime.Multiline = true;
            this.txtAppointTime.Name = "txtAppointTime";
            this.txtAppointTime.Size = new System.Drawing.Size(418, 38);
            this.txtAppointTime.TabIndex = 90;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(78, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 29);
            this.label4.TabIndex = 85;
            this.label4.Text = "Sex";
            // 
            // DateAppointment
            // 
            this.DateAppointment.Location = new System.Drawing.Point(243, 589);
            this.DateAppointment.Name = "DateAppointment";
            this.DateAppointment.Size = new System.Drawing.Size(418, 26);
            this.DateAppointment.TabIndex = 84;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label16.Location = new System.Drawing.Point(10, 587);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(227, 29);
            this.label16.TabIndex = 79;
            this.label16.Text = "Appointment Date:";
            // 
            // btnVisAppointmentAdd
            // 
            this.btnVisAppointmentAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnVisAppointmentAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVisAppointmentAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisAppointmentAdd.ForeColor = System.Drawing.Color.White;
            this.btnVisAppointmentAdd.Location = new System.Drawing.Point(372, 640);
            this.btnVisAppointmentAdd.Name = "btnVisAppointmentAdd";
            this.btnVisAppointmentAdd.Size = new System.Drawing.Size(117, 44);
            this.btnVisAppointmentAdd.TabIndex = 78;
            this.btnVisAppointmentAdd.Text = "Add";
            this.btnVisAppointmentAdd.UseVisualStyleBackColor = false;
            this.btnVisAppointmentAdd.Click += new System.EventHandler(this.btnVisAppointmentAdd_Click);
            // 
            // texWhomToSee
            // 
            this.texWhomToSee.Location = new System.Drawing.Point(243, 217);
            this.texWhomToSee.Multiline = true;
            this.texWhomToSee.Name = "texWhomToSee";
            this.texWhomToSee.Size = new System.Drawing.Size(418, 38);
            this.texWhomToSee.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(20, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 29);
            this.label1.TabIndex = 54;
            this.label1.Text = "Visitor Name:";
            // 
            // textVisName
            // 
            this.textVisName.Location = new System.Drawing.Point(243, 107);
            this.textVisName.Multiline = true;
            this.textVisName.Name = "textVisName";
            this.textVisName.Size = new System.Drawing.Size(418, 38);
            this.textVisName.TabIndex = 55;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(12, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 29);
            this.label3.TabIndex = 56;
            this.label3.Text = "Whom To See:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(83, -17);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(142, 81);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 38;
            this.pictureBox5.TabStop = false;
            // 
            // CreateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 697);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateAppointment";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DateAppointment;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnVisAppointmentAdd;
        private System.Windows.Forms.TextBox texWhomToSee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textVisName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAppointTime;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbVisStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVisSex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtVisReason;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textPhoneNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}