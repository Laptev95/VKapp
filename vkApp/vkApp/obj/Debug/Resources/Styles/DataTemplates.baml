   M S B A M L   `   `   `  ����R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   AudioItemTemplate  ��Name  SimpleButtonStyle �� ElementName � Triggers :� RoutedEvent  AudioLoadAnim � ColumnDefinitions ��Name � ToolTip J� Opacity �� Triggers	 �� Value
 �� Binding �� Mode  AccentBrush �� Value �� 
TargetName �� Property �� Path  PostItemDataTemplate�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %�  &	        7  7  7  7  7  7  &	 �    7   �� 5      .R�5   
   �� $  RootElement��6   8��  $��0,5,0,5q�5      $��32��6#   ��5   Q   �� *DataContext.PlayAudioCommand+$ pageRoot����6�   �� z�5      T� 5       5
      :� 5      $ FrameworkElement.Loaded��6   .[�5      �� 8�� 6&   5      .��5      � 
������ $��Center=�6,    5      �� 5      $��12 �6'   �� 5      $
��0.5* �6'   $	��500��64   �� 5      $
��0.3* �6'   �� 5      $
��0.2* �6'   .+�5      �� $ Title��6,   $��1��6   $��13(�6T   $��CharacterEllipsis=�6b   $��0,0,5,0q�5   7   ��5   ;   �� *Artist+ 5      �� *Artist+67   �� 5      8�� $��2��6D   $
��Left=�6T   $	 0.6Q�6o   $��0,0,0,0q�6}   ��5      �� *Title+.��5      �� $ Artist��6    $��13(�6H   $��CharacterEllipsis=�6V   ��60   �� *Title+ 5      �� *Artist+5      �� 5      $ Duration��6   $��3��6.   $��Right=�5      $	 0.6Q�68   $��12(�6F   $��Center=�6T   $��0,0,24,0q�6o   $��CharacterEllipsis=�6�   ��5   >   �� *
Duration+5   �   5      5        5!   
   �� 5"      $
	 True��6E   
 6   �� *	IsPlaying+$ OneWay=�.a�5#      �� 8  $ Title��6T    � ���� 5$      8  $ Artist��6T    � ���� 5%      8  $ Duration��6T    � ���� 5&      $ Title��6@    � ��$ SemiBold"�6/   6@   �� 5'      $ Artist��6@    � ��$ SemiBold"�6/   6@   �� 5(      $ Duration��6@    � ��$ SemiBold"�6/   6@   �� 5)      $ Title��66    �@J�Opacity$ 1Q�6,   66   �� 5*      $ Artist��66    �@J�Opacity$ 1Q�6,   66   �� 5+      $ Duration��66    �@J�Opacity$ 1Q�6,   66   5,      �� 50      $
	 True��6T   
 6   �� $ Artist��$ IsMouseOver�.a�51      �� $ Artist��6    �@�Cursor$
 Hand��6?   �� 52      $ Artist��6    � ��$ 	Underline{�6H   53      55      �� 57      .R�58   
   �� .+�59      �� 8��  ��6   �� *Audios+6:   �� 5:      
����  �$��1��6$   $��0,5,0,5q�6/   $	 0.3Q�6@   5;      5<      5>      