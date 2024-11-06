namespace FileSorter
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.cmdBrowseSource = new System.Windows.Forms.Button();
            this.chklstFileTypes = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdScan = new System.Windows.Forms.Button();
            this.txtFileList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.cmdBrowseOutput = new System.Windows.Forms.Button();
            this.cmdProcess = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.lblSelectedSize = new System.Windows.Forms.Label();
            this.chkCheckAllTypes = new System.Windows.Forms.Button();
            this.cmdUncheckAllTypes = new System.Windows.Forms.Button();
            this.cmdCheckCommonTypes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source Directory";
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(12, 25);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(614, 20);
            this.txtSource.TabIndex = 1;
            // 
            // cmdBrowseSource
            // 
            this.cmdBrowseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseSource.Location = new System.Drawing.Point(632, 23);
            this.cmdBrowseSource.Name = "cmdBrowseSource";
            this.cmdBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseSource.TabIndex = 2;
            this.cmdBrowseSource.Text = "Browse";
            this.cmdBrowseSource.UseVisualStyleBackColor = true;
            this.cmdBrowseSource.Click += new System.EventHandler(this.cmdBrowseSource_Click);
            // 
            // chklstFileTypes
            // 
            this.chklstFileTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chklstFileTypes.FormattingEnabled = true;
            this.chklstFileTypes.IntegralHeight = false;
            this.chklstFileTypes.Location = new System.Drawing.Point(12, 70);
            this.chklstFileTypes.Name = "chklstFileTypes";
            this.chklstFileTypes.Size = new System.Drawing.Size(171, 275);
            this.chklstFileTypes.TabIndex = 3;
            this.chklstFileTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstFileTypes_ItemCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Found File Types";
            // 
            // cmdScan
            // 
            this.cmdScan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdScan.Location = new System.Drawing.Point(713, 23);
            this.cmdScan.Name = "cmdScan";
            this.cmdScan.Size = new System.Drawing.Size(75, 23);
            this.cmdScan.TabIndex = 5;
            this.cmdScan.Text = "Scan";
            this.cmdScan.UseVisualStyleBackColor = true;
            this.cmdScan.Click += new System.EventHandler(this.cmdScan_Click);
            // 
            // txtFileList
            // 
            this.txtFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileList.Location = new System.Drawing.Point(189, 70);
            this.txtFileList.Multiline = true;
            this.txtFileList.Name = "txtFileList";
            this.txtFileList.Size = new System.Drawing.Size(599, 304);
            this.txtFileList.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Output Directory (make sure it is empty!)";
            // 
            // txtDestination
            // 
            this.txtDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestination.Location = new System.Drawing.Point(12, 393);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(614, 20);
            this.txtDestination.TabIndex = 8;
            // 
            // cmdBrowseOutput
            // 
            this.cmdBrowseOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdBrowseOutput.Location = new System.Drawing.Point(632, 391);
            this.cmdBrowseOutput.Name = "cmdBrowseOutput";
            this.cmdBrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.cmdBrowseOutput.TabIndex = 9;
            this.cmdBrowseOutput.Text = "Browse";
            this.cmdBrowseOutput.UseVisualStyleBackColor = true;
            this.cmdBrowseOutput.Click += new System.EventHandler(this.cmdBrowseOutput_Click);
            // 
            // cmdProcess
            // 
            this.cmdProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdProcess.Location = new System.Drawing.Point(713, 391);
            this.cmdProcess.Name = "cmdProcess";
            this.cmdProcess.Size = new System.Drawing.Size(75, 23);
            this.cmdProcess.TabIndex = 10;
            this.cmdProcess.Text = "Process";
            this.cmdProcess.UseVisualStyleBackColor = true;
            this.cmdProcess.Click += new System.EventHandler(this.cmdProcess_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 419);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Location = new System.Drawing.Point(186, 54);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(58, 13);
            this.lblFileCount.TabIndex = 12;
            this.lblFileCount.Text = "Total Files:";
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.AutoSize = true;
            this.lblSelectedCount.Location = new System.Drawing.Point(375, 54);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(76, 13);
            this.lblSelectedCount.TabIndex = 13;
            this.lblSelectedCount.Text = "Selected Files:";
            // 
            // lblSelectedSize
            // 
            this.lblSelectedSize.AutoSize = true;
            this.lblSelectedSize.Location = new System.Drawing.Point(591, 54);
            this.lblSelectedSize.Name = "lblSelectedSize";
            this.lblSelectedSize.Size = new System.Drawing.Size(75, 13);
            this.lblSelectedSize.TabIndex = 14;
            this.lblSelectedSize.Text = "Selected Size:";
            // 
            // chkCheckAllTypes
            // 
            this.chkCheckAllTypes.Location = new System.Drawing.Point(12, 351);
            this.chkCheckAllTypes.Name = "chkCheckAllTypes";
            this.chkCheckAllTypes.Size = new System.Drawing.Size(41, 23);
            this.chkCheckAllTypes.TabIndex = 15;
            this.chkCheckAllTypes.Text = "All";
            this.chkCheckAllTypes.UseVisualStyleBackColor = true;
            this.chkCheckAllTypes.Click += new System.EventHandler(this.chkCheckAllTypes_Click);
            // 
            // cmdUncheckAllTypes
            // 
            this.cmdUncheckAllTypes.Location = new System.Drawing.Point(59, 351);
            this.cmdUncheckAllTypes.Name = "cmdUncheckAllTypes";
            this.cmdUncheckAllTypes.Size = new System.Drawing.Size(52, 23);
            this.cmdUncheckAllTypes.TabIndex = 16;
            this.cmdUncheckAllTypes.Text = "None";
            this.cmdUncheckAllTypes.UseVisualStyleBackColor = true;
            this.cmdUncheckAllTypes.Click += new System.EventHandler(this.cmdUncheckAllTypes_Click);
            // 
            // cmdCheckCommonTypes
            // 
            this.cmdCheckCommonTypes.Location = new System.Drawing.Point(117, 351);
            this.cmdCheckCommonTypes.Name = "cmdCheckCommonTypes";
            this.cmdCheckCommonTypes.Size = new System.Drawing.Size(66, 23);
            this.cmdCheckCommonTypes.TabIndex = 17;
            this.cmdCheckCommonTypes.Text = "Common";
            this.cmdCheckCommonTypes.UseVisualStyleBackColor = true;
            this.cmdCheckCommonTypes.Click += new System.EventHandler(this.cmdCheckCommonTypes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdCheckCommonTypes);
            this.Controls.Add(this.cmdUncheckAllTypes);
            this.Controls.Add(this.chkCheckAllTypes);
            this.Controls.Add(this.lblSelectedSize);
            this.Controls.Add(this.lblSelectedCount);
            this.Controls.Add(this.lblFileCount);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.cmdProcess);
            this.Controls.Add(this.cmdBrowseOutput);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFileList);
            this.Controls.Add(this.cmdScan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chklstFileTypes);
            this.Controls.Add(this.cmdBrowseSource);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Sorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Button cmdBrowseSource;
        private System.Windows.Forms.CheckedListBox chklstFileTypes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdScan;
        private System.Windows.Forms.TextBox txtFileList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Button cmdBrowseOutput;
        private System.Windows.Forms.Button cmdProcess;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Label lblSelectedSize;
        private System.Windows.Forms.Button chkCheckAllTypes;
        private System.Windows.Forms.Button cmdUncheckAllTypes;
        private System.Windows.Forms.Button cmdCheckCommonTypes;
    }
}

