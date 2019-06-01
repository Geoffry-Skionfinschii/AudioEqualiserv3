// Decompiled with JetBrains decompiler
// Type: AudioEqualiser.ProgramSettings
// Assembly: AudioEqualiser, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5D7B6984-A4AE-4F09-AD43-7CBCA6FB0086
// Assembly location: D:\Programs\AudioEqualiser2\AudioEqualiser.exe

namespace AudioEqualiser
{
  public struct ProgramSettings
  {
    public float shift;
    public float allowance;
    public float target;

    public ProgramSettings(string str)
    {
      string[] strArray = str.Split(',');
      this.shift = float.Parse(strArray[0]);
      this.allowance = float.Parse(strArray[1]);
      this.target = float.Parse(strArray[2]);
    }

    public ProgramSettings(float shift, float allowance, float target)
    {
      this.shift = shift;
      this.allowance = allowance;
      this.target = target;
    }
  }
}
