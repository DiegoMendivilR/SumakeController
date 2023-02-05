namespace CESATAutomationDevelop.Screens
{
    partial class Simulation
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
            this.panelScan = new System.Windows.Forms.TableLayoutPanel();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLastScan = new System.Windows.Forms.Label();
            this.lblTorque = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.monitoringPanel.SuspendLayout();
            this.panelScan.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // monitoringPanel
            // 
            this.monitoringPanel.Controls.Add(this.panelInfo);
            this.monitoringPanel.Controls.Add(this.panelScan);
            this.monitoringPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monitoringPanel.Location = new System.Drawing.Point(0, 0);
            this.monitoringPanel.Name = "monitoringPanel";
            this.monitoringPanel.Size = new System.Drawing.Size(800, 450);
            this.monitoringPanel.TabIndex = 1;
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
            // lblLastScan
            // 
            this.lblLastScan.AutoSize = true;
            this.lblLastScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLastScan.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblLastScan.Location = new System.Drawing.Point(269, 50);
            this.lblLastScan.Name = "lblLastScan";
            this.lblLastScan.Size = new System.Drawing.Size(260, 50);
            this.lblLastScan.TabIndex = 36;
            this.lblLastScan.Text = "Piece Serial";
            this.lblLastScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTorque
            // 
            this.lblTorque.AutoSize = true;
            this.lblTorque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTorque.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.lblTorque.Location = new System.Drawing.Point(535, 50);
            this.lblTorque.Name = "lblTorque";
            this.lblTorque.Size = new System.Drawing.Size(262, 50);
            this.lblTorque.TabIndex = 38;
            this.lblTorque.Text = "N/A";
            this.lblTorque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label5.Location = new System.Drawing.Point(535, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 50);
            this.label5.TabIndex = 39;
            this.label5.Text = "Torque";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label4.Location = new System.Drawing.Point(269, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 50);
            this.label4.TabIndex = 37;
            this.label4.Text = "Piece Serial";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInfo
            // 
            this.panelInfo.ColumnCount = 3;
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.panelInfo.Controls.Add(this.label2, 0, 1);
            this.panelInfo.Controls.Add(this.label1, 0, 0);
            this.panelInfo.Controls.Add(this.label4, 1, 0);
            this.panelInfo.Controls.Add(this.label5, 2, 0);
            this.panelInfo.Controls.Add(this.lblTorque, 2, 1);
            this.panelInfo.Controls.Add(this.lblLastScan, 1, 1);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 43);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.RowCount = 2;
            this.panelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelInfo.Size = new System.Drawing.Size(800, 100);
            this.panelInfo.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 50);
            this.label1.TabIndex = 46;
            this.label1.Text = "Screwdriver Status";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 50);
            this.label2.TabIndex = 52;
            this.label2.Text = "N/A";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.monitoringPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Simulation";
            this.Text = "Simulation";
            this.monitoringPanel.ResumeLayout(false);
            this.monitoringPanel.PerformLayout();
            this.panelScan.ResumeLayout(false);
            this.panelScan.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel monitoringPanel;
        private System.Windows.Forms.TableLayoutPanel panelInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTorque;
        private System.Windows.Forms.Label lblLastScan;
        private System.Windows.Forms.TableLayoutPanel panelScan;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label3;
    }
}