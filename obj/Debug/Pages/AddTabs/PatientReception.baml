   M S B A M L   `   `   `  ����H  Dcourseproject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:courseproject.Pages.AddTabscourseproject.Pages.AddTabs  5      2    ,courseproject.Pages.AddTabs.PatientReception   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:courseproject.Pages.AddTabs     5      -   5          N� Title$  Employee��5	      .��5      ��  �� Orientation$ Vertical=�6   $��20q�6(   .+�5   
   �� $��Пациент:��6      GeneralLabel#��[  6#   �� 5   
   -   5         ��Name$ PatientComboBox��5        GeneralComboBox#��[ 6,   $��45��6U   $	��280��6a   $
��Left=�6m    �� 
IsReadOnly . 6�   �� 5   
   $��Вакцина:��6   #��[  6#   �� 5   
   -   5        $ DrugComboBox��5      #��[ 6)   $��45��6R   $	��280��6^   $
��Left=�6j   �� 5   
   $��	Врач:��6   #��[  6    �� 5   
   -   5        $ EmployeeComboBox��5      #��[ 6-   $��45��6V   $	��280��6b   $
��Left=�6n   �� 5   
   $��	Дата:��6   #��[  6    (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ ReceptionDatePicker��5        GeneralDatePicker#��[ 62   $��45��6]   $	��280��6i   $
��Left=�6u   �� 5   
   $ 
Horizontal=�6   .+�5      �� -   5        $��Сохранить��5      $��50��6)   $	��175��65   $
��Left=�6A     LoginButton#��[ 6\   $��0, 65, 50, 65q�6�   �� 5      -   5         ��Name$ DeleteButton��5      $��Удалить��6+   $��50��6=   $	��175��6I   $
��Left=�6U   #��[ 6p   $��50, 65, 50, 65q�6�   5      5      5      