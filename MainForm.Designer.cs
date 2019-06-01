namespace AudioEqualiser
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.globalResetSettings = new System.Windows.Forms.Button();
            this.globalApplySettings = new System.Windows.Forms.Button();
            this.globalVolumeShiftSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.globalVolumeAllowance = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.globalTargetVolume = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.programIgnore = new System.Windows.Forms.CheckBox();
            this.programList = new System.Windows.Forms.ComboBox();
            this.programCopyGlobal = new System.Windows.Forms.Button();
            this.programResetSettings = new System.Windows.Forms.Button();
            this.programApplySettings = new System.Windows.Forms.Button();
            this.programVolumeShiftSpeed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.programVolumeAllowance = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.programTargetVolume = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.globalVolumeShiftSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalVolumeAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalTargetVolume)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programVolumeShiftSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programVolumeAllowance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.programTargetVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.globalResetSettings);
            this.groupBox1.Controls.Add(this.globalApplySettings);
            this.groupBox1.Controls.Add(this.globalVolumeShiftSpeed);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.globalVolumeAllowance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.globalTargetVolume);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 139);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Global Settings";
            // 
            // globalResetSettings
            // 
            this.globalResetSettings.Location = new System.Drawing.Point(6, 105);
            this.globalResetSettings.Name = "globalResetSettings";
            this.globalResetSettings.Size = new System.Drawing.Size(109, 23);
            this.globalResetSettings.TabIndex = 7;
            this.globalResetSettings.Text = "Revert Settings";
            this.globalResetSettings.UseVisualStyleBackColor = true;
            this.globalResetSettings.Click += new System.EventHandler(this.globalResetSettings_Click);
            // 
            // globalApplySettings
            // 
            this.globalApplySettings.Location = new System.Drawing.Point(129, 105);
            this.globalApplySettings.Name = "globalApplySettings";
            this.globalApplySettings.Size = new System.Drawing.Size(109, 23);
            this.globalApplySettings.TabIndex = 6;
            this.globalApplySettings.Text = "Apply Settings";
            this.globalApplySettings.UseVisualStyleBackColor = true;
            this.globalApplySettings.Click += new System.EventHandler(this.globalApplySettings_Click);
            // 
            // globalVolumeShiftSpeed
            // 
            this.globalVolumeShiftSpeed.DecimalPlaces = 2;
            this.globalVolumeShiftSpeed.Location = new System.Drawing.Point(115, 79);
            this.globalVolumeShiftSpeed.Name = "globalVolumeShiftSpeed";
            this.globalVolumeShiftSpeed.Size = new System.Drawing.Size(120, 20);
            this.globalVolumeShiftSpeed.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max Volume Change:";
            // 
            // globalVolumeAllowance
            // 
            this.globalVolumeAllowance.DecimalPlaces = 2;
            this.globalVolumeAllowance.Location = new System.Drawing.Point(115, 53);
            this.globalVolumeAllowance.Name = "globalVolumeAllowance";
            this.globalVolumeAllowance.Size = new System.Drawing.Size(120, 20);
            this.globalVolumeAllowance.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Volume Allowance:";
            // 
            // globalTargetVolume
            // 
            this.globalTargetVolume.DecimalPlaces = 2;
            this.globalTargetVolume.Location = new System.Drawing.Point(115, 27);
            this.globalTargetVolume.Name = "globalTargetVolume";
            this.globalTargetVolume.Size = new System.Drawing.Size(120, 20);
            this.globalTargetVolume.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Volume Target:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.programIgnore);
            this.groupBox2.Controls.Add(this.programList);
            this.groupBox2.Controls.Add(this.programCopyGlobal);
            this.groupBox2.Controls.Add(this.programResetSettings);
            this.groupBox2.Controls.Add(this.programApplySettings);
            this.groupBox2.Controls.Add(this.programVolumeShiftSpeed);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.programVolumeAllowance);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.programTargetVolume);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 186);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Per Program Settings";
            // 
            // programIgnore
            // 
            this.programIgnore.AutoSize = true;
            this.programIgnore.Location = new System.Drawing.Point(16, 131);
            this.programIgnore.Name = "programIgnore";
            this.programIgnore.Size = new System.Drawing.Size(98, 17);
            this.programIgnore.TabIndex = 10;
            this.programIgnore.Text = "Ignore Program";
            this.programIgnore.UseVisualStyleBackColor = true;
            // 
            // programList
            // 
            this.programList.FormattingEnabled = true;
            this.programList.Location = new System.Drawing.Point(6, 19);
            this.programList.Name = "programList";
            this.programList.Size = new System.Drawing.Size(232, 21);
            this.programList.TabIndex = 9;
            this.programList.Text = "Select Program...";
            this.programList.SelectedIndexChanged += new System.EventHandler(this.programList_SelectedIndexChanged);
            // 
            // programCopyGlobal
            // 
            this.programCopyGlobal.Location = new System.Drawing.Point(130, 127);
            this.programCopyGlobal.Name = "programCopyGlobal";
            this.programCopyGlobal.Size = new System.Drawing.Size(109, 23);
            this.programCopyGlobal.TabIndex = 8;
            this.programCopyGlobal.Text = "Revert to Global";
            this.programCopyGlobal.UseVisualStyleBackColor = true;
            this.programCopyGlobal.Click += new System.EventHandler(this.programCopyGlobal_Click);
            // 
            // programResetSettings
            // 
            this.programResetSettings.Location = new System.Drawing.Point(6, 156);
            this.programResetSettings.Name = "programResetSettings";
            this.programResetSettings.Size = new System.Drawing.Size(109, 23);
            this.programResetSettings.TabIndex = 7;
            this.programResetSettings.Text = "Revert Settings";
            this.programResetSettings.UseVisualStyleBackColor = true;
            this.programResetSettings.Click += new System.EventHandler(this.programResetSettings_Click);
            // 
            // programApplySettings
            // 
            this.programApplySettings.Location = new System.Drawing.Point(130, 156);
            this.programApplySettings.Name = "programApplySettings";
            this.programApplySettings.Size = new System.Drawing.Size(109, 23);
            this.programApplySettings.TabIndex = 6;
            this.programApplySettings.Text = "Apply Settings";
            this.programApplySettings.UseVisualStyleBackColor = true;
            this.programApplySettings.Click += new System.EventHandler(this.programApplySettings_Click);
            // 
            // programVolumeShiftSpeed
            // 
            this.programVolumeShiftSpeed.DecimalPlaces = 2;
            this.programVolumeShiftSpeed.Location = new System.Drawing.Point(115, 99);
            this.programVolumeShiftSpeed.Name = "programVolumeShiftSpeed";
            this.programVolumeShiftSpeed.Size = new System.Drawing.Size(120, 20);
            this.programVolumeShiftSpeed.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Max Volume Change:";
            // 
            // programVolumeAllowance
            // 
            this.programVolumeAllowance.DecimalPlaces = 2;
            this.programVolumeAllowance.Location = new System.Drawing.Point(115, 73);
            this.programVolumeAllowance.Name = "programVolumeAllowance";
            this.programVolumeAllowance.Size = new System.Drawing.Size(120, 20);
            this.programVolumeAllowance.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Volume Allowance:";
            // 
            // programTargetVolume
            // 
            this.programTargetVolume.DecimalPlaces = 2;
            this.programTargetVolume.Location = new System.Drawing.Point(115, 47);
            this.programTargetVolume.Name = "programTargetVolume";
            this.programTargetVolume.Size = new System.Drawing.Size(120, 20);
            this.programTargetVolume.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Volume Target:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 351);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.globalVolumeShiftSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalVolumeAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.globalTargetVolume)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programVolumeShiftSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programVolumeAllowance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.programTargetVolume)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown globalTargetVolume;
        private System.Windows.Forms.NumericUpDown globalVolumeShiftSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown globalVolumeAllowance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button globalApplySettings;
        private System.Windows.Forms.Button globalResetSettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button programResetSettings;
        private System.Windows.Forms.Button programApplySettings;
        private System.Windows.Forms.NumericUpDown programVolumeShiftSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown programVolumeAllowance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown programTargetVolume;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button programCopyGlobal;
        private System.Windows.Forms.ComboBox programList;
        private System.Windows.Forms.CheckBox programIgnore;
    }
}