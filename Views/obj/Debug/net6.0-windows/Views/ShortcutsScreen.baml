   M S B A M L   `   `   `  ����@  <Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:RedRatShortcuts.Views.ViewsRedRatShortcuts.Views.Views  5      1    +RedRatShortcuts.Views.Views.ShortcutsScreen   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:RedRatShortcuts.Views.Views     5      -   5          >�Name$  shortcutsScreen��5	       � 	Resources 5       �� 
TargetType   StatusIndicatorStyle �� Property �� Value �� Triggers �� Binding �� Value��%�  &	        �� 5   
   " ��6   .�5      ��  � ��$4 .../Resource/img/img_StatusIndicator_Active.png��6'    5      �� 5       6   �� *RunButtonTitle+ Run6A   .a�5      ��  � ��$6 0../Resource/img/img_StatusIndicator_Inactive.png��6/   5      �� 5       6   �� *RunButtonTitle+ Stop6A   .a�5      ��  � ��$4 .../Resource/img/img_StatusIndicator_Active.png��6/   5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��80��6   �� 5      $��* �6   �� 5      $��40��6   .+�5!   
   � $��0��6   $��10q�6   	 � ColumnDefinitions	 5"      �� 5#      $��* �6#   �� 5$      $
��Auto �6#   .+�5'      �� $��0��6   $��RedRat Shortcut Manager��5(      $��Center=�5)      $��32(�5*      �� 5,      $��1��6   $��Add New��5-      $��30,20,41,10q�5/      $��	10,0,10,0q�50      ��5.      �� *AddShortcutCommand+50      52      �� 54   
   $��1��6   $��15q�6$   .��55      �� $��25q�56      ��55      �� *	Shortcuts+��58      �� 59      .R�5:      � $��0,5,0,5q�6   	 5;      �� 5<   "   $
��Auto �63   �� 5=   "   $��* �63   �� 5>   "   $
��Auto �63   �� 5?   "   $
��Auto �63   �� 5@   "   $
��Auto �63   �� 5A   "   $
��Auto �63   .+�5C      �� $��0��6$   
 �� BitmapScalingMode$

 Fant=�5E   $   $��48��5F   $   $��0,0,25,0q�5G   $   ��5D   $   �� *	IconImage+5G   $   �� 5H      $��1��6(   $��WrapWithOverflow=�5J   (   $��Center=�5K   (   $��16(�5L   (   ��5I   (   �� *
FileName+5L   (   �� 5M      $��2��6$   $��ALT + ��5N   $   $
��Left=�5O   $   $��Center=�5P   $   $��16(�5Q   $   �� 5R      $��3��6$   $
��Left=�5T   &   $��Center=�5U   &   $��16(�5V   &   ��5S   &   �� *ShortcutKeys+5V   &   �� 5W      $��4��6%   $
��Edit��5X   %   $��Center=�5Z   %   $��52��5[   %   $��26��60   $��20,0,0,0q�5\   %   ��5Y   %   �� *!DataContext.EditShortcutCommand+ �� ElementName$ shortcutsScreen����6v   �� 5\   %   �� 5]      $��5��6%   $��Remove��5^   %   $��Center=�5`   %   $��52��5a   %   $��26��60   $��10,0,0,0q�5b   %   ��5_   %   �� *#!DataContext.RemoveShortcutCommand+$ shortcutsScreen����6x   �� 5b   %   5d      5e      5g      5i      � 5k   
   $��2��6   
�������	 5l      �� 5m      $��10��6#   �� 5n      $��32 �6#   �� 5o      $��* �6#   �� 5p      $��75��6#   �� 5q      $��75��6#   �� 5r      $��10��6#   .+�5u      �� $��1��6   #��[  5v      $

 Fant=�5w      $��26��5x      $��5q�5y      �� 5z      $��2��6   $��4,0,8,0q�5|      $��Center=�5}      
���iii�$��14(�5      ��5{      �� *
InfoText+ �� FallbackValue$ The app is running.��5      �� 5�      $��3��6   $��6q�5�      ��5�      �� *RunButtonTitle+$	 Run����5�      �� *
RunCommand+5�      �� 5�      $��4��6   $
��Quit��5�      $��6q�5�      ��5�      �� *ExitCommand+5�      5�      5�      5�      