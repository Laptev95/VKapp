   M S B A M L   `   `   `  ����	  vkApp.    (vkApp.View.Settings.SettingsAccountsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5         MainBackgroundBrush  N� 
Background#  [  5       N� Title$ SettingsAccountsView��5	      z�5      T� 5   
    � Triggers 5      :� 5   
    :� RoutedEvent$ Page.Loaded��6   .[�5      ��   PageLoadAnim#��[ 6   5      .��5      � .+�5   
   �� $��28(�6   $
��Thin"�6"   $��
24,10,0,15q�64     ForegroundBrush#��[ 6H   �� 5   
   $��1��6   $��Bottom=�6   #��[ 6:    J� SnapsToDevicePixels . $��0,0,0,0q�6}    J� Opacity$
 0.15Q�6�   �� 5   
   $��	24,20,0,0q�6   $	��300��6(   $
��Left=�64   .+�5      ��   AccentBrush#��[ 6   $��18(�6B   $��Segoe UI SemiLight)�6P   �� 5      $��0,10,0,0q�6   $	 0.7Q�6*   $��12(�68   #��[ 6F   � 5      $��0,10,0,0q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      �� 5       $
��Auto �6'   .+�5"      � $��0��6   $��36��6'   $��36��62   #��[ 6>   .+�5#      �� $��Right=�6i   $��1��6�   $��36��6�   $��36��6�   ��6   �� *Main.Profile.PhotoMedium+  Locator �� Source# [ 6�   5$      �� 5%      $��1��6   $��5,0,0,0q�6-   $	 0.8Q�6>   .+�5&      �� -   5         ��Name$ UsernameTextBlock��5&       $
��Left=�6�   $��14(�6�   $��Medium"�6�   #��[ 6�   ��6;   �� *Main.Profile.FirstName+# [ 6�   �� 5'      $
��Left=�6i   $��12(�6�   #��[ 6�   ��6!   �� *Main.Profile.LastName+# [ 6�   5(      �� 5)      $��2��6   $��20,0,0,0q�6)     CommonButtonStyle#��[ 6;   $#��Сменить аккаунт��6f   $��Center=�6�   ��6�   �� *SignOutVkCommand+5*      �� 5+      #��[ 6     CommonCheckBoxStyle#��[ 6E   $P��JТрансляция аудиозаписей на мою страницу��6r   $��0,10,0,0q�6�   	 d� 	IsChecked	 6�   �� *Main.EnableStatusBroadcasting+# [ 
 �� Mode$
 TwoWay=�5,      5-      5.      