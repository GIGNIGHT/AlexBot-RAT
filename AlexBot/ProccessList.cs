using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace AlexBot
{
	public class ProccessList : Form
	{
		public Socket selected;

		public ToolSocket tsock;

		public string proccessname = "";

		private IContainer components = null;

		private ListView listView1;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader6;

		private ColumnHeader threads;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		public ProccessList()
		{
			InitializeComponent();
		}

		private void ProccessListLoad(object sender, EventArgs e)
		{
			tsock.sendCommand(selected, "proccess.getList", "1");
			string[] array = tsock.Read(10240, selected).Split('|');
			string[] array2 = array;
			foreach (string text in array2)
			{
				string[] inf = text.Split('/');
				if (inf.Length > 2)
				{
					ListViewItem item = null;
					Action action = delegate
					{
						item = listView1.Items.Add(inf[0]);
					};
					if (base.InvokeRequired)
					{
						Invoke(action);
					}
					else
					{
						action();
					}
					if (proccessname == inf[0])
					{
						Invoke((Action)delegate
						{
							item.ForeColor = Color.Red;
						});
						Invoke((Action)delegate
						{
							item.Font = new Font(listView1.Font, FontStyle.Bold);
						});
						Invoke((Action)delegate
						{
							item.SubItems.AddRange(new string[2]
							{
								inf[1],
								inf[2]
							});
						});
					}
					else
					{
						Invoke((Action)delegate
						{
							item.SubItems.AddRange(new string[2]
							{
								inf[1],
								inf[2]
							});
						});
					}
				}
			}
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem selectedItem in listView1.SelectedItems)
			{
				tsock.sendCommand(selected, "proccess.kill", selectedItem.Text + ".exe");
			}
			Action action = method_0;
			if (base.InvokeRequired)
			{
				Invoke(action);
			}
			else
			{
				action();
			}
			tsock.sendCommand(selected, "proccess.getList", "1");
			try
			{
				string[] array;
				if ((array = tsock.Read(10240, selected).Split('|')) != null)
				{
					string[] array2 = array;
					foreach (string text in array2)
					{
						string[] inf = text.Split('/');
						if (inf.Length > 2)
						{
							ListViewItem item = null;
							_003C_003Ec__DisplayClass19 @object;
							action = @object.method_0;
							if (base.InvokeRequired)
							{
								Invoke(action);
							}
							else
							{
								action();
							}
							if (proccessname == inf[0])
							{
								Invoke(new Action(@object.method_1));
								Invoke(new Action(@object.method_2));
								Invoke(new Action(@object.method_3));
							}
							else
							{
								Invoke(new Action(@object.method_4));
							}
						}
					}
				}
			}
			catch (Exception)
			{
				Close();
			}
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			Action action = method_1;
			if (base.InvokeRequired)
			{
				Invoke(action);
			}
			else
			{
				action();
			}
			tsock.sendCommand(selected, "proccess.getList", "1");
			try
			{
				string[] array;
				if ((array = tsock.Read(10240, selected).Split('|')) != null)
				{
					string[] array2 = array;
					foreach (string text in array2)
					{
						string[] inf = text.Split('/');
						if (inf.Length > 2)
						{
							ListViewItem item = null;
							_003C_003Ec__DisplayClass27 @object;
							action = @object.method_0;
							if (base.InvokeRequired)
							{
								Invoke(action);
							}
							else
							{
								action();
							}
							if (proccessname == inf[0])
							{
								Invoke(new Action(@object.method_1));
								Invoke(new Action(@object.method_2));
								Invoke(new Action(@object.method_3));
							}
							else
							{
								Invoke(new Action(@object.method_4));
							}
						}
					}
				}
			}
			catch (Exception)
			{
				Close();
			}
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			CreateProcess createProcess = new CreateProcess();
			createProcess.s = selected;
			createProcess.s1 = tsock;
			createProcess.ShowDialog();
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
			columnHeader5 = new System.Windows.Forms.ColumnHeader();
			columnHeader6 = new System.Windows.Forms.ColumnHeader();
			threads = new System.Windows.Forms.ColumnHeader();
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
			toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
			listView1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[3]
			{
				columnHeader5,
				columnHeader6,
				threads
			});
			listView1.ContextMenuStrip = contextMenuStrip1;
			listView1.Font = new System.Drawing.Font("Segoe UI Light", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.HoverSelection = true;
			listView1.Location = new System.Drawing.Point(0, 0);
			listView1.Name = "listView1";
			listView1.Size = new System.Drawing.Size(562, 299);
			listView1.TabIndex = 2;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = System.Windows.Forms.View.Details;
			columnHeader5.Text = "Имя процесса";
			columnHeader5.Width = 120;
			columnHeader6.Text = "ID";
			columnHeader6.Width = 90;
			threads.Text = "Потоки";
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3]
			{
				toolStripMenuItem_0,
				toolStripMenuItem_1,
				toolStripMenuItem_2
			});
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(162, 92);
			toolStripMenuItem_0.Name = "завершитьToolStripMenuItem";
			toolStripMenuItem_0.Size = new System.Drawing.Size(161, 22);
			toolStripMenuItem_0.Text = "Завершить";
			toolStripMenuItem_0.Click += new System.EventHandler(toolStripMenuItem_0_Click);
			toolStripMenuItem_1.Name = "обновитьToolStripMenuItem";
			toolStripMenuItem_1.Size = new System.Drawing.Size(161, 22);
			toolStripMenuItem_1.Text = "Обновить";
			toolStripMenuItem_1.Click += new System.EventHandler(toolStripMenuItem_1_Click);
			toolStripMenuItem_2.Name = "новыйПроцессToolStripMenuItem";
			toolStripMenuItem_2.Size = new System.Drawing.Size(161, 22);
			toolStripMenuItem_2.Text = "Новый процесс";
			toolStripMenuItem_2.Click += new System.EventHandler(toolStripMenuItem_2_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(562, 299);
			base.Controls.Add(listView1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Name = "ProccessList";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Процессы";
			base.Load += new System.EventHandler(ProccessListLoad);
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}

		[CompilerGenerated]
		private void method_0()
		{
			listView1.Items.Clear();
		}

		[CompilerGenerated]
		private void method_1()
		{
			listView1.Items.Clear();
		}
	}
}
