   M S B A M L   `   `   `  ����S  OMusicianInvoiceGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulla5clr-namespace:MusicianInvoiceGenerator.Views.Controls'MusicianInvoiceGenerator.Views.Controls  5      a5clr-namespace:MusicianInvoiceGenerator.Views.Controls'MusicianInvoiceGenerator.Views.Controls  5      C    =MusicianInvoiceGenerator.Views.Controls.InvoicePreviewControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Glocal5clr-namespace:MusicianInvoiceGenerator.Views.Controls     5      Duc5clr-namespace:MusicianInvoiceGenerator.Views.Controls     5      
�������  � 	Resources  5
       �� 
TargetType �� Property �� Value��%W   '��       �� 5   
   " ��6   .�5      ��  � ��$ 2,2,2,2q�6'   5      5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   � $	��Top=�6    � ColumnDefinitions 5      �� 5      $��4* �6#   �� 5      $��6* �6#   �� 5      $��4* �6#   .+�5      �  5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$   �� 5"      $
��Auto �6$   .+�5%      �� $��Bill To:��6   �� 5&      $��1��6@   ��6   ��  �� Path$ RecipientName�6@   �� 5'      $��2��6>   ��6   �� $ RecipientL1�6>   �� 5(      $��3��6>   ��6   �� $ RecipientL2�6>   �� 5)      $��4��6@   ��6   �� $ RecipientTown�6@   �� 5*      $��5��6D   ��6   �� $ RecipientPostcode�6D   5+      � 5,      $��2��6    5-      �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   �� 51      $
��Auto �6$   .+�54      �� $��INVOICE��6   $��Right=�6+   �� 55      $��Right=�6@   $��1��6\   ��6   �� $ InvoiceNumber�6\   �� 56      $��Right=�6>   $��2��6Z   ��6   �� $ InvoiceDate�6Z   �� 57      $��Right=�6:   $��3��6V   ��6   �� $ DueDate�6V   58      59      � 5:   
   $��1��6   .+�5<      =   7MusicianInvoiceGenerator.Views.Controls.GigDisplayTable  $��Center=�6$   $��20q�6A   5=      � 5>   
   $��2��6    5?      �� 5@      $��4* �6#   �� 5A      $��6* �6#   �� 5B      $��4* �6#   .+�5D      �  5E      �� 5F      �� 5G      �� 5H      �� 5I      �� 5J      �� 5K      �� 5L      .+�5N      �� $��Sender Contact:��6   �� 5O      $��1��6=   ��6   �� $ 
SenderName�6=   �� 5P      $��2��6@   ��6   �� $ SenderPhoneNo�6@   �� 5Q      $��3��6;   ��6   �� $ SenderL1�6;   �� 5R      $��4��6;   ��6   �� $ SenderL2�6;   �� 5S      $��5��6=   ��6   �� $ 
SenderTown�6=   �� 5T      $��6��6A   ��6   �� $ SenderPostcode�6A   5V      � 5W      $��2��6    5X      �� 5Y      $
��Auto �6$   �� 5Z      $
��Auto �6$   �� 5[      $
��Auto �6$   �� 5\      $
��Auto �6$   �� 5]      .+�5_      �� $��Pay To:��6   �� 5`      $��1��6   $��Right=�6J   ��6)   �� $ 
SenderName�6J   �� 5a      $��2��6   $��Right=�6H   ��6)   �� $ SortCode�6H   �� 5b      $��3��6   $��Right=�6M   ��6)   �� $ AccountNumber�6M   5c      5e      5f      5g      