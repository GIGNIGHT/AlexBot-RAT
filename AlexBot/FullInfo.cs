using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace AlexBot
{
	public class FullInfo : Form
	{
		public ToolSocket tsock;

		public Socket sock;

		public string ip;

		private IContainer components = null;

		private ListView listView1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem toolStripMenuItem_0;

		public FullInfo()
		{
			InitializeComponent();
		}

		public void LoadInformation()
		{
			string contents;
			if (!Directory.Exists("cache/userinfo/" + ip) && !File.Exists("cache/userinfo/" + ip + "/allinfo.bin"))
			{
				tsock.sendCommand(sock, "fullinfo", "1");
				contents = tsock.Read(10240, sock);
				Directory.CreateDirectory("cache/userinfo/" + ip);
				File.WriteAllText("cache/userinfo/" + ip + "/allinfo.bin", contents);
			}
			if (File.Exists("cache/userinfo/" + ip + "/allinfo.bin"))
			{
				contents = File.ReadAllText("cache/userinfo/" + ip + "/allinfo.bin");
			}
			else
			{
				tsock.sendCommand(sock, "fullinfo", "1");
				contents = tsock.Read(10240, sock);
				Directory.CreateDirectory("cache/userinfo/" + ip);
				File.WriteAllText("cache/userinfo/" + ip + "/allinfo.bin", contents);
			}
			string[] array = contents.Split('|');
			string[] array2 = array;
			foreach (string text in array2)
			{
				string[] info = text.Split('/');
				Invoke((Action)delegate
				{
					listView1.Items.Add(info[0]).SubItems.Add(info[1]);
				});
			}
		}

		private void FullInfoLoad(object sender, EventArgs e)
		{
			Thread thread = new Thread(LoadInformation);
			thread.IsBackground = true;
			thread.Start();
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			if (File.Exists("cache/userinfo/" + ip + "/allinfo.bin"))
			{
				File.Delete("cache/userinfo/" + ip + "/allinfo.bin");
			}
			string contents;
			if (!Directory.Exists("cache/userinfo/" + ip) && !File.Exists("cache/userinfo/" + ip + "/allinfo.bin"))
			{
				tsock.sendCommand(sock, "fullinfo", "1");
				contents = tsock.Read(10240, sock);
				Directory.CreateDirectory("cache/userinfo/" + ip);
				File.WriteAllText("cache/userinfo/" + ip + "/allinfo.bin", contents);
			}
			if (File.Exists("cache/userinfo/" + ip + "/allinfo.bin"))
			{
				contents = File.ReadAllText("cache/userinfo/" + ip + "/allinfo.bin");
			}
			else
			{
				tsock.sendCommand(sock, "fullinfo", "1");
				contents = tsock.Read(10240, sock);
				Directory.CreateDirectory("cache/userinfo/" + ip);
				File.WriteAllText("cache/userinfo/" + ip + "/allinfo.bin", contents);
			}
			string[] array = contents.Split('|');
			string[] array2 = array;
			foreach (string text in array2)
			{
				string[] info = text.Split('/');
				_003C_003Ec__DisplayClass4 @object;
				Invoke(new Action(@object.method_0));
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
			components = new System.ComponentModel.Container();
			listView1 = new System.Windows.Forms.ListView();
			columnHeader1 = new System.Windows.Forms.ColumnHeader();
			columnHeader2 = new System.Windows.Forms.ColumnHeader();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			listView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2]
			{
				columnHeader1,
				columnHeader2
			});
			listView1.ContextMenuStrip = contextMenuStrip1;
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.Location = new System.Drawing.Point(0, 0);
			listView1.Name = "listView1";
			listView1.Size = new System.Drawing.Size(500, 280);
			listView1.TabIndex = 0;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = System.Windows.Forms.View.Details;
			columnHeader1.Text = "Наименование";
			columnHeader1.Width = 120;
			columnHeader2.Text = "Информация";
			columnHeader2.Width = 220;
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[1]
			{
				toolStripMenuItem_0
			});
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
			toolStripMenuItem_0.Name = "обновитьДанныеToolStripMenuItem";
			toolStripMenuItem_0.Size = new System.Drawing.Size(172, 22);
			toolStripMenuItem_0.Text = "Обновить данные";
			toolStripMenuItem_0.Click += new System.EventHandler(toolStripMenuItem_0_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(499, 281);
			base.Controls.Add(listView1);
			base.Name = "FullInfo";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Информация о компьютере";
			base.Load += new System.EventHandler(FullInfoLoad);
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}
	}
}
