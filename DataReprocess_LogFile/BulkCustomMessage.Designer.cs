namespace DataReprocess_LogFile
{
    partial class BulkCustomMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkCustomMessage));
            this.txtIDs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtEventName = new System.Windows.Forms.TextBox();
            this.txtInstallation = new System.Windows.Forms.TextBox();
            this.txtQueueNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.clearIDsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIDs
            // 
            this.txtIDs.Location = new System.Drawing.Point(12, 66);
            this.txtIDs.Multiline = true;
            this.txtIDs.Name = "txtIDs";
            this.txtIDs.Size = new System.Drawing.Size(219, 421);
            this.txtIDs.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IDs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Message ";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 26);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(407, 20);
            this.txtMessage.TabIndex = 3;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(237, 66);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(182, 23);
            this.btnBuild.TabIndex = 4;
            this.btnBuild.Text = "Build Messages";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // lstMessages
            // 
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.Location = new System.Drawing.Point(425, 26);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(500, 433);
            this.lstMessages.TabIndex = 5;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(425, 465);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(148, 23);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Process All Messages";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEventName
            // 
            this.txtEventName.Location = new System.Drawing.Point(237, 134);
            this.txtEventName.Name = "txtEventName";
            this.txtEventName.Size = new System.Drawing.Size(182, 20);
            this.txtEventName.TabIndex = 7;
            // 
            // txtInstallation
            // 
            this.txtInstallation.Location = new System.Drawing.Point(237, 173);
            this.txtInstallation.Name = "txtInstallation";
            this.txtInstallation.Size = new System.Drawing.Size(182, 20);
            this.txtInstallation.TabIndex = 8;
            // 
            // txtQueueNumber
            // 
            this.txtQueueNumber.Location = new System.Drawing.Point(237, 212);
            this.txtQueueNumber.Name = "txtQueueNumber";
            this.txtQueueNumber.Size = new System.Drawing.Size(182, 20);
            this.txtQueueNumber.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "EventName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Installation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Queue Number";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(850, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Load File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1,
            this.toolStripDropDownButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(937, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(200, 16);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel1.Text = "0";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMessagesToolStripMenuItem,
            this.clearIDsToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(47, 20);
            this.toolStripDropDownButton1.Text = "Clear";
            // 
            // clearIDsToolStripMenuItem
            // 
            this.clearIDsToolStripMenuItem.Name = "clearIDsToolStripMenuItem";
            this.clearIDsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.clearIDsToolStripMenuItem.Text = "Clear IDs";
            this.clearIDsToolStripMenuItem.Click += new System.EventHandler(this.clearIDsToolStripMenuItem_Click);
            // 
            // clearMessagesToolStripMenuItem
            // 
            this.clearMessagesToolStripMenuItem.Name = "clearMessagesToolStripMenuItem";
            this.clearMessagesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.clearMessagesToolStripMenuItem.Text = "Clear Messages";
            this.clearMessagesToolStripMenuItem.Click += new System.EventHandler(this.clearMessagesToolStripMenuItem_Click);
            // 
            // BulkCustomMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 519);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQueueNumber);
            this.Controls.Add(this.txtInstallation);
            this.Controls.Add(this.txtEventName);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lstMessages);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIDs);
            this.Controls.Add(this.statusStrip1);
            this.Name = "BulkCustomMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BulkCustomMessage";
            this.Load += new System.EventHandler(this.BulkCustomMessage_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIDs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.ListBox lstMessages;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtEventName;
        private System.Windows.Forms.TextBox txtInstallation;
        private System.Windows.Forms.TextBox txtQueueNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem clearMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearIDsToolStripMenuItem;
    }
}