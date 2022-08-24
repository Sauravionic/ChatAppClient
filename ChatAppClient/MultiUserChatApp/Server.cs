using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MultiUserChatApp
{
    class Server
    {
        TcpClient tcpClient;
        public string message;
        public string username;
        public Server()
        {
            try
            { 
            tcpClient = new TcpClient("192.168.1.44", 7891);
            }
            catch(Exception)
            {
                MessageBox.Show("Server not started. You're not welcome");
            }
            NetworkStream ns = tcpClient.GetStream();
            StreamReader sr = new StreamReader(ns);
            this.message = sr.ReadLine();
        }

        public void connectUser(string username)
        {
            try
            {
                NetworkStream ns = tcpClient.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine("Username is " + username);
                sw.Flush();
                MessageBox.Show("User " + username + " is Connected", "Information");
                sw.Close();
                ns.Close();
                this.username = username;
            }
            catch(InvalidOperationException e)
            {
                MessageBox.Show("User Already Connected");
            }
        }

      public string messageTransaciton(string message)
        {
            string messageToDisplay = "";
            TcpClient tc = new TcpClient("192.168.1.44", 7892);
            try
            {
                NetworkStream ns = tc.GetStream();
                StreamWriter sw = new StreamWriter(ns);
                sw.WriteLine("Chat Sent by " + username + " is " + message);
                sw.Flush();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            try
            {
                NetworkStream ns = tc.GetStream();
                StreamReader sr = new StreamReader(ns);
                messageToDisplay = sr.ReadLine();
                sr.Close(); 
            }
            catch(Exception e)
            {

            }
            return messageToDisplay;
        } 
        
    }
}

        /*
        public void ConnectToServer(string username)
        {
            if(!tcpClient.Connected)
            { 
                tcpClient.Connect("127.0.0.1", 7891);
                NetworkStream ns = tcpClient.GetStream();
                byte[] bytes = Encoding.ASCII.GetBytes(username);
                ns.Write(bytes, 0, bytes.Length);
                ns.Close();
                string userConnected = UserConnected();
            }
        } 

        public string UserConnected(TcpClient tcpClient)
        {
            
            
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7895);

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                server.Connect(ip);
            }
            catch (SocketException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }

            byte[] data = new byte[1024];
            int receivedDataLength = server.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
            //System.Diagnostics.Trace.WriteLine(stringData);
            server.Close();
            return stringData;
            
        }
        
        public string connection(string username)
        {
            if (!tcpClient.Connected)
            {
                tcpClient.Connect("127.0.0.1", 7891);

                //Send username to server from client (server.cs to client.cs)

                PacketBuilder packetBuilder = new PacketBuilder(tcpClient);
                packetBuilder.writeMessage(username);

                string userConnected = UserConnected(tcpClient);
                return userConnected;
            }
            return null;
        }

        public void sendMessage(string message)
        {
            
        }

        public string messageReceived()
        {
            return null;
        }
    }
    */
