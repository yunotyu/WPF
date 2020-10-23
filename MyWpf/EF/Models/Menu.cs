using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.EF.Models
{
    public partial class Menu:BindableBase
    {
        public Menu()
        {
            User_Menu= new HashSet<User_Menu>();
        }

        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                this.RaisePropertyChanged("Id");
            }
        }

        private string menuName;

        public string MenuName
        {
            get { return menuName; }
            set 
            {
                menuName = value;
                this.RaisePropertyChanged("MenuName");
            }
        }

        private bool isSelected;
        [NotMapped]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }


        public virtual ICollection<User_Menu> User_Menu { get; set; }
    }
}
