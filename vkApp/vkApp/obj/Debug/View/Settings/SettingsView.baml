   M S B A M L   `   `   `  ����@  <vkApp, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null/clr-namespace:vkApp.ControlsvkApp.Controls  5      3clr-namespace:vkApp.BehavioursvkApp.Behaviours  5	      &     vkApp.View.Settings.SettingsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1controlsclr-namespace:vkApp.Controls     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      /
behavioursclr-namespace:vkApp.Behaviours  5	      -   5           vkApp.Controls.PageBase   Name$  pageRoot��5         vkApp.Controls.PageBase   Loaded$ SettingsView_OnLoaded��6    N� Title$ SettingsView��5
       N� 	KeepAlive .     MainBackgroundBrush N� 
Background# [  5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� 
���   �$��2��6!   � 5   
   $	��200��6   ���	#FF323F48.+�5      �� .+�5      �� -   5         ��Name$ SettingsButton��5      $
��Left=�61   $��0,5,0,0q�6L    � Cursor$
 Hand��6]   	 � ToolTip$	 
Назад��5   B   ��6   �� *CloseSettingsCommand+��5      �� 5       
 �� 
TargetType"
 ��6*   .R�5!      ��  ��Name$ 	rootPanel��6)    J� Opacity$	 0.7Q�6<    �� Orientation$ 
Horizontal=�6J   
������ .+�5"   "   F�   BackIcon#��[ 6'     SidebarForegroundBrush#��[ 6H    �� Stretch$ Uniform=�6w   $��5��6�   $��18,3,0,0q�6�   �� 5#   "   $��Center=�6,   $
��Left=�6G   #��[ 6b   $ 1Q�6�   $��13(�6�   $��6,1,0,0q�6�   $��Настройки��5$   ,   $��Regular"�6=   &   System.Windows.Media.TextOptions   TextFormattingMode$ Display=�6R   5%       �� Triggers 5&      P� 5'   "    P� Property �@J�IsMouseOver P� Value . . �5(   &   ��  �� 
TargetName$ 	rootPanel��6J    �� Property �@J�Opacity �� Value$ 1Q�6@   6J   5)   #   P� 5*   "    � �� . . �5+   &   �� $ 	rootPanel��6L    �@J�Opacity$	 0.6Q�6@   6L   5,   #   5.      50      �� 52      -   5         ��Name$ MenuListBox��52      $��0,30,0,0q�6/   $��	0,10,0,10q�6A   $��Disabled=�6U   
�������  CommonListBoxStyle#��[ 53   -     MainMenuListBoxItemStyle#��[ 6Y    �� SelectedIndex$ 0��54      ��52   �   �� *	MenuItems+.  (System.Windows.Interactivity.Interaction   	Behaviors 55      *   $vkApp.Behaviours.TransitionBehaviour  56        MainMenuLoadAnim   
Transition# [ 69      TransitionDelay$	 100��6h   ��58      �� 59      .R�5:      �� $��Segoe UI SemiLight)�6=   ��6(   �� *Key+6=   5;      5=      5>      5?       � 5@   
   -   5          �Name$ SettingsFrame��5@      $��1��6'     � JournalOwnership$ OwnsJournal=�6v     � NavigationUIVisibility$ Hidden=�5A        � Source 5@   7   �� *SelectedItem.Value+ �� ElementName$ MenuListBox��5A   0   �� 5B   
   #��[ 6   $��1��6C   $��Right=�6M   $	 0.1Q�6i   $��2��6w   5C      5D      