using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MyWpf.Validation
{
    public class NumberValidation : ValidationRule
    {
        public int MaxNum { get; set; }
        public int MinNum { get; set; }

        /// <summary>
        /// 验证规则
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var isNum = int.TryParse((string)value, out int num);
            if (!isNum)
            {
                return new ValidationResult(false, "输入的值无效");
            }
            if (num < MinNum )
            {
                //返回验证结果
                return new ValidationResult(false, $"值不能小于{MinNum}");
            }
            else if (num > MaxNum)
            {
                return new ValidationResult(false, $"值不能大于{MaxNum}");
            }
            return  new ValidationResult(true, null);
        }
    }
}
