using MyWpf.AttachProperty;
using MyWpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWpf.ViewModels
{
    public class TipViewModel:ViewModelBase
    {
        public TipViewModel()
        {
            closeCommand.ExcuteAction = new Action<object>(o =>
              {
                  var tip = o as Tip;
                  tip.Close();
              });
        }
    }
}
