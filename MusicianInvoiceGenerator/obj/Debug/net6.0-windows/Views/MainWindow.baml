   M S B A M L   `   `   `  ����S  OMusicianInvoiceGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:MusicianInvoiceGeneratorMusicianInvoiceGenerator  5   	   Y1clr-namespace:MusicianInvoiceGenerator.ViewModels#MusicianInvoiceGenerator.ViewModels  5   	   )    #MusicianInvoiceGenerator.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5uc&clr-namespace:MusicianInvoiceGenerator     5   	   @vm1clr-namespace:MusicianInvoiceGenerator.ViewModels     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � DataContext 5
      =  7MusicianInvoiceGenerator.ViewModels.MainWindowViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $	��12* �6   �� 5      $��1* �6   .+�5   
   � $��1��6   $��1��6    5      �� 5      $
��Auto �6    �� 5      �� 5      $
��Auto �6    .+�5       � $��0��6    5!      �� 5"      $	��10* �6'   �� 5#      $��1* �6'   �� 5$      $	��10* �6'   .+�5'      � $��0��6    5(      �� 5)      $
��Auto �6(   �� 5*      $
��Auto �6(   �� 5+      $
��Auto �6(   �� 5,      $
��Auto �6(   .+�5.      �� $��Personal Details��6    $��Center=�68   � 5/      $��1��6    6(   �� *SenderContact+.+�50      2   ,MusicianInvoiceGenerator.ContactEntryControl  $��5,5,5,5q�61   51      �� 52      $��2��6    $��Bank Details��6-   $��Center=�6A   � 53      $��3��6    6(   �� *BankDetails+.+�54      5   /MusicianInvoiceGenerator.BankDetailEntryControl  $��3��64   $��5,5,5,5q�6A   55      56      � 58      $��2��6    59      �� 5:      $
��Auto �6(   �� 5;      $
��Auto �6(   �� 5<      $
��Auto �6(   �� 5=      $
��Auto �6(   .+�5?      �� $��Recipient Details��6    $��Center=�69   � 5@      $��1��6    6(   �� *RecipientContact+.+�5A        $��5,5,5,5q�61   5B      �� 5C      $��2��6    $��Dates��6-   $��Center=�6:   � 5D      $��3��6   $��5,5,5,5q�6(    5E      �� 5F      $
��Auto �6/   �� 5G       5I      �� 5J      �� 5K      .+�5M      �� $��0��6$   $��Invoice Date: ��64   (  "System.Windows.Controls.DatePicker  5N      $��1��6%   $��2,2,2,2q�65      SelectedDate 6F   �� *InvoiceDate+�� 5O      $��0��6$   $��1��64   $��
Due Date: ��6A     5P      $��1��6%   $��1��65   $��2,2,2,2q�6B    6S   �� *	DueDate+5Q      5R      5S      � 5T      $��1��6    6    �� *
GigEntry+ 5U      �� 5V      $
��Auto �6$   �� 5W      $
��Auto �6$   .+�5Y      �� $��Payment Details��6   $��Center=�63   �� 5Z      ��6   �� *Gigs+��5[      �� 5\      .R�5]      4   .MusicianInvoiceGenerator.GigDetailEntryControl  5^      ��5`      �� 5a       �� 
TargetType" ��6*   .R�5b      �� .+�5c   "   �� �� 5d   "   $��
btn_AddGig��6)   $��60��6V   $��20��6a   $��Add Gig��6m   $��2,2,2,2q�6   ��6;   �� *AddGig+6   5e      5f      5h      5i      � 5j      $��2��6    5k      �� 5l      $��5* �6'   �� 5m      $��1* �6'   .+�5o      �� $��1��68   $��32��6H   $��Generate Invoice��6T   $��2,2,2,2q�6o   ��6   �� *
NewInvoice+6o   5p      5q      5r      5s      