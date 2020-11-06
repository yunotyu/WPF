using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.Integration;
using System.Windows.Media;
using Grid = System.Windows.Controls.Grid;

namespace MyWpf.Common
{
    public class Utils
    {
        /// <summary>
        /// 递归遍历逻辑树的所有Image元素，并清除source属性，释放资源
        /// 记得要把bitmapImage.CacheOption = BitmapCacheOption.OnLoad;不然还是无法释放图片资源
        /// </summary>
        /// <param name="uIElement"></param>
        public static void ClearImageSource(object uIElement)
        {
            if (!(uIElement is DependencyObject))
            {
                return;
            }
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(uIElement as DependencyObject); i++)
            {
                ////获取对应位置的父节点的子节点
                //var child = VisualTreeHelper.GetChild(uIElement as DependencyObject, i);
                //if((child as Image)!=null )
                //{
                //    (child as Image).Source = null;
                //}
                //if((child as CartesianChart) != null)
                //{
                //    var chart = child as CartesianChart;
                //    chart = null;
                //}
                ////获取这个子节点的子节点,递归
                //ClearImageSource(child);
            }
        }

        public static void  ClearChart(object uIElement)
        {
            if (!(uIElement is DependencyObject))
            {
                return;
            }
            foreach (var item in LogicalTreeHelper.GetChildren(uIElement as DependencyObject))
            {
                if (item is Grid)
                {
                    GetGridChild(item as Grid);
                }
            }
        }

        public static void GetGridChild(object item)
        {
            for (int i = 0; i < (item as Grid).Children.Count; i++)
            {
                if (!(item is DependencyObject))
                {
                    return;
                }
                //var item1 = VisualTreeHelper.GetChild(item as DependencyObject, i);
                var item1 = (item as Grid).Children[i];
                //获取chart控件，释放资源
                if (item1 is WindowsFormsHost)
                {
                    ((item1 as WindowsFormsHost).Child as Chart).Dispose();
                    (item1 as WindowsFormsHost).Dispose();

                }
                if (item1 is Grid || item1 is ContentControl && !(item1 is Card) && !(item1 is WindowsFormsHost))
                {
                    if (item1 is ContentControl)
                    {
                        GetGridChild(((item1 as ContentControl).Content) as DependencyObject);
                    }
                    else
                    {
                        GetGridChild(item1 as DependencyObject);

                    }
                }
            }
        }
    }
   
}

