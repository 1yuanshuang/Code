using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using DataLibrary;
using GalaSoft.MvvmLight;

namespace Smlant.ViewModels
{
    public class TreeViewWithContextMenuViewModel:ViewModelBase
    {
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand<Device> ConnectionCommand { get; set; }
        public RelayCommand<Device> OffCommand { get; set; }

        public RelayCommand<Device> SelectedChangedCommand{get;set;}

        private List<Device> dataSource;
        public List<Device> DataSource
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

        private Device selectedItem;
        public Device SelectedItem
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

        private List<int> levelSource;
        public List<int> LevelSource
        {
            get { return levelSource; }
            set
            {
                if (levelSource != value)
                {
                    levelSource = value;
                    RaisePropertyChanged("LevelSource");
                }
            }
        }

        private int selectedLevel;
        public int SelectedLevel
        {
            get { return selectedLevel; }
            set
            {
                if (selectedLevel != value)
                {
                    selectedLevel = value;
                    LoadData();
                    RaisePropertyChanged("SelectedLevel");
                }
            }
        }

        public TreeViewWithContextMenuViewModel()
        {
            LevelSource = new List<int>
            {
                1,2,3,4,5,6
            };
            SelectedLevel = 2;

            RefreshCommand = new RelayCommand(LoadData);
            SelectedChangedCommand = new RelayCommand<Device>((s) =>
            {
                SelectedItem = s;
            });

            ConnectionCommand = new RelayCommand<Device>((s) =>
            {
                s.Status = DeviceStatus.Connected;
                SelectedItem = s;
            }, (s) =>
            {
                return s.Status == DeviceStatus.Off;;
            });

            OffCommand = new RelayCommand<Device>((s) =>
            {
                s.Status = DeviceStatus.Off;
                SelectedItem = s;
            }, (s) =>
            {
                return s.Status == DeviceStatus.Connected;
            });

            LoadData();
        }

        public void LoadData()
        {
            DataSource = DataFactory.GetAllTypeDevice(1, SelectedLevel);
        }
    }
}
