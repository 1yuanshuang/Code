﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;

namespace Smlant.Views
{
    /// <summary>
    /// TreeViewTemplate.xaml 的交互逻辑
    /// </summary>
    public partial class TreeViewTemplate : UserControl
    {
        private IUnityContainer _container;

        public TreeViewTemplate()
        {
            InitializeComponent();
            _container = (IUnityContainer)ServiceLocator.Current.GetService(typeof(IUnityContainer));
            this.DataContext = _container.Resolve<ViewModels.TreeViewTemplateViewModelcs>();
        }
    }
}
