using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MyWpf.Converters
{
    public class ImageToStringConverter : IValueConverter
    {
        /// <summary>
        /// 将绑定的属性值转换为前台需要的对象
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is string)
            {
                var info = new FileInfo(value as string);
                using (FileStream stream = new FileStream(info.FullName, FileMode.Open))
                {   
                    byte[] bytes = new byte[info.Length + 64];
                    stream.Read(bytes, 0, System.Convert.ToInt32(info.Length));
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new MemoryStream(bytes);
                    bitmapImage.EndInit();
                    return bitmapImage;
                }
            }
            return Binding.DoNothing;
        }

        /// <summary>
        /// 将前台对象转换为绑定的属性值类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is BitmapImage)
            {
                var uri = (value as BitmapImage).UriSource;
                return uri.OriginalString;
            }
            return Binding.DoNothing;
        }
    }
}
