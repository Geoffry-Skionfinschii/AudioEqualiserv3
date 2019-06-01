// Decompiled with JetBrains decompiler
// Type: AudioEqualiser.AudioSessionInformation
// Assembly: AudioEqualiser, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5D7B6984-A4AE-4F09-AD43-7CBCA6FB0086
// Assembly location: D:\Programs\AudioEqualiser2\AudioEqualiser.exe

using CSCore.CoreAudioAPI;

namespace AudioEqualiser
{
    public struct AudioSessionInformation
    {
        public int process;
        public AudioSessionControl2 session;
        public SimpleAudioVolume volumeObject;
        public AudioMeterInformation audioMeter;
        public string processName;

        public AudioSessionInformation(AudioSessionControl2 session)
        {
            this.session = session;
            this.process = session.ProcessID;
            this.volumeObject = session.QueryInterface<SimpleAudioVolume>();
            this.audioMeter = session.QueryInterface<AudioMeterInformation>();
            this.processName = session.Process.ProcessName;
        }

        public void Dispose()
        {
            this.session.Dispose();
            this.volumeObject.Dispose();
            this.audioMeter.Dispose();
        }
    }
}
