   M S B A M L   `   `   `  ����@  <vkApp, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null-clr-namespace:vkApp.HelpersvkApp.Helpers  5      !    vkApp.View.Main.FriendsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /helpersclr-namespace:vkApp.Helpers     5      X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5          N�Name$  pageRoot��5	       N� 	KeepAlive .     MainBackgroundBrush N� 
Background# [  5
       N� Title$ FriendsView��69   z�5      T� 5   
    � Triggers 5      :� 5   
    :� RoutedEvent$ Page.Loaded��6   .[�5      ��   PageLoadAnim#��[ 6   5       � 	Resources 5        FriendsCollection �� Source��%2   &	       �� 5   
    69   �� *	Friends+5      .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      .+�5   
   � $��60��6   $��1��6   ���	#FF5376A0$	��Top=�6B   .+�5       � ���	#FF5E81AB$
��Left=�6*   .+�5!      �� 	 �� Orientation$	 
Horizontal=�6   $��	20,0,20,0q�66   .+�5"      ��   MainBackButtonStyle#��[ 6   ��6J   �� *Main.GoBackCommand+  Locator
 �� Source#
 [ y�5#      �� *Main.CanGoBack+#
 [   BoolToVisibilityConverter �� 	Converter# [ �� 5$      $��Друзья��6    $��Center=�6.   $��16(�6I   
�������6W   5%      5&      5'      � 5(   
   $��1��6   .+�5)      %  Xceed.Wpf.Toolkit.BusyIndicator    CommonProgressBarStyle   ProgressBarStyle# [ 6d     BusyIndicatorStyle#��[ 6�      IsBusy 6!   �� *Main.IsWorking+#
 [ .��5*      �� $��24,0,0,0q�6   $��0,5,0,0q�6,     CommonListBoxStyle#��[ 6�    %� 
ScrollUnit$ Pixel=�5+      $��Disabled=�6D    	 FriendListBoxItemStyle#��[	 5,      ��5*   >   �� #
 [ ��5-      �� 5.      .R�5/      �  � Orientation$ 
Horizontal=�6(   50      ��52      �� 53      .R�54      ��  
 SimpleButtonStyle#��[
 6%   $	��120��55   "   $	��120��6.   ��54   P   �� *DataContext.GoToFriendCommand+ �� ElementName$ pageRoot����6�   ��  � ToolTip 55   ;   �� *Name+z�56   "   T� 57   &    59   "   :� 5:   &   $ FrameworkElement.Loaded��63   .[�5;   *   ��   FriendLoadAnim#��[ 6:   5<   '   .��5>   "   �  �Name$ RootGrid��6'    5?   &   �� 5@   *   �� 5A   *   $
��Auto �68   .+�5C   &   � $��2��6+   .+�5D   *   �� $��UniformToFill=�6k    �� BitmapScalingMode$ HighQuality=�6�   $   vkApp.Helpers.ImageAsyncHelper   	SourceUri 60   �� *PhotoMedium+6�   5E   '   �� 5F   &   $��1��60   
���   � J� Opacity$	 0.8Q�6J   �� 5G   &   $��1��61   .+�5H   *   �� $��Normal"�6O   $��11(�6c   $��5,3,5,0q�6q   $��CharacterEllipsis=�6�   $	 0.8Q�6�   
���������64   �� *	FirstName+6�   �� 5I   *   $��Segoe UI SemiLight)�6N   $��12(�6n   $��5,-2,5,7q�6|   $��CharacterEllipsis=�6�   
���������64   �� *
LastName+6�   5J   '   5K   #   5L      5M      5O      5P      5Q      5R      5S      