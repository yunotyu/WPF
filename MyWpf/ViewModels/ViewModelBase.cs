using MyWpf.Commands;
using MyWpf.Views;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;
using MyWpf.Validation;
using MyWpf.AttachProperty;
using System.IO;
using System.Drawing;
using MyWpf.EF.Models;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using LiveCharts;
using System.Windows.Media;
using LiveCharts.Configurations;
using System.Security.RightsManagement;

namespace MyWpf.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        //protected DelegateCommand moveCommand;

        ///// <summary>
        ///// 窗体移动
        ///// </summary>
        //public DelegateCommand MoveCommand
        //{
        //    get { return moveCommand; }
        //    set
        //    {
        //        moveCommand = value;
        //        this.RaisePropertyChanged("MoveCommand");
        //    }
        //}

        /// <summary>
        /// 屏幕的工作区的最大高度，防止窗体无边框透明化后，最大化占据工作栏
        /// </summary>
        public double WinMaxHeight { get; set; }

        /// <summary>
        /// 屏幕的工作区的最大宽度
        /// </summary>
        public double WinMaxWidth { get; set; }

        protected DelegateCommand closeCommand;

        public DelegateCommand CloseCommand
        {
            get { return closeCommand; }
            set
            {
                closeCommand = value;
                this.RaisePropertyChanged("CloseCommand");
            }
        }

        protected DelegateCommand firstCommand;

        /// <summary>
        /// 第一页
        /// </summary>
        public DelegateCommand FirstCommand
        {
            get { return firstCommand; }
            set
            {
                firstCommand = value;
                this.RaisePropertyChanged("FirstCommand");
            }
        }

        protected DelegateCommand lastCommand;
        /// <summary>
        /// 最后一页
        /// </summary>
        public DelegateCommand LastCommand
        {
            get { return lastCommand; }
            set
            {
                lastCommand = value;
                this.RaisePropertyChanged("LastCommand");
            }
        }

        protected DelegateCommand nextCommand;
        /// <summary>
        /// 下一页
        /// </summary>
        public DelegateCommand NextCommand
        {
            get { return nextCommand; }
            set
            {
                nextCommand = value;
                this.RaisePropertyChanged("NextCommand");
            }
        }

        protected DelegateCommand prevCommand;
        /// <summary>
        /// 上一页
        /// </summary>
        public DelegateCommand PrevCommand
        {
            get { return prevCommand; }
            set
            {
                prevCommand = value;
                this.RaisePropertyChanged("PrevCommand");
            }
        }

        protected DelegateCommand gotoCommand;
        /// <summary>
        /// 跳转到第几页
        /// </summary>
        public DelegateCommand GotoCommand
        {
            get { return gotoCommand; }
            set
            {
                gotoCommand = value;
                this.RaisePropertyChanged("GotoCommand");
            }
        }

        protected DelegateCommand dataGirdDouClickCommand;
        /// <summary>
        /// datagrid双击选中行
        /// </summary>
        public DelegateCommand DataGirdDouClickCommand
        {
            get { return dataGirdDouClickCommand; }
            set
            {
                dataGirdDouClickCommand = value;
                this.RaisePropertyChanged("DataGirdDouClickCommand");
            }
        }

        protected DelegateCommand uploadHeaderCommand;
        /// <summary>
        /// 上传头像
        /// </summary>
        public DelegateCommand UploadHeaderCommand
        {
            get { return uploadHeaderCommand; }
            set
            {
                uploadHeaderCommand = value;
                this.RaisePropertyChanged("UploadHeader");
            }
        }

        protected User editUserData;

        /// <summary>
        /// 显示到编辑用户界面的数据
        /// </summary>
        public User EditUserData
        {
            get { return editUserData; }
            set
            {
                editUserData = value;
                this.RaisePropertyChanged("EditUserData");
            }
        }

        protected User addUserData;

        public User AddUserData
        {
            get { return addUserData; }
            set
            {
                addUserData = value;
                this.RaisePropertyChanged("AddUserData");
            }
        }

        protected DelegateCommand deleteCommand;

        public DelegateCommand DeleteCommand
        {
            get { return deleteCommand; }
            set
            {
                deleteCommand = value;
                this.RaisePropertyChanged("DeleteCommand");
            }
        }

        protected DelegateCommand searchCommand;

        public DelegateCommand SearchCommand
        {
            get { return searchCommand; }
            set
            {
                searchCommand = value;
                this.RaisePropertyChanged("SearchCommand");
            }
        }


        public CartesianMapper<Store> Config { get; set; }

        public ViewModelBase()
        {
            //moveCommand = new DelegateCommand();
            closeCommand = new DelegateCommand();
            firstCommand = new DelegateCommand();
            lastCommand = new DelegateCommand();
            nextCommand = new DelegateCommand();
            prevCommand = new DelegateCommand();
            gotoCommand = new DelegateCommand();
            dataGirdDouClickCommand = new DelegateCommand();
            uploadHeaderCommand = new DelegateCommand();
            deleteCommand = new DelegateCommand();
            searchCommand = new DelegateCommand();

            //上传头像
            uploadHeaderCommand = new DelegateCommand();
            uploadHeaderCommand.ExcuteAction = new Action<object>(o =>
            {
                UploadHeaderPic(o as Window);
            });

            WinMaxHeight = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            WinMaxWidth = System.Windows.Forms.SystemInformation.WorkingArea.Width;
        }

        //将鼠标点击移动事件放到这里
        public void MoveWindow(Object obj, MouseButtonEventArgs e)
        {
            //注意，要判断是否是左键，因为只有左键能触发下面的移动
            //按下其他键无法触发，会报错
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (obj as Window).DragMove();
            }
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        public void ShowTip(string msg, Window parent=null)
        {
            Tip tip = new Tip();
            if (msg.Length > 4)
            {
                tip.Msg.FontSize = 12;
            }
            tip.Msg.Text = msg;
            tip.Owner = parent;
            if (parent != null)
            {
                tip.Owner = parent;
               
            }
            tip.ShowDialog();
        }

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="window"></param>
        private void UploadHeaderPic(Window window)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png|*.png|jpg|*.jpg|bmp|*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo info = new FileInfo(openFileDialog.FileName);
                var fileExtension = info.Extension;
                if (!info.Exists)
                {
                    ShowTip("文件不存在", window);
                    return;
                }
                if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".bmp")
                {
                    using (FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        //判断照片的大小
                        if (info.Length > 1048576)
                        {
                            ShowTip("图片大于1M", window);
                            return;
                        }
                        Bitmap bitmap = new Bitmap(fileStream);
                        var newFileName = (info.Name.Split('.'))[0] + "_" + Guid.NewGuid().ToString() + fileExtension;
                        //var root = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).FullName).FullName;
                        bitmap.Save(@"HeaderPic/" + newFileName);
                        if (window is EditUser)
                        {
                            EditUserData.Icon = @"HeaderPic/" + newFileName;

                        }
                        else if (window is AddUser)
                        {
                            AddUserData.Icon = @"HeaderPic/" + newFileName;
                        }
                        else if(window is Home)
                        {
                            (window.DataContext as HomeViewModel).User.Icon= @"HeaderPic/" + newFileName;
                        }
                        
                        //EditUserData.ImaSource = new BitmapImage(new Uri(@"/Image/" + newFileName, UriKind.Relative));
                        ShowTip("上传成功", window);
                    }
                }
                else
                {
                    ShowTip("请选择正确的图像文件", window);
                    return;
                }
            }
        }


        /// <summary>
        /// 初始化坐标轴
        /// </summary>
        private void InitChartAxi(CartesianChart chart,string Xname,string yName)
        {
            Config  = Mappers.Xy<Store>()
                             .X(s => Convert.ToInt32(s.Time.AddHours(8).Subtract(DateTime.Parse("1970-1-1")).TotalSeconds))
                             .Y(s=>s.Count);

            //初始化图表的x轴
            Axis x = new Axis();
            x.Separator.StrokeThickness = 1;
            x.Separator.Stroke = System.Windows.Media.Brushes.Black;
            x.Separator.Step = TimeSpan.FromDays(31).TotalSeconds;
            x.Title = Xname;
            x.ShowLabels = true;
            x.LabelFormatter = (d => DateTime.Parse("1970-01-01 00:00:00").AddSeconds(d - 8 * 60 * 60).ToLongDateString());
            //System.Windows.Data.Binding xBinding = new System.Windows.Data.Binding();
            //xBinding.Source = this;//绑定数据源
            //xBinding.Path = new PropertyPath("XLabels");//绑定的数据源的属性名
            //xBinding.Mode = System.Windows.Data.BindingMode.TwoWay;
            //xBinding.UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
            ////将控件属性和数据源属性绑定到一起
            //x.SetBinding(Axis.LabelsProperty, xBinding);
            chart.AxisX.Add(x);

            //初始化图表y轴
            Axis y = new Axis();
            y.Separator.StrokeThickness = 1;
            y.Separator.Stroke = System.Windows.Media.Brushes.Black;
            y.Title = yName;
            y.ShowLabels = true;
            //System.Windows.Data.Binding yBinding = new System.Windows.Data.Binding();
            //yBinding.Source = this;
            //yBinding.Path = new PropertyPath("YLabels");
            //yBinding.Mode = System.Windows.Data.BindingMode.TwoWay;
            //yBinding.UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged;
            //y.SetBinding(Axis.LabelsProperty, yBinding);
            chart.AxisY.Add(y);
            
        }

        /// <summary>
        /// 绘制曲线
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="points"></param>
        private void PaintLine(CartesianChart chart,SeriesCollection series, ChartValues<Store> points,string lineName)
        {
            System.Windows.Data.Binding binding = new System.Windows.Data.Binding();
            binding.Source = this;
            binding.Mode = System.Windows.Data.BindingMode.TwoWay;
            binding.Path = new PropertyPath("Series");
            chart.SetBinding(CartesianChart.SeriesProperty, binding);

            var line = new LineSeries(Config)
            {
                Title = lineName,
                StrokeThickness = 2,
                Values = points,
                LineSmoothness = 1,
                //Fill = System.Windows.Media.Brushes.Transparent,
                //LabelPoint = new Func<ChartPoint, string>((c) =>
                //  {
                //      return $"时间:{c.X},进货量:{c.Y}";
                //  }),
                DataLabels = true,
                LabelPoint = p => p.Y.ToString(),

            };
            series.Add(line);
        }

        /// <summary>
        /// 绘制图表
        /// </summary>
        public virtual void InitChart(CartesianChart chart,SeriesCollection series, string Xname, string yName, ChartValues<Store> points, string lineName)
        {
            InitChartAxi(chart, Xname, yName);
            PaintLine(chart, series, points, lineName);
        }

        /// <summary>
        /// 递归获取元素的最顶级父元素
        /// </summary>
        /// <returns></returns>
        public UIElement GetEleTopParent(FrameworkElement element)
        {
            while (element.Parent != null)
            {
                element = element.Parent as FrameworkElement;
            }
            return element;
        }

        ///// <summary>
        ///// 将配置起始位置写入
        ///// </summary>
        //public void WriteBaseConfig()
        //{
        //    FileInfo info = new FileInfo(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "config/configs.txt");
        //    if (!info.Exists)
        //    {
        //        info.Create();
        //        using (FileStream stream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "config/configs.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //        {
        //            using (StreamWriter writer=new StreamWriter(stream))
        //            {
        //                writer.WriteLine("keys:");
        //                writer.WriteLine("Theme:");
        //                writer.Flush();
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 将配置写到文件里
        ///// </summary>
        //public void WriteUserConfig(string config)
        //{
        //    using (FileStream stream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "config/configs.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
        //    {
        //        using(StreamWriter writer=new StreamWriter(stream))
        //        {
        //            //将写的位置放到文本的最后
        //            writer.BaseStream.Seek(0, SeekOrigin.Begin);
        //            writer.WriteLine(config);
        //            writer.Flush();
        //        }
        //    }
        //}

        //public List<string> ReadUserConfig(string path)
        //{

        //    return strs;
        //}
    }
}
