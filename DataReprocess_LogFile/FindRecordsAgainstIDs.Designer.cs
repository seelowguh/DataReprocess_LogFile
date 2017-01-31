namespace DataReprocess_LogFile
{
    partial class frmFindRecords
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDs = new System.Windows.Forms.TextBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnIDFilepath = new System.Windows.Forms.Button();
            this.btnDataFilepath = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOutputFilePath = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.chkCreateDeclaration = new System.Windows.Forms.CheckBox();
            this.lblSQLTablePath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Filepath";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Data Filepath";
            // 
            // txtIDs
            // 
            this.txtIDs.Location = new System.Drawing.Point(103, 10);
            this.txtIDs.Name = "txtIDs";
            this.txtIDs.Size = new System.Drawing.Size(313, 20);
            this.txtIDs.TabIndex = 2;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(103, 37);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(313, 20);
            this.txtData.TabIndex = 3;
            // 
            // btnIDFilepath
            // 
            this.btnIDFilepath.Location = new System.Drawing.Point(422, 8);
            this.btnIDFilepath.Name = "btnIDFilepath";
            this.btnIDFilepath.Size = new System.Drawing.Size(111, 23);
            this.btnIDFilepath.TabIndex = 4;
            this.btnIDFilepath.Text = "Browse...";
            this.btnIDFilepath.UseVisualStyleBackColor = true;
            this.btnIDFilepath.Click += new System.EventHandler(this.btnIDFilepath_Click);
            // 
            // btnDataFilepath
            // 
            this.btnDataFilepath.Location = new System.Drawing.Point(422, 35);
            this.btnDataFilepath.Name = "btnDataFilepath";
            this.btnDataFilepath.Size = new System.Drawing.Size(111, 23);
            this.btnDataFilepath.TabIndex = 5;
            this.btnDataFilepath.Text = "Browse...";
            this.btnDataFilepath.UseVisualStyleBackColor = true;
            this.btnDataFilepath.Click += new System.EventHandler(this.btnDataFilepath_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(103, 64);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(313, 20);
            this.txtOutput.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output Filepath";
            // 
            // btnOutputFilePath
            // 
            this.btnOutputFilePath.Location = new System.Drawing.Point(422, 62);
            this.btnOutputFilePath.Name = "btnOutputFilePath";
            this.btnOutputFilePath.Size = new System.Drawing.Size(111, 23);
            this.btnOutputFilePath.TabIndex = 8;
            this.btnOutputFilePath.Text = "Browse...";
            this.btnOutputFilePath.UseVisualStyleBackColor = true;
            this.btnOutputFilePath.Click += new System.EventHandler(this.btnOutputFilePath_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(16, 116);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(517, 23);
            this.btnProcess.TabIndex = 9;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // chkCreateDeclaration
            // 
            this.chkCreateDeclaration.AutoSize = true;
            this.chkCreateDeclaration.Location = new System.Drawing.Point(16, 93);
            this.chkCreateDeclaration.Name = "chkCreateDeclaration";
            this.chkCreateDeclaration.Size = new System.Drawing.Size(111, 17);
            this.chkCreateDeclaration.TabIndex = 10;
            this.chkCreateDeclaration.Text = "Create SQL Table";
            this.chkCreateDeclaration.UseVisualStyleBackColor = true;
            this.chkCreateDeclaration.CheckedChanged += new System.EventHandler(this.chkCreateDeclaration_CheckedChanged);
            // 
            // lblSQLTablePath
            // 
            this.lblSQLTablePath.AutoSize = true;
            this.lblSQLTablePath.Location = new System.Drawing.Point(170, 94);
            this.lblSQLTablePath.Name = "lblSQLTablePath";
            this.lblSQLTablePath.Size = new System.Drawing.Size(44, 13);
            this.lblSQLTablePath.TabIndex = 11;
            this.lblSQLTablePath.Text = "Filepath";
            // 
            // frmFindRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 151);
            this.Controls.Add(this.lblSQLTablePath);
            this.Controls.Add(this.chkCreateDeclaration);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnOutputFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnDataFilepath);
            this.Controls.Add(this.btnIDFilepath);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.txtIDs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(560, 190);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(560, 190);
            this.Name = "frmFindRecords";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Records Against IDs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDs;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Button btnIDFilepath;
        private System.Windows.Forms.Button btnDataFilepath;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOutputFilePath;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.CheckBox chkCreateDeclaration;
        private System.Windows.Forms.Label lblSQLTablePath;
    }
}