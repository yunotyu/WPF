using MyWpf.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Validation
{
    public class ValidationHelper
    {
        /// <summary>
        /// 用于提交时，验证对象是否全部属性验证通过
        /// </summary>
        /// <param name="obj"></param>
        public static Dictionary<string,string> ValidationObject(object obj)
        {
            Dictionary<string, string> validationResDic = new Dictionary<string, string>();
            if (obj != null)
            {
                //ObjectContext.GetObjectType(obj.GetType()这个是获取EF查询出来的动态代理类的实际实体类型
                if (obj.GetType() == typeof(User)|| typeof(User) == ObjectContext.GetObjectType(obj.GetType()))
                {
                    var u = obj as User;
                    //判断是否是编辑用户
                    if (!u.IsEdit)
                    {
                        if (!string.Equals(u.Pwd, u.ConfirmPwd))
                        {
                            validationResDic.Add("错误", "2次输入的密码不一致");
                        }
                    }
                    else
                    {
                        //保证ConfirmPwd有值，不会报错
                        u.ConfirmPwd = u.Pwd;
                    }

                }
                Validation(validationResDic, obj);
            }
            return validationResDic;
        }


        private static void Validation(Dictionary<string,string> dic,object obj)
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, new ValidationContext(obj), validationResults, true);
            validationResults.ForEach(r =>
            {
                dic.Add(r.MemberNames.First(), r.ErrorMessage);
            });
        } 
    }
}
