   M S B A M L   `   `   `  ����@  <vkApp, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null3clr-namespace:vkApp.ConvertersvkApp.Converters  5      /clr-namespace:vkApp.ControlsvkApp.Controls  5      3clr-namespace:vkApp.BehavioursvkApp.Behaviours  5	          vkApp.View.Main.MusicView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      /
convertersclr-namespace:vkApp.Converters  5      +controlsclr-namespace:vkApp.Controls  5      /
behavioursclr-namespace:vkApp.Behaviours  5	      X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5
      -   5          N�Name$  pageRoot��5       N� 	KeepAlive .   N� Title$ 	MusicView��5      z�5      T� 5   
    � Triggers 5      :� 5   
    :� RoutedEvent$ Page.Loaded��6   .[�5      ��    PageLoadAnim#��[  6   5       � 	Resources 5      ,   &vkApp.Converters.AudioTemplateSelector  AudioTemplateSelector  AudioItemTemplate   AudioTemplate  PostItemDataTemplate   PostTemplate  TracksCollection �� Source��%`   &	       7  7  &	        5   
   8   8  6|   �� 5   
    68   �� *Tracks+5      .��5!      � 	 � RowDefinitions	 5"   
   �� 5#      $��60 �6   �� 5$      .+�5&   
   � $��60��6   $��1��6   ���	#FF5376A0$	��Top=�6B   .+�5'      � ���	#FF5E81AB$
��Left=�6*   .+�5(      �� 
 �� Orientation$
 
Horizontal=�6   $��	20,0,20,0q�66   .+�5)      ��   MainBackButtonStyle#��[ 6   ��6J   �� *Main.GoBackCommand+  Locator �� Source# [ y�5*      �� *Main.CanGoBack+# [   BoolToVisibilityConverter �� 	Converter# [ �� 5+      $��Аудиозаписи��6    $��Center=�63   $��16(�6N   
�������6\   5,      5-      5.      � 5/   
   $��1��6   .+�50      %  Xceed.Wpf.Toolkit.BusyIndicator    CommonProgressBarStyle   ProgressBarStyle# [ 6d    	 BusyIndicatorStyle#��[	 6�      IsBusy 6!   �� *Main.IsWorking+# [ .��51      �� -   5         ��Name$ 
music_list��51       
 AudioListBoxItemStyle#��[
 52      $��0q�6M   #��[ 53       %� 
ScrollUnit$ Pixel=�6O   $��Disabled=�54      ��51   .   �� # [ .  (System.Windows.Interactivity.Interaction   	Behaviors 55      7   1vkApp.Behaviours.AutoScrollToCurrentItemBehaviour  56      58      59      5:      5;      5<      