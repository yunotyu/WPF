   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5   	   @ <MyWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MyWpfMyWpf 5   	   3clr-namespace:MyWpf.ViewModelsMyWpf.ViewModels 5	   	   3clr-namespace:MyWpf.ConvertersMyWpf.Converters 5
   	   +clr-namespace:MyWpf.CommonMyWpf.Common 5   	      
MyWpf.Home   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35KInteraction9http://schemas.microsoft.com/expression/2010/interactions  5   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5   	   localclr-namespace:MyWpf  5   	   'vmclr-namespace:MyWpf.ViewModels  5	   	   -conveterclr-namespace:MyWpf.Converters  5
   	   %baseclr-namespace:MyWpf.Common  5   	   -   5          MyWpf.Common.WindowBase   Name$
  home��5   	    � Title$
 Home��5   	   $	��800��6   $
��1200��6#   ��5   	   �� *WinMaxHeight+��6,   �� *WinMaxWidth+'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      GlassFrameThickness$ -1q�6   62    � 	Resources 5      *  $MyWpf.Converters.MultiParamConverter 	  multi��%   &	          5   
   67   5       � DataContext 5      $  MyWpf.ViewModels.HomeViewModel  5   
   6   .   (System.Windows.Interactivity.Interaction   Triggers 5       /   )System.Windows.Interactivity.EventTrigger  5!   
      	EventName$ Loaded��6   .   (System.Windows.Interactivity.TriggerBase   Actions. 5"      >  8Microsoft.Expression.Interactivity.Core.CallMethodAction  	   
MethodName$	 WindowLoaded��6H   
   TargetObject
 6/   �� 5#      5$       J� Effect 5/      3	  -System.Windows.Media.Effects.DropShadowEffect	  50   
    	  
BlurRadius$ 5Q�6   6-   .��5K      ]� ��. .+�5N   
   �� -   5         ��Name$
 tool��5N   3   $	��100��6   $	��Top=�6   ��6A   ��  	 theme �� Source# [  �� Path$ 	SkinColor� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�._�5O      � -   5         �Name$ imaData��5O       � ColumnDefinitions 5P      �� 5Q      $	��100 �6'   65   �� 5R      6)   �� 5S      6)   .+�5W      �� .+�5X      �� $��	0,10,30,0q�6   $��Center=�60   $��Center=�6M    � Cursor$
 Hand��6h   $��40��6�   $��40��6�   ��6w   �� $ 	User.Icon�  imaToStr �� 	Converter# [  � ToolTip 5Y      _� 5Z       _� 	Placement$ Right=�6&   ��68   �� $ 	User.Name�5[       � ContextMenu 5]      �� 5^      .@�5_   "   m� $��注销��6,    5`   &     5a   *   $ Click��69   . 5b   .   6
   0System.Windows.Interactivity.InvokeCommandAction
   
  Command 6D   �� *LogOutCommand+ 
  CommandParameter 6f   ��  �� RelativeSource ��  �� AncestorType$ ContextMenuL� �� Mode$ FindAncestor=�$ PlacementTarget�6�   5c   +   5e   #   5f       J� Clip 5h      @� 5i       @� RadiusX$ 20Q�6.     @� RadiusY$  20Q�6;   ! @� Center$! 20,20&�6H   6Y    5k        5l      $ 	MouseDown��6-   . 5m   "   
   68   �� *EditLoginUserCommand+ 6a   ��  �� $ FindAncestor=�$ WindowL�6�   5n      5p      � 5s      $��0,6,30,0q�6   $��40��6-   $��50��69   .+�5u      �� -   5        " ��Name$" menuImg��5u   5   $y�Visible=�6    $��Uniform=�6F   $��../../Image/menu.png��6Y    5v        5w   "   $ 	MouseDown��61   . 5x   &   
   6<   �� *MenuCommand+ 5y   *   `� 5z   .   # `� 	Converter## [  6;   .1�5{   2   ��  6:   �� $ ImageL�$ FindAncestor=�6�   �� 5|   2   $ �� ElementName$$ backMenuImg��6:   6V   5}   /   5   '   5�   #   ��5�      �� 5�   "   % �� 
TargetType"% ��6(   & �� Triggers& 5�   &   P� 5�   *   ' P� Property' �@J�IsMouseOver( P� Value( . . �5�   .   �� ) �� Property) �@J�Effect* �� Value* 5�   2   	  5�   6   $ 4Q�6G   + 	  Color$
+ Gray��6V   , 	  ShadowDepth$, 1Q�6c   6u   5�   /   5�   +   5�   #   - � Triggers- 5�      :� 5�   "   . :� RoutedEvent$. 	MouseDown��6/   [�5�   &   �� 5�   *   .��5�   .   �� .��5�   2   t� / g� Duration$/ 0:0:0.5D�6E   0 �� TargetProperty$0 Margin�6X   1 �� 
TargetName$
1 menu��6{   	2 t� To$2 0,0,0,0X�6�   6�   5�   /   5�   +   5�   #   5�      �� 5�      -   5        $" backMenuImg��5�   4   $y�Hidden=�6    $��Uniform=�6I   $��../../Image/backmenu.png��6[    5�        5�   "   $ 	MouseDown��61   . 5�   &   
   6<   �� *BackMenuCommand+ 5�   *   `� 5�   .   ## [  6;   .1�5�   2   ��  6:   �� $ ImageL�$ FindAncestor=�6�   �� 5�   2   $$ menuImg��6:   6R   5�   /   5�   '   5�   #   ��5�      �� 5�   "   "% ��6(   & 5�   &   P� 5�   *   ' �@J�IsMouseOver( . . �5�   .   �� ) �@J�Effect* 5�   2   	  5�   6   $ 4Q�6G   $
+ Gray��6V   $, 1Q�6c   6u   5�   /   5�   +   5�   #   - 5�      :� 5�   "   $. 	MouseDown��6/   [�5�   &   �� 5�   *   .��5�   .   �� .��5�   2   t� $/ 0:0:0.5D�6E   $0 Margin�6X   $
1 menu��6{   $2 	-80,0,0,0X�6�   6�   5�   /   5�   +   5�   #   5�      5�      5�      �� 5�      $
��Left=�6   $��0��68   $��1��6E   $
 Hand��6U   $��	Welcome !��6c   $��Center=�6t   $��25(�6�   $
��Bold"�6�   6�   �� 5�      $��2��6   3 �� Orientation$3 
Horizontal=�6.   $��Right=�6G   .+�5�      �� $
 Hand��6   $��	0,10,20,0q�6�   $��0q�6�   $��30��6�   $��30��6�   $	��Top=�6�   ��6+   �� *
MinCommand+��6J   ��  �� $ WindowL�$ FindAncestor=� 5�      _� 5�      .��6&   	最小化5�      ��5�      �� 5�      4 �� ImageSource$4 ../Image/mini.png��6)   6K   5�      �� 5�      $
 Hand��6   $��	0,10,20,0q�6-   $��0q�6@   $��30��6�   $��30��6�   $	��Top=�6�   ��6T   �� *MaxNormalCommand+��6z   ��  �� $ WindowL�$ FindAncestor=� 5�      _� 5�      .��6&   	最大化5�      ��5�      �� 5�      4 6)   �� *MaxNormalPicPath+# [ 6y   5�      �� 5�      -   5        5 ��Name$5 b��5�   ,   $
 Hand��6   $��-5,5,5,0q�6X   $��0q�6l   $��40��6�   $��40��6�   $	��Top=�6�   ��67   �� *CloseCommand+ 5�      _� 5�      .��6'   关闭5�      ��5�      �� 5�      $4 ../Image/close.png��6)   6L   5�      5�      5�      5�      �� 5�   
   -   5        $
 menu��5�      $
��Left=�6   $��	-80,0,0,0q�65   $��80��6H   ��6T   �� # [ $ 	SkinColor�$ TwoWay=�$ PropertyChanged=�._�5�      �� $3 Vertical=�6   .+�5�      �� -   5        6 ��Name$6 menuList��5�      ��6,   �� *	Modules+ 5�        5�      $ SelectionChanged��6)   . 5�      
   64   �� *SelectChangedCommand+ 5�   "   `� 5   &   ## [  63   .1�5  *   ��  62   �� $ FindAncestor=�$ WindowL�6}   �� 5  *   $ SelectedIndex�62    6G   �� $ FindAncestor=�$ ListBoxL�6�   5  '   5     5     ��5
     �� 5     .R�5     � .+�5  "   �� $��60��6i   $��30��6u   ��6(   �� *
IconCode+# [ 5  #   5     5     ��5     �� 5     "% ��6    .�5     �� ) � ��* 5  "   �� 5  &   7 �� 
TargetType"7 ��66   .R�5  *   � $ itemGrid��6A   $��0,20,0,0q�6/   #��z��6S    5  .   _� 5  2   $ Right=�6:   .��5  6   �� ��6@   �� *
MenuName+6\   5  3   .+�5!  .   �� $��Center=�6@   $��Center=�6]   6z   5"  +   5#  '   5%     & 5(     P� 5)  "   ' �@J�IsMouseOver( . . �5*  &   �� ) � ��
* �����6R   5+  #   P� 5,  "   ' �@J�IsMouseOver( .  . �5-  &   �� ) � ��
* ���� 6Y   5.  #   51     53     54     55     � 58  
   $��	0,-50,0,0q�6    59     �� 5:     $��0 �6#   6/   �� 5;     6%   8 � RowDefinitions8 5=     �� 5?     6"   �� 5@     $��30 �6    6.   .+�5F     �� -	   5        9 ��Name$9 mainContent��5F  /   $��0,80,0,0q�6   $��0��6D   $��1��6Q   5G     �� 5J     $��30��6�   $��1��6�   $��0��6�   $��2��6�   ��6   �� # [ $ 	SkinColor�$ TwoWay=�$ PropertyChanged=�._�5K     �� $��Center=�6   ��5L     �� 5M     "7 ��6*   .R�5N     �� .+�5O  "   �� $��Right=�61   $��Center=�6M   6j   5P     5Q     .@�5S     �� $��当前用户:��6!   60   �� 5T     ��6!   �� *	User.Name+6>   �� 5U     $��30,0,0,0q�6    $��时间:��63   6@   �� 5V     $��0,0,40,0q�6    ��62   �� *CurrentTime+6Q   5W     5X     5Y     5[     5^     