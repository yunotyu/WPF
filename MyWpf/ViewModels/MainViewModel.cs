using LiveCharts;
using LiveCharts.Wpf;
using MyWpf.Commands;
using MyWpf.EF.Models;
using MyWpf.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public SeriesCollection Series { get; set; }
        public ChartValues<EF.Models.Store> Points { get; set; }
        public StoreService StoreService { get; set; }

        private DelegateCommand initChartCommand;

        public DelegateCommand InitChartCommand
        {
            get { return initChartCommand; }
            set
            {
                initChartCommand = value;
                this.RaisePropertyChanged("InitChartCommand");
            }
        }

        public MainViewModel()
        {
            StoreService = new StoreService();
            Points = new ChartValues<Store>();
            Series = new SeriesCollection();

            initChartCommand = new DelegateCommand();

            //初始化曲线图
            initChartCommand.ExcuteAction = new Action<object>(o =>
            {
                Points.Clear();
                Series.Clear();
                var c = o as CartesianChart;
                c.Series.Clear();
                c.AxisX.Clear();
                c.AxisY.Clear();
                var s = StoreService.Query();
                s.Sort(new Comparison<Store>((s1, s2) =>
                {
                    if (s1.Time < s2.Time)
                    {
                        return -1;
                    }
                    else if (s1.Time > s2.Time)
                    {
                        return 1;
                    }
                    return 0;

                }));
                s.ForEach(sto => Points.Add(sto));
                InitChart(c, Series, "时间", "进货数", Points, "进料");
            });
        }
    }
}
