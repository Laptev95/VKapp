   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   AudioItemTemplate  ��Name  SimpleButtonStyle �� ElementName � Triggers :� RoutedEvent  AudioLoadAnim � ColumnDefinitions ��Name � ToolTip J� Opacity �� Triggers	 �� Value
 �� Binding �� Mode  AccentBrush �� Value �� 
TargetName �� Property �� Path  PostItemDataTemplate�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %v  &	        7  7  7  7  7  7  &	 �    7   �� .R��� $  RootElement��8��  $��0,5,0,5q�$��32������ *DataContext.PlayAudioCommand+$ pageRoot������ z�T�  :� $ FrameworkElement.Loaded��.[��� 8�� .��� 
������ $��Center=� �� $��12 ��� $
��0.5* �$	��500���� $
��0.3* ��� $
��0.2* �.+��� $ Title��$��1��$��13(�$��CharacterEllipsis=�$��0,0,5,0q����� *Artist+ �� *Artist+�� 8�� $��2��$
��Left=�$	 0.6Q�$��0,0,0,0q����� *Title+.���� $ Artist��$��13(�$��CharacterEllipsis=����� *Title+ �� *Artist+�� $ Duration��$��3��$��Right=�$	 0.6Q�$��12(�$��Center=�$��0,0,24,0q�$��CharacterEllipsis=����� *
Duration+ �� $
	 True��
 �� *	IsPlaying+$ OneWay=�.a��� 8  $ Title�� � ���� 8  $ Artist�� � ���� 8  $ Duration�� � ���� $ Title�� � ��$ SemiBold"��� $ Artist�� � ��$ SemiBold"��� $ Duration�� � ��$ SemiBold"��� $ Title�� �@J�Opacity$ 1Q��� $ Artist�� �@J�Opacity$ 1Q��� $ Duration�� �@J�Opacity$ 1Q��� $
	 True��
 �� $ Artist��$ IsMouseOver�.a��� $ Artist�� �@�Cursor$
 Hand���� $ Artist�� � ��$ 	Underline{��� .R��� .+��� 8��  ���� *Audios+�� 
����  �$��1��$��0,5,0,5q�$	 0.3Q�