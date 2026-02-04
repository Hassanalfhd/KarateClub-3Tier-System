namespace KartateClubConApp_PersLayer.Users
{
    partial class frmPermissions
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContaner = new System.Windows.Forms.Panel();
            this.lblShowAddvancesPermission = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ckPayment = new System.Windows.Forms.CheckBox();
            this.ckPeriods = new System.Windows.Forms.CheckBox();
            this.ckBeltTests = new System.Windows.Forms.CheckBox();
            this.ckMembers = new System.Windows.Forms.CheckBox();
            this.ckBeltRanks = new System.Windows.Forms.CheckBox();
            this.ckMemberIntructors = new System.Windows.Forms.CheckBox();
            this.ckInstuctors = new System.Windows.Forms.CheckBox();
            this.ckUsers = new System.Windows.Forms.CheckBox();
            this.ckAllPermissions = new System.Windows.Forms.CheckBox();
            this.btnCansel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlContaner.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCloes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(677, 48);
            this.panel1.TabIndex = 1;
            // 
            // btnCloes
            // 
            this.btnCloes.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCloes.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCloes.FlatAppearance.BorderSize = 0;
            this.btnCloes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCloes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnCloes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloes.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloes.Image = global::KartateClubConApp_PersLayer.Properties.Resources.close;
            this.btnCloes.Location = new System.Drawing.Point(597, 0);
            this.btnCloes.Name = "btnCloes";
            this.btnCloes.Size = new System.Drawing.Size(80, 48);
            this.btnCloes.TabIndex = 12;
            this.btnCloes.UseVisualStyleBackColor = true;
            this.btnCloes.Click += new System.EventHandler(this.btnCloes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Buxton Sketch", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(245, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Permissions:";
            // 
            // pnlContaner
            // 
            this.pnlContaner.Controls.Add(this.lblShowAddvancesPermission);
            this.pnlContaner.Controls.Add(this.panel3);
            this.pnlContaner.Controls.Add(this.btnCansel);
            this.pnlContaner.Controls.Add(this.btnSave);
            this.pnlContaner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContaner.Location = new System.Drawing.Point(0, 48);
            this.pnlContaner.Name = "pnlContaner";
            this.pnlContaner.Size = new System.Drawing.Size(677, 327);
            this.pnlContaner.TabIndex = 2;
            // 
            // lblShowAddvancesPermission
            // 
            this.lblShowAddvancesPermission.AutoSize = true;
            this.lblShowAddvancesPermission.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowAddvancesPermission.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(38)))), ((int)(((byte)(37)))));
            this.lblShowAddvancesPermission.Location = new System.Drawing.Point(443, 246);
            this.lblShowAddvancesPermission.Name = "lblShowAddvancesPermission";
            this.lblShowAddvancesPermission.Size = new System.Drawing.Size(149, 17);
            this.lblShowAddvancesPermission.TabIndex = 15;
            this.lblShowAddvancesPermission.Text = "Advances Permission";
            this.lblShowAddvancesPermission.Click += new System.EventHandler(this.lblShowAddvancesPermission_Click);
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.ckPayment);
            this.panel3.Controls.Add(this.ckPeriods);
            this.panel3.Controls.Add(this.ckBeltTests);
            this.panel3.Controls.Add(this.ckMembers);
            this.panel3.Controls.Add(this.ckBeltRanks);
            this.panel3.Controls.Add(this.ckMemberIntructors);
            this.panel3.Controls.Add(this.ckInstuctors);
            this.panel3.Controls.Add(this.ckUsers);
            this.panel3.Controls.Add(this.ckAllPermissions);
            this.panel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(44, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(565, 220);
            this.panel3.TabIndex = 14;
            // 
            // ckPayment
            // 
            this.ckPayment.AutoSize = true;
            this.ckPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckPayment.Location = new System.Drawing.Point(0, 184);
            this.ckPayment.Name = "ckPayment";
            this.ckPayment.Size = new System.Drawing.Size(565, 23);
            this.ckPayment.TabIndex = 0;
            this.ckPayment.Text = "Payment";
            this.ckPayment.UseVisualStyleBackColor = true;
            // 
            // ckPeriods
            // 
            this.ckPeriods.AutoSize = true;
            this.ckPeriods.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckPeriods.Location = new System.Drawing.Point(0, 161);
            this.ckPeriods.Name = "ckPeriods";
            this.ckPeriods.Size = new System.Drawing.Size(565, 23);
            this.ckPeriods.TabIndex = 0;
            this.ckPeriods.Text = "Subscription Periods";
            this.ckPeriods.UseVisualStyleBackColor = true;
            // 
            // ckBeltTests
            // 
            this.ckBeltTests.AutoSize = true;
            this.ckBeltTests.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckBeltTests.Location = new System.Drawing.Point(0, 138);
            this.ckBeltTests.Name = "ckBeltTests";
            this.ckBeltTests.Size = new System.Drawing.Size(565, 23);
            this.ckBeltTests.TabIndex = 0;
            this.ckBeltTests.Text = "Belt Tests";
            this.ckBeltTests.UseVisualStyleBackColor = true;
            // 
            // ckMembers
            // 
            this.ckMembers.AutoSize = true;
            this.ckMembers.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckMembers.Location = new System.Drawing.Point(0, 115);
            this.ckMembers.Name = "ckMembers";
            this.ckMembers.Size = new System.Drawing.Size(565, 23);
            this.ckMembers.TabIndex = 0;
            this.ckMembers.Text = "Members";
            this.ckMembers.UseVisualStyleBackColor = true;
            // 
            // ckBeltRanks
            // 
            this.ckBeltRanks.AutoSize = true;
            this.ckBeltRanks.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckBeltRanks.Location = new System.Drawing.Point(0, 92);
            this.ckBeltRanks.Name = "ckBeltRanks";
            this.ckBeltRanks.Size = new System.Drawing.Size(565, 23);
            this.ckBeltRanks.TabIndex = 0;
            this.ckBeltRanks.Text = "Belt Ranks";
            this.ckBeltRanks.UseVisualStyleBackColor = true;
            // 
            // ckMemberIntructors
            // 
            this.ckMemberIntructors.AutoSize = true;
            this.ckMemberIntructors.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckMemberIntructors.Location = new System.Drawing.Point(0, 69);
            this.ckMemberIntructors.Name = "ckMemberIntructors";
            this.ckMemberIntructors.Size = new System.Drawing.Size(565, 23);
            this.ckMemberIntructors.TabIndex = 0;
            this.ckMemberIntructors.Text = "Member Intructors";
            this.ckMemberIntructors.UseVisualStyleBackColor = true;
            // 
            // ckInstuctors
            // 
            this.ckInstuctors.AutoSize = true;
            this.ckInstuctors.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckInstuctors.Location = new System.Drawing.Point(0, 46);
            this.ckInstuctors.Name = "ckInstuctors";
            this.ckInstuctors.Size = new System.Drawing.Size(565, 23);
            this.ckInstuctors.TabIndex = 0;
            this.ckInstuctors.Text = "Instructors";
            this.ckInstuctors.UseVisualStyleBackColor = true;
            // 
            // ckUsers
            // 
            this.ckUsers.AutoSize = true;
            this.ckUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckUsers.Location = new System.Drawing.Point(0, 23);
            this.ckUsers.Name = "ckUsers";
            this.ckUsers.Size = new System.Drawing.Size(565, 23);
            this.ckUsers.TabIndex = 0;
            this.ckUsers.Text = "Users";
            this.ckUsers.UseVisualStyleBackColor = true;
            // 
            // ckAllPermissions
            // 
            this.ckAllPermissions.AutoSize = true;
            this.ckAllPermissions.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckAllPermissions.Location = new System.Drawing.Point(0, 0);
            this.ckAllPermissions.Name = "ckAllPermissions";
            this.ckAllPermissions.Size = new System.Drawing.Size(565, 23);
            this.ckAllPermissions.TabIndex = 0;
            this.ckAllPermissions.Text = "All Permissions";
            this.ckAllPermissions.UseVisualStyleBackColor = true;
            // 
            // btnCansel
            // 
            this.btnCansel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCansel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnCansel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCansel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCansel.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCansel.Image = global::KartateClubConApp_PersLayer.Properties.Resources.close;
            this.btnCansel.Location = new System.Drawing.Point(347, 279);
            this.btnCansel.Name = "btnCansel";
            this.btnCansel.Size = new System.Drawing.Size(109, 36);
            this.btnCansel.TabIndex = 13;
            this.btnCansel.UseVisualStyleBackColor = true;
            this.btnCansel.Click += new System.EventHandler(this.btnCloes_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::KartateClubConApp_PersLayer.Properties.Resources.download__1_;
            this.btnSave.Location = new System.Drawing.Point(171, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 36);
            this.btnSave.TabIndex = 12;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(677, 375);
            this.Controls.Add(this.pnlContaner);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPermissions";
            this.Text = "frmPermissions";
            this.Load += new System.EventHandler(this.frmPermissions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlContaner.ResumeLayout(false);
            this.pnlContaner.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlContaner;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCloes;
        private System.Windows.Forms.Button btnCansel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox ckPeriods;
        private System.Windows.Forms.CheckBox ckBeltTests;
        private System.Windows.Forms.CheckBox ckMembers;
        private System.Windows.Forms.CheckBox ckBeltRanks;
        private System.Windows.Forms.CheckBox ckMemberIntructors;
        private System.Windows.Forms.CheckBox ckInstuctors;
        private System.Windows.Forms.CheckBox ckUsers;
        private System.Windows.Forms.CheckBox ckPayment;
        private System.Windows.Forms.Label lblShowAddvancesPermission;
        private System.Windows.Forms.CheckBox ckAllPermissions;







    }
}