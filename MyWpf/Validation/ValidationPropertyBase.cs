using MyWpf.EF.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Validation
{
    /// <summary>
    /// 验证属性值改变
    /// </summary>
    public class ValidationPropertyBase : BindableBase, IDataErrorInfo
    {
        public string this[string columnName] 
        {
            get
            {
                var user = this as User;
                if(string.Equals(columnName, "ConfirmPwd")|| string.Equals(columnName, "Pwd"))
                {
                    if (user.Pwd != user.ConfirmPwd)
                    {
                        user.PwdMsg = "2次输入密码不一致";
                        return null;
                    }
                    else
                    {
                        user.PwdMsg = string.Empty;
                    }
                    //if (this.GetType().GetProperty(columnName).GetValue(this) == null)
                    //{
                    //    return "2次输入的密码不一致";
                    //}
                    //if (this.GetType().GetProperty("Pwd").GetValue(this) == null)
                    //{
                    //    return "2次输入的密码不一致";
                    //}
                    //string confirmPwd= this.GetType().GetProperty(columnName).GetValue(this).ToString();
                    //string pwd = this.GetType().GetProperty("Pwd").GetValue(this).ToString();
                    //if (string.IsNullOrEmpty(pwd))
                    //{
                    //    return "2次输入的密码不一致";
                    //}
                    //else if (string.Equals(pwd, confirmPwd))
                    //{
                    //    return null;
                    //}
                    //return "2次输入的密码不一致";
                }
                List<ValidationResult> results = new List<ValidationResult>();

                var valRes= Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this),
                    new ValidationContext(this) { MemberName = columnName }, results);
                if (!valRes)
                {
                    return results.First().ErrorMessage;
                }
                return null;
            }
        }

        public string Error => null;
    }
}
