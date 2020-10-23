using MyWpf.Common;
using MyWpf.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyWpf.Views
{
    /// <summary>
    /// EditUser.xaml 的交互逻辑
    /// </summary>
    public partial class EditUser : WindowBase
    {
        public EditUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(((this.DataContext) as UsersViewModel).EditUserData.Name);
            ((this.DataContext) as UsersViewModel).EditUserData.Icon = @"HeaderPic/warning_20a75982-4ad4-4a8e-ac09-593becb130ca.png";
            var s = new FileInfo(@"HeaderPic/warning_20a75982-4ad4-4a8e-ac09-593becb130ca.png");
            var d = s.FullName;
            using (FileStream stream = new FileStream(s.FullName, FileMode.Open))
            {
                byte[] bytes = new byte[s.Length + 64];
                stream.Read(bytes, 0, Convert.ToInt32(s.Length));
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(bytes);
                bitmapImage.EndInit();
                imas.Source = bitmapImage;
            }

            //((this.DataContext) as UsersViewModel).EditUserData.Icon =
            //    Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName
            //    +"\\Image\\11_2d1a8fc6-f1e3-40c6-8f68-7d6160a2db7c.png";
            //imas.Source = new BitmapImage(new Uri(((this.DataContext) as UsersViewModel).EditUserData.Icon, UriKind.Absolute));

            var a = this.imas.Source;
        }
    }
}
