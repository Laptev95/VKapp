   M S B A M L   `   `   `  ����@  <vkApp, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:vkApp.ChromeWindowvkApp.ChromeWindow  5   	   3clr-namespace:vkApp.BehavioursvkApp.Behaviours  5   	   3clr-namespace:vkApp.ConvertersvkApp.Converters  5   	       vkApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   3chromeWindow clr-namespace:vkApp.ChromeWindow  5   	   /
behavioursclr-namespace:vkApp.Behaviours  5   	   "ignorehttp://www.ignore.com  5	   	   /
convertersclr-namespace:vkApp.Converters  5   	   -   5        $	��800��5   	   $	��600��6     � WindowStartupLocation$  Manual=�5   	    � Title$ ВКонтакте��5   G    � Topmost 5   	   �� *	IsChecked+ �� ElementName$ 	pinButton�� � WindowState 5   	   �� *WindowState+��5   	   �� *WindowWidth+��6'   �� *WindowHeight+ � Left 5   	   �� *
WindowLeft+
 � Top 6%   �� *	WindowTop+ � DataContext 5   	   �� *Main+   Locator �� Source# [  	 � 	Resources	 5        MainMenuGroups
 �� Source �� GroupDescriptions2  ,System.Windows.Data.PropertyGroupDescription   PropertyName��%m   &	       �� 5   
   
 66   �� *MainMenuItems+ 5        5      $ Group��6+   5      5      .  (System.Windows.Interactivity.Interaction   	Behaviors 5      .   (vkApp.ChromeWindow.ChromeWindowBehaviour  5   
   .��5       � -   5         �Name$ RootGrid��5        � ColumnDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#       � RowDefinitions 5%   
   �� 5&      �� 5'      $
��Auto �6   .+�5)   
   r�  r� LoadedBehavior$ Manual=�6    r� Volume$ 1Q�6/   � 5+   
   $	��200��6   $��0��6   $��3��6+   y�6<   �� *ShowSidebar+  BoolToVisibilityConverter �� 	Converter# [  5,      �� 5-      $��60 �6    �� 5.      $��80 �6    �� 5/      $��* �6    .+�51      � $��0��6   ���	#FF5376A0.+�52      ��  �� Orientation$ 
Horizontal=�6   .+�53      F�  
 VkIcon#��[ 6   
������� �� Stretch$ Uniform=�6G   $��24��6Y   $��Center=�6e   $��20,0,0,0q�6�   $
��Left=�6�   54      5I      � 5J      $��2��6   ���	#FF323F48 5K      �� 5L      $
��360* �6$   �� 5M      $	��150 �6$   .+�5O      �� $��0��6     CommonListBoxStyle#��[ 5P        MainMenuListBoxItemStyle#��[ 6�   $��Disabled=�5Q      ��5O   '   �� # [  �� SelectedItem 6f   �� *SelectedMainMenuItem+ �� SelectedIndex 5P   B   �� *SelectedMainMenuItemIndex+ �� Mode$ TwoWay=� 5R      *   $vkApp.Behaviours.TransitionBehaviour  5S        MainMenuLoadAnim   
Transition# [ 69      TransitionDelay$	 100��6h   ��5U      �� 5V      .R�5W      �  5X   "   �� 5Y   &   �� 5Z   &   .+�5\   "   F� $��0��6'   $��16��6N   $ Uniform=�6Y   $��0,0,20,0q�6k    J� SnapsToDevicePixels .  
���������68   �� *Icon+6�   �� 5]   "   $��Regular"�6C   $��14(�6X   $��1��6f   ���	#FFF8FFFF$��0,0,-1,0q�6�   ��6,   �� *Title+6�   5^      5_      5a      5b      � 5c      -   5        $ 	user_info��5c      $��1��6&   ���	#FF2D343A.+�5d      �� $��
85,20,0,35q�6   $��16(�6y   
���������60   �� *Main.Profile.FirstName+# [  6�   �� 5e      $��
85,40,0,15q�6   $��14(�6y   
���������60   �� *Main.Profile.LastName+# [  6�   � 5f      $��Center=�6   $��Center=�64   $��50��6O   $��
20,0,130,0q�6[   $��50��6o   .+�5g      �� -   5        $
��Mask��5g       �� CornerRadius$ 30��6)   ���	#FF2D343A6;   �� 5h       �� BitmapScalingMode$ HighQuality=�6j   $��0q�6�   $��UniformToFill=�6�   ��6   �� *Main.Profile.PhotoMedium+# [   J� OpacityMask 5i      !� 5j       !� Visual 6*   �� $
 Mask��5l      5m      5n      �� 5o      $��0��6     J� Opacity$	  0.2Q�6)   $��10��67   $��Right=�6B   ��5p      �� 5q      ! �� EndPoint$	! 1,0&�6*   " �� 
StartPoint$	" 0,0&�69   .��5r      � # � Color$# Black��6'   $ � Offset$$ 1Q�65   � 5s      $# 	#FF5376A0��6'   $$ 0Q�69   5t      5v      5w      � 5x   
   $��60��6   $��1��6   ���	#FF5376A0$	��Top=�6�   y�6B   �� *
ShowTopbar+# [ 6�    � 5y   
   -   5        %  �Name$% 	RootFrame��5y      &  � NavigationUIVisibility$& Hidden=�6#   $��1��6C   �� 5z   
   $��1��6   $ 
Horizontal=�6%   $	��Top=�6>   $��Right=�6V   $��10q�6r   .+�5{      d� -   5        ' d�Name$' 	pinButton��5{        PinButtonStyle#��[ 6.   $��0,0,15,0q�6V    . 6h   �� 5|        MinimizeButtonStyle#��[ 6   $��Bottom=�6B   $��0,0,15,0q�6]    . ��6�   �� *MinimizeWindowCommand+d� 5}      -   5        $' MaximizeButton��5}       	 MaximizeButtonStyle#��[	 63   $��Bottom=�6`   $��0,0,15,0q�6{    . ( d� 	IsChecked( 6�   �� *IsWindowMaximized+$ OneWay=���6�   �� *MaximizeWindowCommand+�� 5~       
 CloseButtonStyle#��[
 6    . ��6Z   �� *CloseWindowCommand+5      �� 5�   
   -   5        ) ��Name$) 
ResizeGrip��5�   C   $��1��6   $��0��6%   $��2��62   * � Cursor$* SizeNWSE��6W   $��Right=�6j   $��Bottom=�6�   6�   5�      5�      