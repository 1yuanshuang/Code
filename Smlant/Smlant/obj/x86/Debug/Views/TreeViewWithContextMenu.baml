   M S B A M L   `   `   `  ����F  BDataLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:DataLibrary;assembly=DataLibraryDataLibrary  5      A =Smlant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Smlant.DataTemplatesSmlant.DataTemplates 5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      i eGalaSoft.MvvmLight.Extras.WPF4, Version=3.0.0.29165, Culture=neutral, PublicKeyToken=f396425e4cefefbcoPclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF4GalaSoft.MvvmLight.Command 5	      *   $Smlant.Views.TreeViewWithContextMenu   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      BDataLib.clr-namespace:DataLibrary;assembly=DataLibrary     5      <LocalTmeplate"clr-namespace:Smlant.DataTemplates     5      bEventPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      hGalaCommandPclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF4     5	        � 	Resources  5      :  4Smlant.DataTemplates.ContextMenuDataTemplateSelector #  ContextMenuDataTemplateSelector  
RouterMenu m� Icon  
SwitchMenu  ConcentratorMenu  SwitchTemplate �� DataType   DataLibrary.Switcher �� ItemsSource �� Orientation � ContextMenu �� RelativeSource �� Mode �� AncestorType	 � ToolTip  RouterTemplate   DataLibrary.Router  ConcentratorTemplate   DataLibrary.Concentrator
 �� 
TargetType �� Property �� Value��%�  &	        &	      &	     &	     &	     7  &	 �    7  &	 C    7  '�� _
    '�� �
    '�� �
      5   
   68   �� 5   
   .@�5      m� $��启动路由器��6    5      �� 5      $ ��..\..\Resource\Connect.png��6   5      m� 5      $��断开路由器��6    5      �� 5      $��..\..\Resource\Break.png��6   5      5      �� 5   
   .@�5      m� $��启动交换机��6    5      �� 5      $ ��..\..\Resource\Connect.png��6   5      m� 5       $��断开交换机��6    5!      �� 5"      $��..\..\Resource\Break.png��6   5$      5%      �� 5&   
   .@�5'      m� $��启动集线器��6    5(      �� 5)      $ ��..\..\Resource\Connect.png��6   5+      m� 5,      $��断开集线器��6    5-      �� 5.      $��..\..\Resource\Break.png��6   50      51      �� 53   
   "  6]    6:   �� *
ChildNodes+.R�54      �� $ 
Horizontal=�6   8   .+�55      �� $��2q�64   ��6   �� *
ImageUrl+64   �� 56      $��2q�62   $��Center=�6=   ��6   �� *Name+6=   �� 57      $��2q�6   ��6$   �� *DataContext.OffCommand+ �� $ FindAncestor=�$ UserControlL���58      �� .��59      �� .+�5:      �� $ ��..\..\Resource\Connect.png��6    $	 重新连接��6D   5;      5<      �� 5=      $��2q�6   ��6$   �� *DataContext.ConnectionCommand+ �� $ FindAncestor=�$ UserControlL���5>      �� .��5?      �� .+�5@      �� $��..\..\Resource\Break.png��6    $	 断开连接��6B   5A      5B      5C      5D      �� 5F   
   "  6]    6:   �� *
ChildNodes+.R�5G      �� $ 
Horizontal=�6   8   .+�5H      �� $��2q�64   ��6   �� *
ImageUrl+64   �� 5I      $��2q�62   $��Center=�6=   ��6   �� *Name+6=   �� 5J      $��2q�6   $��重启路由��6$   ��63   �� *DataContext.OffCommand+ �� $ FindAncestor=�$ UserControlL���5K      �� 5L      �� 5M      $��2q�6   $��断开连接��6$   ��64   �� *DataContext.ConnectionCommand+ �� $ FindAncestor=�$ UserControlL���5N      �� 5O      5P      5Q      �� 5S   
   "  64   .R�5T      �� $ 
Horizontal=�6   8   .+�5U      �� $��2q�64   ��6   �� *
ImageUrl+64   �� 5V      $��2q�62   $��Center=�6=   ��6   �� *Name+6=   �� 5W      $��2q�6   $��重新连接��6$   ��63   �� *DataContext.OffCommand+ �� $ FindAncestor=�$ UserControlL���5X      �� �� 5Y      $��2q�6   $��断开连接��6$   ��64   �� *DataContext.ConnectionCommand+ �� $ FindAncestor=�$ UserControlL���5Z      �� 5[      5\      �� 5]   
   "
 ��6   .�5^      ��  � ��$ 5q�6'   5_      �� 5`   
   "
 ��6   .�5a      ��  � ��$ Center=�62   5b      �� 5c   
   "
 ��6   .�5d      ��  � ��$ 5q�6'   �� 5e       � ��$ 80��6&   �� 5f       � ��$ 23��6*   5g      5h      .��5i      �  � RowDefinitions 5j   
   �� 5k      $
��auto �6   �� 5l      $��* �6   .+�5n   
   �� $��0��6   $ 
Horizontal=�6"   $
��Left=�6;   $��Center=�6V   $��5q�6q   .+�5o      �� $��23��68   ��6   �� *RefreshCommand+.��5p      �� $ 
Horizontal=�6   .+�5q      �� $!��..\..\Resource\LoadData.png��6   $��2q�6A   �� 5r      $��刷新��6    $��2q�6*   5s      5t      �� 5u      $��树的深度��6   $��5q�6$   �� 5v      ��6   �� *LevelSource+ �� SelectedItem 6;   �� *SelectedLevel+ �� Mode$ TwoWay=�5w      R� 5x   
   $��1��6   #��[  6C   $��5q�6�   ��6    �� *
DataSource+.  (System.Windows.Interactivity.Interaction   Triggers 5y      /  )System.Windows.Interactivity.EventTrigger  5z         	EventName$ SelectedItemChanged��6%   3  -System.Windows.Interactivity.EventTriggerBase   
SourceName$ trv_Menu��6E   .  (System.Windows.Interactivity.TriggerBase   Actions. 5{      /	  )GalaSoft.MvvmLight.Command.EventToCommand	   	  Command 61   �� *SelectedChangedCommand+ 	  CommandParameter 5|   0   ��  �� ElementName$ trv_Menu�� �� Path$ SelectedItem�5}      5      5�      5�      