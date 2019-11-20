using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AlexBot
{
	public class MessageDialog : Form
	{
		public Socket selected;

		public ToolSocket tsock;

		private IContainer components = null;

		private TextBox textBox1;

		private Label label1;

		private Label label2;

		private TextBox textBox2;

		private Button button1;

		public MessageDialog()
		{
			InitializeComponent();
		}

		private void Button1Click(object sender, EventArgs e)
		{
			tsock.sendCommand(selected, "message", textBox2.Text, textBox1.Text);
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
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			textBox1.Location = new System.Drawing.Point(12, 38);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(202, 20);
			textBox1.TabIndex = 0;
			label1.Location = new System.Drawing.Point(12, 22);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(152, 13);
			label1.TabIndex = 1;
			label1.Text = "Заголовок сообщения";
			label2.Location = new System.Drawing.Point(12, 70);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(100, 15);
			label2.TabIndex = 2;
			label2.Text = "Сообщение";
			textBox2.AllowDrop = true;
			textBox2.Location = new System.Drawing.Point(12, 88);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox2.Size = new System.Drawing.Size(202, 70);
			textBox2.TabIndex = 3;
			button1.Location = new System.Drawing.Point(12, 171);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(202, 23);
			button1.TabIndex = 4;
			button1.Text = "Отправить";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(226, 206);
			base.Controls.Add(button1);
			base.Controls.Add(textBox2);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(textBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "MessageDialog";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Отправить сообщение";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
