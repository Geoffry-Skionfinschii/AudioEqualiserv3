// Decompiled with JetBrains decompiler
// Type: AudioEqualiser.AudioApplicationContext
// Assembly: AudioEqualiser, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5D7B6984-A4AE-4F09-AD43-7CBCA6FB0086
// Assembly location: D:\Programs\AudioEqualiser2\AudioEqualiser.exe

using System;
using System.Windows.Forms;

namespace AudioEqualiser
{
  internal class AudioApplicationContext : ApplicationContext
  {
    private NotifyIcon trayIcon;

    public AudioApplicationContext()
    {
      this.trayIcon = new NotifyIcon()
      {
        Icon = FormUtils.DefaultFormIcon,
        ContextMenu = new ContextMenu(new MenuItem[2]
        {
          new MenuItem("Open...", new EventHandler(this.Open)),
          new MenuItem("Exit", new EventHandler(this.Exit))
        }),
        Visible = true
      };
    }

    private void Open(object sender, EventArgs e)
    {
      if (Program.mainForm != null && Program.mainForm.Visible)
        return;
      Program.mainForm = new Form1();
      Program.mainForm.Visible = true;
    }

    private void Exit(object sender, EventArgs e)
    {
      this.trayIcon.Visible = false;
      Application.Exit();
    }
  }
}
