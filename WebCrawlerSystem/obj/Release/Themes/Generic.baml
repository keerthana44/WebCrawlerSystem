   M S B A M L   `   `   `  ���� K  GWebCrawlerSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WebCrawlerSystemWebCrawlerSystem  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   DefaultWatermarkTemplate'    !WebCrawlerSystem.WatermarkTextBox  �� 
TargetType �� Property �� Value �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard g� Duration �� 
TargetName	 �� TargetProperty
 �� KeyTime �� Value O� KeyTime O� Value g� 	BeginTime R� KeyTime  System.Windows.Visibility   Visible R� Value ��Name J� Opacity ��Name J� OpacityMask �� EndPoint �� 
StartPoint � Color � Offset ��Name J� SnapsToDevicePixels ��Name    	Watermark    WatermarkTemplate J� IsHitTestVisible  �� Color! �� Triggers" ]� 
Conditions# �� Property$ �� Value% �� 
TargetName& P� Property' P� Value�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     (localclr-namespace:WebCrawlerSystem  %l  &	        '   (     7   �� .R��� 
�������|�.  ���� �� "    .���  � ��
 �   ���  � ��
 �������  � ��
 �������  � ��$ 1q���  � ��$ 3q���  �@J�	AllowDrop . ��  �@�FocusVisualStyle Z� ��  � ��$ 0����  � ��$ 0����  � ��$ Center=���  �@  WatermarkTemplate8   ��  � �� �� "   .R��    CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 00:00:00.001D�$ White��$2	 ,(Border.BorderBrush).(SolidColorBrush.Color)�.g��� $
 0��$ 	#FF000000��U� $ 00:00:00.001D�$ 
Background��$	 (UIElement.Opacity)�.\��� $ 0��$	 0.8Q�  Disabled��. �� .��U� $ 00:00:00.001D�$ 
Background��$	 (UIElement.Opacity)�.\��� $ 0��$	 0.2Q�U� $ 00:00:00.001D�$ PART_ContentHost��$	 (UIElement.Opacity)�.\��� $ 0��$	 0.5Q�T� $ 00:00:00X�$ 00:00:00.0010000D�$ DisabledLayer��$	 (UIElement.Visibility)�..�i� $ 00:00:00��# Z   ReadOnly��  FocusedStates��.   Focused��. �� .���� $ 00:00:00.001D�$ White��$2	 ,(Border.BorderBrush).(SolidColorBrush.Color)�.g��� $
 0��$ 	#FF000000��U� $ 00:00:00.001D�$ 
Background��$	 (UIElement.Opacity)�.\��� $ 0��$	 0.8Q�U� $ 00:00:00.001D�$ Inner��$	 (UIElement.Opacity)�.\��� $ 0��$
 0.75Q�  	Unfocused��.+��� $ White�����	#FFFFFFFF$��1q����	#FFFFFFFF�� $ 
Background��#��z��
�������$��1q�$	 0.5Q��� $ Inner��
�������$��1,1,1,1q�$	 0.2Q���Z�  �� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFFFFFFF��$ 0.196Q�� $ 	#00000000��$ 1Q��� $ PART_ContentHost��# z $��2,2,2,2q��� $ PART_WatermarkHost��#��z #��z #��z��#��z�� .  #��z��$y�	Collapsed=��� $ DisabledLayer��$y�	Collapsed=���Z� ���� $  	LightGray��! ]� " �� # �@J�	IsFocused$ .  �� # � ��$$  ��/��� $% PART_WatermarkHost�� � y�$ Visible=�P� & � {�' .  . ��� $% PART_ContentHost�� �@J�Opacity$	 0.2Q��� $% 
Background�� �@J�Opacity$	 0.2Q�