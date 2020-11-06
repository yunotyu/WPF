using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using MyWpf.Commands;
using MyWpf.Common;
using MyWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyWpf
{
    public class SkinViewModel : ViewModelBase
    {
        ~SkinViewModel()
        {
            //System.Windows.Forms.MessageBox.Show("SkinViewModel被析构");
        }

        public DelegateCommand InitCommand { get; set; }

        public SkinViewModel()
        {
            //for (byte r = 0; r < 255; r += 50)
            //{
            //    for (byte g = 0; g < 255; g += 50)
            //    {
            //        Colors.Add(new ThemeColor { SkinColor = new SolidColorBrush(Color.FromRgb(r, g, )) });
            //        //for (byte b = 0; b < 255; b += 50)
            //        //{

            //        //}
            //    }
            //}
            Colors.Add(new ThemeColor { SkinColor = new SolidColorBrush(Color.FromRgb(0x33, 0x99, 0xff)) });
            for (int i = 0; i < 40; i++)
            {
                //byte r = (byte)new Random().Next(0+10, 255-10);
                //byte b = (byte)new Random().Next(0+15, 255-15);
                //byte g = (byte)new Random().Next(0+20, 255-20);
                byte r =(byte) (i*5 + 30);
                byte b =(byte) (i*2 + 10);
                byte g =(byte) (i*3 + 20);
                Colors.Add(new ThemeColor { SkinColor = new SolidColorBrush(Color.FromRgb(r, b, g)) });

            }

            for (int i = 0; i < 40; i++)
            {
                byte r = (byte)(i * 2 + 10);
                byte b = (byte)(i * 5 + 30);
                byte g = (byte)(i * 3 + 20);
                Colors.Add(new ThemeColor { SkinColor = new SolidColorBrush(Color.FromRgb(r, b, g)) });

            }

            for (int i = 0; i < 40; i++)
            {
                byte r = (byte)(i * 2 + 10);
                byte b = (byte)(i * 2 + 10);
                byte g = (byte)(i * 5 + 30);
                Colors.Add(new ThemeColor { SkinColor = new SolidColorBrush(Color.FromRgb(r, b, g)) });

            }

            //初始化颜色块
            InitCommand = new DelegateCommand();
            InitCommand.ExcuteAction = new Action<object>(o =>
              {
                  var panel = o as WrapPanel;
                  if (panel != null)
                  {
                      panel.Children.Clear();
                      foreach (var color in Colors)
                      {
                          Button but = new Button();
                          but.Width = 50;
                          but.Height = 50;
                          but.Background = color.SkinColor;
                          but.Margin = new Thickness(0, 20, 10, 0);
                          but.Click += But_Click;//将值赋给全局
                          panel.Children.Add(but);
                      }
                  }
              });
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            ThemeConfig.SkinColor = but.Background;

            //获取当前用户的配置
            var config= JsonHelper.ReadJsonFileToStr<Configs>("./config/configs.json");
            var brush = ThemeConfig.SkinColor as SolidColorBrush;
            var userConfig = config.UserConfig.Where(u => u.UserName == AppCache.CurUser.Name).FirstOrDefault();
            var oldConfig = userConfig;

            //将当前主题颜色保存到当前用户的配置里
            userConfig.R = brush.Color.R.ToString(); 
            userConfig.G = brush.Color.G.ToString();
            userConfig.B = brush.Color.B.ToString();

            //移除原来的用户配置，再插入新的配置
            config.UserConfig.Remove(oldConfig);
            config.UserConfig.Insert(0, userConfig);
            JsonHelper.SaveToJson<Configs>("./config/configs.json", config);
        }

    }
}
