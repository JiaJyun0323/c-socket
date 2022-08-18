using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SocketClient
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public Socket client;
        public string host = "127.0.0.1";
        public int port = 15000;
        public string username = "";
        public string message = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, RoutedEventArgs e)
        {
            host = IPTextBox.Text.ToString();
            port = Int16.Parse(portTextBox.Text.ToString());
            username = usernameTextBox.Text.ToString();
            connectClick();

            IPAddress ip = IPAddress.Parse(host);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint point = new IPEndPoint(ip, port);
            client.Connect(point);
            client.Send((Encoding.ASCII.GetBytes(username)));

            Thread receiveThread = new Thread(ReceiveMsg);
            receiveThread.Start();
        }

        public void ReceiveMsg()
        {
            while (true)
            {
                try
                {
                    byte[] result = new byte[1024];
                    int receiveNumber = client.Receive(result);
                    String recStr = Encoding.ASCII.GetString(result, 0, receiveNumber);
                    msgListBox.Dispatcher.BeginInvoke(
                           new Action(() => { msgListBox.Items.Add(recStr); }), null);

                    Trace.WriteLine("server disconnect");

                    if (recStr == "server disconnect")
                    {
                        //disconnect method
                        //msgListBox.Items.Add("server disconnect");
                        return;
                    }

                }
                catch (Exception ex)
                {
                    //中斷
                }
            }
        }
            
        private void disconnectButton_Click(object sender, RoutedEventArgs e)
        {
            disconnClick();
            client.Send((Encoding.ASCII.GetBytes("disconnect")));
            msgListBox.Items.Add("disconnect");
            client.Shutdown(SocketShutdown.Both);
            client.Disconnect(false);
            client.Close();
        }




        private void sendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            message = messageTextbox.Text.ToString();
            try
            {
                client.Send(Encoding.ASCII.GetBytes(message));
                messageTextbox.Text = "";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void disconnClick()
        {
            messageTextbox.IsEnabled = false;
            sendMessageButton.IsEnabled = false;
            disconnectButton.IsEnabled = false;
            connectButton.IsEnabled = true;
            portTextBox.IsEnabled = true;
            IPTextBox.IsEnabled = true;
            usernameTextBox.IsEnabled = true;
        }
        private void connectClick()
        {
            messageTextbox.IsEnabled = true;
            sendMessageButton.IsEnabled = true;
            disconnectButton.IsEnabled = true;
            connectButton.IsEnabled = false;
            portTextBox.IsEnabled = false;
            IPTextBox.IsEnabled = false;
            usernameTextBox.IsEnabled = false;
        }
    }
}
