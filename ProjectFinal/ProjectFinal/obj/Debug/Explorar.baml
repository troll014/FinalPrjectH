   M S B A M L   `   `   `  ����G  CProjectFinal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ProjectFinalProjectFinal  5          ProjectFinal.Explorar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ,localclr-namespace:ProjectFinal     5      -   5          N� Title$  Explorar��5      $	��650��6   $	��600��6%    N� 
Background �#DEB887 � 	Resources 5         itemCollectionViewSource��%   &	        �� 5   
   6   5      .��5      �� $
��Auto=�6   .��5   
   � .+�5   
   �� .+�5      �� $��Explorar��6   $��30(�6(   ���#A0522D$
��Left=�6K   $��
60,10,0,10q�6f   �� 5      $-��'Seleccione la tabla que desea explorar:��6   ���#A0522D$��
10,10,10,0q�6[   �� 5      -   5         ��Name$ ExistingTableComboBox��5      $��10q�66   � 5      .+�5      �� -   5         ��Name$ searchTextBox��5      
������ $��5q�6r   ���#A0522D6~   �� 5       J� IsHitTestVisible .  $��Buscar especies��65   
������� �� Padding$ 5q�6^   $��Italic$�6j   ��5      �� 5       �� 
TargetType" ��6    .�5       ��  �� Property � y�	 �� Value$	 	Collapsed=�6;   
 �� Triggers
 5!      �� 5"   "    �� Binding 6.   �� *Text+ �� ElementName$ searchTextBox�� �� Value  6b   .a�5#   &   ��  � y�$	 Visible=�6C   5$   #   5&      5(      5*      �� 5+      $��	Filtrado:��6   ���#A0522D$��
10,10,10,0q�6=   �� 5-      -   5        $ FilterComboBox��5-      $��10q�6/   .@�5.      �� $��Por ID��6   �� 5/      $��
Por Nombre��6   �� 50      $��Alfabéticamente��6   51      �� 53      -   5        $��Buscar��53      $	��120��6'   $��30��63   $��Center=�6?   $��
10,10,10,0q�6\   ���#DEB887���#A0522D$��0q�6�   
������ $
��10,5q�6�   6�   &   System.Windows.Controls.DataGrid  55      -   5        $��faunaDataGrid��55         AutoGenerateColumns .  $��
10,10,10,0q�6�   ��6,   ��  �� Source# [  ��58      �� 59       �� Color$ #DEB887��6&    �� Opacity$	 0.5Q�66      Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *id+  5=      $ Nombre��6)    69   �� *nombre+  5>      $ Descripción��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^    6>   �� *descripcion+6^     5?      $ Fecha��6)    68   �� *fecha+4  .System.Windows.Controls.DataGridTemplateColumn  5@      $ Imagen��6-      CellTemplate 5A      �� 5B      .R�5C   "   �� $	��100��6B   ��6(   �� *imagen+6B   5D      5F      5H      5I      5J      5L      5O      