   M S B A M L   `   `   `  ���� K  GWebCrawlerSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WebCrawlerSystemWebCrawlerSystem  (    "WebCrawlerSystem.ReportUserControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:WebCrawlerSystem       � 	Resources  ��%    .���  � RowDefinitions �� $
��Auto ��� $��* �.+��� -   $��btnGoToHome��$��
GO TO HOME��$��10q�$��Right=�   CreamButton#��[  &   System.Windows.Controls.DataGrid  -     Name$ ReportDataGrid��   CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .     
IsReadOnly . $��10q�$��14(�   	RowHeight$ 30Q�$��2��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 Project Name��
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ProjectName+ �� Mode$ OneWay=�  $	 Website��$
 2*  �� *
WebsiteUrl+$ OneWay=�  $	 Total Links Checked��$
 *  �� *TotalCrawled+$ OneWay=�  $	 Total Broken Links��$
 *  �� *BrokenLinks+$ OneWay=�  $
	 Date��$
 *  �� *	CrawlDate+$ OneWay=� �� StringFormat$ d��