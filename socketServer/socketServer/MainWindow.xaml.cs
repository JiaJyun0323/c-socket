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

namespace socketServer
{



    public partial class MainWindow : Window
    {
        public Socket server;
        public string host ="127.0.0.1";
        public int port = 15000;
        private HashSet<Socket> socketHashSet = new HashSet<Socket>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void portTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IPTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void startServerBT_Click(object sender, RoutedEventArgs e)
        {
            if (server == null)
            {
                host = IPTextbox.Text.ToString();
                port = Int16.Parse(portTextbox.Text.ToString());

                msgListBox.Items.Add("ip :"+host+"  port :"+port+"  Server Start");
                IPAddress ip = IPAddress.Parse(host);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);//SocketOptionLevel.Socket:socket 選項會套用至所有通訊端。
                                                                                                      //ReuseAddress:允許要繫結至已使用中位址的通訊端
                IPEndPoint point = new IPEndPoint(ip, port);
                server.Bind(point);
                server.Listen(5);

                Thread thread = new Thread(ListenCline);
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void ListenCline()
        {
            while (true)
            {
                try
                {
                    Socket client = server.Accept();
                    string clientIP = client.RemoteEndPoint.ToString();


                    Thread receiveMsg = new Thread(ReceiveMsg);
                    receiveMsg.IsBackground = true;
                    receiveMsg.Start(client);
                }
                catch
                { return; }
            }
        }

        public void ReceiveMsg(object client)
        {
            bool isName = false;
            string username = "";
            Socket clientConn = (Socket)client;
            socketHashSet.Add(clientConn);
            IPAddress clientIP = (clientConn.RemoteEndPoint as IPEndPoint).Address;
            //msgListBox.Items.Add("  connect");

            while (true)
            {
                try
                {
                 
                    byte[] result = new byte[1024];
                    //receive message from client
                    int receive_num = clientConn.Receive(result);
                    String receive_str = Encoding.ASCII.GetString(result, 0, receive_num);
                    if (receive_num > 0)
                    {
                        if (isName == false)
                        {
                            username = receive_str;
                            isName = true;
                            msgListBox.Dispatcher.BeginInvoke(new Action(() => { msgListBox.Items.Add(username + "  connect"); }), null);
                            foreach (Socket s in socketHashSet)
                            {
                                s.Send(Encoding.ASCII.GetBytes("Welcome " + username + "\n"));

                            }
                            continue;
                        }
                        else if(receive_str=="disconnect"){
                            socketHashSet.Remove(clientConn);
                            foreach (Socket s in socketHashSet)
                            {
                                s.Send(Encoding.ASCII.GetBytes(username + "disconnect" + "\n"));
                            }
                            clientConn.Shutdown(SocketShutdown.Both);
                            clientConn.Close();
                        }
                        String send_str = username + " : " + receive_str;

                        //resend message to client
                        foreach(Socket s in socketHashSet)
                        {
                            s.Send(Encoding.ASCII.GetBytes(username + ":" + receive_str));

                        }

                        msgListBox.Dispatcher.BeginInvoke(
                            new Action(() => { msgListBox.Items.Add(send_str); }), null);

                    }
                }
                catch (Exception e)
                {
                    return;
                    //exception close()
                    //clientConn.Send(Encoding.ASCII.GetBytes("用戶離開" ));
                    //Console.WriteLine(e);
                    //clientConn.Shutdown(SocketShutdown.Both);
                    //clientConn.Close();
                    //break;
                }
            }
            }

        private void stopListenBT_Click(object sender, RoutedEventArgs e)
        {
            if (server != null)
            {
                foreach (Socket s in socketHashSet)
                {
                    s.Send(Encoding.ASCII.GetBytes("server disconnect"));
                    s.Shutdown(SocketShutdown.Both);
                    s.Close();
                }
                socketHashSet.Clear();
                //server.Shutdown(SocketShutdown.Both);
                server.Close();
                server = null;
            }
        }
    }
}
