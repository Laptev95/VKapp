   M S B A M L   `   `   `  ���� O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4   PhoneProgressBarSliderThumb  �� 
TargetType J� IsHitTestVisible  PhoneProgressBarSliderStyle �� 
TargetType �� Property �� Value �Name � RowDefinitions ]�Name ]� Thumb	 n�Name
 ]� IncreaseRepeatButton ]� DecreaseRepeatButton  CommonProgressBarStyle  AccentBrush'   !System.Windows.VisualStateManager    VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� RepeatBehavior g� Duration �� 
TargetName �� TargetProperty R� KeyTime R� Value  System.Windows.Visibility9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� Value O� KeyTime   EasingFunction4  .System.Windows.Media.Animation.ExponentialEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode   Exponent g� 	BeginTime ��Name J� Opacity ��Name ��Name  HeaderProgressBarStyle �� BasedOn  BusyIndicatorStyle%  Xceed.Wpf.Toolkit.BusyIndicator  ForegroundBrush  ��Name! ��Name"   BusyContent#   IsBusy$ � IsIndeterminate�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     4xctk)http://schemas.xceed.com/wpf/xaml/toolkit  1system&clr-namespace:System;assembly=mscorlib  %J  &	        &	 0     7   &	 �    7  7  7  7  7  7  &	 �
    7  &	 d    7  7  �� "  n�.R���  .  $��3��$��3��#��z���� " ��.���  �@�Maximum$
 3000Q���  �@�Minimum$ 0Q���  �@J�Opacity$ 1Q���  � �� �� "  ��.R�� $ GridRoot�� �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�]� $ 
PART_Track��$��1�� n� $	 Thumb��8��  #��z��
 �� $��Slider.IncreaseLarge����Z�  �� $��Slider.DecreaseLarge����Z� �� " �.���  � ��8   ��  �@J�IsHitTestVisible .  ��  � ��$ 12q���  � �� �� "  �.R��    CommonStates��.   Determinate��  Indeterminate��. �� $ Forever��$ 
00:00:04.4D�.��T� $ IndeterminateRoot��$ 
Visibility�..�i� $ 0��  Visible=�T� $ DeterminateRoot��$ 
Visibility�..�i� $ 0��  	Collapsed=�U� $ Slider1��$ Value�.\�  $
 1000Q�$ 
00:00:00.5��   $ EaseOut=�$ 1Q��� $
 2000Q�$ 
00:00:02.0��  $
 3000Q�$ 
00:00:02.5��   $ EaseIn=�$ 1Q�U� $ Slider2��$ Value�$ 
00:00:00.2X�.\�  $
 1000Q�$ 
00:00:00.5��   $ EaseOut=�$ 1Q��� $
 2000Q�$ 
00:00:02.0��  $
 3000Q�$ 
00:00:02.5��   $ EaseIn=�$ 1Q�U� $ Slider3��$ Value�$ 
00:00:00.4X�.\�  $
 1000Q�$ 
00:00:00.5��   $ EaseOut=�$ 1Q��� $
 2000Q�$ 
00:00:02.0��  $
 3000Q�$ 
00:00:02.5��   $ EaseIn=�$ 1Q�U� $ Slider4��$ Value�$ 
00:00:00.6X�.\�  $
 1000Q�$ 
00:00:00.5��   $ EaseOut=�$ 1Q��� $
 2000Q�$ 
00:00:02.0��  $
 3000Q�$ 
00:00:02.5��   $ EaseIn=�$ 1Q�U� $ Slider5��$ Value�$ 
00:00:00.8X�.\�  $
 1000Q�$ 
00:00:00.5��   $ EaseOut=�$ 1Q��� $
 2000Q�$ 
00:00:02.0��  $
 3000Q�$ 
00:00:02.5��   $ EaseIn=�$ 1Q�U� $ Slider1��$ Opacity�.\�n� $ 1Q�$ 0��n� $ 0Q�$ 
00:00:02.5��U� $ Slider2��$ Opacity�$ 
00:00:00.2X�.\�n� $ 1Q�$ 0��n� $ 0Q�$ 
00:00:02.5��U� $ Slider3��$ Opacity�$ 
00:00:00.4X�.\�n� $ 1Q�$ 0��n� $ 0Q�$ 
00:00:02.5��U� $ Slider4��$ Opacity�$ 
00:00:00.6X�.\�n� $ 1Q�$ 0��n� $ 0Q�$ 
00:00:02.5��U� $ Slider5��$ Opacity�$ 
00:00:00.8X�.\�n� $ 1Q�$ 0��n� $ 0Q�$ 
00:00:02.5��.+�� $ DeterminateRoot��$y�Visible=�#��z��#��z��.+��� $ 
PART_Track��$	 0.1Q�$��4���� $ PART_Indicator��#��z��$
��Left=�$��4���� $ IndeterminateRoot��$y�	Collapsed=�#��z��}�. ._�� $��-5,0,0,0q�.+��� $ Slider1��8�� #��z���� $ Slider2��8�� #��z���� $ Slider3��8�� #��z���� $ Slider4��8�� #��z���� $ Slider5��8�� #��z���� 8   " �.���  � ��$	 Top=���  � ��$ Center=���  � ��$	 200����  � ��$ 24,2,0,0q���  � ��$ 0q���  � ��$ 5���� "  .���  � �� .  ��  � |� .  ��  � ��$ Stretch=���  � ��$ Stretch=���  � ��$ Stretch=���  � ��$ Stretch=���  � ��8   ��  �@ BusyContent$ Загрузка����  � �� �� "   .R��    VisibilityStates��.   
Hidden��. �� .��T� $ 00:00:00X�$ 00:00:00.001D�$ busycontent��$ (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�T� $ 00:00:00X�$ 00:00:00.001D�$ overlay��$ (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�  Visible��. �� .��T� $ 00:00:00X�$ 00:00:00.001D�$ busycontent��$ (UIElement.Visibility)�..�i� $ 00:00:00��  Visible=�T� $ 00:00:00X�$ 00:00:00.001D�$ overlay��$ (UIElement.Visibility)�..�i� $ 00:00:00��  Visible=�  BusyStatusStates��.   Idle��. �� .��T� $ 00:00:00X�$ 00:00:00.001D�$ content��$ (Control.IsEnabled)�..�i� $ 00:00:00�� ��True��T� $ 00:00:00X�$ 00:00:00.001D�$ content��$ (UIElement.Visibility)�..�i� $ 00:00:00��  Visible=�  Busy��. �� .��T� $ 00:00:00X�$ 00:00:00.001D�$ content��$ (Control.IsEnabled)�..�i� $ 00:00:00�� ��	False��T� $ 00:00:00X�$ 00:00:00.001D�$ content��$ (UIElement.Visibility)�..�i� $ 00:00:00��  	Collapsed=�.+��� $  content��#��z��#��z��#��z��#��z����.  |�.  �� $ overlay���� $! busycontent������ $��Center=�$��Center=�$��	100,0,0,0q�.+��� #��z" #��z��$	 0.7Q�$
��Wrap=�$��18(�� 8�� #$ z# $	��200��