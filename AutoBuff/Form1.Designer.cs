namespace AutoBuff
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.cbbCaNhan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbDoi = new System.Windows.Forms.ComboBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbCall = new System.Windows.Forms.ComboBox();
            this.cbbHuy = new System.Windows.Forms.ComboBox();
            this.btnSetPartnerLocation = new System.Windows.Forms.Button();
            this.cbbScan = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(195, 307);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(122, 17);
            this.chkAuto.TabIndex = 1;
            this.chkAuto.Text = "Buff tự động liên tục";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // cbbCaNhan
            // 
            this.cbbCaNhan.FormattingEnabled = true;
            this.cbbCaNhan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0"});
            this.cbbCaNhan.Location = new System.Drawing.Point(123, 6);
            this.cbbCaNhan.Name = "cbbCaNhan";
            this.cbbCaNhan.Size = new System.Drawing.Size(53, 21);
            this.cbbCaNhan.TabIndex = 2;
            this.cbbCaNhan.SelectedIndexChanged += new System.EventHandler(this.cbbCaNhan_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hồi giáp cá nhân";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Hồi giáp đội";
            // 
            // cbbDoi
            // 
            this.cbbDoi.FormattingEnabled = true;
            this.cbbDoi.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0"});
            this.cbbDoi.Location = new System.Drawing.Point(123, 33);
            this.cbbDoi.Name = "cbbDoi";
            this.cbbDoi.Size = new System.Drawing.Size(53, 21);
            this.cbbDoi.TabIndex = 4;
            this.cbbDoi.SelectedIndexChanged += new System.EventHandler(this.cbbDoi_SelectedIndexChanged);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(29, 318);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 6;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hủy Buff";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Call";
            // 
            // cbbCall
            // 
            this.cbbCall.FormattingEnabled = true;
            this.cbbCall.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0"});
            this.cbbCall.Location = new System.Drawing.Point(123, 87);
            this.cbbCall.Name = "cbbCall";
            this.cbbCall.Size = new System.Drawing.Size(53, 21);
            this.cbbCall.TabIndex = 9;
            this.cbbCall.SelectedIndexChanged += new System.EventHandler(this.cbbCall_SelectedIndexChanged);
            // 
            // cbbHuy
            // 
            this.cbbHuy.FormattingEnabled = true;
            this.cbbHuy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0"});
            this.cbbHuy.Location = new System.Drawing.Point(123, 60);
            this.cbbHuy.Name = "cbbHuy";
            this.cbbHuy.Size = new System.Drawing.Size(53, 21);
            this.cbbHuy.TabIndex = 10;
            this.cbbHuy.SelectedIndexChanged += new System.EventHandler(this.cbbHuy_SelectedIndexChanged);
            // 
            // btnSetPartnerLocation
            // 
            this.btnSetPartnerLocation.Location = new System.Drawing.Point(89, 259);
            this.btnSetPartnerLocation.Name = "btnSetPartnerLocation";
            this.btnSetPartnerLocation.Size = new System.Drawing.Size(75, 23);
            this.btnSetPartnerLocation.TabIndex = 11;
            this.btnSetPartnerLocation.Text = "Set Call";
            this.btnSetPartnerLocation.UseVisualStyleBackColor = true;
            this.btnSetPartnerLocation.Click += new System.EventHandler(this.btnSetPartnerLocation_Click);
            // 
            // cbbScan
            // 
            this.cbbScan.FormattingEnabled = true;
            this.cbbScan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0"});
            this.cbbScan.Location = new System.Drawing.Point(123, 114);
            this.cbbScan.Name = "cbbScan";
            this.cbbScan.Size = new System.Drawing.Size(53, 21);
            this.cbbScan.TabIndex = 13;
            this.cbbScan.SelectedIndexChanged += new System.EventHandler(this.cbbScan_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Scan";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 113);
            this.Controls.Add(this.cbbScan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSetPartnerLocation);
            this.Controls.Add(this.cbbHuy);
            this.Controls.Add(this.cbbCall);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbDoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbCaNhan);
            this.Controls.Add(this.chkAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Amita";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.ComboBox cbbCaNhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbbDoi;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbCall;
        private System.Windows.Forms.ComboBox cbbHuy;
        private System.Windows.Forms.Button btnSetPartnerLocation;
        private System.Windows.Forms.ComboBox cbbScan;
        private System.Windows.Forms.Label label5;
    }
}

