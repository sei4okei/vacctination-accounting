   M S B A M L   `   `   `  ����H  Dcourseproject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:courseproject.Pages.AddTabscourseproject.Pages.AddTabs  5      )    #courseproject.Pages.AddTabs.Patient   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:courseproject.Pages.AddTabs     5      -   5          N� Title$  Patient��5	      .��5      ��  �� Orientation$ Vertical=�6   $��20q�6(   .+�5   
   �� $��Имя:��6      GeneralLabel#��[  6   �� 5   
   -   5         ��Name$ PatientFirstNameTextBox��5        GeneralTextBox#��[ 63   $��45��6[   $	��280��6g   $
��Left=�6s   �� 5   
   $��Фамилия:��6   #��[  6#   �� 5   
   -   5        $ PatientLastNameTextBox��5      #��[ 62   $��45��6Z   $	��280��6f   $
��Left=�6r   �� 5   
   $��Отчество:��6   #��[  6$   �� 5   
   -   5        $ PatientMiddleNameTextBox��5      #��[ 64   $��45��6\   $	��280��6h   $
��Left=�6t   �� 5   
   $ ��Дата рождения:��6   #��[  6)   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ PatientDatePicker��5        GeneralDatePicker#��[ 60   $��45��6[   $	��280��6g   $
��Left=�6s   �� 5   
   $(��"Город регистрации:��6   #��[  6-   �� 5   
   -   5        $ PatientCityTextBox��5      #��[ 6.   $��45��6V   $	��280��6b   $
��Left=�6n   �� 5   
   $ ��Номер участка:��6   #��[  6)   �� 5   
   -   5         ��Name$ PatientRegionComboBox��5        GeneralComboBox#��[ 62   $��45��6[   $	��280��6g   $
��Left=�6s   �� 5   
   $��Номер полиса:��6   #��[  6(   �� 5   
   -   5        $# PatientInsurancePolicyTextBox��5      #��[ 69   $��45��6a   $	��280��6m   $
��Left=�6y   �� 5   
   $ 
Horizontal=�6   .+�5      �� -	   5        $��Сохранить��5      $��50��6)   $	��175��65   $
��Left=�6A     LoginButton#��[ 6\   $��0, 65, 50, 65q�6�   �� 5      -
   5         ��Name$ DeleteButton��5      $��Удалить��6+   $��50��6=   $	��175��6I   $
��Left=�6U   #��[ 6p   $��50, 65, 50, 65q�6�   5      5      5      