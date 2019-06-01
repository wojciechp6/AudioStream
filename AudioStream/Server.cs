using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class StateObject
{
    public IPEndPoint endPoint;
    public UdpClient udpClient;
    public ManualResetEvent allDone;
}

public class Server
{
    public event Action<byte[], int> OnDataReceived;
    public event Action<int> OnDataSended;

    UdpClient client, listener;

    private Server(UdpClient client, int port, bool isServer)
    {
        if (isServer)
            Listen(port);
        else
        {
            this.client = client;
            Send(Encoding.ASCII.GetBytes("connect"));
        }
    }

    public static Server StartListening(int port)
    {
        return new Server(null, port, true);
    }

    public static Server Connect(byte[] ip, int port)
    {
        IPAddress ipAddress = ip.Length != 0 ? new IPAddress(ip) : LocalIPAddress();
        IPEndPoint endPoint = new IPEndPoint(ipAddress, port);

        UdpClient client = new UdpClient();
        client.Connect(endPoint);
        Console.WriteLine(endPoint);

        return new Server(client, port, false);
    }

    public static IPAddress LocalIPAddress()
    {
        if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
        {
            return null;
        }

        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

        return host
            .AddressList
            .FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
    }

    public static void SearchForLocalReceivers(int port, Action<IEnumerable<IPAddress>> callback)
    {
        Task.Run(() =>
        {
            try
            {
                UdpClient broadcast = new UdpClient(port);
                byte[] msg = Encoding.ASCII.GetBytes("ping");
                broadcast.Send(msg, msg.Length, new IPEndPoint(IPAddress.Broadcast, port));

                var list = new List<IPAddress>();
                IPAddress myself = LocalIPAddress();

                broadcast.Client.ReceiveTimeout = 500;
                try // Catch the timeout exception 
                {
                    while (true)
                    {
                        var any = new IPEndPoint(IPAddress.Any, port);
                        var data = broadcast.Receive(ref any);
                        if (any.Address.ToString() != myself.ToString())
                        {
                            list.Add(any.Address);
                            callback(list);
                        }
                    }
                }
                catch { }
                broadcast.Close();
            }
            catch { }
        });
    }

    void Listen(int port)
    {
        try
        {
            Task.Run(() =>
            {
                ManualResetEvent allDone = new ManualResetEvent(false);

                while (true)
                {
                    allDone.Reset();
                    Console.WriteLine("Waiting for a connection...");

                    var any = new IPEndPoint(IPAddress.Any, port);
                    var listener = new UdpClient(port);
                    listener.BeginReceive(new AsyncCallback(AcceptCallback), new StateObject { endPoint = any, udpClient = listener, allDone = allDone });

                    allDone.WaitOne();
                }
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    void AcceptCallback(IAsyncResult ar)
    {

        var state = ar.AsyncState as StateObject;
        byte[] data = state.udpClient.EndReceive(ar, ref state.endPoint);
        string msg = Encoding.ASCII.GetString(data);
        Console.WriteLine(msg);
        if (msg == "connect")
        {
            Console.WriteLine(state.endPoint);
            client = state.udpClient;
            client.BeginReceive(new AsyncCallback(ReadCallback), state.endPoint);
        }
        else
        {
            state.udpClient.Send(data, data.Length, state.endPoint);
            state.udpClient.Close();
            state.allDone.Set();
        }
    }

    void ReadCallback(IAsyncResult ar)
    {
        var ip = ar.AsyncState as IPEndPoint;
        byte[] data = client.EndReceive(ar, ref ip);

        OnDataReceived?.Invoke(data, data.Length);
        client.BeginReceive(new AsyncCallback(ReadCallback), ip);
    }

    public void Send(byte[] data, int bytesCount = -1)
    {
        client.BeginSend(data, bytesCount >= 0 ? bytesCount : data.Length, new AsyncCallback(SendCallback), null);
    }

    private void SendCallback(IAsyncResult ar)
    {
        try
        {
            int bytesSent = client.EndSend(ar);
            OnDataSended?.Invoke(bytesSent);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public void Close()
    {
        client?.Close();
    }
}