﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Common
{
    /// <summary>
    /// 配置类
    /// </summary>
    public class Configs
    {
        public List<UserConfig> UserConfig { get; set; }
        public List<ThemeConfig> ThemeConfig { get; set; }

        public Configs()
        {
            UserConfig = new List<UserConfig>();
            ThemeConfig = new List<ThemeConfig>();
        }
    }
}