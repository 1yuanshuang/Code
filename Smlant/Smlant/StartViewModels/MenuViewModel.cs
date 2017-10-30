using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Command;

namespace Smlant.StartViewModels
{
    public class MenuViewModel:ViewModelBase
    {
        private IEventAggregator eventAggregator;

        public RelayCommand<StartMenu> ShowContentCommand { get; set; }

        private List<StartMenu> dataSource;
        public List<StartMenu> DataSource
        {
            get { return dataSource; }
            set
            {
                if (dataSource != value)
                {
                    dataSource = value;
                    RaisePropertyChanged("DataSource");
                }
            }
        }

        private StartMenu selectedItem;
        public StartMenu SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    RaisePropertyChanged("SelectedItem");
                }
            }
        }

        public MenuViewModel()
        {
            AddView(new StartMenu(new Views.TreeViewTemplate()){Name = "无限级树模板"});
            AddView(new StartMenu(new Views.TreeViewWithContextMenu()) { Name = "模板选择器" });
            AddView(new StartMenu(new Views.TreeViewWithCheckBox()) { Name="复选框树模板"});
            eventAggregator = (IEventAggregator)ServiceLocator.Current.GetService(typeof(IEventAggregator));

            ShowContentCommand = new RelayCommand<StartMenu>((s) =>
            {
                SelectedItem = s;
                eventAggregator.GetEvent<Events.MenuTreeViewSelectedItemChanged>().Publish(s);
            });
        }

        public void ClearView()
        {
            DataSource = new List<StartMenu>();
        }

        public void AddView(StartMenu view)
        {            
            var temp = new List<StartMenu>();
            if (DataSource != null)
            {
                foreach (var entity in DataSource)
                {
                    temp.Add(entity);
                }
            }
            temp.Add(view);
            DataSource = temp;
        }
    }

    public class StartMenu
    {
        public string Name { get; set; }
        public UserControl ViewContent { get; set; }

        public StartMenu()
        {
        }
        public StartMenu(UserControl view)
            : this()
        {
            ViewContent = view;
        }
    }
}
