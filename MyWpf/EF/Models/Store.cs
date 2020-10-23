using MyWpf.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.EF.Models
{
    public class Store : ValidationPropertyBase
    {
        private int id;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                this.RaisePropertyChanged("Id");
            }
        }

        private string productName;

        [Required(ErrorMessage ="{0}不能为空")]
        [StringLength(64,MinimumLength =1,ErrorMessage ="{0}在{2}到{1}个字符之间")]
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                this.RaisePropertyChanged("ProductName");
            }
        }


        private DateTime time;

        [Required(ErrorMessage ="{0}不能为空")]
        public DateTime Time
        {
            get { return time; }
            set
            {
                time = value;
                this.RaisePropertyChanged("Time");
            }
        }

        private int count;

        [Required(ErrorMessage ="{0}不能为空")]
        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                this.RaisePropertyChanged("Count");
            }
        }



    }
}
