   M S B A M L   `   `   `  ����?  ;Lab2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab2Lab2  5   	       Lab2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Lab2     5   	   -   5          � Title$  Aplikacja - piłkarze��5   	   $	��450��6&   $	��800��63   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��2* �6   �� 5      $��3* �6   .+�5   
   �� $��0��6   .+�5      �� -   5         ��Name$ 	labelImie��5      $
��Imie��6'   #   Lab2.TextBoxWithErrorProvider  5      -   5          Name$ textBoxImie��5   -   $
��10,3q�6B   �� 5      -   5        $ labelNazwisko��5      $��Nazwisko��6+     5      -   5        $ textBoxNazwisko��5   -   $
��10,3q�6F   �� 5       �� Orientation$ 
Horizontal=�6   $
��0,10q�62   .+�5      �� -   5        $ 	labelWiek��5      $��Wiek:   ��6,   �� 5      -   5        $ labelWiekWartosc��5      ��62   ��  �� Path$ Value� �� ElementName$ 
sliderWiek��5      �� 5      -   5         ��Name$ 
sliderWiek��5      $
��10,0q�6)    � Minimum$ 15Q�67   	 � Maximum$	 50Q�6D   
 � Value$
 25Q�6Q    �� TickFrequency$ 1Q�6\    �� IsSnapToTickEnabled . 6n   �� 5      $ 
Horizontal=�6   $	��0,5q�62   .+�5      �� -	   5        $ 	labelWaga��5      $��Waga:  ��6,   �� 5      -
   5        $ labelWagaWartosc��5      ��62   �� $ Value�$ 
sliderWaga��5      �� 5      -   5        $ 
sliderWaga��5      $
��10,0q�6)   $ 50Q�67   $		 120Q�6D   $
 75Q�6R   $ 1Q�6]    . 6o   �� 5      $��0��6   $ 
Horizontal=�6)   $��20q�6B   $��Center=�6N   .+�5      �� -   5         ��Name$ buttonDodaj��5      $��Dodaj��6/   $��80��6?   $��3q�6e   �� 5       -   5        $ buttonEdytuj��5       $��Edytuj��6/   $��80��6@   $��3q�6f   {�.  6q   �� 5!      -   5        $ 
buttonUsun��5!      $��Usuń��6-   $��80��6<   $��3q�6a   {�.  6l   5"      �� 5#      -   5        $ 
LabelBledy��5#      $�� ��6(   5$      �� 5%   
   -   5         ��Name$ listBoxLista��5%      $��1��6(   $��20q�68   6D   5&      5'      