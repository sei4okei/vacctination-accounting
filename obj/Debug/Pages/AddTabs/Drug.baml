   M S B A M L   `   `   `  ����H  Dcourseproject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:courseproject.Pages.AddTabscourseproject.Pages.AddTabs  5      &     courseproject.Pages.AddTabs.Drug   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:courseproject.Pages.AddTabs     5      -   5          N� Title$  Employee��5	      .��5      ��  �� Orientation$ Vertical=�6   $��20q�6(   .+�5   
   �� $��Название:��6      GeneralLabel#��[  6$   �� 5   
   -   5         ��Name$ NameTextBox��5        GeneralTextBox#��[ 6'   $��45��6O   $	��280��6[   $
��Left=�6g   �� 5   
   $ ��Дозировка (мг):��6   #��[  6*   �� 5   
   -   5        $ DosageTextBox��5      #��[ 6)   $��45��6Q   $	��280��6]   $
��Left=�6i   �� 5   
   $'��!Противопоказания:��6   #��[  6,   �� 5   
   -   5        $ ContraindicatorsTextBox��5      #��[ 63   $��90��6[   $	��280��6g   $
��Left=�6s   �� 5   
   $ ��Срок годности:��6   #��[  6)   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ ExpirationDatePicker��5        GeneralDatePicker#��[ 63   $��45��6^   $	��280��6j   $
��Left=�6v   �� 5   
   $ 
Horizontal=�6   .+�5      �� -   5        $��Сохранить��5      $��50��6)   $	��175��65   $
��Left=�6A     LoginButton#��[ 6\   $��0, 65, 50, 65q�6�   �� 5      -   5         ��Name$ DeleteButton��5      $��Удалить��6+   $��50��6=   $	��175��6I   $
��Left=�6U   #��[ 6p   $��50, 65, 50, 65q�6�   5      5      5      