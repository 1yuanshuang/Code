   M S B A M L   `   `   `  ����F  BDataLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:DataLibrary;assembly=DataLibraryDataLibrary  5      A =Smlant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Smlant.DataTemplatesSmlant.DataTemplates 5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      i eGalaSoft.MvvmLight.Extras.WPF4, Version=3.0.0.29165, Culture=neutral, PublicKeyToken=f396425e4cefefbcoPclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF4GalaSoft.MvvmLight.Command 5	      '   !Smlant.Views.TreeViewWithCheckBox   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      BDataLib.clr-namespace:DataLibrary;assembly=DataLibrary     5      <LocalTmeplate"clr-namespace:Smlant.DataTemplates     5      bEventPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      hGalaCommandPclr-namespace:GalaSoft.MvvmLight.Command;assembly=GalaSoft.MvvmLight.Extras.WPF4     5	        � 	Resources  5      :  4Smlant.DataTemplates.ContextMenuDataTemplateSelector #  ContextMenuDataTemplateSelector  
RouterMenu  
SwitchMenu  ConcentratorMenu m� Command m� CommandParameter �� ElementName �� Path  SwitchTemplate �� DataType   DataLibrary.Switcher �� ItemsSource �� Orientation � ContextMenu	 d� 	IsChecked
 �� Mode  RouterTemplate   DataLibrary.Router  ConcentratorTemplate   DataLibrary.Concentrator �� 
TargetType �� Property �� Value��%�  &	        &	      &	 S     &	 �     &	 *    7  &	 �    7  &	 �    7  '��     '�� V    '�� �      5   
   68   �� 5   
   .@�5      m� $��重启路由��6   5      �� 5   
   .@�5      m� $��重启交换机��6   5      �� 5   
   .@�5      m� $��断开集线器��6    6&   �� *
OffCommand+ 5      �� $ trv_Menu��$ SelectedItem�5      �� 5   
   "  6]    6:   �� *
ChildNodes+.R�5      �� $ 
Horizontal=�6   8   .+�5      �� $��2q�6H   $��Center=�6S   	 6   �� *
IsSelected+$
 TwoWay=�6S   �� 5      $��2q�64   ��6   �� *
ImageUrl+64   �� 5      $��2q�62   $��Center=�6=   ��6   �� *Name+6=   5      5      �� 5   
   "  6]    6:   �� *
ChildNodes+.R�5       �� $ 
Horizontal=�6   8   .+�5!      �� $��2q�6H   $��Center=�6S   	 6   �� *
IsSelected+$
 TwoWay=�6S   �� 5"      $��2q�64   ��6   �� *
ImageUrl+64   �� 5#      $��2q�62   $��Center=�6=   ��6   �� *Name+6=   5$      5%      �� 5&   
   "  64   .R�5'      �� $ 
Horizontal=�6   8   .+�5(      �� $��2q�6H   $��Center=�6S   	 6   �� *
IsSelected+$
 TwoWay=�6S   �� 5)      $��2q�64   ��6   �� *
ImageUrl+64   �� 5*      $��2q�62   $��Center=�6=   ��6   �� *Name+6=   5+      5,      �� 5-   
   " ��6   .�5.      ��  � ��$ 5q�6'   5/      �� 50   
   " ��6   .�51      ��  � ��$ Center=�62   52      �� 53   
   " ��6   .�54      ��  � ��$ 5q�6'   �� 55       � ��$ 80��6&   �� 56       � ��$ 23��6*   57      58      .��59      �  � RowDefinitions 5:   
   �� 5;      $
��auto �6   �� 5<      $��* �6   .+�5>   
   �� $��0��6   $ 
Horizontal=�6"   $
��Left=�6;   $��Center=�6V   $��5q�6q   .+�5?      �� $��23��68   ��6   �� *RefreshCommand+.��5@      �� $ 
Horizontal=�6   .+�5A      �� $!��..\..\Resource\LoadData.png��6   $��2q�6A   �� 5B      $��刷新��6    $��2q�6*   5C      5D      �� 5E      $��树的深度��6   $��5q�6$   �� 5F      ��6   �� *LevelSource+ �� SelectedItem 6;   �� *SelectedLevel+$
 TwoWay=�5G      R� 5H   
   $��1��6   #��[  6C   $��5q�6�   ��6    �� *
DataSource+.  (System.Windows.Interactivity.Interaction   Triggers 5I      /  )System.Windows.Interactivity.EventTrigger  5J         	EventName$ SelectedItemChanged��6%   3  -System.Windows.Interactivity.EventTriggerBase   
SourceName$ trv_Menu��6E   .  (System.Windows.Interactivity.TriggerBase   Actions. 5K      /	  )GalaSoft.MvvmLight.Command.EventToCommand	   	  Command 61   �� *SelectedChangedCommand+ 	  CommandParameter 5L   0   �� $ trv_Menu��$ SelectedItem�5M      5O      5P      5Q      