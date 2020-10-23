using MyWpf.EF.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Common
{
    public class PageHelper<T>:BindableBase where T:class
    {
        private ObservableCollection<T> items;

        /// <summary>
        /// 分页数据
        /// </summary>
        public ObservableCollection<T> Items
        {
            get { return items; }
            set
            {
                items = value;
                this.RaisePropertyChanged("Items");
            }
        }



        private int curPage;

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurPage
        {
            get { return curPage; }
            set
            {
                curPage = value;
                this.RaisePropertyChanged("CurPage");
            }
        }

        private int allPageCount;

        /// <summary>
        /// 总页数
        /// </summary>
        public int AllPageCount
        {
            get { return allPageCount; }
            set
            {
                allPageCount = value;
                this.RaisePropertyChanged("AllPageCount");
            }
        }

        private int allItemCount;

        /// <summary>
        /// 总记录数
        /// </summary>
        public int AllItemCount
        {
            get { return allItemCount; }
            set
            {
                allItemCount = value;
                this.RaisePropertyChanged("AllItemCount");
            }
        }

        private int perPageItem;
        /// <summary>
        /// 每页的显示记录数
        /// </summary>
        public int PerPageItem
        {
            get { return perPageItem; }
            set
            {
                perPageItem = value;
                this.RaisePropertyChanged("PerPageItem");
            }
        }

        public PageHelper()
        {
            items = new ObservableCollection<T>();
            perPageItem = 5;
            curPage = 1;
        }

        /// <summary>
        /// 获取总页数
        /// </summary>
        public void  GetAllPageCount()
        {
            var res = this.allItemCount % perPageItem;
            if (res== 0)
            {
                AllPageCount = this.allItemCount / perPageItem;
            }
            else
            {
                AllPageCount = this.allItemCount / perPageItem + 1;
            }
        }

        public List<User> GetPage(List<User> models)
        {
            //if (typeof(T) == typeof(User))
            //{
                
            //}
           return models.OrderBy(u => u.Id).Skip((curPage - 1) * perPageItem).Take(perPageItem).ToList();
        }
    }
}
