   M S B A M L   `   `   `  ���� @  <vkApp, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:vkApp.HelpersvkApp.Helpers       vkApp.View.Main.GroupsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /helpersclr-namespace:vkApp.Helpers     X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     N�Name$  pageRoot�� N� 	KeepAlive .     MainBackgroundBrush N� 
Background# [   N� Title$ 
GroupsView��z�T�  � Triggers :�  :� RoutedEvent$ Page.Loaded��.[���   PageLoadAnim#��[  � 	Resources   GroupsCollection �� Source��%#   &	       ��  �� *Groups+.���  � RowDefinitions �� $��60 ��� .+�� $��60��$��1�����	#FF5376A0$	��Top=�.+�� ���	#FF5E81AB$
��Left=�.+��� 	 �� Orientation$	 
Horizontal=�$��	20,0,20,0q�.+���   MainBackButtonStyle#��[ ���� *Main.GoBackCommand+  Locator
 �� Source#
 [ y��� *Main.CanGoBack+#
 [   BoolToVisibilityConverter �� 	Converter# [ �� $��Группы��$��Center=�$��16(�
�������� $��1��.+�%  Xceed.Wpf.Toolkit.BusyIndicator    CommonProgressBarStyle   ProgressBarStyle# [   BusyIndicatorStyle#��[    IsBusy �� *Main.IsWorking+#
 [ .���� $��24,0,0,0q�$��0,5,0,0q�  CommonListBoxStyle#��[  %� 
ScrollUnit$ Pixel=�$��Disabled=� 	 FriendListBoxItemStyle#��[	 ���� #
 [ ���� .R��  � Orientation$ 
Horizontal=����� .R���  
 SimpleButtonStyle#��[
 $	��120��$	��120������ * DataContext.GoToSocietyCommand+ �� ElementName$ pageRoot������  � ToolTip �� *Name+z�T�  :� $ FrameworkElement.Loaded��.[���   FriendLoadAnim#��[ .���  �Name$ RootGrid�� �� �� $��40 �.+�� $��2��.+��� $��UniformToFill=� �� BitmapScalingMode$ HighQuality=�$   vkApp.Helpers.ImageAsyncHelper   	SourceUri �� *PhotoMedium+�� $��1��
���   � J� Opacity$	 0.8Q��� $��1��$��Center=�$��Normal"�$��11(�
�������$
��Wrap=�$��CharacterEllipsis=�$��5q����� *Name+