   M S B A M L   `   `   `  ����@  <MyWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MyWpf.ViewsMyWpf.Views  5      3clr-namespace:MyWpf.ViewModelsMyWpf.ViewModels  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	      3clr-namespace:MyWpf.ConvertersMyWpf.Converters  5          MyWpf.Views.Users   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:MyWpf.Views     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      'vmclr-namespace:MyWpf.ViewModels  5      XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5	      h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Einter9http://schemas.microsoft.com/expression/2010/interactions  5
      ,convertclr-namespace:MyWpf.Converters  5        � 	Resources  5      %   MyWpf.ViewModels.UsersViewModel 	  users  headerStyle �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader �� Property �� Value*   $MyWpf.Converters.MultiParamConverter 	 multi��%�   &	        &	      &	 d       5   
   6-   �� 5   
   "  6$   .�5      ��  � ��$ Center=�6;   6L   5        5   
   66   5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��4* �6   6*   �� 5      $��* �6   6)   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $
��Left=�6.   $��10,0,0,0q�6I   .+�5      �� -   5         ��Name$ searchTextbox��5   V   $��15(�6m   
�������$	��500��6�   $��Center=�6�    * &MaterialDesignOutlinedTextFieldTextBox#��[ 6�   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 请输入搜索内容��5       ��5      ��  �� Source# [  	 �� Path$	 
SearchText�5    B   �� 5!      $��15,0,0,0q�5"      ��5!      ��  	 theme# [ $	 	SkinColor�
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=���6�   �� # [  $	 SearchCommand���5#      �� 5$      $ 
Horizontal=�6!   .+�5%      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�62   �� 5&      $��10,0,0,0q�6$   $��搜索��66   6C   5'      5)      5*      �� 5-   
   $ 
Horizontal=�6   $��Right=�6.   .+�5.      �� $��0,0,20,0q�6�   ��6   �� # [ $	 	SkinColor�$
 TwoWay=�$ PropertyChanged=���5/      �� 50      $ 
Horizontal=�6!   .+�51        $ PlaylistCheck=�62   �� 52      $��10,0,0,0q�6$   $��编辑��66   6C   53      55      �� 58      $��0,0,20,0q�6�   ��6   �� # [ $	 	SkinColor�$
 TwoWay=�$ PropertyChanged=���6�   �� # [  $	 AddUserDiaCommand���59      `� 5:       `� 	Converter# [ 6#   .1�5;      �� 6$   �� 5=      # [  6"   $
	 Page�6B   $
 TwoWay=�6N   6^   5>      ��5@      �� 5A      $ 
Horizontal=�6!   .+�5B        $ PlaylistPlus=�62   �� 5C      $��10,0,0,0q�6$   $��添加��66   6C   5D      5F      �� 5H      $��0,0,20,0q�6�   ��6   �� # [ $	 	SkinColor�$
 TwoWay=�$ PropertyChanged=���6�   �� # [  $	 DeleteCommand���5I      �� 5J      $ 
Horizontal=�6!   .+�5K        $ PlaylistRemove=�62   �� 5L      $��10,0,0,0q�6$   $��删除��66   6C   5M      5O      �� 5Q      $��0,0,20,0q�6�   ��6   �� # [ $	 	SkinColor�$
 TwoWay=�$ PropertyChanged=���5R      �� 5S      $ 
Horizontal=�6!   .+�5T        $ PlaylistPlay=�62   �� 5U      $��10,0,0,0q�6$   $��刷新��66   6C   5V      5X      5Y      &   System.Windows.Controls.DataGrid  5\   
      
IsReadOnly . $��1��6&      CanUserAddRows .     SelectionMode$ Extended=�5]   
      AutoGenerateColumns .     ColumnHeaderStyle# [ 5`      ��5^   
   �� # [  $	 
Page.Items�   Columns 5a      4  .System.Windows.Controls.DataGridCheckBoxColumn  5b      ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly .  1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6=   �� *
IsSelected+$
 TwoWay=�$ PropertyChanged=�6�   0
  *System.Windows.Controls.DataGridTextColumn
  5c         
Visibility$ Hidden=�6<    6%   �� *Id+6R   
  5d         Header$ 姓名��6>    6%   �� *Name+6L   
  5e      $ 年龄��6=    6%   �� *Age+6K   
  5f      $ 手机��6?    6%   �� *Phone+6M   
  5g      $ 地址��6A    6%   �� *	Address+6O   .  (System.Windows.Interactivity.Interaction   Triggers 5j      /  )System.Windows.Interactivity.EventTrigger  5k         	EventName$ MouseDoubleClick��6!   .  (System.Windows.Interactivity.TriggerBase   Actions. 5l      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6,   �� # [  $	 DataGirdDouClickCommand�   CommandParameter 5m      `� 5n      # [ 6+   .1�5o   "   �� $	 SelectedItem�6u    �� RelativeSource 6*   ��  �� AncestorType$ DataGridL� �� Mode$ FindAncestor=�6�   �� 5p   "   6,   5q      5s      5t      5w      �� 5z   
   $ 
Horizontal=�6   $��2��6.   $��0,0,0,20q�6;   $��Bottom=�6M   $��Right=�6h   .+�5|      �� $ 
Horizontal=�6   $��Center=�62   $��0,0,20,0q�6M   .+�5}      �� $��Center=�6   $��15(�67   $��每页��6E   6R   �� 5~      -   5        $ perPageItem��5~      $��20(�6�   $��Center=�6�   $��Center=�6�   $��40��6�   $��40��6�   $��0q�6�   ��6/   �� # [  $	 Page.PerPageItem�$
 TwoWay=���6�   Z� .��6   5        5�      $ TextChanged��6)   . 5�         64   �� # [  $	 UpdatePerPageItemCommand� 6�   ��  �� $ FindAncestor=�$ TextBoxL�$
	 Text�6�   5�      .��5�   .   .��5�   0   5�      �� 5�      $��Center=�6   $��15(�67   $	��条��6E   6P   5�      �� 5�      $��0,0,10,0q�6   $ 
Horizontal=�6-   $��Center=�6F   .+�5�      �� $��15(�6   $��Center=�6+   $	��第��6F   6Q   �� 5�      -   5        $ gotoPage��5�      $��0q�6{   $��20(�6�   $��40��6�   $��Center=�6�   $��Center=�6�   $��40��6   ��6,   �� # [  $	 Page.CurPage�$
 TwoWay=���6�   Z� 6  �� 5�      $��15(�6   $��Center=�6*   $	��页��6E   6P   5�      �� 5�      $��0,0,20,0q�6  $��前往��6.  ��6   �� # [ $	 	SkinColor�$
 TwoWay=�$ PropertyChanged=���6�   �� # [  $	 GotoCommand���6�   ��  %  System.Windows.Markup.Reference      Name$  gotoPage��$
	 Text�6=  �� 5�      $ 
Horizontal=�6   .+�5�      �� $��0,0,10,0q�6   $��20(�60   $	��共��6>   $��Center=�6G   6d   �� 5�      $��20(�6   $��Center=�6�   ��6-   �� # [  $	 Page.AllPageCount�$
 TwoWay=�6�   �� 5�      $��	10,0,20,0q�6   $��20(�61   $	��页��6?   $��Center=�6H   6e   5�      �� 5�      $��0,0,10,0q�6�   $��首页��6�   ��6   �� # [ $	 	SkinColor�$
 TwoWay=�$ PropertyChanged=���6�   �� # [  $	 FirstCommand�6�   �� 5�      $��0,0,10,0q�6�   $��	上一页��6�   ��6   �� # [ $	 	SkinColor�$
 TwoWay=�$ PropertyChanged=���6�   �� # [  $	 PrevCommand�6�   �� 5�      $��0,0,10,0q�6�   $��	下一页��6�   ��6   �� # [ $	 	SkinColor�$
 TwoWay=�$ PropertyChanged=���6�   �� # [  $	 NextCommand�6�   �� 5�      $��0,0,10,0q�6�   $��尾页��6�   ��6   �� # [ $	 	SkinColor�$
 TwoWay=�$ PropertyChanged=���6�   �� # [  $	 LastCommand�6�   5�      5�      5�      