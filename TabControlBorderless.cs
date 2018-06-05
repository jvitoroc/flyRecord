﻿using System;
using System.Windows.Forms;

namespace flyrecord { 

    public class TabControlBorderless : TabControl
    {
        public TabControlBorderless()
        {
            if (!this.DesignMode) this.Multiline = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !this.DesignMode)
                m.Result = new IntPtr(1);
            else
                base.WndProc(ref m);
        }
    }
}