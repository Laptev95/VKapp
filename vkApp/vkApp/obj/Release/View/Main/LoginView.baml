   M S B A M L   `   `   `  ���� @  <vkApp, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null/clr-namespace:vkApp.ControlsvkApp.Controls  3clr-namespace:vkApp.BehavioursvkApp.Behaviours      vkApp.View.Main.LoginView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  +controlsclr-namespace:vkApp.Controls  /
behavioursclr-namespace:vkApp.Behaviours    N� 	KeepAlive  .   N� Title$ 	LoginView��z�T�  � Triggers :�  :� RoutedEvent$ Page.Loaded��.[���    PageLoadAnim#��[   � 	Resources  
 VkLogo F�Name �� Left
 �� Top �� Stretch	 �� StrokeLineJoin  BackgroundBrush  AccentBrush  LoginButtonStyle
 �� 
TargetType �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels � ColumnDefinitions ��Name 
 VkIcon ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	       7  7  &	     7  7  �� .R�F� $
 Path��$��428.799��$��469.596��$ -2.98023e-008��$ -3.5733e-005��$
 Fill=�$��5��$	 Round=�8��  8�� |������G(�/�hۉ� �HC�9:Ќ�h@�� �O���n����(�y	��{���!��р�pHB������b��@�y	��{�HC�H1:�����b��� "
 ��.���  � ��8   ��  � ��
 �������  � ��$ 14(���  � ��$ SemiBold"���  � ��$ 	40,9,40,9q���  � ��$ 0q���  �@�Cursor$
 Hand����  � �� �� " ��.R��� $ border��#��z��#��z��#��z�� . ._�� #��z�� �� $
��Auto ��� .+��� $ VkIcon��#��z��$��0,2,15,0q�$��18��$��18������ .R�F� 8�� 
�������$ Uniform=��� $ contentPresenter��$��1��|�.  #��z����. # z #��z�� P�  �@J�IsMouseOver . . ��� $ border�� �@J�Opacity$	 0.8Q�P�  � �� . . ��� $ border�� �@J�Opacity$	 0.9Q�.��� .+�� $��Center=� � RowDefinitions �� $
��Auto ��� .+��� $��Center=�$��Center=� �� Orientation$ Vertical=�$��0,0,0,0q�.+�F� $	��200��$ Uniform=�#��[ #��[ �� $��Welcome��  ForegroundBrush#��[ $��Segoe UI SemiLight)�$��64(�$��0,0,0,0q� J� Opacity$	 0.7Q��� $��1��$.��(Войти через ВКонтакте��$��Center=�$��0,30,0,0q�#��[ ���� *LoginVkCommand+�� $��Normal"�$��Copyright © Laptev 2015��#��[ $��10(�$��Bottom=�$	 0.5Q�$��Center=�$��0,0,0,7q�