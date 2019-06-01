using AudioEqualiser.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioEqualiser
{
    public partial class MainForm : Form
    {
        public Dictionary<string, ProcessItem> programListData;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.InitProgramList();
        }

        private void InitProgramList()
        {
            this.programListData = (Dictionary<string, ProcessItem>)null;
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
                if (!this.programListData.Any((val => val.Value.name == pgmDat.Key)))
                    this.programListData[pgmDat.Key] = new ProcessItem(pgmDat.Key, "*");
            }
            this.RefreshList();
            this.LoadGlobalSettingState();
        }

        private void LoadGlobalSettingState()
        {
            this.globalTargetVolume.Value = (Decimal)Program.globalVolumeTarget;
            this.globalVolumeShiftSpeed.Value = (Decimal)Program.globalMaxShift;
            this.globalVolumeAllowance.Value = (Decimal)Program.globalAllowance;
        }

        private void globalApplySettings_Click(object sender, EventArgs e)
        {
            Settings.Default.GlobalVolumeTarget = (float)this.globalTargetVolume.Value;
            Settings.Default.GlobalVolumeAllowance = (float)this.globalVolumeAllowance.Value;
            Settings.Default.GlobalVolumeShiftSpeed = (float)this.globalVolumeShiftSpeed.Value;
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
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
                return;
            this.LoadProgramSettingState(((ProcessItem)comboBox.SelectedItem).name);
        }

        private void LoadProgramSettingState(string programName)
        {
            if (Program.programSettingData.ContainsKey(programName))
            {
                ProgramSettings programSettings = Program.programSettingData[programName];
                this.programTargetVolume.Value = (Decimal)programSettings.target;
                this.programVolumeShiftSpeed.Value = (Decimal)programSettings.shift;
                this.programVolumeAllowance.Value = (Decimal)programSettings.allowance;
            }
            else
            {
                this.programTargetVolume.Value = (Decimal)Program.globalVolumeTarget;
                this.programVolumeShiftSpeed.Value = (Decimal)Program.globalMaxShift;
                this.programVolumeAllowance.Value = (Decimal)Program.globalAllowance;
            }
        }

        private void programApplySettings_Click(object sender, EventArgs e)
        {
            string name = ((ProcessItem)this.programList.SelectedItem).name;
            Program.programSettingData[name] = new ProgramSettings((float)this.programVolumeShiftSpeed.Value, (float)this.programVolumeAllowance.Value, (float)this.programTargetVolume.Value, this.programIgnore.Checked);
            this.SetTagValue(name, "*");
            Program.SaveProgramSettingData();
        }

        private void programResetSettings_Click(object sender, EventArgs e)
        {
            this.LoadProgramSettingState(((ProcessItem)this.programList.SelectedItem).name);
        }

        private void programCopyGlobal_Click(object sender, EventArgs e)
        {
            string name = ((ProcessItem)this.programList.SelectedItem).name;
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
            this.programList.DataSource = (object)this.programListData.Values.ToList<ProcessItem>();
        }
    }
}
