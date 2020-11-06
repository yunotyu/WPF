using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Brush = System.Windows.Media.Brush;
using Color = System.Windows.Media.Color;

namespace MyWpf.Common
{
    public class ThemeConfig : INotifyPropertyChanged
    {
        private static Brush skinColor;

        public event PropertyChangedEventHandler PropertyChanged;

        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;//静态事件处理属性更改

        /// <summary>
        /// 记录主题颜色
        /// </summary>
        public static Brush SkinColor
        {
            get { return skinColor; }
            set
            {
                skinColor = value;
                //如果不为空，调用属性改变方法
                StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(nameof(SkinColor)));
            }
        }

        public ThemeConfig()
        {
            SkinColor = new SolidColorBrush(Color.FromRgb(0x33, 0x99, 0xff));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}   
