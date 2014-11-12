namespace FinalProject_Team
{
    partial class MainMenu
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
            this.btnPrinterUse = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnAddJob = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSupplies = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrinterUse
            // 
            this.btnPrinterUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrinterUse.Location = new System.Drawing.Point(37, 71);
            this.btnPrinterUse.Name = "btnPrinterUse";
            this.btnPrinterUse.Size = new System.Drawing.Size(129, 45);
            this.btnPrinterUse.TabIndex = 0;
            this.btnPrinterUse.Text = "PRINTER USE";
            this.btnPrinterUse.UseVisualStyleBackColor = true;
            this.btnPrinterUse.Click += new System.EventHandler(this.btnPrinterUse_Click);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaintenance.Location = new System.Drawing.Point(37, 135);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(129, 45);
            this.btnMaintenance.TabIndex = 1;
            this.btnMaintenance.Text = "MAINTENANCE";
            this.btnMaintenance.UseVisualStyleBackColor = true;
            this.btnMaintenance.Click += new System.EventHandler(this.btn_Maintenance_Info_Click);
            // 
            // btnAddJob
            // 
            this.btnAddJob.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddJob.Location = new System.Drawing.Point(183, 135);
            this.btnAddJob.Name = "btnAddJob";
            this.btnAddJob.Size = new System.Drawing.Size(129, 45);
            this.btnAddJob.TabIndex = 2;
            this.btnAddJob.Text = "ADD JOB";
            this.btnAddJob.UseVisualStyleBackColor = true;
            this.btnAddJob.Click += new System.EventHandler(this.btnAddJob_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Log Out";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(121, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "MAIN MENU";
            // 
            // btnSupplies
            // 
            this.btnSupplies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplies.Location = new System.Drawing.Point(183, 71);
            this.btnSupplies.Name = "btnSupplies";
            this.btnSupplies.Size = new System.Drawing.Size(129, 45);
            this.btnSupplies.TabIndex = 2;
            this.btnSupplies.Text = "SUPPLIES";
            this.btnSupplies.UseVisualStyleBackColor = true;
            this.btnSupplies.Click += new System.EventHandler(this.btnSupplies_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(37, 198);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(129, 45);
            this.btnAddUser.TabIndex = 2;
            this.btnAddUser.Text = "ADD USER";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 301);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSupplies);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnAddJob);
            this.Controls.Add(this.btnMaintenance);
            this.Controls.Add(this.btnPrinterUse);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrinterUse;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Button btnAddJob;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSupplies;
        private System.Windows.Forms.Button btnAddUser;
    }
}