   M S B A M L   `   `   `  ����C  ?GameTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GameTask.View.PagesGameTask.View.Pages  5      %    GameTask.View.Pages.ResultsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:GameTask.View.Pages     5        N� Title$  ResultsPage��5	      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     DataGrid.Small#��[  5      $��15q�5         AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         
IsReadOnly$
 True��5         SelectionMode$ Single=�5         	RowHeight$ 60Q�5      ��5      �� *GameResults+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Ник��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 5   %   	   
FontWeight$	 SemiBold"�5   %   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5   %   �� *
PlayerName+5   %     5      $ Попытки��6%   $	 120 5   %   
 5   %   �� *
Attempts+5   %     5      $ Дата��6%   $	 100 5   %   
 5   %   �� *Date+ �� StringFormat$ 
dd.MM.yyyy��5   %   5       5!      5"      