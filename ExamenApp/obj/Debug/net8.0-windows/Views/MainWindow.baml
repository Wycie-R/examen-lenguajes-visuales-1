   M S B A M L   `   `   `  ����  	ExamenApp     ExamenApp.Views.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Sistema de Gestion��5   	   $	��600��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�6=   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��0��6   $��Gestión de Productos��6!   $��24(�6=   $
��Bold"�6K   $��Center=�5      $��10q�61   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5      �� $��Buscar:��6   $��Center=�6'   $��0,0,10,0q�6B   �� 5      $	��200��5      $��25��6"   ��5      �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5   "   5      &   System.Windows.Controls.DataGrid  5   
   $��2��6      AutoGenerateColumns$ False��5      $��10q�6/   ��5       �� *
Products+ �� SelectedItem 5      �� *SelectedProduct+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6H   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+6H     5      $ Nombre��6%   $		 200 6N   
 65   �� *Name+6N     5      $ Precio��6%   $		 100 6_   
 65   �� *Price+ �� StringFormat$ C��6_     5       $ 
Categoría��6%   $		 150 6Z   
 68   �� *Category.Name+6Z   5"      �� 5%   
   $��3��6   $ 
Horizontal=�6"   $��Center=�6;   $��10q�6X   .+�5&      �� $��Agregar Producto��6   $	��120��5'      $��30��6!   $��5q�6-   ��5&   0   �� *AddProductCommand+5'   -   �� 5(      $��Editar Producto��6   $	��120��5)      $��30��6!   $��5q�6-   ��5(   /   �� *EditProductCommand+5)   -   �� 5*      $��Eliminar Producto��6   $	��120��5+      $��30��6!   $��5q�6-   ��5*   1   �� *DeleteProductCommand+5+   -   �� 5,      $��Agregar Categoría��6   $	��120��5-      $��30��6!   $��5q�6-   ��5,   1   �� *AddCategoryCommand+5-   -   5.      5/      50      