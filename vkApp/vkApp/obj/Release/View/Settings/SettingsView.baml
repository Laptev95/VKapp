   M S B A M L   `   `   `  ���� @  <vkApp, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null/clr-namespace:vkApp.ControlsvkApp.Controls  3clr-namespace:vkApp.BehavioursvkApp.Behaviours  &     vkApp.View.Settings.SettingsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1controlsclr-namespace:vkApp.Controls     c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  /
behavioursclr-namespace:vkApp.Behaviours  -      vkApp.Controls.PageBase   Name$  pageRoot��   vkApp.Controls.PageBase   Loaded$ SettingsView_OnLoaded�� N� Title$ SettingsView�� N� 	KeepAlive .     MainBackgroundBrush N� 
Background# [  .���  � ColumnDefinitions �� $
��Auto ���  � RowDefinitions �� �� $
��Auto �.+��� 
���   �$��2��� $	��200�����	#FF323F48.+��� .+��� -    ��Name$ SettingsButton��$
��Left=�$��0,5,0,0q� � Cursor$
 Hand��	 � ToolTip$	 
Назад������ *CloseSettingsCommand+���� 
 �� 
TargetType"
 ��.R���  ��Name$ 	rootPanel�� J� Opacity$	 0.7Q� �� Orientation$ 
Horizontal=�
������ .+�F�   BackIcon#��[   SidebarForegroundBrush#��[  �� Stretch$ Uniform=�$��5��$��18,3,0,0q��� $��Center=�$
��Left=�#��[ $ 1Q�$��13(�$��6,1,0,0q�$��Настройки��$��Regular"�&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  �� 
TargetName$ 	rootPanel�� �� Property �@J�Opacity �� Value$ 1Q�P�  � �� . . ��� $ 	rootPanel�� �@J�Opacity$	 0.6Q��� -    ��Name$ MenuListBox��$��0,30,0,0q�$��	0,10,0,10q�$��Disabled=�
�������  CommonListBoxStyle#��[   MainMenuListBoxItemStyle#��[  �� SelectedIndex$ 0������ *	MenuItems+.  (System.Windows.Interactivity.Interaction   	Behaviors *   $vkApp.Behaviours.TransitionBehaviour    MainMenuLoadAnim   
Transition# [    TransitionDelay$	 100������ .R��� $��Segoe UI SemiLight)����� *Key+ � -     �Name$ SettingsFrame��$��1��  � JournalOwnership$ OwnsJournal=�  � NavigationUIVisibility$ Hidden=�  � Source �� *SelectedItem.Value+ �� ElementName$ MenuListBox���� #��[ $��1��$��Right=�$	 0.1Q�$��2��