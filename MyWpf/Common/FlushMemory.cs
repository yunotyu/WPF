﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Common
{
    public class FlushMemory
    {
        [DllImport("kernel32.dll")]

        public static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void Flush()
        {
            GC.Collect();

            GC.WaitForPendingFinalizers();

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }

        }
    }
}
