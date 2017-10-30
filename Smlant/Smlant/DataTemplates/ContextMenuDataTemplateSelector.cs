using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using DataLibrary;

namespace Smlant.DataTemplates
{
    public class ContextMenuDataTemplateSelector:DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            DataTemplate template = null;
            if (item is Router)
            {
                template = element.FindResource("RouterTemplate") as HierarchicalDataTemplate;
            }
            else if (item is Switcher)
            {
                template = element.FindResource("SwitchTemplate") as HierarchicalDataTemplate;
            }
            else if (item is Concentrator)
            {
                template = element.FindResource("ConcentratorTemplate") as DataTemplate;
            }
            return template;
        }
    }
}
