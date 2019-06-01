// Decompiled with JetBrains decompiler
// Type: AudioEqualiser.Form1
// Assembly: AudioEqualiser, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5D7B6984-A4AE-4F09-AD43-7CBCA6FB0086
// Assembly location: D:\Programs\AudioEqualiser2\AudioEqualiser.exe

using AudioEqualiser.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AudioEqualiser
{
  public class Form1 : Form
  {
    public Dictionary<string, ProcessItem> programListData;
    private IContainer components;
    private GroupBox groupBox1;
    private GroupBox groupBox2;
    private Label label3;
    private NumericUpDown globalTargetVolume;
    private Label label2;
    private NumericUpDown globalVolumeAllowance;
    private Label label1;
    private NumericUpDown globalVolumeShiftSpeed;
    private Button globalResetSettings;
    private Button globalApplySettings;
    private ComboBox programList;
    private Label label4;
    private GroupBox groupBox3;
    private Label label5;
    private NumericUpDown programTargetVolume;
    private Label label6;
    private NumericUpDown programVolumeAllowance;
    private Label label7;
    private NumericUpDown programVolumeShiftSpeed;
    private Button programCopyGlobal;
    private Button programResetSettings;
    private Button programApplySettings;

    public Form1()
    {
      this.InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.InitProgramList();
    }

    private void InitProgramList()
    {
      this.programListData = (Dictionary<string, ProcessItem>) null;
      this.programListData = new Dictionary<string, ProcessItem>();
      foreach (KeyValuePair<int, AudioSessionInformation> audioSession in Program.audioSessions)
      {
        string processName = audioSession.Value.processName;
        ProcessItem processItem = new ProcessItem(processName);
        if (Program.programSettingData.ContainsKey(processName))
          processItem.tag = "*";
        this.programListData[processName] = processItem;
      }
      foreach (KeyValuePair<string, ProgramSettings> keyValuePair in Program.programSettingData)
      {
        KeyValuePair<string, ProgramSettings> pgmDat = keyValuePair;
        if (!this.programListData.Any<KeyValuePair<string, ProcessItem>>((Func<KeyValuePair<string, ProcessItem>, bool>) (val => val.Value.name == pgmDat.Key)))
          this.programListData[pgmDat.Key] = new ProcessItem(pgmDat.Key, "*");
      }
      this.RefreshList();
      this.LoadGlobalSettingState();
    }

    private void LoadGlobalSettingState()
    {
      this.globalTargetVolume.Value = (Decimal) Program.globalVolumeTarget;
      this.globalVolumeShiftSpeed.Value = (Decimal) Program.globalMaxShift;
      this.globalVolumeAllowance.Value = (Decimal) Program.globalAllowance;
    }

    private void globalApplySettings_Click(object sender, EventArgs e)
    {
      Settings.Default.GlobalVolumeTarget = (float) this.globalTargetVolume.Value;
      Settings.Default.GlobalVolumeAllowance = (float) this.globalVolumeAllowance.Value;
      Settings.Default.GlobalVolumeShiftSpeed = (float) this.globalVolumeShiftSpeed.Value;
      Settings.Default.Save();
      Program.LoadGlobalSettings();
      this.LoadGlobalSettingState();
    }

    private void globalResetSettings_Click(object sender, EventArgs e)
    {
      this.LoadGlobalSettingState();
    }

    private void programList_SelectedIndexChanged(object sender, EventArgs e)
    {
      ComboBox comboBox = (ComboBox) sender;
      if (comboBox.SelectedItem == null)
        return;
      this.LoadProgramSettingState(((ProcessItem) comboBox.SelectedItem).name);
    }

    private void LoadProgramSettingState(string programName)
    {
      if (Program.programSettingData.ContainsKey(programName))
      {
        ProgramSettings programSettings = Program.programSettingData[programName];
        this.programTargetVolume.Value = (Decimal) programSettings.target;
        this.programVolumeShiftSpeed.Value = (Decimal) programSettings.shift;
        this.programVolumeAllowance.Value = (Decimal) programSettings.allowance;
      }
      else
      {
        this.programTargetVolume.Value = (Decimal) Program.globalVolumeTarget;
        this.programVolumeShiftSpeed.Value = (Decimal) Program.globalMaxShift;
        this.programVolumeAllowance.Value = (Decimal) Program.globalAllowance;
      }
    }

    private void programApplySettings_Click(object sender, EventArgs e)
    {
      string name = ((ProcessItem) this.programList.SelectedItem).name;
      Program.programSettingData[name] = new ProgramSettings((float) this.programVolumeShiftSpeed.Value, (float) this.programVolumeAllowance.Value, (float) this.programTargetVolume.Value);
      this.SetTagValue(name, "*");
      Program.SaveProgramSettingData();
    }

    private void programResetSettings_Click(object sender, EventArgs e)
    {
      this.LoadProgramSettingState(((ProcessItem) this.programList.SelectedItem).name);
    }

    private void programCopyGlobal_Click(object sender, EventArgs e)
    {
      string name = ((ProcessItem) this.programList.SelectedItem).name;
      Program.programSettingData.Remove(name);
      Program.SaveProgramSettingData();
      this.SetTagValue(name, "");
      this.RefreshList();
    }

    public void SetTagValue(string processName, string tag)
    {
      ProcessItem processItem = this.programListData[processName];
      processItem.tag = tag;
      this.programListData[processName] = processItem;
      this.RefreshList();
    }

    public void AddValue(string processName)
    {
      this.programListData.Add(processName, new ProcessItem(processName));
    }

    public void MarkListDirty()
    {
      this.InitProgramList();
    }

    public void RefreshList()
    {
      this.programList.DataSource = (object) this.programListData.Values.ToList<ProcessItem>();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.groupBox1 = new GroupBox();
      this.groupBox2 = new GroupBox();
      this.globalVolumeShiftSpeed = new NumericUpDown();
      this.label1 = new Label();
      this.label2 = new Label();
      this.globalVolumeAllowance = new NumericUpDown();
      this.label3 = new Label();
      this.globalTargetVolume = new NumericUpDown();
      this.programList = new ComboBox();
      this.globalApplySettings = new Button();
      this.globalResetSettings = new Button();
      this.label4 = new Label();
      this.groupBox3 = new GroupBox();
      this.label5 = new Label();
      this.programTargetVolume = new NumericUpDown();
      this.label6 = new Label();
      this.programVolumeAllowance = new NumericUpDown();
      this.label7 = new Label();
      this.programVolumeShiftSpeed = new NumericUpDown();
      this.programResetSettings = new Button();
      this.programApplySettings = new Button();
      this.programCopyGlobal = new Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.globalVolumeShiftSpeed.BeginInit();
      this.globalVolumeAllowance.BeginInit();
      this.globalTargetVolume.BeginInit();
      this.groupBox3.SuspendLayout();
      this.programTargetVolume.BeginInit();
      this.programVolumeAllowance.BeginInit();
      this.programVolumeShiftSpeed.BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.globalResetSettings);
      this.groupBox1.Controls.Add((Control) this.globalApplySettings);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.globalTargetVolume);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.globalVolumeAllowance);
      this.groupBox1.Controls.Add((Control) this.label1);
      this.groupBox1.Controls.Add((Control) this.globalVolumeShiftSpeed);
      this.groupBox1.Location = new Point(12, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new Size(409, 136);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Global Settings";
      this.groupBox2.Controls.Add((Control) this.groupBox3);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.programList);
      this.groupBox2.Location = new Point(12, 154);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new Size(409, 181);
      this.groupBox2.TabIndex = 1;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Program Settings";
      this.globalVolumeShiftSpeed.DecimalPlaces = 2;
      this.globalVolumeShiftSpeed.Location = new Point(131, 51);
      this.globalVolumeShiftSpeed.Name = "globalVolumeShiftSpeed";
      this.globalVolumeShiftSpeed.Size = new Size(114, 20);
      this.globalVolumeShiftSpeed.TabIndex = 0;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(6, 53);
      this.label1.Name = "label1";
      this.label1.Size = new Size(92, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Audio Shift Speed";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(6, 79);
      this.label2.Name = "label2";
      this.label2.Size = new Size(94, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Volume Allowance";
      this.globalVolumeAllowance.DecimalPlaces = 2;
      this.globalVolumeAllowance.Location = new Point(131, 77);
      this.globalVolumeAllowance.Name = "globalVolumeAllowance";
      this.globalVolumeAllowance.Size = new Size(114, 20);
      this.globalVolumeAllowance.TabIndex = 2;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(6, 27);
      this.label3.Name = "label3";
      this.label3.Size = new Size(76, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Target Volume";
      this.globalTargetVolume.DecimalPlaces = 2;
      this.globalTargetVolume.Location = new Point(131, 25);
      this.globalTargetVolume.Name = "globalTargetVolume";
      this.globalTargetVolume.Size = new Size(114, 20);
      this.globalTargetVolume.TabIndex = 4;
      this.programList.FormattingEnabled = true;
      this.programList.Location = new Point(58, 24);
      this.programList.Name = "programList";
      this.programList.Size = new Size(342, 21);
      this.programList.TabIndex = 0;
      this.programList.SelectedIndexChanged += new EventHandler(this.programList_SelectedIndexChanged);
      this.globalApplySettings.Location = new Point(305, 103);
      this.globalApplySettings.Name = "globalApplySettings";
      this.globalApplySettings.Size = new Size(98, 26);
      this.globalApplySettings.TabIndex = 6;
      this.globalApplySettings.Text = "Apply";
      this.globalApplySettings.UseVisualStyleBackColor = true;
      this.globalApplySettings.Click += new EventHandler(this.globalApplySettings_Click);
      this.globalResetSettings.Location = new Point(201, 103);
      this.globalResetSettings.Name = "globalResetSettings";
      this.globalResetSettings.Size = new Size(98, 26);
      this.globalResetSettings.TabIndex = 7;
      this.globalResetSettings.Text = "Reset";
      this.globalResetSettings.UseVisualStyleBackColor = true;
      this.globalResetSettings.Click += new EventHandler(this.globalResetSettings_Click);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(6, 27);
      this.label4.Name = "label4";
      this.label4.Size = new Size(46, 13);
      this.label4.TabIndex = 1;
      this.label4.Text = "Program";
      this.groupBox3.Controls.Add((Control) this.programCopyGlobal);
      this.groupBox3.Controls.Add((Control) this.programResetSettings);
      this.groupBox3.Controls.Add((Control) this.programApplySettings);
      this.groupBox3.Controls.Add((Control) this.label5);
      this.groupBox3.Controls.Add((Control) this.programTargetVolume);
      this.groupBox3.Controls.Add((Control) this.label6);
      this.groupBox3.Controls.Add((Control) this.programVolumeAllowance);
      this.groupBox3.Controls.Add((Control) this.label7);
      this.groupBox3.Controls.Add((Control) this.programVolumeShiftSpeed);
      this.groupBox3.Location = new Point(0, 51);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(409, 131);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(6, 16);
      this.label5.Name = "label5";
      this.label5.Size = new Size(76, 13);
      this.label5.TabIndex = 11;
      this.label5.Text = "Target Volume";
      this.programTargetVolume.DecimalPlaces = 2;
      this.programTargetVolume.Location = new Point(131, 14);
      this.programTargetVolume.Name = "programTargetVolume";
      this.programTargetVolume.Size = new Size(114, 20);
      this.programTargetVolume.TabIndex = 10;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(6, 68);
      this.label6.Name = "label6";
      this.label6.Size = new Size(94, 13);
      this.label6.TabIndex = 9;
      this.label6.Text = "Volume Allowance";
      this.programVolumeAllowance.DecimalPlaces = 2;
      this.programVolumeAllowance.Location = new Point(131, 66);
      this.programVolumeAllowance.Name = "programVolumeAllowance";
      this.programVolumeAllowance.Size = new Size(114, 20);
      this.programVolumeAllowance.TabIndex = 8;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(6, 42);
      this.label7.Name = "label7";
      this.label7.Size = new Size(92, 13);
      this.label7.TabIndex = 7;
      this.label7.Text = "Audio Shift Speed";
      this.programVolumeShiftSpeed.DecimalPlaces = 2;
      this.programVolumeShiftSpeed.Location = new Point(131, 40);
      this.programVolumeShiftSpeed.Name = "programVolumeShiftSpeed";
      this.programVolumeShiftSpeed.Size = new Size(114, 20);
      this.programVolumeShiftSpeed.TabIndex = 6;
      this.programResetSettings.Location = new Point(198, 94);
      this.programResetSettings.Name = "programResetSettings";
      this.programResetSettings.Size = new Size(98, 26);
      this.programResetSettings.TabIndex = 13;
      this.programResetSettings.Text = "Reset";
      this.programResetSettings.UseVisualStyleBackColor = true;
      this.programResetSettings.Click += new EventHandler(this.programResetSettings_Click);
      this.programApplySettings.Location = new Point(302, 94);
      this.programApplySettings.Name = "programApplySettings";
      this.programApplySettings.Size = new Size(98, 26);
      this.programApplySettings.TabIndex = 12;
      this.programApplySettings.Text = "Apply";
      this.programApplySettings.UseVisualStyleBackColor = true;
      this.programApplySettings.Click += new EventHandler(this.programApplySettings_Click);
      this.programCopyGlobal.Location = new Point(94, 94);
      this.programCopyGlobal.Name = "programCopyGlobal";
      this.programCopyGlobal.Size = new Size(98, 26);
      this.programCopyGlobal.TabIndex = 14;
      this.programCopyGlobal.Text = "Reset To Global";
      this.programCopyGlobal.UseVisualStyleBackColor = true;
      this.programCopyGlobal.Click += new EventHandler(this.programCopyGlobal_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(433, 350);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.Name = nameof (Form1);
      this.Text = "Audio Equaliser";
      this.Load += new EventHandler(this.Form1_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.globalVolumeShiftSpeed.EndInit();
      this.globalVolumeAllowance.EndInit();
      this.globalTargetVolume.EndInit();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.programTargetVolume.EndInit();
      this.programVolumeAllowance.EndInit();
      this.programVolumeShiftSpeed.EndInit();
      this.ResumeLayout(false);
    }
  }
}
