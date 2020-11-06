using MyWpf.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpf
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //定时把物理内存转换为虚拟内存
            Task.Run(new Action(() =>
            {
                FlushMemory.Flush();
                Thread.Sleep(15 * 60 * 1000);//15分钟处理一次
            }));
        }
    }
}
