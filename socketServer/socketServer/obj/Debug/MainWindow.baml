   M S B A M L   `   `   `  ????G  CsocketServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:socketServersocketServer  5   	       socketServer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:socketServer     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ? .+?5
   
   ?? -   5         ??Name$ 	IPTextbox??5
      $??	127.0.0.1??6%   $
??Left=?66   $??	99,29,0,0q?6Q    ?? TextWrapping$
 Wrap=?6d   $	??Top=?6x   $	??313??6?   $??34??6?   6?   ?? 5   
   $
??IP :??6   $
??Left=?6   $??	39,29,0,0q?6:   $	??Top=?6M   $??38??6e   $??42??6q   ?? 5   
   -   5        $ portTextbox??5      $??20000??6'   $
??Left=?64   $??	99,89,0,0q?6O   $
 Wrap=?6b   $	??Top=?6v   $	??313??6?   $??33??6?   6?   ?? 5   
   $??Port :??6   $
??Left=?6!   $??	39,85,0,0q?6<   $	??Top=?6O   $??37??6g   $??42??6s   ?? 5   
   -   5         ??Name$ startServerBT??5      $??Start Server??6(   $
??Left=?6?   $??
541,29,0,0q?6Z   $	??Top=?6n   $??41??6?   $	??145??6?   6?   ?? 5   
   -   5        $ stopListenBT??5      $??Stop Listen??6'   $
??Left=?6=   $??
541,94,0,0q?6X   $	??Top=?6l   $??39??6?   $	??145??6?   6?   ?? 5   
   -   5         ??Name$ 
msgListBox??5      $??30,145,30,10q?6Q   5      5      