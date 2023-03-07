using System.Drawing;

namespace CESATAutomationDevelop
{
    partial class Controller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonIOCard = new System.Windows.Forms.Button();
            this.buttonFixture = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.buttonMonitor = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelMenu.Controls.Add(this.buttonIOCard);
            this.panelMenu.Controls.Add(this.buttonFixture);
            this.panelMenu.Controls.Add(this.buttonSettings);
            this.panelMenu.Controls.Add(this.buttonMonitor);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 500);
            this.panelMenu.TabIndex = 28;
            // 
            // buttonIOCard
            // 
            this.buttonIOCard.BackColor = System.Drawing.Color.Transparent;
            this.buttonIOCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonIOCard.FlatAppearance.BorderSize = 0;
            this.buttonIOCard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.buttonIOCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIOCard.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIOCard.ForeColor = System.Drawing.Color.White;
            this.buttonIOCard.Image = global::CESATAutomationDevelop.Properties.Resources.chip_white_24;
            this.buttonIOCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIOCard.Location = new System.Drawing.Point(0, 262);
            this.buttonIOCard.Name = "buttonIOCard";
            this.buttonIOCard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonIOCard.Size = new System.Drawing.Size(200, 54);
            this.buttonIOCard.TabIndex = 33;
            this.buttonIOCard.Text = " I/O";
            this.buttonIOCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIOCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonIOCard.UseVisualStyleBackColor = false;
            this.buttonIOCard.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // buttonFixture
            // 
            this.buttonFixture.BackColor = System.Drawing.Color.Transparent;
            this.buttonFixture.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFixture.FlatAppearance.BorderSize = 0;
            this.buttonFixture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.buttonFixture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFixture.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFixture.ForeColor = System.Drawing.Color.White;
            this.buttonFixture.Image = global::CESATAutomationDevelop.Properties.Resources.fixture_24_white;
            this.buttonFixture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFixture.Location = new System.Drawing.Point(0, 208);
            this.buttonFixture.Name = "buttonFixture";
            this.buttonFixture.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonFixture.Size = new System.Drawing.Size(200, 54);
            this.buttonFixture.TabIndex = 32;
            this.buttonFixture.Text = " Fixture";
            this.buttonFixture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFixture.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonFixture.UseVisualStyleBackColor = false;
            this.buttonFixture.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.Transparent;
            this.buttonSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.Image = global::CESATAutomationDevelop.Properties.Resources.wrench_24_white;
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.Location = new System.Drawing.Point(0, 154);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonSettings.Size = new System.Drawing.Size(200, 54);
            this.buttonSettings.TabIndex = 31;
            this.buttonSettings.Text = " Settings";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSettings.UseVisualStyleBackColor = false;
            this.buttonSettings.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // buttonMonitor
            // 
            this.buttonMonitor.BackColor = System.Drawing.Color.Transparent;
            this.buttonMonitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMonitor.FlatAppearance.BorderSize = 0;
            this.buttonMonitor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.buttonMonitor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMonitor.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMonitor.ForeColor = System.Drawing.Color.White;
            this.buttonMonitor.Image = global::CESATAutomationDevelop.Properties.Resources.monitoring_24_white;
            this.buttonMonitor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMonitor.Location = new System.Drawing.Point(0, 100);
            this.buttonMonitor.Name = "buttonMonitor";
            this.buttonMonitor.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.buttonMonitor.Size = new System.Drawing.Size(200, 54);
            this.buttonMonitor.TabIndex = 30;
            this.buttonMonitor.Text = " Monitoring";
            this.buttonMonitor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMonitor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMonitor.UseVisualStyleBackColor = false;
            this.buttonMonitor.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelTitle.Controls.Add(this.label12);
            this.panelTitle.Controls.Add(this.buttonClose);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(200, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(783, 100);
            this.panelTitle.TabIndex = 29;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Lucida Sans Unicode", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(305, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(180, 34);
            this.label12.TabIndex = 53;
            this.label12.Text = "Automation";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label12_MouseDown);
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(200, 497);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(778, 3);
            this.panelBottom.TabIndex = 31;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(978, 100);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(5, 400);
            this.panelRight.TabIndex = 32;
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.Location = new System.Drawing.Point(200, 100);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(771, 390);
            this.panelContent.TabIndex = 30;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(753, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(26, 26);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseEnter += new System.EventHandler(this.buttonClose_MouseEnter);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            // 
            // panelLogo
            // 
            this.panelLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelLogo.BackgroundImage")));
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 100);
            this.panelLogo.TabIndex = 30;
            this.panelLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            // 
            // Controller
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(983, 500);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Controller";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMT-C1 Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SMTC1Controller_FormClosing);
            this.panelMenu.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button buttonMonitor;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonFixture;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Button buttonIOCard;
        private System.Windows.Forms.Panel panelContent;
    }
}

