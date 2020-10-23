using MyWpf.Validation;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace MyWpf.EF.Models
{
    public partial class User : ValidationPropertyBase
    {
        public User()
        {
            this.User_Menu = new HashSet<User_Menu>();
            icon = @"./HeaderPic/defualHeader.png";
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

       

        private bool isEdit;

        /// <summary>
        /// 标记是否是编辑用户
        /// </summary>
        [NotMapped]
        public bool IsEdit
        {
            get { return isEdit; }
            set
            {
                isEdit = value;
                this.RaisePropertyChanged("IsEdit");
            }
        }

        private bool isEditLogingUser;
        /// <summary>
        /// 是否在编辑登录用户
        /// </summary>
        [NotMapped]
        public bool IsEditLogingUser
        {
            get { return isEditLogingUser; }
            set
            {
                isEditLogingUser = value;
                this.RaisePropertyChanged("IsEditLogingUser");
            }
        }

        private string pwdMsg;
        /// <summary>
        /// 显示密码验证提示信息
        /// </summary>
        [NotMapped]
        public string PwdMsg
        {
            get { return pwdMsg; }
            set
            {
                pwdMsg = value;
                this.RaisePropertyChanged("PwdMsg");
            }
        }


        private string confirmPwd;
        /// <summary>
        /// 再次输入的密码
        /// </summary>
        [NotMapped]
        public string ConfirmPwd
        {
            get { return confirmPwd; }
            set
            {
                confirmPwd = value;
                this.RaisePropertyChanged("ConfirmPwd");
            }
        }


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

        private string token;

        [StringLength(64)]
        public string Token
        {
            get { return token; }
            set
            {
                token = value;
                this.RaisePropertyChanged("Token");
            }
        }


        private string age;

        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(maximumLength:3,MinimumLength =1,ErrorMessage ="请输入1到3位数字")]
        [Range(minimum: 1, maximum: 150, ErrorMessage = "{0}要在{1}和{2}之间")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "{0}只能输入正数")]
        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                this.RaisePropertyChanged("Age");
            }
        }

        private string name;
        [Required(ErrorMessage = "{0}不能为空")]
        [StringLength(maximumLength:16,MinimumLength =1,ErrorMessage ="{0}长度要在{2}到{1}之间")]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.RaisePropertyChanged("Name");
            }
        }

        private string phone;
        [StringLength(16)]
        //[RegularExpression(@"^1[3456789]\d{9}$",ErrorMessage ="手机号码格式错误")]
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                this.RaisePropertyChanged("Phone");
            }
        }

        private string address;
        [StringLength(32)]
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                this.RaisePropertyChanged("Address");
            }
        }

        private string pwd;
        [StringLength(16,MinimumLength =3,ErrorMessage ="输入{2}到{1}位密码")]
        [Required]
        public string Pwd
        {
            get { return pwd; }
            set
            {
                pwd = value;
                this.RaisePropertyChanged("Pwd");
            }
        }

        private string icon;
        [StringLength(128)]
        public string Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                this.RaisePropertyChanged("Icon");
            }
        }

        //private ImageSource imaSource;
        ///// <summary>
        ///// 头像
        ///// </summary>
        //[NotMapped]
        //public ImageSource ImaSource
        //{
        //    get { return imaSource; }
        //    set
        //    {
        //        if (!string.IsNullOrEmpty(icon))
        //        {
        //            imaSource = new BitmapImage(new Uri(icon, UriKind.Relative));
        //        }
        //        else
        //        {
        //            imaSource = value;
        //        }
        //        this.RaisePropertyChanged("ImaSource");
        //    }
        //}


        public virtual ICollection<User_Menu> User_Menu { get; set; }

        //[NotMapped]
        //public string Error => null;

        //[NotMapped]

        //public string this[string columnName]
        //{
        //    get
        //    {
        //        if (!string.IsNullOrEmpty(columnName))
        //        {
        //            var proType= this.GetType().GetProperty(columnName).PropertyType;
        //            if (proType.Name.ToLower().Contains("int32"))
        //            {
        //                if (((int)(this.GetType().GetProperty(columnName).GetValue(this))) < 1)
        //                {
        //                    return "值不能小于1";
        //                }
        //            }
        //        }
        //        return null;
        //    }
        //}
    }
}
