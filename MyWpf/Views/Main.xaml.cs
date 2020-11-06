using MyWpf.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyWpf.Views
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
            //var vm = new HomeViewModel();
            //vm.StoreService.Query().ForEach(s =>
            //{
            //    vm.XLabels.Add(s.Time.ToLongDateString());
            //    vm.Points.Add(s.Count.ToString());

            //});
            //vm.InitChart(this.chart, vm.XLabels, vm.YLabels, "时间", "进货数", vm.Points, "进料");
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new TextBox().KeyDown += Main_KeyDown;
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
       
    }
}
