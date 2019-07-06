using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Service
    {
        
        static byte[] buffer = new byte[4096];
        private static int count;
        private static Encoding encode = Encoding.Default;

        public String UdpWorker(String dst_ip,String dst_port,String localPort,String message,out String sendMessage)
        {
            int tempLocalPort;
            int.TryParse(localPort, out tempLocalPort);
            UdpClient client = new UdpClient(tempLocalPort);
            String ret="";
            try
            {
                int temp_port;
                int.TryParse(dst_port,out temp_port);
                IPEndPoint ipendpoint = new IPEndPoint(IPAddress.Parse(dst_ip), temp_port);
                byte[] data = Encoding.Default.GetBytes(message);
                client.Send(data, data.Length, ipendpoint);
                sendMessage = "send success";
                //并且接收返回的
               //byte[] ret_bytes= client.Receive(ref ipendpoint);
                client.Close();
                //转化
                //ret = Encoding.Default.GetString(ret_bytes, 0, ret_bytes.Length);
            }
            catch (Exception)
            {
                ret = Constant.ERROR;
                sendMessage = "send error";
            }
            ret = Constant.SUCCESS;
            return ret;
        }


        public static void ClientAccepted(IAsyncResult ar)
        {
            #region
            //设置计数器
            count++;
            var socket = ar.AsyncState as Socket;
            //这就是客户端的Socket实例，我们后续可以将其保存起来
            var client = socket.EndAccept(ar);
            //客户端IP地址和端口信息
            IPEndPoint clientipe = (IPEndPoint)client.RemoteEndPoint;


            //接收客户端的消息(这个和在客户端实现的方式是一样的）异步
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), client);
            //准备接受下一个客户端请求(异步)
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);
            #endregion
        }
        public static void ReceiveMessage(IAsyncResult ar)
        {
            int length = 0;
            string message = "";
            var socket = ar.AsyncState as Socket;
            //客户端IP地址和端口信息
            IPEndPoint clientipe = (IPEndPoint)socket.RemoteEndPoint;
            try
            {
                #region
             
                length = socket.EndReceive(ar);
                //读取出来消息内容
                message = Encoding.UTF8.GetString(buffer, 0, length);
                
                //服务器发送消息
                socket.Send(Encoding.UTF8.GetBytes("server received data")); //默认Unicode
                //接收下一个消息(因为这是一个递归的调用，所以这样就可以一直接收消息）异步
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
                #endregion
            }
            catch (Exception ex)
            {
                new Service().DestroySocket(socket);
            }
        }
      
        public void TcpSend(string data, Socket clientSocket)
        {
            if (clientSocket.Connected)
            {
                clientSocket.Send(encode.GetBytes(data));
            }
        }
        public bool Connect(string host, int port, int localPort, out Socket socket)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //做一个绑定  允许接收信息
            clientSocket.Bind(new IPEndPoint(IPAddress.Any, localPort));
            socket = clientSocket;
            //尝试连接
            try
            {
                socket.Connect(host, port);
            }
            catch (Exception)
            {
                return false;
            }
            
            //返回连接结果
            return socket.Connected;
        }

        public  string Receive(Socket socket, int timeout)
        {
            string result = string.Empty;
            socket.ReceiveTimeout = timeout;
            List<byte> data = new List<byte>();
            byte[] buffer = new byte[1024];
            int length = 0;
            try
            {
                while ((length = socket.Receive(buffer)) > 0)
                {
                    for (int j = 0; j < length; j++)
                    {
                        data.Add(buffer[j]);
                    }
                    if (length < buffer.Length)
                    {
                        break;
                    }
                }
            }
            catch { }
            if (data.Count > 0)
            {
                result = encode.GetString(data.ToArray(), 0, data.Count);
            }
            return result;
        }
        public  void DestroySocket(Socket socket)
        {
            if (socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
            }
            socket.Close();
        }
    }
}
