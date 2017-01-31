namespace DataReprocess_LogFile.Forms
{
    partial class frmSettings
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.txtInstallation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQN = new System.Windows.Forms.TextBox();
            this.radRQYes = new System.Windows.Forms.RadioButton();
            this.radRQNo = new System.Windows.Forms.RadioButton();
            this.radSQNo = new System.Windows.Forms.RadioButton();
            this.radSQYes = new System.Windows.Forms.RadioButton();
            this.radRX = new System.Windows.Forms.RadioButton();
            this.radLX = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblResponse = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(56, 167);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(204, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(143, 13);
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(162, 20);
            this.txtEvent.TabIndex = 1;
            // 
            // txtInstallation
            // 
            this.txtInstallation.Location = new System.Drawing.Point(143, 39);
            this.txtInstallation.Name = "txtInstallation";
            this.txtInstallation.Size = new System.Drawing.Size(162, 20);
            this.txtInstallation.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "EventName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Installation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Execution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Use Specific Queues";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Rotate Queues";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Queue Number";
            // 
            // txtQN
            // 
            this.txtQN.Location = new System.Drawing.Point(143, 116);
            this.txtQN.Name = "txtQN";
            this.txtQN.Size = new System.Drawing.Size(23, 20);
            this.txtQN.TabIndex = 13;
            // 
            // radRQYes
            // 
            this.radRQYes.AutoSize = true;
            this.radRQYes.Location = new System.Drawing.Point(5, 3);
            this.radRQYes.Name = "radRQYes";
            this.radRQYes.Size = new System.Drawing.Size(43, 17);
            this.radRQYes.TabIndex = 14;
            this.radRQYes.TabStop = true;
            this.radRQYes.Text = "Yes";
            this.radRQYes.UseVisualStyleBackColor = true;
            // 
            // radRQNo
            // 
            this.radRQNo.AutoSize = true;
            this.radRQNo.Location = new System.Drawing.Point(80, 3);
            this.radRQNo.Name = "radRQNo";
            this.radRQNo.Size = new System.Drawing.Size(39, 17);
            this.radRQNo.TabIndex = 15;
            this.radRQNo.TabStop = true;
            this.radRQNo.Text = "No";
            this.radRQNo.UseVisualStyleBackColor = true;
            // 
            // radSQNo
            // 
            this.radSQNo.AutoSize = true;
            this.radSQNo.Location = new System.Drawing.Point(80, 2);
            this.radSQNo.Name = "radSQNo";
            this.radSQNo.Size = new System.Drawing.Size(39, 17);
            this.radSQNo.TabIndex = 17;
            this.radSQNo.TabStop = true;
            this.radSQNo.Text = "No";
            this.radSQNo.UseVisualStyleBackColor = true;
            this.radSQNo.CheckedChanged += new System.EventHandler(this.radSQNo_CheckedChanged);
            // 
            // radSQYes
            // 
            this.radSQYes.AutoSize = true;
            this.radSQYes.Location = new System.Drawing.Point(3, 2);
            this.radSQYes.Name = "radSQYes";
            this.radSQYes.Size = new System.Drawing.Size(43, 17);
            this.radSQYes.TabIndex = 16;
            this.radSQYes.TabStop = true;
            this.radSQYes.Text = "Yes";
            this.radSQYes.UseVisualStyleBackColor = true;
            this.radSQYes.CheckedChanged += new System.EventHandler(this.radSQYes_CheckedChanged);
            // 
            // radRX
            // 
            this.radRX.AutoSize = true;
            this.radRX.Location = new System.Drawing.Point(80, 3);
            this.radRX.Name = "radRX";
            this.radRX.Size = new System.Drawing.Size(40, 17);
            this.radRX.TabIndex = 19;
            this.radRX.TabStop = true;
            this.radRX.Text = "RX";
            this.radRX.UseVisualStyleBackColor = true;
            // 
            // radLX
            // 
            this.radLX.AutoSize = true;
            this.radLX.Location = new System.Drawing.Point(5, 3);
            this.radLX.Name = "radLX";
            this.radLX.Size = new System.Drawing.Size(38, 17);
            this.radLX.TabIndex = 18;
            this.radLX.TabStop = true;
            this.radLX.Text = "LX";
            this.radLX.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radRX);
            this.panel1.Controls.Add(this.radLX);
            this.panel1.Location = new System.Drawing.Point(143, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(162, 22);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radRQYes);
            this.panel2.Controls.Add(this.radRQNo);
            this.panel2.Location = new System.Drawing.Point(143, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(162, 22);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radSQYes);
            this.panel3.Controls.Add(this.radSQNo);
            this.panel3.Location = new System.Drawing.Point(143, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(162, 22);
            this.panel3.TabIndex = 0;
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponse.ForeColor = System.Drawing.Color.Red;
            this.lblResponse.Location = new System.Drawing.Point(0, 207);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(0, 15);
            this.lblResponse.TabIndex = 22;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 222);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtQN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInstallation);
            this.Controls.Add(this.txtEvent);
            this.Controls.Add(this.btnSave);
            this.Name = "frmSettings";
            this.Text = "Clarif-i Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.TextBox txtInstallation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQN;
        private System.Windows.Forms.RadioButton radRQYes;
        private System.Windows.Forms.RadioButton radRQNo;
        private System.Windows.Forms.RadioButton radSQNo;
        private System.Windows.Forms.RadioButton radSQYes;
        private System.Windows.Forms.RadioButton radRX;
        private System.Windows.Forms.RadioButton radLX;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblResponse;
    }
}