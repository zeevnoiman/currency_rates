   M S B A M L   `   `   `  ����I  Ecurrency_rates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:currency_rates.Viewscurrency_rates.Views  5      .    (currency_rates.Views.CurrencyHistoryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:currency_rates.Views     5        � 	Resources  5	         RoundCorner �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Triggers	 P� Property
 P� Value �� 
TargetName 
� GradientOrigin �� RelativeTransform �� CenterX �� CenterY �� ScaleX �� ScaleY T� X T� Y � Color � Offset��%s  &	        �� 5
   
   " ��6$   .�5      ��  � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 1q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      � $
 grid��6   .+�5      �� $ border��6%   
�������$	 200��6H   
�������$��2q�6o   ._�5   "   �� $��Center=�63   $��Center=�5   +   $
��Bold"�5   +   5   #   5      5       5      P� 5      	 � ��
 . . �5   "   �� $ border��6?    � �� 5   &   
� 5   *   $ 0.496,1.052&�6>    5   .   V� 5    2   .~�5!   6   �� $	 0.5Q�6E   $	 0.5Q�6S   $	 1.5Q�6a   $	 1.5Q�6n   T� 5"   6   $
 0.02Q�6I   $	 0.3Q�6R   5#   3   .��5%   .   � $ 	#00000000��6;   $ 1Q�6M   � 5&   .   $ 	#FF303030��6;   $	 0.3Q�6M   5'   +   5)   #   5*      P� 5+      	 �@J�IsMouseOver
 . . �5,   "   �� $ border��6@    � �� �#c7ced86T   �� 5-   "    � �� �#fceaea6?   5.      P� 5/      	 � {�
 .  . �50   "   �� $
 grid��6<    �@J�Opacity$
 0.25Q�6N   51      54      56      57      59      .��5;      �  � RowDefinitions 5<   
   �� 5=      �� 5>      .+�5@   
   � $��0��6    � ColumnDefinitions 5A      �� 5B      $
��224* �6#   �� 5C      $
��255* �6#   �� 5D      $
��215* �6#    5F      �� 5G      $��95 �6    �� 5H      $	��105 �6    �� 5I      $	��120 �6    .+�5K      �� $��1��6   $��1��6'    �� Orientation$ 
Horizontal=�67   $��3��6P   .+�5L      �� $��Center=�6   $��10q�67   $��15(�6C   $
��Bold"�6Q   $+��%Select a Currency to see the history:��6c   +   %currency_rates.Views.AllTheQuotesView  5M      -   5          Name$ Source��5M   )   $��10q�69   $��50��6E   5N      � 5O      $��2��6   $��3��6     5P      �� 5Q      $
��287* �6'   �� 5R      $
��125* �6'   �� 5S      $
��282* �6'   .+�5U      �� -   5        $��1��5U      #��[  6>   $��Center=�6�   $��Center=�6�   $��30q�6�   ��6o   �� *getHistoryCommand+.��5V      �� $]��WC:\Users\Daniel\source\repos\currency_rates\currency_rates\images\arrow_right_16742.png��6   5W      5X      5Y      &    currency_rates.Views.HistoryView  5Z   
   -   5          Name$ historyViewuc��5Z      $��1��63   5[      5\      