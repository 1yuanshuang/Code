﻿using System;
using System.ComponentModel;

namespace TestDataBind
{
    class MyData1//: INotifyPropertyChanged
    {
        private string text;
        private bool enabled;
        //public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            get => text;
            set
            {
                text = value;
                if (IsNumberic(text))
                {
                    enabled = true;
                }
                else
                {
                    enabled = false;
                }

                //if(this.PropertyChanged!=null)
                //{
                //    this.PropertyChanged.Invoke(this,new PropertyChangedEventArgs("Text"));
                //}

              //  this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Text"));
            }
        }

        public bool Enabled
        {
            get => enabled; 
            set => enabled = value; 
        }

        protected bool IsNumberic(string message)
        {
            System.Text.RegularExpressions.Regex rex = new System.Text.RegularExpressions.Regex(@"^\d+$");

            if (rex.IsMatch(message))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}