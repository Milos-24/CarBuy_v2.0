   M S B A M L   `   `   `  ����F  BCarBuy v2.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:CarBuy_v2._0CarBuy_v2._0  5   	   U/clr-namespace:CarBuy_v2._0.Properties.Languages!CarBuy_v2._0.Properties.Languages  5   	       CarBuy_v2._0.Options   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:CarBuy_v2._0     5   	   Dlanguage/clr-namespace:CarBuy_v2._0.Properties.Languages     5   	   -   5          � Title$  
MainWindow��5	   	   $	��250��6   $	��400��6)    � WindowStyle$
 None=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � AllowsTransparency$
 True��5   	   
������ .��5      ��  �� CornerRadius$ 50��6   ._�5   
   ��    OptionsBorder#���   6   ��5      �� 5       �� 
StartPoint$	 0,1&�6&    �� EndPoint$	 1,0&�67   .��5      �  � Color$ #01000a��6#   	 � Offset$	 0Q�63   � 5      $ #93929c��6#   $
	 0.75Q�63   5      ._�5      � 
 � RowDefinitions
 5      �� 5      $��10 �6(   �� 5      $	��230 �6(   �� 5      $��10 �6(    � ColumnDefinitions 5#      �� 5$      $��10 �6+   �� 5%      $	��190 �6+   �� 5&      $	��190 �6+   �� 5'      $��10 �6+   .+�5-      �� -   5        $��1��5-   3   $��2��6@   $��80��6P   $��30��6[     CancelButton#���  6g   $��100,190,0,0q�6�    � 	Resources 5.       �� 
TargetType �� Property �� Value��%^   '��       �� 5/      " ��6    .�50      ��  �@��CornerRadius$ 7��6=   51      52      53      �� 56      -   5        $��1��56   2   $��2��6?   $��80��6O   $��30��6Z     ApplyButton#���  6f   $��
0,190,80,0q�6�    57      ��%^   '��       �� 58      " ��6$   .�59   "   ��  �@��CornerRadius$ 7��6A   5:      5;      5<      �� 5>      -   5         ��Name$ themeSelected��5>      $��1��62   $��1��6?   $��90��6O   $��25��6Z   $��30,0,0,0q�6f   $��
Montserrat)�6x   
���   �$��16(�6�   .@�5?      ��  �� 
IsSelected$
 True��6#   .��65   	Default6>   �� 5@      .��6#   Red6(   �� 5A      .��6#   Blue6)   5B      �� 5D      -   5        $ languageSelected��5D   B   $��1��6\   $��2��6i   $��90��6y   $��25��6�   $��0,0,30,0q�6�   $��
Montserrat)�6�   $��16(�6�   .@�5E      �� $
 True��6'   .��69   	English6B   �� 5F      .��6'   	Serbian60   5G      5I      5J      5K      5L      