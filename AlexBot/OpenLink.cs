using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AlexBot
{
	public class OpenLink : Form
	{
		public Socket sock;

		public ToolSocket tsock;

		private IContainer components = null;

		private Label label1;

		private TextBox textBox1;

		private Button button1;

		public OpenLink()
		{
			InitializeComponent();
		}

		private void Button1Click(object sender, EventArgs e)
		{
			tsock.sendCommand(sock, "link.open", textBox1.Text);
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
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			label1.Location = new System.Drawing.Point(12, 9);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(100, 15);
			label1.TabIndex = 0;
			label1.Text = "Укажите ссылку:*";
			textBox1.Location = new System.Drawing.Point(12, 27);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(232, 20);
			textBox1.TabIndex = 1;
			textBox1.Text = "http://";
			button1.Location = new System.Drawing.Point(12, 53);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 2;
			button1.Text = "Открыть";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(256, 90);
			base.Controls.Add(button1);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "OpenLink";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Открыть ссылку";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
