   M S B A M L   `   `   `  ����@  <vkApp, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null/clr-namespace:vkApp.ControlsvkApp.Controls  5      3clr-namespace:vkApp.BehavioursvkApp.Behaviours  5          vkApp.View.Main.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      +controlsclr-namespace:vkApp.Controls  5      /
behavioursclr-namespace:vkApp.Behaviours  5        N� 	KeepAlive  .   N� Title$ 	LoginView��5      z�5      T� 5   
    � Triggers 5      :� 5   
    :� RoutedEvent$ Page.Loaded��6   .[�5      ��    PageLoadAnim#��[  6   5       � 	Resources 5       
 VkLogo F�Name �� Left
 �� Top �� Stretch	 �� StrokeLineJoin  BackgroundBrush  AccentBrush  LoginButtonStyle
 �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels � ColumnDefinitions ��Name 
 VkIcon ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	       7  7  &	 I    7  7  �� 5   
   .R�5      F� $
 Path��6   $��428.799��6!   $��469.596��61   $ -2.98023e-008��6B   $ -3.5733e-005��6^   $
 Fill=�6x   $��5��6�   $	 Round=�6�   8��  8�� |������G(�/�hۉ� �HC�9:Ќ�h@�� �O���n����(�y	��{���!��р�pHB������b��@�y	��{�HC�H1:�����b�6   5      �� 5   
   "
 ��6)   .�5      ��  � ��8   6+   �� 5       � ��
 �����6+   �� 5       � ��$ 14(�6)   �� 5       � ��$ SemiBold"�6+   �� 5        � ��$ 	40,9,40,9q�6(   �� 5!       � ��$ 0q�60   �� 5"       �@�Cursor$
 Hand��6'   �� 5#       � �� 5$      �� 5%      " ��6&   .R�5&      �� $ border��6!   #��z��61   #��z��6]   #��z��6�    . ._�5'      � #��z��6#    5(   "   �� 5)   &   $
��Auto �67   �� 5*   &   .+�5,   "   �� $ VkIcon��61   #��z��6A   $��0,2,15,0q�6k   $��18��6}   $��18��6�   ��5-   &   �� 5.   *   .R�5/   .   F� 8�� 
�������$ Uniform=�6_   50   +   52   #   �� 53   "   $ contentPresenter��63   $��1��6M   |�.  #��z��6o   ��. # z 6�   #��z��6	  54      55       56      P� 57       �@J�IsMouseOver . . �58   "   �� $ border��6<    �@J�Opacity$	 0.8Q�6P   59      P� 5:       � �� . . �5;   "   �� $ border��6<    �@J�Opacity$	 0.9Q�6P   5<      5>      5@      5A      5B      .��5D      � .+�5E   
   � $��Center=�6    � RowDefinitions 5F      �� 5G      $
��Auto �6    �� 5H      .+�5J      �� $��Center=�6   $��Center=�66    �� Orientation$ Vertical=�6Q   $��0,0,0,0q�6h   .+�5K      F� $	��200��6   $ Uniform=�6#   #��[ 65   #��[ 6Y   �� 5L      $��Welcome��6     ForegroundBrush#��[ 6+   $��Segoe UI SemiLight)�6Y   $��64(�6y   $��0,0,0,0q�6�    J� Opacity$	 0.7Q�6�   5M      �� 5N      $��1��6   $.��(Войти через ВКонтакте��6"   $��Center=�6B   $��0,30,0,0q�6_   #��[ 6�   ��6q   �� *LoginVkCommand+6�   5O      �� 5P   
   $��Normal"�6   $��Copyright © Laptev 2015��6(   #��[ 6G   $��10(�6u   $��Bottom=�6�   $	 0.5Q�6�   $��Center=�6�   $��0,0,0,7q�6�   5Q      5R      