   M S B A M L   `   `   `  ����I  Ecurrency_rates, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:currency_rates.Viewscurrency_rates.Views  5      &     currency_rates.Views.ConvertView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:currency_rates.Views     5        � 	Resources  5	         RoundCorner �� 
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
 0.25Q�6N   51      54      56      57      59      .��5:      �  � RowDefinitions 5;   
   �� 5<      $	��16* �6   �� 5=      $	��60* �6   �� 5>      $	��18* �6   �� 5?      $
��259* �6    � ColumnDefinitions 5A   
   �� 5B      $	��38* �6   �� 5C      $	��60* �6   �� 5D      $	��39* �6   �� 5E      $	��60* �6   �� 5F      $	��38* �6   .+�5H   
   � $��4��6   $��1��6   .+�5I      �� -   5        $��20q�5I   ,   #��[  68   $��Center=�6�   $��Center=�6�   ��6i   �� *GetConvertCommand+.��5J      �� $]��WC:\Users\Daniel\source\repos\currency_rates\currency_rates\images\arrow_right_16742.png��6   5K      5L      �� 5M   
   $��From:��6   $��1��6!   $��0��61   $��Bottom=�6>   $
��Bold"�6Y   $��16��6k   �� 5N   
   $	��To:��6   $��3��6   $��0��6/   $��Bottom=�6<   $
��Bold"�6W   $��16��6i   +   %currency_rates.Views.AllTheQuotesView  5O   
   -   5          Name$ Source��5O   !   $��1��61   $��1��6>   $��50��6O     5P   
   -   5        $ Target��5P   !   $��1��61   $��3��6>   $��50��6O   �� 5Q   
   -   5        $��convert_result��5Q      $��2��6?   $��2��6L   ��6(   �� *Value+6L   �� 5R   
   
������ $��1��6-   $��Center=�6:   $��Center=�6W   $��2��6r   �� 5S      $��32��6   $��0q�6)   .��5T      �� $R��LC:\Users\Daniel\source\repos\currency_rates\currency_rates\images\setas2.png��6   5U      5V      �� 5W   
   $��Result:��6   $��1��6#   $��2��63   $��Right=�6A   $
��Bold"�6]   $��38��6o   $	��0,1q�6z   &    currency_rates.Views.HistoryView  5X   
   -   5          Name$ historyViewuc��5X      $��3��63   $��5��6@   $y�Hidden=�6T   $��10q�6h   5Z      5[      