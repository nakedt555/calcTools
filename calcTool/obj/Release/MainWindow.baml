   M S B A M L   `   `   `  ���� C  ?calcTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:calcToolcalcTool      calcTool.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:calcTool     -     �Name$  calcToos�� � Title$ 	caclTools��$��191.304��$��398.951�� � 
ResizeMode$ NoResize=�.��� $	��172��$	��Top=�$��0,0,2,0q� � ColumnDefinitions �� $
��280* ��� $
��111* �.+��� $
��Left=�$	��177��$	��Top=�$	��393��$��2��$��	0,0,-2,-5q�.@��� $��進数変換��$��0,0,0,-2q�$	��100��.��� ���	#FFE5E5E5$	��160��$	��Top=�$��
0,-24,-3,0q� �� $	��26* ��� $
��Auto �$��18���� $��0 ��� $	��11* ��� $	��62* ��� $
��273* �.+��� -    ��Name$ input_binery��$
��Left=�$��26��$��	10,33,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��254��$��3��$��3�� �� TextAlignment$ Right=��� $
��Left=�$��24��$��1,35,0,0q�$
��Wrap=�$��2進数��$	��Top=�$��53��$��14(� �� TextAlignment$ Center=�$��4�� J� RenderTransformOrigin$ 1.482,2.068&��� -   	 ��Name$	 	clear_btn��$��	クリア��$��5��$
��Left=�$��
196,33,0,0q�$	��Top=�$��58��$��26��$ 0.58,-0.636&��� -   $ input_decimal��$
��Left=�$��26��$��	10,70,0,0q�$
 Wrap=�$	��Top=�$	��254��$��3��$��3��$ Right=��� $
��Left=�$��24��$��1,72,0,0q�$
��Wrap=�$	��Top=�$��53��$��14(�$ Center=�$��4��$ 1.482,2.068&��� $�10���� $�進数���� -   $ 	input_hex��$
��Left=�$��26��$��
10,108,0,0q�$
 Wrap=�$	��Top=�$	��254��$��3��$��3��$ Right=��� $
��Left=�$��24��$��	1,110,0,0q�$
��Wrap=�$	��Top=�$��53��$��14(�$ Center=�$��4��$ 1.482,2.068&��� $�16���� $�進数���� $��周期・周波数変換��$
��Left=�$	��100��$��0,0,0,-2q�.��� ���	#FFE5E5E5$��-21,-77,-310,-5q�.+��� -   $ 
input_freq��$
��Left=�$��23��$��	77,94,0,0q�$
 Wrap=�$	��Top=�$	��252���� -   $ input_period��$
��Left=�$��23��$��
77,166,0,0q�$
 Wrap=�$	��Top=�$	��252���� -   $		 f2p��$��	↓変換��$
��Left=�$��165,132,0,0q�$	��Top=�$��75��$ 1.051,0.679&��� -	   
 ��Name$
 p_unit_menu��$
��Left=�$��334,166,0,0q�$	��Top=�$��60���� -
   $		 p2f��$��	↑変換��$
��Left=�$��
77,132,0,0q�$	��Top=�$��75���� -   $
 f_unit_menu��$
��Left=�$��
334,95,0,0q�$	��Top=�$��60���� $
��Left=�$��22��$��	28,95,0,0q�$
��Wrap=�$��	周波数��$	��Top=�$��44��$��14(�$ Center=��� $
��Left=�$��23��$��
28,166,0,0q�$
��Wrap=�$��周期��$	��Top=�$��44��$ Center=�$��16(���Z� �� -   $	 clear��$��	クリア��$
��Left=�$��254,132,0,0q�$	��Top=�$��75��$ 1.051,0.679&�