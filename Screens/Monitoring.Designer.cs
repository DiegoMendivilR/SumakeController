namespace CESATAutomationDevelop.Screens
{
    partial class Monitoring
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
            this.monitoringPanel = new System.Windows.Forms.Panel();
            this.panelInfo2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTp = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTr = new System.Windows.Forms.Label();
            this.lblScrewdriverIdCode = new System.Windows.Forms.Label();
            this.lblScrewdriverStatus = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTorque = new System.Windows.Forms.Label();
            this.lblLastScan = new System.Windows.Forms.Label();
            this.lblJs = new System.Windows.Forms.Label();
            this.lblJob = new System.Windows.Forms.Label();
            this.panelScan = new System.Windows.Forms.TableLayoutPanel();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblChangeJob = new System.Windows.Forms.Label();
            this.labelJobSeq = new System.Windows.Forms.Label();
            this.labelJob = new System.Windows.Forms.Label();
            this.numJS = new System.Windows.Forms.NumericUpDown();
            this.numJ = new System.Windows.Forms.NumericUpDown();
            this.btnChangeJob = new System.Windows.Forms.Button();
            this.btnOpenPort = new System.Windows.Forms.Button();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.monitoringPanel.SuspendLayout();
            this.panelInfo2.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelScan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJ)).BeginInit();
            this.SuspendLayout();
            // 
            // monitoringPanel
            // 
            this.monitoringPanel.Controls.Add(this.comboPorts);
            this.monitoringPanel.Controls.Add(this.panelInfo2);
            this.monitoringPanel.Controls.Add(this.panelInfo);
            this.monitoringPanel.Controls.Add(this.panelScan);
            this.monitoringPanel.Controls.Add(this.lblChangeJob);
            this.monitoringPanel.Controls.Add(this.labelJobSeq);
            this.monitoringPanel.Controls.Add(this.labelJob);
            this.monitoringPanel.Controls.Add(this.numJS);
            this.monitoringPanel.Controls.Add(this.numJ);
            this.monitoringPanel.Controls.Add(this.btnChangeJob);
            this.monitoringPanel.Controls.Add(this.btnOpenPort);
            this.monitoringPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitoringPanel.Location = new System.Drawing.Point(0, 0);
            this.monitoringPanel.Name = "monitoringPanel";
            this.monitoringPanel.Size = new System.Drawing.Size(800, 450);
            this.monitoringPanel.TabIndex = 0;
            // 
            // panelInfo2
            // 
            this.panelInfo2.ColumnCount = 4;
            this.panelInfo2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.panelInfo2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.panelInfo2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.panelInfo2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.panelInfo2.Controls.Add(this.label7, 0, 0);
            this.panelInfo2.Controls.Add(this.lblTp, 0, 1);
            this.panelInfo2.Controls.Add(this.label9, 1, 0);
            this.panelInfo2.Controls.Add(this.lblTr, 1, 1);
            this.panelInfo2.Controls.Add(this.lblScrewdriverIdCode, 3, 1);
            this.panelInfo2.Controls.Add(this.lblScrewdriverStatus, 2, 1);
            this.panelInfo2.Controls.Add(this.label10, 3, 0);
            this.panelInfo2.Controls.Add(this.label11, 2, 0);
            this.panelInfo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo2.Location = new System.Drawing.Point(0, 143);
            this.panelInfo2.Name = "panelInfo2";
            this.panelInfo2.RowCount = 2;
            this.panelInfo2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelInfo2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelInfo2.Size = new System.Drawing.Size(800, 100);
            this.panelInfo2.TabIndex = 65;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 50);
            this.label7.TabIndex = 41;
            this.label7.Text = "Tp";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTp
            // 
            this.lblTp.AutoSize = true;
            this.lblTp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTp.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblTp.Location = new System.Drawing.Point(3, 50);
            this.lblTp.Name = "lblTp";
            this.lblTp.Size = new System.Drawing.Size(114, 50);
            this.lblTp.TabIndex = 47;
            this.lblTp.Text = "N/A";
            this.lblTp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label9.Location = new System.Drawing.Point(123, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 50);
            this.label9.TabIndex = 43;
            this.label9.Text = "TR";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTr
            // 
            this.lblTr.AutoSize = true;
            this.lblTr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTr.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblTr.Location = new System.Drawing.Point(123, 50);
            this.lblTr.Name = "lblTr";
            this.lblTr.Size = new System.Drawing.Size(114, 50);
            this.lblTr.TabIndex = 49;
            this.lblTr.Text = "N/A";
            this.lblTr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScrewdriverIdCode
            // 
            this.lblScrewdriverIdCode.AutoSize = true;
            this.lblScrewdriverIdCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScrewdriverIdCode.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblScrewdriverIdCode.Location = new System.Drawing.Point(523, 50);
            this.lblScrewdriverIdCode.Name = "lblScrewdriverIdCode";
            this.lblScrewdriverIdCode.Size = new System.Drawing.Size(274, 50);
            this.lblScrewdriverIdCode.TabIndex = 50;
            this.lblScrewdriverIdCode.Text = "N/A";
            this.lblScrewdriverIdCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScrewdriverStatus
            // 
            this.lblScrewdriverStatus.AutoSize = true;
            this.lblScrewdriverStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScrewdriverStatus.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblScrewdriverStatus.Location = new System.Drawing.Point(243, 50);
            this.lblScrewdriverStatus.Name = "lblScrewdriverStatus";
            this.lblScrewdriverStatus.Size = new System.Drawing.Size(274, 50);
            this.lblScrewdriverStatus.TabIndex = 51;
            this.lblScrewdriverStatus.Text = "N/A";
            this.lblScrewdriverStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label10.Location = new System.Drawing.Point(523, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(274, 50);
            this.label10.TabIndex = 44;
            this.label10.Text = "Screwdriver ID Code";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label11.Location = new System.Drawing.Point(243, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(274, 50);
            this.label11.TabIndex = 45;
            this.label11.Text = "Screwdriver Status";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInfo
            // 
            this.panelInfo.ColumnCount = 4;
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.panelInfo.Controls.Add(this.label6, 0, 0);
            this.panelInfo.Controls.Add(this.label8, 1, 0);
            this.panelInfo.Controls.Add(this.label4, 2, 0);
            this.panelInfo.Controls.Add(this.label5, 3, 0);
            this.panelInfo.Controls.Add(this.lblTorque, 3, 1);
            this.panelInfo.Controls.Add(this.lblLastScan, 2, 1);
            this.panelInfo.Controls.Add(this.lblJs, 1, 1);
            this.panelInfo.Controls.Add(this.lblJob, 0, 1);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 43);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.RowCount = 2;
            this.panelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelInfo.Size = new System.Drawing.Size(800, 100);
            this.panelInfo.TabIndex = 64;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 50);
            this.label6.TabIndex = 40;
            this.label6.Text = "Job";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label8.Location = new System.Drawing.Point(123, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 50);
            this.label8.TabIndex = 42;
            this.label8.Text = "JS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label4.Location = new System.Drawing.Point(243, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(434, 50);
            this.label4.TabIndex = 37;
            this.label4.Text = "Piece Serial";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label5.Location = new System.Drawing.Point(683, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 50);
            this.label5.TabIndex = 39;
            this.label5.Text = "Torque";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTorque
            // 
            this.lblTorque.AutoSize = true;
            this.lblTorque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTorque.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblTorque.Location = new System.Drawing.Point(683, 50);
            this.lblTorque.Name = "lblTorque";
            this.lblTorque.Size = new System.Drawing.Size(114, 50);
            this.lblTorque.TabIndex = 38;
            this.lblTorque.Text = "N/A";
            this.lblTorque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastScan
            // 
            this.lblLastScan.AutoSize = true;
            this.lblLastScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastScan.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblLastScan.Location = new System.Drawing.Point(243, 50);
            this.lblLastScan.Name = "lblLastScan";
            this.lblLastScan.Size = new System.Drawing.Size(434, 50);
            this.lblLastScan.TabIndex = 36;
            this.lblLastScan.Text = "Piece Serial";
            this.lblLastScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJs
            // 
            this.lblJs.AutoSize = true;
            this.lblJs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJs.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblJs.Location = new System.Drawing.Point(123, 50);
            this.lblJs.Name = "lblJs";
            this.lblJs.Size = new System.Drawing.Size(114, 50);
            this.lblJs.TabIndex = 48;
            this.lblJs.Text = "N/A";
            this.lblJs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblJob.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblJob.Location = new System.Drawing.Point(3, 50);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(114, 50);
            this.lblJob.TabIndex = 46;
            this.lblJob.Text = "N/A";
            this.lblJob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelScan
            // 
            this.panelScan.AutoSize = true;
            this.panelScan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelScan.ColumnCount = 2;
            this.panelScan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.panelScan.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelScan.Controls.Add(this.txtInput, 1, 0);
            this.panelScan.Controls.Add(this.label3, 0, 0);
            this.panelScan.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelScan.Location = new System.Drawing.Point(0, 0);
            this.panelScan.Name = "panelScan";
            this.panelScan.RowCount = 1;
            this.panelScan.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelScan.Size = new System.Drawing.Size(800, 43);
            this.panelScan.TabIndex = 63;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.SystemColors.Control;
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.txtInput.Location = new System.Drawing.Point(62, 3);
            this.txtInput.Name = "txtInput";
            this.txtInput.ReadOnly = true;
            this.txtInput.Size = new System.Drawing.Size(735, 37);
            this.txtInput.TabIndex = 34;
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 43);
            this.label3.TabIndex = 35;
            this.label3.Text = "Scan";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChangeJob
            // 
            this.lblChangeJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChangeJob.AutoSize = true;
            this.lblChangeJob.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblChangeJob.Location = new System.Drawing.Point(408, 419);
            this.lblChangeJob.Name = "lblChangeJob";
            this.lblChangeJob.Size = new System.Drawing.Size(37, 23);
            this.lblChangeJob.TabIndex = 62;
            this.lblChangeJob.Text = "OK";
            // 
            // labelJobSeq
            // 
            this.labelJobSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelJobSeq.AutoSize = true;
            this.labelJobSeq.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.labelJobSeq.Location = new System.Drawing.Point(219, 415);
            this.labelJobSeq.Name = "labelJobSeq";
            this.labelJobSeq.Size = new System.Drawing.Size(73, 23);
            this.labelJobSeq.TabIndex = 61;
            this.labelJobSeq.Text = "JobSeq";
            // 
            // labelJob
            // 
            this.labelJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelJob.AutoSize = true;
            this.labelJob.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelJob.Location = new System.Drawing.Point(70, 416);
            this.labelJob.Name = "labelJob";
            this.labelJob.Size = new System.Drawing.Size(40, 23);
            this.labelJob.TabIndex = 60;
            this.labelJob.Text = "Job";
            // 
            // numJS
            // 
            this.numJS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numJS.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.numJS.Location = new System.Drawing.Point(152, 413);
            this.numJS.Name = "numJS";
            this.numJS.Size = new System.Drawing.Size(61, 37);
            this.numJS.TabIndex = 59;
            this.numJS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numJ
            // 
            this.numJ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numJ.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.numJ.Location = new System.Drawing.Point(7, 410);
            this.numJ.Name = "numJ";
            this.numJ.Size = new System.Drawing.Size(60, 37);
            this.numJ.TabIndex = 58;
            this.numJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnChangeJob
            // 
            this.btnChangeJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangeJob.FlatAppearance.BorderSize = 0;
            this.btnChangeJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeJob.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F);
            this.btnChangeJob.ForeColor = System.Drawing.Color.White;
            this.btnChangeJob.Location = new System.Drawing.Point(302, 416);
            this.btnChangeJob.Name = "btnChangeJob";
            this.btnChangeJob.Size = new System.Drawing.Size(100, 30);
            this.btnChangeJob.TabIndex = 57;
            this.btnChangeJob.Text = "Change Job";
            this.btnChangeJob.UseVisualStyleBackColor = true;
            this.btnChangeJob.Click += new System.EventHandler(this.btnChangeJob_Click);
            // 
            // btnOpenPort
            // 
            this.btnOpenPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenPort.FlatAppearance.BorderSize = 0;
            this.btnOpenPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenPort.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenPort.ForeColor = System.Drawing.Color.White;
            this.btnOpenPort.Location = new System.Drawing.Point(688, 412);
            this.btnOpenPort.Name = "btnOpenPort";
            this.btnOpenPort.Size = new System.Drawing.Size(100, 30);
            this.btnOpenPort.TabIndex = 56;
            this.btnOpenPort.Text = "Open Port";
            this.btnOpenPort.UseVisualStyleBackColor = true;
            this.btnOpenPort.Click += new System.EventHandler(this.btnOpenPort_Click);
            // 
            // comboPorts
            // 
            this.comboPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPorts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboPorts.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(573, 412);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(109, 31);
            this.comboPorts.TabIndex = 66;
            // 
            // Monitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monitoringPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Monitoring";
            this.Text = "Monitoring";
            this.monitoringPanel.ResumeLayout(false);
            this.monitoringPanel.PerformLayout();
            this.panelInfo2.ResumeLayout(false);
            this.panelInfo2.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelScan.ResumeLayout(false);
            this.panelScan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numJS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numJ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel monitoringPanel;
        private System.Windows.Forms.TableLayoutPanel panelInfo2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTr;
        private System.Windows.Forms.Label lblScrewdriverIdCode;
        private System.Windows.Forms.Label lblScrewdriverStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel panelInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTorque;
        private System.Windows.Forms.Label lblLastScan;
        private System.Windows.Forms.Label lblJs;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.TableLayoutPanel panelScan;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblChangeJob;
        private System.Windows.Forms.Label labelJobSeq;
        private System.Windows.Forms.Label labelJob;
        private System.Windows.Forms.NumericUpDown numJS;
        private System.Windows.Forms.NumericUpDown numJ;
        private System.Windows.Forms.Button btnChangeJob;
        private System.Windows.Forms.Button btnOpenPort;
        private System.Windows.Forms.ComboBox comboPorts;
    }
}