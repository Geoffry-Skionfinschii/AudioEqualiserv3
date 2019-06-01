// Decompiled with JetBrains decompiler
// Type: AudioEqualiser.Program
// Assembly: AudioEqualiser, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5D7B6984-A4AE-4F09-AD43-7CBCA6FB0086
// Assembly location: D:\Programs\AudioEqualiser2\AudioEqualiser.exe

using AudioEqualiser.Properties;
using CSCore.CoreAudioAPI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows.Forms;

namespace AudioEqualiser
{
    internal static class Program
    {
        public static Dictionary<int, AudioSessionInformation> audioSessions = new Dictionary<int, AudioSessionInformation>();
        private static Dictionary<int, float> audioLastVol = new Dictionary<int, float>();
        public static Dictionary<string, ProgramSettings> programSettingData = new Dictionary<string, ProgramSettings>();
        public static float globalMaxShift = 0.005f;
        public static float globalAllowance = 0.2f;
        public static float globalVolumeTarget = 0.05f;
        public static Form1 mainForm;
        private static Thread loopThread;

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Program.LoadGlobalSettings();
            Program.LoadProgramSettings();
            Program.UpdateLoop();
            Application.Run((ApplicationContext)new AudioApplicationContext());
        }

        public static void LoadGlobalSettings()
        {
            Program.globalVolumeTarget = Settings.Default.GlobalVolumeTarget;
            Program.globalMaxShift = Settings.Default.GlobalVolumeShiftSpeed;
            Program.globalAllowance = Settings.Default.GlobalVolumeAllowance;
        }

        public static void LoadProgramSettings()
        {
            Program.programSettingData.Clear();
            StringCollection programSettings = Settings.Default.ProgramSettings;
            if (programSettings == null)
                return;
            foreach (string str in programSettings)
            {
                string[] strArray = str.Split('?');
                Program.programSettingData.Add(strArray[0], new ProgramSettings(strArray[1]));
            }
        }

        internal static void SaveProgramSettingData()
        {
            StringCollection stringCollection = new StringCollection();
            foreach (KeyValuePair<string, ProgramSettings> keyValuePair in Program.programSettingData)
            {
                string key = keyValuePair.Key;
                ProgramSettings programSettings = keyValuePair.Value;
                stringCollection.Add(key + "?" + (object)programSettings.shift + "," + (object)programSettings.allowance + "," + (object)programSettings.target);
            }
            Settings.Default.ProgramSettings = stringCollection;
            Settings.Default.Save();
            Program.LoadProgramSettings();
        }

        public static string GetMainModuleFilepath(int processId)
        {
            using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT ProcessId, Name FROM Win32_Process WHERE ProcessId = " + (object)processId))
            {
                using (ManagementObjectCollection source = managementObjectSearcher.Get())
                {
                    ManagementObject managementObject = source.Cast<ManagementObject>().FirstOrDefault<ManagementObject>();
                    if (managementObject != null)
                        return (string)managementObject["Name"];
                }
            }
            return (string)null;
        }

        private static void UpdateLoop()
        {
            Program.loopThread = new Thread((ThreadStart)(() =>
           {
               long num1 = 0;
               while (true)
               {
                   long num2 = DateTime.Now.Ticks / 10000L;
                   if (num1 < num2)
                   {
                       Program.FindAudioSources();
                       num1 = num2 + 1000L;
                   }
                   Program.UpdateAudioSources();
                   Thread.Sleep(1);
               }
           }));
            Program.loopThread.IsBackground = true;
            Program.loopThread.Start();
        }

        private static void FormListDirty()
        {
            if (Program.mainForm == null || !Program.mainForm.Visible)
                return;
            Program.mainForm.MarkListDirty();
        }

        private static void UpdateAudioSources()
        {
            foreach (KeyValuePair<int, AudioSessionInformation> audioSession in Program.audioSessions)
            {
                AudioSessionInformation sessionInformation = audioSession.Value;
                float num1 = Program.globalVolumeTarget / 100f;
                float num2 = Program.globalAllowance / 100f;
                float num3 = Program.globalMaxShift / 100f;
                string processName = sessionInformation.processName;
                if (Program.programSettingData.ContainsKey(processName))
                {
                    ProgramSettings programSettings = Program.programSettingData[processName];
                    num1 = programSettings.target / 100f;
                    num2 = programSettings.allowance / 100f;
                    num3 = programSettings.shift / 100f;
                }
                if (sessionInformation.audioMeter.BasePtr == IntPtr.Zero)
                {
                    Program.audioSessions.Remove(sessionInformation.process);
                    sessionInformation.Dispose();
                    Program.FormListDirty();
                }
                else
                {
                    float val2_1 = num1 / sessionInformation.audioMeter.GetPeakValue();
                    double masterVolume = (double)sessionInformation.volumeObject.MasterVolume;
                    double peakValue = (double)sessionInformation.audioMeter.PeakValue;
                    float num4 = Program.audioLastVol[sessionInformation.process];
                    if ((double)sessionInformation.audioMeter.PeakValue >= (double)num1 * (double)sessionInformation.volumeObject.MasterVolume && (double)Math.Abs(val2_1 - num4) > (double)num2)
                    {
                        float val2_2 = Math.Min(num4 + num3, Math.Max(num4 - num3, val2_1));
                        Program.audioLastVol[sessionInformation.process] = val2_2;
                        sessionInformation.volumeObject.MasterVolume = Math.Min(1f, Math.Max(0.0f, val2_2));
                    }
                }
            }
        }

        private static void FindAudioSources()
        {
            using (AudioSessionManager2 audioSessionManager2 = Program.GetDefaultAudioSessionManager2(DataFlow.Render))
            {
                using (AudioSessionEnumerator sessionEnumerator = audioSessionManager2.GetSessionEnumerator())
                {
                    foreach (AudioSessionControl audioSessionControl in sessionEnumerator)
                    {
                        AudioSessionControl2 session = audioSessionControl.QueryInterface<AudioSessionControl2>();
                        if (!Program.audioSessions.ContainsKey(session.ProcessID))
                        {
                            AudioSessionInformation sessionInformation1 = new AudioSessionInformation(session);
                            Program.audioSessions.Add(session.ProcessID, sessionInformation1);
                            Program.audioLastVol.Add(session.ProcessID, sessionInformation1.volumeObject.MasterVolume * sessionInformation1.audioMeter.PeakValue);
                            Program.FormListDirty();
                            sessionInformation1.session.Process.Exited += (EventHandler)((sender, e) =>
                           {
                               Process process = sender as Process;
                               AudioSessionInformation sessionInformation;
                               Program.audioSessions.TryGetValue(process.Id, out sessionInformation);
                               sessionInformation.Dispose();
                               Program.audioSessions.Remove(process.Id);
                               Program.audioLastVol.Remove(process.Id);
                               Program.FormListDirty();
                           });
                        }
                        else
                            session.Dispose();
                        audioSessionControl.Dispose();
                    }
                    sessionEnumerator.Dispose();
                }
                audioSessionManager2.Dispose();
            }
        }

        private static AudioSessionManager2 GetDefaultAudioSessionManager2(
          DataFlow dataFlow)
        {
            using (MMDeviceEnumerator deviceEnumerator = new MMDeviceEnumerator())
            {
                using (MMDevice defaultAudioEndpoint = deviceEnumerator.GetDefaultAudioEndpoint(dataFlow, Role.Multimedia))
                {
                    AudioSessionManager2 audioSessionManager2 = AudioSessionManager2.FromMMDevice(defaultAudioEndpoint);
                    deviceEnumerator.Dispose();
                    defaultAudioEndpoint.Dispose();
                    return audioSessionManager2;
                }
            }
        }
    }
}
