using MyWpf.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.EF
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base("name=ConnectStr1")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //2.去掉 将表名设置为实体类型名称的复数版本 的约定(如 对应ClassInfo 在数据库生成 ClassInfos表)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<User> User { get; set; }   
        public DbSet<User_Menu> User_Menu { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Store> Store { get; set; }

    }
}
