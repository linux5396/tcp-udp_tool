   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem     WpfApp1.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp1     9System&clr-namespace:System;assembly=mscorlib       � Icon$%  /WpfApp1;component/img/logo.png�� � Title$I CTCP/UDP测试工具-QG内部            @CopyRight 2019 version 1.0��$��525.2��$	��800�� � 
ResizeMode$ CanMinimize=� � 	Resources    bu �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� EndPoint
 �� 
StartPoint � Color � Offset��%�  &	        �� " ��.���  � ��$ 15(���  � ��$ 4q���  � ��$ Black"���  � ��
 �������  � ��$ 0q���  � �� �	#FFFF4300��  � ��$	 100����  � ��$ 35����  � �� �� " ��.R��� $��PART_Background��#��z��$��0q�$ 16������ $		 0,1&�$	
 0,0&�.��� $ White��$	 0.0Q�� $ 	#FF5C25D7��$	 0.5Q�� $ White��$	 0.0Q�._��� #��z��$��Center=�$��Center=�.��� $��0,10,22.6,0.2q� � ColumnDefinitions �� $
��406* ��� $
��365* �.+��� $�� ��$
��Left=�$	��187��$��391,277,-13.8,0q�$	��Top=�$	��394��$��2���� $��
QG studio ��$
��Left=�$	��173��$��
10,10,-7,0q�$	��Top=�$	��768��$��2��.���� -    ��Name$ protocol��$
��Left=�$��
347,28,0,0q�$	��Top=�$	��120�����	#FFF9F7F7���	#FFD71A1A J� Opacity$ 0.495Q� �� 
IsReadOnly . $��22������ $		 0,1&�$	
 0,0&�.��� $ 	#FFF0F0F0��$ 0Q�� $ 	#FFEDF1EF��$ 1Q�.@��� -   $	��UDP��$
��Left=�$��118.4���� -   $	��TCP��$
��Left=�$��118.4���� -   $��button_start��#��[  $
��Send��$
��Left=�$��203.6,53,0,0q�$	��Top=�$��79��$
 0.64Q�}�. ���	#FF6318B1$��69��$��1���� $��目标IP��$
��Left=�$��	87,53,0,0q�$	��Top=� � Cursor$
 Hand�� J� RenderTransformOrigin$ -3.769,-2.398&����	#FF7E1BE5$��63��$��23���� -    ��Name$ 	text_box1��$
��Left=�$��23��$��
150,53,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��120���� $��目标端口��$
��Left=�$��
87,106,0,0q�$	��Top=�$
 Hand��$ -3.769,-2.398&����	#FF7E1BE5$��63��$��23���� -   $ dst_port��$
��Left=�$��23��$��150,106,0,0q�$
 Wrap=�$	��Top=�$	��120���� $��发
送
内
容��$
��Left=�$��
37,310,0,0q�$	��Top=�$
 Hand��$ -3.769,-2.398&����	#FF7E1BE5$��27��$��71���� $��接
收
内
容��$
��Left=�$��9.6,310,0,0q�$	��Top=�$
 Hand��$ -3.769,-2.398&����	#FF7E1BE5$��27��$��71��$��1���� $��Label��$
��Left=�$��10,150,-13,0q�$	��Top=�$	��774��$��5��$��2���� -   $��send_box��$	 0.5Q�$
��Left=�$	��125��$��
78,309,0,0q�$	��Top=�$	��234��. �/� .T�J� .*�.*��� $� ���� -   $��receive_box��$	 0.5Q� �� 
IsReadOnly . $
��Left=�$	��125��$��51.6,309,0,0q�$	��Top=�$	��260��$��1��. �/� .T�J� .*�.*��� $�[ Message Received ]���� $�� ��$
��Left=�$	��187��$��
19,277,0,0q�$	��Top=�$	��367��.���� -	   $��tcp_send_button��#��[  $
��Send��$
��Left=�$��
291,43,0,0q�$	��Top=�$��58��$��60���� $��协议类型��$
��Left=�$��
302,53,0,0q�$	��Top=�$
 Hand��$ -3.769,-2.398&����	#FF7E1BE5$��63��$��23���� $��本机通信端口��$
��Left=�$��302,105,0,0q�$	��Top=�$
 Hand��$ -3.769,-2.398&����	#FF7E1BE5$��84��$��26���� -
   $ 
local_port��$
��Left=�$��26��$��386,105,0,0q�$
 Wrap=�$	��Top=�$	��100��$��2���� -   $��info_box��$	 0.5Q� . $
��Left=�$��54��$��
19,207,0,0q�$	��Top=�$	��734��$��2��. �/� .T�J� .*�.*��� $�[ INFO ]��J� .*�.*��� ����  �� ImageSource$# /WpfApp1;component/img/qg.png�� �� Opacity$	 0.3Q�