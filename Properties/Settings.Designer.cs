// Decompiled with JetBrains decompiler
// Type: AudioEqualiser.Properties.Settings
// Assembly: AudioEqualiser, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5D7B6984-A4AE-4F09-AD43-7CBCA6FB0086
// Assembly location: D:\Programs\AudioEqualiser2\AudioEqualiser.exe

using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AudioEqualiser.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.7.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.defaultInstance;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("10")]
    public float GlobalVolumeTarget
    {
      get
      {
        return (float) this[nameof (GlobalVolumeTarget)];
      }
      set
      {
        this[nameof (GlobalVolumeTarget)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("0.5")]
    public float GlobalVolumeShiftSpeed
    {
      get
      {
        return (float) this[nameof (GlobalVolumeShiftSpeed)];
      }
      set
      {
        this[nameof (GlobalVolumeShiftSpeed)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("10")]
    public float GlobalVolumeAllowance
    {
      get
      {
        return (float) this[nameof (GlobalVolumeAllowance)];
      }
      set
      {
        this[nameof (GlobalVolumeAllowance)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    public StringCollection ProgramSettings
    {
      get
      {
        return (StringCollection) this[nameof (ProgramSettings)];
      }
      set
      {
        this[nameof (ProgramSettings)] = (object) value;
      }
    }
  }
}
