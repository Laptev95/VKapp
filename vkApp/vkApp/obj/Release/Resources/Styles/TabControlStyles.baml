   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   TabItem.Selected.Background  �� Color  TabItem.Selected.Border  CommonTabControlStyle �� 
TargetType �� Property �� Value �� 
TargetType �Name J� SnapsToDevicePixels-   'System.Windows.Input.KeyboardNavigation    TabNavigation � ColumnDefinitions	 ��Name
 � RowDefinitions ��Name ��Name K� IsItemsHost    TabIndex K� ZIndex ��Name    DirectionalNavigation ��Name �� Triggers P� Property P� Value �� 
TargetName  TabItem.Static.Background �� EndPoint �� 
StartPoint � Color � Offset  TabItem.Static.Border   TabItem.MouseOver.Background  TabItem.MouseOver.Border  TabItem.Disabled.Background  TabItem.Disabled.Border 	 CommonTabItemStyle 
 FocusVisual  ForegroundBrush J� Opacity �� RelativeSource �� AncestorType ^� 
Conditions �� Binding  �� Value  AccentBrush�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %  &	        &	      &	 &     7  &	 U    &	 �    &	 �    &	     &	 '    &	 :    &		 M    7 
 7  7  7  7   7  7  7  7  7  7  7  7  7  7  7  7  7  �� $  #FFFFFF���� $  #ACACAC���� " ��.���  � ��$ 0,10,0,0q���  � ��$ Center=���  � ��$ Center=���  � ��
 ���� ��  � ��8   ��  � ��$ 0q���  � ��# � ����  � �� �� " ��.R�� $ templateRoot��}�.  . $ Local=� �� $	 ColumnDefinition0���� $	 ColumnDefinition1��$��0 �
 �� $ RowDefinition0��$
��Auto ��� $ RowDefinition1��$��* �.+��� $ headerPanel��
������ $��0�� . $��25,0,0,0q�$��0��$ 1��$ 1���� $ contentPanel��#��z��#��z��#��z��$��0��$ 	Contained=�$��1��$ 2��$ Local=�._��� $ PART_SelectedContentHost��$��SelectedContent��#��z��# z  P�  �@��TabStripPlacement$ Bottom=�. ��� $ headerPanel�� � ��$ 1���� $ contentPanel�� � ��$ 0���� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$
 Auto ��� $ headerPanel�� � ��$ 2,0,2,2q�P�  �@��TabStripPlacement$
 Left=�. ��� $ headerPanel�� � ��$ 0���� $ contentPanel�� � ��$ 0���� $ headerPanel�� � ��$ 0���� $ contentPanel�� � ��$ 1���� $ ColumnDefinition0�� � ��$
 Auto ��� $ ColumnDefinition1�� � ��$ * ��� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$ 0 ��� $ headerPanel�� � ��$ 2,2,0,2q�P�  �@��TabStripPlacement$ Right=�. ��� $ headerPanel�� � ��$ 0���� $ contentPanel�� � ��$ 0���� $ headerPanel�� � ��$ 1���� $ contentPanel�� � ��$ 0���� $ ColumnDefinition0�� � ��$ * ��� $ ColumnDefinition1�� � ��$
 Auto ��� $ RowDefinition0�� � ��$ * ��� $ RowDefinition1�� � ��$ 0 ��� $ headerPanel�� � ��$ 0,2,2,2q�P�  � {� .  . ��� $ templateRoot��# � �� � ���� $	 0,1&�$	 0,0&�.��� $ #F0F0F0��$	 0.0Q�� $ #E5E5E5��$	 1.0Q��� $  #ACACAC���� $	 0,1&�$	 0,0&�.��� $ #ECF4FC��$	 0.0Q�� $ #DCECFC��$	 1.0Q��� $  #7EB4EA���� $  #F0F0F0���� $  #D9D9D9���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��
 ���� ��  � ��8  ��  � ��$ 0q���  � ��$ 0q���  � ��$ 	15,3,15,4q���  � ��$ Stretch=���  � ��$ Stretch=���  � ��$ 13(���  � ��$ Normal"���  � �� �� " ��.R�� $ templateRoot�� . $��0,0,15,0q�.+��� $ 
mainBorder��#��z��$��0q�#��z��$��0q�._��� $ innerBorder��8�� $��0q�8�� $��-1q�$ 0Q��� $ contentPresenter��$��Header��|�.  #��z����. # z $	 0.6Q����� *HorizontalContentAlignment+ �� " ������ *VerticalContentAlignment+ �� " �� ^�  ��  �� *IsMouseOver+ �� *Self+  true��  �� *TabStripPlacement+ �� " ��  Left.0��� $ 
mainBorder��8   � ���� $ 
mainBorder��8   � ���� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q�^�  ��  �� *IsMouseOver+ �� *Self+  true��  �� *TabStripPlacement+ �� " ��
  Bottom.0��� $ 
mainBorder��8   � ���� $ 
mainBorder��8   � ���� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q�^�  ��  �� *IsMouseOver+ �� *Self+  true��  �� *TabStripPlacement+ �� " ��	  Right.0��� $ 
mainBorder��8 	  � ���� $ 
mainBorder��8 
  � ���� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q�^�  ��  �� *IsMouseOver+ �� *Self+  true��  �� *TabStripPlacement+ �� " ��  Top.0��� $ contentPresenter�� �@J�Opacity$
 0.85Q�^�  ��  �� *	IsEnabled+ �� *Self+	  false��  �� *TabStripPlacement+ �� " ��  Left.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder��8   � ���� $ 
mainBorder��8   � ���� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q�^�  ��  �� *	IsEnabled+ �� *Self+	  false��  �� *TabStripPlacement+ �� " ��
  Bottom.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder��8   � ���� $ 
mainBorder��8   � ���� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q�^�  ��  �� *	IsEnabled+ �� *Self+	  false��  �� *TabStripPlacement+ �� " ��	  Right.0��� $ contentPresenter�� �@J�Opacity$
 0.56Q��� $ 
mainBorder��8   � ���� $ 
mainBorder��8   � ���� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q�^�  ��  �� *	IsEnabled+ �� *Self+	  false��  �� *TabStripPlacement+ �� " ��  Top^�  ��  �� *
IsSelected+ �� *Self+	  false��  �� *TabStripPlacement+ �� " ��  Left.0��� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q�^�  ��  �� *
IsSelected+ �� *Self+  true��  �� *TabStripPlacement+ �� " ��  Left.0���  �@K�ZIndex$ 1����  � ��$ 
-2,-2,0,-2q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 1,1,0,1q��� $ 
mainBorder�� � ��$ 1,1,0,1q�^�  ��  �� *
IsSelected+ �� *Self+	  false��  �� *TabStripPlacement+ �� " ��
  Bottom.0��� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q�^�  ��  �� *
IsSelected+ �� *Self+  true��  �� *TabStripPlacement+ �� " ��
  Bottom.0���  �@K�ZIndex$ 1����  � ��$ 
-2,0,-2,-2q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 1,0,1,1q��� $ 
mainBorder�� � ��$ 1,0,1,1q�^�  ��  �� *
IsSelected+ �� *Self+	  false��  �� *TabStripPlacement+ �� " ��	  Right.0��� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q�^�  ��  �� *
IsSelected+ �� *Self+  true��  �� *TabStripPlacement+ �� " ��	  Right.0���  �@K�ZIndex$ 1����  � ��$ 
0,-2,-2,-2q��� $ innerBorder�� �@J�Opacity$ 1Q��� $ innerBorder�� � ��$ 0,1,1,1q��� $ 
mainBorder�� � ��$ 0,1,1,1q�^�  ��  �� *
IsSelected+ �� *Self+	  false��  �� *TabStripPlacement+ �� " ��  Top^�  ��  �� *
IsSelected+ �� *Self+  true��  �� *TabStripPlacement+ �� " ��  Top.0���  �@K�ZIndex$ 1���� $ contentPresenter�� �@J�Opacity$ 1Q���  � ��$ Normal"��� $ 
mainBorder��8   � ����  � ��
 �����