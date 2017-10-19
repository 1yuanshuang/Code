using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using DataLibrary;
using GalaSoft.MvvmLight.Command;

namespace Smlant.ViewModels
{
    public class TreeViewTemplateViewModelcs:ViewModelBase
    {

        public RelayCommand RefreshCommand { get; set; }

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

        public TreeViewTemplateViewModelcs()
        {
            LevelSource = new List<int>
            {
                1,2,3,4,5,6
            };
            SelectedLevel = 2;
            LoadData();
            RefreshCommand = new RelayCommand(LoadData);
        }

        public void LoadData()
        {
            DataSource = DataFactory.GetBaseTypeDevices(1, SelectedLevel);
        }

    }
}
