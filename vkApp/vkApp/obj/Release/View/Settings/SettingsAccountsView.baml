   M S B A M L   `   `   `  ���� 	  vkApp.    (vkApp.View.Settings.SettingsAccountsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008        MainBackgroundBrush  N� 
Background#  [   N� Title$ SettingsAccountsView��z�T�  � Triggers :�  :� RoutedEvent$ Page.Loaded��.[���   PageLoadAnim#��[ .��� .+��� $��28(�$
��Thin"�$��
24,10,0,15q�  ForegroundBrush#��[ �� $��1��$��Bottom=�#��[  J� SnapsToDevicePixels . $��0,0,0,0q� J� Opacity$
 0.15Q��� $��	24,20,0,0q�$	��300��$
��Left=�.+���   AccentBrush#��[ $��18(�$��Segoe UI SemiLight)��� $��0,10,0,0q�$	 0.7Q�$��12(�#��[ � $��0,10,0,0q� � ColumnDefinitions �� $
��Auto ��� �� $
��Auto �.+�� $��0��$��36��$��36��#��[ .+��� $��Right=�$��1��$��36��$��36������ *Main.Profile.PhotoMedium+  Locator �� Source# [ �� $��1��$��5,0,0,0q�$	 0.8Q�.+��� -    ��Name$ UsernameTextBlock��$
��Left=�$��14(�$��Medium"�#��[ ���� *Main.Profile.FirstName+# [ �� $
��Left=�$��12(�#��[ ���� *Main.Profile.LastName+# [ �� $��2��$��20,0,0,0q�  CommonButtonStyle#��[ $#��Сменить аккаунт��$��Center=����� *SignOutVkCommand+�� #��[   CommonCheckBoxStyle#��[ $P��JТрансляция аудиозаписей на мою страницу��$��0,10,0,0q�	 d� 	IsChecked	 �� *Main.EnableStatusBroadcasting+# [ 
 �� Mode$
 TwoWay=�