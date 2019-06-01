// Decompiled with JetBrains decompiler
// Type: AudioEqualiser.FormUtils
// Assembly: AudioEqualiser, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5D7B6984-A4AE-4F09-AD43-7CBCA6FB0086
// Assembly location: D:\Programs\AudioEqualiser2\AudioEqualiser.exe

using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace AudioEqualiser
{
    public static class FormUtils
    {
        private static Icon _defaultFormIcon;

        public static Icon DefaultFormIcon
        {
            get
            {
                if (FormUtils._defaultFormIcon == null)
                    FormUtils._defaultFormIcon = (Icon)typeof(Form).GetProperty("DefaultIcon", BindingFlags.Static | BindingFlags.NonPublic).GetValue((object)null, (object[])null);
                return FormUtils._defaultFormIcon;
            }
        }
    }
}
