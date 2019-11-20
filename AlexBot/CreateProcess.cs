using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AlexBot
{
	public class CreateProcess : Form
	{
		public ToolSocket s1;

		public Socket s;

		private IContainer components = null;

		private TextBox textBox1;

		private Label label1;

		private Button button1;

		public CreateProcess()
		{
			InitializeComponent();
		}

		private void Button1Click(object sender, EventArgs e)
		{
			s1.sendCommand(s, "link.open", textBox1.Text);
			Close();
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
			button1 = new System.Windows.Forms.Button();
			SuspendLayout();
			textBox1.Location = new System.Drawing.Point(12, 36);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(249, 20);
			textBox1.TabIndex = 0;
			label1.Location = new System.Drawing.Point(12, 19);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(100, 14);
			label1.TabIndex = 1;
			label1.Text = "Имя процесса";
			button1.Location = new System.Drawing.Point(186, 62);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(75, 23);
			button1.TabIndex = 2;
			button1.Text = "Создать";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(273, 105);
			base.Controls.Add(button1);
			base.Controls.Add(label1);
			base.Controls.Add(textBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "CreateProcess";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Создание нового процесса";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
