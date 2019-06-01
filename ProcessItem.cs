// Decompiled with JetBrains decompiler
// Type: AudioEqualiser.ProcessItem
// Assembly: AudioEqualiser, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5D7B6984-A4AE-4F09-AD43-7CBCA6FB0086
// Assembly location: D:\Programs\AudioEqualiser2\AudioEqualiser.exe

namespace AudioEqualiser
{
  public struct ProcessItem
  {
    public string tag;
    public string name;

    public ProcessItem(string name)
    {
      this.name = name;
      this.tag = "";
    }

    public ProcessItem(string name, string tag)
    {
      this.name = name;
      this.tag = tag;
    }

    public override string ToString()
    {
      return this.name + this.tag;
    }
  }
}
