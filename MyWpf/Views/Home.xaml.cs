﻿using MaterialDesignThemes.Wpf;
using MyWpf.EF;
using MyWpf.Service;
using MyWpf.ViewModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyWpf
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Window
    {
     
        public Home()
        {
            InitializeComponent();
        
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //v.MaxNormalKind = PackIconKind.WindowRestore;
            //t.Kind = "WindowRestore";
            //MessageBox.Show(maxNormal.Kind.ToString());
        }
    }

    
}
