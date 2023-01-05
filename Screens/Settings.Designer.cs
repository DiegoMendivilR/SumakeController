namespace SumakeController.Screens
{
    partial class Settings
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
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.comboInternetSettings = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboMode = new System.Windows.Forms.ComboBox();
            this.comboLanguage = new System.Windows.Forms.ComboBox();
            this.comboOkAllSignal = new System.Windows.Forms.ComboBox();
            this.comboBatchMode = new System.Windows.Forms.ComboBox();
            this.comboTorqueUnit = new System.Windows.Forms.ComboBox();
            this.numericDeviceId = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboGateMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBuzzerMode = new System.Windows.Forms.ComboBox();
            this.comboLedMode = new System.Windows.Forms.ComboBox();
            this.comboStartMode = new System.Windows.Forms.ComboBox();
            this.comboBarcodeEnable = new System.Windows.Forms.ComboBox();
            this.comboStartSignalMode = new System.Windows.Forms.ComboBox();
            this.settingsPanel.SuspendLayout();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDeviceId)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            this.settingsPanel.Controls.Add(this.tablePanel);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.MaximumSize = new System.Drawing.Size(850, 565);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(800, 450);
            this.settingsPanel.TabIndex = 0;
            // 
            // tablePanel
            // 
            this.tablePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePanel.ColumnCount = 4;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tablePanel.Controls.Add(this.comboInternetSettings, 3, 5);
            this.tablePanel.Controls.Add(this.label13, 2, 5);
            this.tablePanel.Controls.Add(this.label11, 0, 5);
            this.tablePanel.Controls.Add(this.label9, 0, 4);
            this.tablePanel.Controls.Add(this.label7, 0, 3);
            this.tablePanel.Controls.Add(this.label4, 0, 2);
            this.tablePanel.Controls.Add(this.label2, 0, 1);
            this.tablePanel.Controls.Add(this.label6, 0, 0);
            this.tablePanel.Controls.Add(this.comboMode, 1, 1);
            this.tablePanel.Controls.Add(this.comboLanguage, 1, 2);
            this.tablePanel.Controls.Add(this.comboOkAllSignal, 1, 3);
            this.tablePanel.Controls.Add(this.comboBatchMode, 1, 4);
            this.tablePanel.Controls.Add(this.comboTorqueUnit, 1, 5);
            this.tablePanel.Controls.Add(this.numericDeviceId, 1, 0);
            this.tablePanel.Controls.Add(this.buttonSave, 1, 7);
            this.tablePanel.Controls.Add(this.label1, 0, 6);
            this.tablePanel.Controls.Add(this.comboGateMode, 1, 6);
            this.tablePanel.Controls.Add(this.label3, 2, 0);
            this.tablePanel.Controls.Add(this.label5, 2, 1);
            this.tablePanel.Controls.Add(this.label8, 2, 2);
            this.tablePanel.Controls.Add(this.label10, 2, 3);
            this.tablePanel.Controls.Add(this.label12, 2, 4);
            this.tablePanel.Controls.Add(this.comboBuzzerMode, 3, 0);
            this.tablePanel.Controls.Add(this.comboLedMode, 3, 1);
            this.tablePanel.Controls.Add(this.comboStartMode, 3, 2);
            this.tablePanel.Controls.Add(this.comboBarcodeEnable, 3, 3);
            this.tablePanel.Controls.Add(this.comboStartSignalMode, 3, 4);
            this.tablePanel.Location = new System.Drawing.Point(12, 12);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 8;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tablePanel.Size = new System.Drawing.Size(776, 426);
            this.tablePanel.TabIndex = 12;
            // 
            // comboInternetSettings
            // 
            this.comboInternetSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboInternetSettings.Enabled = false;
            this.comboInternetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboInternetSettings.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboInternetSettings.FormattingEnabled = true;
            this.comboInternetSettings.Location = new System.Drawing.Point(585, 276);
            this.comboInternetSettings.Name = "comboInternetSettings";
            this.comboInternetSettings.Size = new System.Drawing.Size(188, 31);
            this.comboInternetSettings.TabIndex = 59;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label13.Location = new System.Drawing.Point(391, 280);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(188, 23);
            this.label13.TabIndex = 58;
            this.label13.Text = "Internet Settings";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label11.Location = new System.Drawing.Point(3, 280);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(188, 23);
            this.label11.TabIndex = 51;
            this.label11.Text = "Torque Unit";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label9.Location = new System.Drawing.Point(3, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 23);
            this.label9.TabIndex = 49;
            this.label9.Text = "Batch Mode";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label7.Location = new System.Drawing.Point(3, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 23);
            this.label7.TabIndex = 47;
            this.label7.Text = "OKALL Signal";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label4.Location = new System.Drawing.Point(3, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 23);
            this.label4.TabIndex = 45;
            this.label4.Text = "Language";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label2.Location = new System.Drawing.Point(3, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 23);
            this.label2.TabIndex = 43;
            this.label2.Text = "Operation Mode";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label6.Location = new System.Drawing.Point(3, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(188, 23);
            this.label6.TabIndex = 41;
            this.label6.Text = "Device ID";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboMode
            // 
            this.comboMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboMode.Enabled = false;
            this.comboMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboMode.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboMode.FormattingEnabled = true;
            this.comboMode.Location = new System.Drawing.Point(197, 64);
            this.comboMode.Name = "comboMode";
            this.comboMode.Size = new System.Drawing.Size(188, 31);
            this.comboMode.TabIndex = 1;
            // 
            // comboLanguage
            // 
            this.comboLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLanguage.Enabled = false;
            this.comboLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboLanguage.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboLanguage.FormattingEnabled = true;
            this.comboLanguage.Location = new System.Drawing.Point(197, 117);
            this.comboLanguage.Name = "comboLanguage";
            this.comboLanguage.Size = new System.Drawing.Size(188, 31);
            this.comboLanguage.TabIndex = 2;
            // 
            // comboOkAllSignal
            // 
            this.comboOkAllSignal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboOkAllSignal.Enabled = false;
            this.comboOkAllSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboOkAllSignal.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboOkAllSignal.FormattingEnabled = true;
            this.comboOkAllSignal.Location = new System.Drawing.Point(197, 170);
            this.comboOkAllSignal.Name = "comboOkAllSignal";
            this.comboOkAllSignal.Size = new System.Drawing.Size(188, 31);
            this.comboOkAllSignal.TabIndex = 3;
            // 
            // comboBatchMode
            // 
            this.comboBatchMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBatchMode.Enabled = false;
            this.comboBatchMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBatchMode.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboBatchMode.FormattingEnabled = true;
            this.comboBatchMode.Location = new System.Drawing.Point(197, 223);
            this.comboBatchMode.Name = "comboBatchMode";
            this.comboBatchMode.Size = new System.Drawing.Size(188, 31);
            this.comboBatchMode.TabIndex = 4;
            // 
            // comboTorqueUnit
            // 
            this.comboTorqueUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboTorqueUnit.Enabled = false;
            this.comboTorqueUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboTorqueUnit.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboTorqueUnit.FormattingEnabled = true;
            this.comboTorqueUnit.Location = new System.Drawing.Point(197, 276);
            this.comboTorqueUnit.Name = "comboTorqueUnit";
            this.comboTorqueUnit.Size = new System.Drawing.Size(188, 31);
            this.comboTorqueUnit.TabIndex = 5;
            // 
            // numericDeviceId
            // 
            this.numericDeviceId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numericDeviceId.Enabled = false;
            this.numericDeviceId.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.numericDeviceId.Location = new System.Drawing.Point(197, 8);
            this.numericDeviceId.Name = "numericDeviceId";
            this.numericDeviceId.Size = new System.Drawing.Size(188, 37);
            this.numericDeviceId.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePanel.SetColumnSpan(this.buttonSave, 2);
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.White;
            this.buttonSave.Location = new System.Drawing.Point(197, 383);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(382, 30);
            this.buttonSave.TabIndex = 57;
            this.buttonSave.Text = "Save Settings";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label1.Location = new System.Drawing.Point(3, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 23);
            this.label1.TabIndex = 42;
            this.label1.Text = "Gate Mode";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboGateMode
            // 
            this.comboGateMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboGateMode.Enabled = false;
            this.comboGateMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboGateMode.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboGateMode.FormattingEnabled = true;
            this.comboGateMode.Location = new System.Drawing.Point(197, 329);
            this.comboGateMode.Name = "comboGateMode";
            this.comboGateMode.Size = new System.Drawing.Size(188, 31);
            this.comboGateMode.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label3.Location = new System.Drawing.Point(391, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 23);
            this.label3.TabIndex = 44;
            this.label3.Text = "Buzzer Mode";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label5.Location = new System.Drawing.Point(391, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 23);
            this.label5.TabIndex = 46;
            this.label5.Text = "LED Mode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label8.Location = new System.Drawing.Point(391, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 23);
            this.label8.TabIndex = 48;
            this.label8.Text = "Start Mode";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label10.Location = new System.Drawing.Point(391, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(188, 23);
            this.label10.TabIndex = 50;
            this.label10.Text = "Barcode Enable";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.label12.Location = new System.Drawing.Point(391, 227);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(188, 23);
            this.label12.TabIndex = 52;
            this.label12.Text = "Start Signal Mode";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBuzzerMode
            // 
            this.comboBuzzerMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBuzzerMode.Enabled = false;
            this.comboBuzzerMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBuzzerMode.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboBuzzerMode.FormattingEnabled = true;
            this.comboBuzzerMode.Location = new System.Drawing.Point(585, 11);
            this.comboBuzzerMode.Name = "comboBuzzerMode";
            this.comboBuzzerMode.Size = new System.Drawing.Size(188, 31);
            this.comboBuzzerMode.TabIndex = 7;
            // 
            // comboLedMode
            // 
            this.comboLedMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboLedMode.Enabled = false;
            this.comboLedMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboLedMode.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboLedMode.FormattingEnabled = true;
            this.comboLedMode.Location = new System.Drawing.Point(585, 64);
            this.comboLedMode.Name = "comboLedMode";
            this.comboLedMode.Size = new System.Drawing.Size(188, 31);
            this.comboLedMode.TabIndex = 8;
            // 
            // comboStartMode
            // 
            this.comboStartMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboStartMode.Enabled = false;
            this.comboStartMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboStartMode.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboStartMode.FormattingEnabled = true;
            this.comboStartMode.Location = new System.Drawing.Point(585, 117);
            this.comboStartMode.Name = "comboStartMode";
            this.comboStartMode.Size = new System.Drawing.Size(188, 31);
            this.comboStartMode.TabIndex = 9;
            // 
            // comboBarcodeEnable
            // 
            this.comboBarcodeEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBarcodeEnable.Enabled = false;
            this.comboBarcodeEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBarcodeEnable.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboBarcodeEnable.FormattingEnabled = true;
            this.comboBarcodeEnable.Location = new System.Drawing.Point(585, 170);
            this.comboBarcodeEnable.Name = "comboBarcodeEnable";
            this.comboBarcodeEnable.Size = new System.Drawing.Size(188, 31);
            this.comboBarcodeEnable.TabIndex = 10;
            // 
            // comboStartSignalMode
            // 
            this.comboStartSignalMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.comboStartSignalMode.Enabled = false;
            this.comboStartSignalMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboStartSignalMode.Font = new System.Drawing.Font("Lucida Sans Unicode", 14.25F);
            this.comboStartSignalMode.FormattingEnabled = true;
            this.comboStartSignalMode.Location = new System.Drawing.Point(585, 223);
            this.comboStartSignalMode.Name = "comboStartSignalMode";
            this.comboStartSignalMode.Size = new System.Drawing.Size(188, 31);
            this.comboStartSignalMode.TabIndex = 11;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.settingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Text = "Settings";
            this.settingsPanel.ResumeLayout(false);
            this.tablePanel.ResumeLayout(false);
            this.tablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDeviceId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboStartSignalMode;
        private System.Windows.Forms.ComboBox comboMode;
        private System.Windows.Forms.ComboBox comboBarcodeEnable;
        private System.Windows.Forms.ComboBox comboLanguage;
        private System.Windows.Forms.ComboBox comboStartMode;
        private System.Windows.Forms.ComboBox comboOkAllSignal;
        private System.Windows.Forms.ComboBox comboLedMode;
        private System.Windows.Forms.ComboBox comboBatchMode;
        private System.Windows.Forms.ComboBox comboBuzzerMode;
        private System.Windows.Forms.ComboBox comboTorqueUnit;
        private System.Windows.Forms.ComboBox comboGateMode;
        private System.Windows.Forms.NumericUpDown numericDeviceId;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboInternetSettings;
        private System.Windows.Forms.Label label13;
    }
}