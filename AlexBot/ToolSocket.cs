using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace AlexBot
{
	public class ToolSocket
	{
		public const int bufferSize = 1024;

		public byte[] Buffer = new byte[1024];

		public static string SecretCode = "290Sko2-0SL";

		public string encoding = "Windows-1251";

		public int LastSize = 0;

		public int Traffic_Write = 0;

		public int Traffic_Read = 0;

		public IPEndPoint localEndPoint;

		public Socket listener;

		public Main m;

		public ToolSocket(string IP, int PORT, Main m1)
		{
			localEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);
			listener = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			m = m1;
		}

		public void Bind()
		{
			listener.Bind(localEndPoint);
		}

		public void Listen(int log)
		{
			listener.Listen(100);
		}

		public void SetBufferSize(int size)
		{
			Buffer = new byte[size];
		}

		public bool Connect(string IP, int PORT)
		{
			try
			{
				listener.Connect(IPAddress.Parse(IP), PORT);
				return true;
			}
			catch (SocketException)
			{
				return false;
			}
		}

		public static bool SocketConnected(Socket s)
		{
			bool flag = s.Poll(1000, SelectMode.SelectRead);
			bool flag2 = s.Available == 0;
			if (flag && flag2)
			{
				return false;
			}
			return true;
		}

		public void AutoStart(int log = 100)
		{
			Bind();
			Listen(log);
		}

		public void SetEncoding(string en)
		{
			encoding = en;
		}

		public Socket Accept()
		{
			try
			{
				return listener.Accept();
			}
			catch (Exception)
			{
				return null;
			}
		}

		public void UpdateTraffic(Socket sk, int bytes, string type)
		{
			int count = 0;
			Action action = delegate
			{
				count = m.ListItems.SelectedItems.Count;
			};
			if (m.InvokeRequired)
			{
				m.Invoke(action);
			}
			else
			{
				action();
			}
			if (count <= 0)
			{
				return;
			}
			string data = "";
			action = delegate
			{
				data = m.ListItems.Items[m.Select].SubItems[6].Text;
			};
			if (m.InvokeRequired)
			{
				m.Invoke(action);
			}
			else
			{
				action();
			}
			int read = int.Parse(data.Split('/')[0].Split(' ')[0]);
			int write = int.Parse(data.Split('/')[1].Split(' ')[1]);
			checked
			{
				if (type == "write")
				{
					action = delegate
					{
						m.ListItems.Items[m.Select].SubItems[6].Text = read + " KB / " + (write + unchecked(bytes / 1024)) + " KB";
					};
					if (m.InvokeRequired)
					{
						m.Invoke(action);
					}
					else
					{
						action();
					}
				}
				else
				{
					action = delegate
					{
						m.ListItems.Items[m.Select].SubItems[6].Text = read + unchecked(bytes / 1024) + " KB / " + write + " KB";
					};
					if (m.InvokeRequired)
					{
						m.Invoke(action);
					}
					else
					{
						action();
					}
				}
			}
		}

		public int Write(string data, Socket sock = null)
		{
			try
			{
				if (sock == null)
				{
					sock = listener;
				}
				UpdateTraffic(sock, data.Length, "write");
				return sock.Send(Encoding.GetEncoding(encoding).GetBytes(data));
			}
			catch (SocketException)
			{
				return 0;
			}
		}

		public string Read(int ReceiveSize, Socket sock = null)
		{
			try
			{
				if (sock == null)
				{
					sock = listener;
				}
				SetBufferSize(ReceiveSize);
				sock.ReceiveTimeout = 10000;
				UpdateTraffic(sock, LastSize = sock.Receive(Buffer), "read");
				if (Buffer == null)
				{
					return "error|error";
				}
				return Encoding.GetEncoding(encoding).GetString(Buffer);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}

		public static string GetLocalIPAddress()
		{
			IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
			IPAddress[] addressList = hostEntry.AddressList;
			int num = 0;
			IPAddress iPAddress;
			while (true)
			{
				if (num < addressList.Length)
				{
					iPAddress = addressList[num];
					if (iPAddress.AddressFamily == AddressFamily.InterNetwork)
					{
						break;
					}
					num++;
					continue;
				}
				return IPAddress.Parse("127.0.0.1").AddressFamily.ToString();
			}
			return iPAddress.ToString();
		}

		public void sendCommand(Socket s, string command, params string[] parameters)
		{
			Write(SecretCode + "|" + command + "|" + string.Join("|", parameters), s);
		}

		public static bool PortInUse(int port)
		{
			bool result = false;
			IPGlobalProperties iPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
			IPEndPoint[] activeTcpListeners = iPGlobalProperties.GetActiveTcpListeners();
			IPEndPoint[] array = activeTcpListeners;
			foreach (IPEndPoint iPEndPoint in array)
			{
				if (iPEndPoint.Port == port)
				{
					result = true;
					break;
				}
			}
			return result;
		}
	}
}
