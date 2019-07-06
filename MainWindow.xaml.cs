using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Socket socket;
        bool sendButtonCanHidden;
        Thread thread;
        Service service = new Service();
        public MainWindow()
        {
            InitializeComponent();
            //隐藏TCP发送按钮
            tcp_send_button.Visibility = Visibility.Hidden;
            //默认选择UDP测试
            protocol.SelectedIndex = 0;
            
         
        }

        private void Ping(object sender, RoutedEventArgs e)
        {
            TextRange textRangeSend = new TextRange(
                send_box.Document.ContentStart,
                send_box.Document.ContentEnd
                );
            if (protocol.Text.Equals("UDP") && button_start.Content.Equals("Send"))
            {
                if (text_box1.Text.Equals("") || dst_port.Equals("") || local_port.Equals(""))
                {
                    info_box.AppendText("Some properties should not be empty."+"\n");
                }
                String info = "";
                String status= service.UdpWorker(text_box1.Text, dst_port.Text,local_port.Text,textRangeSend.Text,out info);
                if (status.Equals(Constant.SUCCESS))
                {
                    info_box.AppendText(info + "\n");
                }
                else
                {
                    info_box.AppendText("create udp client error!");
                }
                
            }
            //开启连接
            if (protocol.Text.Equals("TCP")&&button_start.Content.Equals("Connect"))
            {
                int tempDstPort;
                int myPort;
                int.TryParse(dst_port.Text, out tempDstPort);
                int.TryParse(local_port.Text, out myPort);
                bool isConnected=false;
                if (myPort < 65531)
                {
                    //建立连接
                    isConnected = service.Connect(text_box1.Text, tempDstPort, myPort, out socket);
                }
                
                
                if (isConnected)
                {
                    button_start.Content = "Stop";
                    info_box.AppendText("Connect success." + "\n");
                    //显示发送按钮
                    tcp_send_button.Visibility = Visibility.Visible;
                    sendButtonCanHidden = false;
                     thread = new Thread(
                    () => ListenAny(socket)
                        );
                    thread.Start();
                }
                else
                {
                    info_box.AppendText("Connect fail."+"\n");
                    //创建失败，及时释放
                    service.DestroySocket(socket);
                    sendButtonCanHidden = true;
                }

            }
            else if (button_start.Content.Equals("Stop"))
            {
                //在释放socket之前必须先关闭读取线程，否则出错
                thread.Abort();
                //释放连接
                service.DestroySocket(socket);
                button_start.Content = "Connect";
                //隐藏发送按钮
                tcp_send_button.Visibility = Visibility.Hidden;
            }
            


        }

       

        private void ListenAny(Socket listenSocket)
        {
            //listenSocket.Listen(100);
               // listenSocket.Listen(1000);
                while (true)
                {
                    string receiveData = service.Receive(listenSocket, 5000*2); //10 seconds timeout.
                    Thread.Sleep(80);
                //通过反射机制，多线程共享一个组件
                if (receiveData != "" && !receiveData.Equals(null))
                {
                    Action action = () =>
                    {

                        receive_box.AppendText(receiveData+"\n");
                    };
                    receive_box.Dispatcher.BeginInvoke(action);
                }
                    
                   
                    //acceptSocket.Send(Encoding.Default.GetBytes("ok"));
                   // service.DestroySocket(acceptSocket); //import
                }
            
           
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
        /**
         * UDP select 
         */
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            //恢复UDP的样式
            button_start.Content = "Send";
            tcp_send_button.Visibility = Visibility.Hidden;
        }
        /**
         * TCP select 
         */
        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
             button_start.Content = "Connect";
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        //TCP send
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextRange textRangeSend = new TextRange(
                send_box.Document.ContentStart,
                send_box.Document.ContentEnd
                );
            service.TcpSend(textRangeSend.Text,socket);
        }
        public void Switch_Connect_Way()
        {
            //清理接收内容的富文本框
        }

    }
}
