   M S B A M L   `   `   `  ����B  >Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ProjectProject  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5	      "    Project.UserControlDashboard   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:Project     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5	      -   5        $6��0/Project;component/Fonts/#Champagne & Limousines)�5
   ?   
�������.��5      �   � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   �� 5      $	��350 �6   .+�5   
   � $��2��6   $��0��6   $��3��6,   .+�5      �� $��15q�6   ���	#FF009CDE$��80��6<   $	��Top=�6H   .+�5      �� $��Общая сумма��6   $��18(�6.   $
��10 5q�6<   $
��Left=�6J   
�������6e   �� 5      -   5         ��Name$ TextBlockTotal��5      $��UZS 0,00��60   $
��10 0q�6C   $��22(�6Q   $��Right=�6_   
�������6{   5      � 5      ���	#FFB8DDEE$��15 100 15 15q�6*   .+�5      �� $��История��6   $��16(�6+   $��10q�69   $
��Left=�6E   �� 5      -   5         ��Name$ ListViewTimeLine��5      $��0 40 0 0q�6[   ���	#FF2B89BF��65   �� *ItemTimeLine+��5       �� 5!       �� 
TargetType" ��6    .�5"      ��  �� Property � |� �� Value .  6:   5#      ��5%      �� 5&      .R�5'      ��  �� Orientation$ 
Horizontal=�6)   .+�5(   "   �� $��50��6,   $��5q�6m   $��Center=�6x   
�������$��14(�6�   $
��Bold"�6�   ��67   ��  �� Path$
 Date�	 �� StringFormat$	 
{0:dd-MMM}��6�   � 5)   "   $
��10 0q�6'   .+�5*   &   �� ���	#FF009CDE$��Center=�6A   $��2��6^   $��	0 9.7 0 0q�6h   � 5+   &   $	��Top=�6+   .+�5,   *   A� $��22��62   $��22��6=   ���	#FF009CDE$��Center=�6]   $��Center=�6x   $��1��6�   A� 5-   *   $��16��62   $��16��6=   ���	#FF009CDE$��Center=�6]   $��Center=�6x   $��2��6�   A� 5.   *   $��6��62   $��6��6<   ���	#FF009CDE$��Center=�6X   $��Center=�6u   5/   '   50   #   � 51   "   $	��180��6'   .+�52   &   �� $��Center=�61   .+�53   *   �� $��	5 10 10 0q�6O   $6��0/Project;component/Fonts/#Champagne & Limousines)�6b   $��18(�6�   
 �� TextAlignment$

 Left=�6�   ��64   �� $
 Type�6�   �� 54   *   $��5q�6V   $6��0/Project;component/Fonts/#Champagne & Limousines)�6a   $��14(�6�   $

 Left=�6�   ���	#FF009CDE��64   �� $ Description�6�   �� 55   *   $��5q�6P   $6��0/Project;component/Fonts/#Champagne & Limousines)�6[   $��18(�6�   $
��Bold"�6�   $

 Left=�6�   ��64   �� $ Value���6�   �� $ Brush�56   '   57   #   58      59      5;      5<      5=      �� 5?   
   $��1��6   $��3��6'   $	��150��68   $
��5 15q�6G   ���	#FFABDDF9.��5@      �� .+�5B      �� 
�������$��1��6)   $��20 0 5 0q�64   �� 5C      ���	#FFB3C4FF$��15q�64   .+�5E      �� $'��!ЕЖЕМЕСЯЧНЫЙ ДОХОД��6    $��20 10q�69   $��18(�6H   �� 5F      -   5         ��Name$! TextBlockMonthlyIncomeEmpty��5F       $+��%Здесь еще ничего нет��6E   $��20q�6a   $��24(�6m   $��Center=�6{   $��Center=�6�   �� 5G      $��Visible=�6#   $��Disabled=�6K   .��5H      �� -   5         ��Name$ StackMonthlyIncome��5H   >   $ 
Horizontal=�6%   $	��Top=�6Z   5I      5J      �� 5K      ���	#FFE4F09B$��1��6-   $��20 0 5 0q�68   �� 5L      ���	#FFB3C4FF$��15q�64    J� RenderTransformOrigin$ 0.483,1.609&�6@   .+�5N      �� $/��)ЕЖЕМЕСЯЧНАЯ ДИАГРАММА��6    $��20 10q�6=   $��18(�6L   �� 5O      -   5        $! TextBlockMonthlyChartsEmpty��5O       $+��%Здесь еще ничего нет��6E   $��20q�6a   $��24(�6m   $��Center=�6{   $��Center=�6�   �� 5P      $��Visible=�6#   $��Disabled=�6K   .��5Q      �� -   5        $ StackMonthlyChart��5Q   >   $ 
Horizontal=�6%   $	��Top=�6Y   5R      5S      �� 5T      
�������$��1��6)   $��20 0 5 0q�64   �� 5U      ���	#FFDEDEDE$��15q�64   5X      5Y      5Z      � 5\   
   $��0��6   $��0��6   $��3��6,   .+�5]      � $��15q�6   ���	#FFAFFFFF  5^      �� 5_      $��40 �6$   �� 5`      $
��181* �6$   .+�5c      �� $��Профили��6   $��16(�6+   $��10q�69   $
��Left=�6E   $��0��6`   �� 5d      -   5        $ ListViewAccounts��5d      $��1��6U   ��65   �� *	Account+��5e      �� 5f      " ��6    .�5g      ��  � |� .  6:   5h      ��5j      �� 5k      .R�5l      �� $	��185��6D   ��6'   �� $
 Name�.��5m   "   � .+�5n   &   ��  ��Language$ pt-BR�6�   $��5q�6t   $6��0/Project;component/Fonts/#Champagne & Limousines)�6   $��15(�6�   $
 Right=�6�   $��Right=�6�   ��6A   �� $ Amount�$	 {0:C}��6�   5o   #   5p      5q      5s      5t      5u      5v      5w      