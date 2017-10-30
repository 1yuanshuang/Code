using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using Smlant.Events;

namespace Smlant.StartViewModels
{
    public class MainContentViewModel:ViewModelBase
    {
        private IEventAggregator eventAggregator;

        private StartMenu dataInstance;
        public StartMenu DataInstance
        {
            get { return dataInstance; }
            set
            {
                if (dataInstance != value)
                { 
                    try
                    {
                        dataInstance = value;                   
                        RaisePropertyChanged("DataInstance");
                    }
                    catch { }
                }
            }
        }

        public MainContentViewModel()
        {
            eventAggregator = (IEventAggregator)ServiceLocator.Current.GetService(typeof(IEventAggregator));
            DataInstance = new StartMenu {Name ="无限极树模板", ViewContent = new Views.TreeViewTemplate()};
            eventAggregator.GetEvent<MenuTreeViewSelectedItemChanged>().Subscribe((s) =>
            {
                DataInstance = s;
            });
        }
    }
}
