   M S B A M L   `   `   `  ���� @  <vkApp, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null7 clr-namespace:vkApp.ChromeWindowvkApp.ChromeWindow  3clr-namespace:vkApp.BehavioursvkApp.Behaviours  3clr-namespace:vkApp.ConvertersvkApp.Converters      vkApp.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  3chromeWindow clr-namespace:vkApp.ChromeWindow  /
behavioursclr-namespace:vkApp.Behaviours  "ignorehttp://www.ignore.com  /
convertersclr-namespace:vkApp.Converters  -   $	��800��$	��600��  � WindowStartupLocation$  Manual=� � Title$ ВКонтакте�� � Topmost �� *	IsChecked+ �� ElementName$ 	pinButton�� � WindowState �� *WindowState+���� *WindowWidth+���� *WindowHeight+ � Left �� *
WindowLeft+
 � Top �� *	WindowTop+ � DataContext �� *Main+   Locator �� Source# [  	 � 	Resources	   MainMenuGroups
 �� Source �� GroupDescriptions2  ,System.Windows.Data.PropertyGroupDescription   PropertyName��%?   &	       �� 
 �� *MainMenuItems+   $ Group��.  (System.Windows.Interactivity.Interaction   	Behaviors .   (vkApp.ChromeWindow.ChromeWindowBehaviour  .��� -    �Name$ RootGrid�� � ColumnDefinitions �� $
��Auto ���  � RowDefinitions �� �� $
��Auto �.+�r�  r� LoadedBehavior$ Manual=� r� Volume$ 1Q�� $	��200��$��0��$��3��y��� *ShowSidebar+  BoolToVisibilityConverter �� 	Converter# [  �� $��60 ��� $��80 ��� $��* �.+�� $��0�����	#FF5376A0.+���  �� Orientation$ 
Horizontal=�.+�F�  
 VkIcon#��[ 
������� �� Stretch$ Uniform=�$��24��$��Center=�$��20,0,0,0q�$
��Left=�� $��2�����	#FF323F48 �� $
��360* ��� $	��150 �.+��� $��0��  CommonListBoxStyle#��[   MainMenuListBoxItemStyle#��[ $��Disabled=����� # [  �� SelectedItem �� *SelectedMainMenuItem+ �� SelectedIndex �� *SelectedMainMenuItemIndex+ �� Mode$ TwoWay=� *   $vkApp.Behaviours.TransitionBehaviour    MainMenuLoadAnim   
Transition# [    TransitionDelay$	 100������ .R��  �� �� .+�F� $��0��$��16��$ Uniform=�$��0,0,20,0q� J� SnapsToDevicePixels .  
����������� *Icon+�� $��Regular"�$��14(�$��1�����	#FFF8FFFF$��0,0,-1,0q����� *Title+� -   $ 	user_info��$��1�����	#FF2D343A.+��� $��
85,20,0,35q�$��16(�
����������� *Main.Profile.FirstName+# [  �� $��
85,40,0,15q�$��14(�
����������� *Main.Profile.LastName+# [  � $��Center=�$��Center=�$��50��$��
20,0,130,0q�$��50��.+��� -   $
��Mask�� �� CornerRadius$ 30�����	#FF2D343A��  �� BitmapScalingMode$ HighQuality=�$��0q�$��UniformToFill=����� *Main.Profile.PhotoMedium+# [   J� OpacityMask !�  !� Visual �� $
 Mask���� $��0��  J� Opacity$	  0.2Q�$��10��$��Right=����� ! �� EndPoint$	! 1,0&�" �� 
StartPoint$	" 0,0&�.��� # � Color$# Black��$ � Offset$$ 1Q�� $# 	#FF5376A0��$$ 0Q�� $��60��$��1�����	#FF5376A0$	��Top=�y��� *
ShowTopbar+# [  � -   %  �Name$% 	RootFrame��&  � NavigationUIVisibility$& Hidden=�$��1���� $��1��$ 
Horizontal=�$	��Top=�$��Right=�$��10q�.+�d� -   ' d�Name$' 	pinButton��  PinButtonStyle#��[ $��0,0,15,0q� . ��   MinimizeButtonStyle#��[ $��Bottom=�$��0,0,15,0q� . ���� *MinimizeWindowCommand+d� -   $' MaximizeButton�� 	 MaximizeButtonStyle#��[	 $��Bottom=�$��0,0,15,0q� . ( d� 	IsChecked( �� *IsWindowMaximized+$ OneWay=����� *MaximizeWindowCommand+��  
 CloseButtonStyle#��[
  . ���� *CloseWindowCommand+�� -   ) ��Name$) 
ResizeGrip��$��1��$��0��$��2��* � Cursor$* SizeNWSE��$��Right=�$��Bottom=�