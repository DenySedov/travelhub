   M S B A M L   `   `   `  ����B  >TestApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TestAppTestApp  5   	       TestApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:TestApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   $	��450��65   $	��800��6E   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��0��6   $��1��6!   $��Center=�61   $��Center=�6N   $��21(�6i   Авторизация6�   �� 5   
   $��3��6   $��1��6!   
Логин68   �� 5    
   -   5         ��Name$ LoginBox��5    /   $��1��6   $��4��6"   6D   �� 5!   
   $��5��6   $��1��6!   Пароль69   G� 5"   
   -   5         G�Name$ PasswordBox��5"   3   $��1��6   $��6��6&   6J   �� 5#   
   -   5         ��Name$ ContinueWithoutButton��5#      $��1��60   $��10��6@   $	��200��6N   $��25��6Z   
������ $��0q�6   .��6�   42Продолжить без регистрации6�   �� 5%   
   -   5        $ EnterButton��5%   .   $��1��6   $��8��6!   .��6]   
Войти6d   �� 5&   
   -   5        $ RegistrationButton��5&   F   $��1��6   $��9��6!   $	��100��6.   $��25��6:   .��6�   Регистрация6�   5'      5(      