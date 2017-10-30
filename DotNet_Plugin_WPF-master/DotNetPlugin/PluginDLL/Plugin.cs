﻿using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PluginDLL
{
    public class Plugin:IEditor
    {
        public string PluginName
        {
            get
            {
                return "设备和接口";
            }
        }

        public UserControl GetControl()
        {
            return new MsgControl();
        }

        //public void Execute(TextBox txtbox)
        //{
        //    txtbox.Text = "2222222222222222";
        //}
    }
}
