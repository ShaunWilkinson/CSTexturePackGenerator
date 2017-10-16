namespace Block_Installer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.locationInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GameRootBrowseBtn = new System.Windows.Forms.Button();
            this.RootFolderSelectDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.modFolderInput = new System.Windows.Forms.TextBox();
            this.ModRootBrowseBtn = new System.Windows.Forms.Button();
            this.installBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.statusTxt = new System.Windows.Forms.RichTextBox();
            this.resizeYes = new System.Windows.Forms.RadioButton();
            this.resizeNo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backupTexturesBtn = new System.Windows.Forms.Button();
            this.restoreTexturesBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // locationInput
            // 
            this.locationInput.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.locationInput.Location = new System.Drawing.Point(15, 225);
            this.locationInput.Margin = new System.Windows.Forms.Padding(4);
            this.locationInput.Name = "locationInput";
            this.locationInput.Size = new System.Drawing.Size(413, 23);
            this.locationInput.TabIndex = 0;
            this.locationInput.TextChanged += new System.EventHandler(this.locationInput_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.label1.Location = new System.Drawing.Point(12, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Colony Survival Root Location";
            // 
            // GameRootBrowseBtn
            // 
            this.GameRootBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.GameRootBrowseBtn.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.GameRootBrowseBtn.Location = new System.Drawing.Point(436, 221);
            this.GameRootBrowseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.GameRootBrowseBtn.Name = "GameRootBrowseBtn";
            this.GameRootBrowseBtn.Size = new System.Drawing.Size(100, 30);
            this.GameRootBrowseBtn.TabIndex = 2;
            this.GameRootBrowseBtn.Text = "Browse";
            this.GameRootBrowseBtn.UseVisualStyleBackColor = true;
            this.GameRootBrowseBtn.Click += new System.EventHandler(this.GameRootBrowseBtn_Click);
            // 
            // RootFolderSelectDialog
            // 
            this.RootFolderSelectDialog.HelpRequest += new System.EventHandler(this.RootFolderSelectDialog_HelpRequest);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.label2.Location = new System.Drawing.Point(12, 260);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Texture Pack Root Folder";
            // 
            // modFolderInput
            // 
            this.modFolderInput.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.modFolderInput.Location = new System.Drawing.Point(15, 281);
            this.modFolderInput.Margin = new System.Windows.Forms.Padding(4);
            this.modFolderInput.Name = "modFolderInput";
            this.modFolderInput.Size = new System.Drawing.Size(413, 23);
            this.modFolderInput.TabIndex = 4;
            this.modFolderInput.TextChanged += new System.EventHandler(this.modFolderInput_TextChanged);
            // 
            // ModRootBrowseBtn
            // 
            this.ModRootBrowseBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ModRootBrowseBtn.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.ModRootBrowseBtn.Location = new System.Drawing.Point(436, 277);
            this.ModRootBrowseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ModRootBrowseBtn.Name = "ModRootBrowseBtn";
            this.ModRootBrowseBtn.Size = new System.Drawing.Size(100, 30);
            this.ModRootBrowseBtn.TabIndex = 5;
            this.ModRootBrowseBtn.Text = "Browse";
            this.ModRootBrowseBtn.UseVisualStyleBackColor = true;
            this.ModRootBrowseBtn.Click += new System.EventHandler(this.ModRootBrowseBtn_Click);
            // 
            // installBtn
            // 
            this.installBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.installBtn.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.installBtn.Location = new System.Drawing.Point(15, 614);
            this.installBtn.Margin = new System.Windows.Forms.Padding(4);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(165, 44);
            this.installBtn.TabIndex = 6;
            this.installBtn.Text = "Install";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.label3.Location = new System.Drawing.Point(12, 384);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Status";
            // 
            // statusTxt
            // 
            this.statusTxt.CausesValidation = false;
            this.statusTxt.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.statusTxt.Location = new System.Drawing.Point(15, 405);
            this.statusTxt.Margin = new System.Windows.Forms.Padding(4);
            this.statusTxt.Name = "statusTxt";
            this.statusTxt.ReadOnly = true;
            this.statusTxt.Size = new System.Drawing.Size(521, 201);
            this.statusTxt.TabIndex = 8;
            this.statusTxt.Text = "";
            // 
            // resizeYes
            // 
            this.resizeYes.AutoSize = true;
            this.resizeYes.Checked = true;
            this.resizeYes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resizeYes.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.resizeYes.Location = new System.Drawing.Point(19, 30);
            this.resizeYes.Name = "resizeYes";
            this.resizeYes.Size = new System.Drawing.Size(53, 22);
            this.resizeYes.TabIndex = 10;
            this.resizeYes.TabStop = true;
            this.resizeYes.Text = "Yes";
            this.resizeYes.UseVisualStyleBackColor = true;
            // 
            // resizeNo
            // 
            this.resizeNo.AutoSize = true;
            this.resizeNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.resizeNo.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.resizeNo.Location = new System.Drawing.Point(81, 30);
            this.resizeNo.Name = "resizeNo";
            this.resizeNo.Size = new System.Drawing.Size(49, 22);
            this.resizeNo.TabIndex = 11;
            this.resizeNo.Text = "No";
            this.resizeNo.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.resizeYes);
            this.groupBox1.Controls.Add(this.resizeNo);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.groupBox1.Location = new System.Drawing.Point(15, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 67);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resize Images if Required?";
            // 
            // backupTexturesBtn
            // 
            this.backupTexturesBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.backupTexturesBtn.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.backupTexturesBtn.Location = new System.Drawing.Point(192, 614);
            this.backupTexturesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.backupTexturesBtn.Name = "backupTexturesBtn";
            this.backupTexturesBtn.Size = new System.Drawing.Size(165, 44);
            this.backupTexturesBtn.TabIndex = 13;
            this.backupTexturesBtn.Text = "Backup Game Textures";
            this.backupTexturesBtn.UseVisualStyleBackColor = true;
            this.backupTexturesBtn.Click += new System.EventHandler(this.backupTexturesBtn_Click);
            // 
            // restoreTexturesBtn
            // 
            this.restoreTexturesBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.restoreTexturesBtn.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreTexturesBtn.Location = new System.Drawing.Point(371, 614);
            this.restoreTexturesBtn.Margin = new System.Windows.Forms.Padding(4);
            this.restoreTexturesBtn.Name = "restoreTexturesBtn";
            this.restoreTexturesBtn.Size = new System.Drawing.Size(165, 44);
            this.restoreTexturesBtn.TabIndex = 14;
            this.restoreTexturesBtn.Text = "Restore Game Textures";
            this.restoreTexturesBtn.UseVisualStyleBackColor = true;
            this.restoreTexturesBtn.Click += new System.EventHandler(this.restoreTexturesBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.groupBox2.Location = new System.Drawing.Point(543, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 452);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Instructions";
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F);
            this.label4.Location = new System.Drawing.Point(9, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(300, 415);
            this.label4.TabIndex = 0;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Block_Installer.Properties.Resources.splash;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(839, 177);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(872, 671);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.restoreTexturesBtn);
            this.Controls.Add(this.backupTexturesBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.installBtn);
            this.Controls.Add(this.ModRootBrowseBtn);
            this.Controls.Add(this.modFolderInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GameRootBrowseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.locationInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Colony Survival: Texture Pack Installer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox locationInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GameRootBrowseBtn;
        private System.Windows.Forms.FolderBrowserDialog RootFolderSelectDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox modFolderInput;
        private System.Windows.Forms.Button ModRootBrowseBtn;
        private System.Windows.Forms.Button installBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox statusTxt;
        private System.Windows.Forms.RadioButton resizeYes;
        private System.Windows.Forms.RadioButton resizeNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button backupTexturesBtn;
        private System.Windows.Forms.Button restoreTexturesBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

