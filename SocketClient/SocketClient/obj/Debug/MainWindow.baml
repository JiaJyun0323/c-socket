   M S B A M L   `   `   `  ????G  CSocketClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SocketClientSocketClient  5   	       SocketClient.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SocketClient     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ? .+?5
   
   ?? $??Scoket Address : ??6   $
??Left=?6,   $??	44,36,0,0q?6G   $	??Top=?6Z   ?? 5   
   $??
Username :??6   $
??Left=?6%   $??
44,119,0,0q?6@   $	??Top=?6T   ?? 5   
   $??Port :??6   $
??Left=?6!   $??	44,75,0,0q?6<   $	??Top=?6O   ?? 5   
   -   5         ??Name$ 	IPTextBox??5      $??	127.0.0.1??6%   $
??Left=?66   $??
154,36,0,0q?6Q    ?? TextWrapping$
 Wrap=?6e   $	??Top=?6y   $	??174??6?   $??25??6?   ?? 5   
   -   5        $ portTextBox??5      $??20000??6'   $
??Left=?64   $??
154,76,0,0q?6O   $
 Wrap=?6c   $	??Top=?6w   $	??174??6?   $??25??6?   ?? 5   
   -   5        $ usernameTextBox??5      $
??Left=?6+   $??154,119,0,0q?6F   $
 Wrap=?6[   $	??Top=?6o   $	??174??6?   $??25??6?   ?? 5   
   -   5         ??Name$ connectButton??5      $??Connect??6(   $
??Left=?6:   $??184,165,0,0q?6U   $	??Top=?6j   $??42??6?   $	??144??6?   6?   ?? 5   
   $??Message :
??6   $
??Left=?6.   $??
44,276,0,0q?6I   $	??Top=?6]   ?? 5   
   -   5        $ messageTextbox??5      $
??Left=?6*   $??
44,316,0,0q?6E   $
 Wrap=?6Y   $	??Top=?6m   $	??284??6?   $??35??6?   {?.  6?   ?? 5   
   -   5        $ sendMessageButton??5      $??Send Message??6,   $
??Left=?6C   $??186,356,0,0q?6^   $	??Top=?6s   $??49??6?   $	??142??6?   {?.  6?   ?? 5   
   -   5        $ disconnectButton??5      $??
Disconnect??6+   $
??Left=?6@   $??186,217,0,0q?6[   $	??Top=?6p   $??45??6?   $	??142??6?   {?.  6?   ?? 5   
   -   5         ??Name$ 
msgListBox??5      $??364,10,23,30q?6Q   5      5      