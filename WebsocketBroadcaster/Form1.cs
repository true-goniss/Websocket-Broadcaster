using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace WebsocketBroadcaster
{
    public partial class Form1 : Form
    {

        WebSocketServer wss;

        public Form1()
        {
            InitializeComponent();

            string port = "12000";
            string wssUrl = "ws://" + System.Net.IPAddress.Any + ":" + port;
            labelPort.Text = port;

            wss = new WebSocketServer(wssUrl);
            wss.Start();
            wss.AddWebSocketService<SocketBehavior>("/");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class SocketBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Sessions.Broadcast(e.Data);
        }

        protected override void OnOpen()
        {

        }
    }
}
