using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace DataLibrary
{
    /// <summary>
    /// 设备状态
    /// </summary>
    public enum DeviceStatus
    {
        Connected,Off
    }

    /// <summary>
    /// 设备基类
    /// </summary>
    public class Device:INotifyPropertyChanged
    {
        //是否被选中
        private bool? isSelected;
        public bool? IsSelected 
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;   
                    ChangeChildNodes(this);
                    ChangedParentNodes(this);
                    NotifyPropertyChanged("IsSelected");
                }
            }
        }
        
        private DeviceStatus status;
        public DeviceStatus Status
        {
            get { return status; }
            set
            {
                if (status != value)
                {
                    status = value;
                    NotifyPropertyChanged("Status");
                }
            }
        }

        public string Name { get; set; }
        public string ImageUrl{get;set;}

        private List<Device> childNodes;
        public List<Device> ChildNodes
        {
            get { return childNodes; }
            set
            {
                if (childNodes != value)
                {
                    childNodes = value;
                    NotifyPropertyChanged("ChildNodes");
                }
            }
        }

        private Device parentNode;
        public Device ParentNode
        {
            get { return parentNode; }
            set
            {
                if (parentNode != value)
                {
                    parentNode = value;
                    NotifyPropertyChanged("ParentNode");
                }
            }
        }

        /// <summary>
        /// 向下遍历,更改孩子节点状态
        /// 注意：这里的父节点不是属性而是字段
        /// 采用字段的原因是因为不想让父节点触发访问器而触发Setter
        /// </summary>
        /// <param name="CurrentNode"></param>
        public void ChangeChildNodes(Device CurrentNode)
        {
            if (CurrentNode.ChildNodes != null)
            {
                foreach (var data in CurrentNode.ChildNodes)
                {
                    data.isSelected = CurrentNode.IsSelected;
                    data.NotifyPropertyChanged("IsSelected");
                    if (data.ChildNodes != null)
                    {
                        data.ChangeChildNodes(data);
                    }
                }
            }
        }

        /// <summary>
        /// 向上遍历,更改父节点状态
        /// 注意：这里的父节点不是属性而是字段
        /// 采用字段的原因是因为不想让父节点触发访问器而触发Setter
        /// </summary>
        /// <param name="CurrentNode"></param>
        public void ChangedParentNodes(Device CurrentNode)
        {
            if (CurrentNode.ParentNode != null)
            {
                bool? parentNodeState = true;
                int selectedCount = 0;  //被选中的个数
                int noSelectedCount = 0;    //不被选中的个数

                foreach (var data in CurrentNode.ParentNode.ChildNodes)
                {
                    if (data.IsSelected == true)
                    {
                        selectedCount++;
                    }
                    else if (data.IsSelected == false)
                    {
                        noSelectedCount++;
                    }
                }

                //如果全部被选中,则修改父节点为选中
                if (selectedCount == 
                    CurrentNode.ParentNode.ChildNodes.Count)
                {
                    parentNodeState = true;
                }
                //如果全部不被选中,则修改父节点为不被选中
                else if (noSelectedCount == 
                    CurrentNode.ParentNode.ChildNodes.Count)
                {
                    parentNodeState = false;
                }
                //否则标记父节点（例如用实体矩形填满）
                else
                {
                    parentNodeState = null;
                }

                CurrentNode.parentNode.isSelected = parentNodeState;
                CurrentNode.parentNode.NotifyPropertyChanged("IsSelected");

                if (CurrentNode.ParentNode.ParentNode != null)
                {
                    ChangedParentNodes(CurrentNode.parentNode);
                }
            }
        }

        public void NotifyPropertyChanged(string name)
        {
            if(PropertyChanged!=null)
            PropertyChanged(this,new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    /// <summary>
    /// 路由器
    /// </summary>
    public class Router : Device
    {

    }

    /// <summary>
    /// 交换机
    /// </summary>
    public class Switcher : Device
    {

    }

    /// <summary>
    /// 集线器
    /// </summary>
    public class Concentrator : Device
    {

    }
}
