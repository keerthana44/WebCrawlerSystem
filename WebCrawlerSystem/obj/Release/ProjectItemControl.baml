   M S B A M L   `   `   `  ���� K  GWebCrawlerSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WebCrawlerSystemWebCrawlerSystem  )    #WebCrawlerSystem.ProjectItemControl   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     0localclr-namespace:WebCrawlerSystem     .��� $��20q�  � ColumnDefinitions  �� $��3* ��� $��* �.+�� $��0�� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+�� $��0��$��10q�  �� $��* ��� $
��Auto �.+�'   !WebCrawlerSystem.WatermarkTextBox  -     Name$ txtSearchUrl��   	Watermark$ ENTER WEBSITE LINK HERE��$��20(�$��10q��� -   $��btnStartSearch��$��Start��$��10 0 0 0q�$��20(�$	��100��$��1��   OrangeButton#��[  �� $��Results��$��10q�$��20(�$��1�� �� TextAlignment$ Center=�&   System.Windows.Controls.DataGrid  -   $��ResultDataGrid��$��10q�   CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .     
IsReadOnly . $��14(�	   	RowHeight$	 30Q�$��2������ 
 �� Path$
 Pages� �� Mode$ OneWay=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Sr No.��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� $
 SerialNumber�$ OneWay=�  $ Link/Url��$ *  �� $
 
WebsiteUrl�$ OneWay=�  $ Status��$	 100  �� $
 Status�$ OneWay=�� $��1�� �� $
��Auto ��� $��* �.+��� -   $��btnGoToHome��$��
GO TO HOME��$��10q�$��Right=�  CreamButton#��[ �� $��1�� �� Orientation$ Vertical=�$��Center=�.+��� $��Center=�$��Center=�.+��� $��10q�  OrangeBlock#��[ ._��� $ Vertical=�.+��� $��CURRENT STATUS��$��18(��� -   $��tbkCurrentStatus��$��NOT STARTED��$��35(��� $��10q�#��[ ._��� $ Vertical=�.+��� $��TOTAL LINKS CRAWLED��$��18(��� -   $��tbkTotalLinksCrawled��$��35(����� $ TwoWay=�$
 TotalCrawled��� $��10q�#��[ ._��� $ Vertical=�.+��� $��TOTAL BROKEN LINKS��$��18(��� -   $��tbkTotalBrokenLinks��$��35(����� $ TwoWay=�$
 TotalBrokenLink�