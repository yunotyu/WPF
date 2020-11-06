using MyWpf.Commands;
using MyWpf.EF.Models;
using MyWpf.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Integration;

namespace MyWpf.ViewModels
{
    public class MainViewModel:ViewModelBase
    {

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

        public List<string> XPoints { get; set; }
        public List<int> YPoints { get; set; }
        public Series Series { get; set; }
        int InitCount;

        public MainViewModel()
        {
            InitCount = 0;
            StoreService = new StoreService();
            XPoints = new List<string>();
            YPoints = new List<int>();
            Series = new Series();

            initChartCommand = new DelegateCommand();

            //初始化曲线图
            initChartCommand.ExcuteAction = new Action<object>(o =>
            {
                //因为每次切换菜单都会重写加载，WindowsFormsHost，第二次不要重新初始化
                if (InitCount > 0)
                {
                    return;
                }
                WindowsFormsHost host = o as WindowsFormsHost;
                if (host.Child is Chart)
                {
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
                    s.ForEach(sto => {
                        XPoints.Add(sto.Time.ToLongDateString());
                        YPoints.Add(sto.Count);
                    });

                    ChartArea area = new ChartArea("area");
                    (host.Child as Chart).ChartAreas.Add(area);

                    Legend legend = new Legend("store");
                    legend.Docking = Docking.Right;
                    legend.IsTextAutoFit = true;
                    (host.Child as Chart).Legends.Add(legend);

                    Series.ChartArea = area.Name;
                    Series.ChartType = SeriesChartType.Line;
                    Series.XValueType = ChartValueType.String;
                    Series.YValueType = ChartValueType.Int32;
                    Series.Legend = legend.Name;
                    Series.LegendText = "仓库1进货";
                    Series.LegendToolTip = "仓库1";
                    Series.IsValueShownAsLabel = true;
                    Series.BorderWidth = 2;//设置线宽
                    Series.ToolTip = "进货曲线";//鼠标放到点上的提示
                    Series.Points.DataBindXY(XPoints, YPoints);

                    (host.Child as Chart).Series.Add(Series);
                    InitCount++;
                }
            });
        }

        ~MainViewModel()
        {
            //MessageBox.Show("MainViewModel销毁");
        }
    }
}
