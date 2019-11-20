using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace AlexBot
{
	public class Speaker : Form
	{
		public Socket sock;

		public ToolSocket tsock;

		private IContainer components = null;

		private TextBox textBox1;

		private Button button1;

		private Button button2;

		public Speaker()
		{
			InitializeComponent();
		}

		private void Button1Click(object sender, EventArgs e)
		{
			tsock.sendCommand(sock, "syntez", textBox1.Text);
		}

		private void Button2Click(object sender, EventArgs e)
		{
			SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
			speechSynthesizer.SpeakAsync(textBox1.Text);
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
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			SuspendLayout();
			textBox1.Location = new System.Drawing.Point(12, 12);
			textBox1.Multiline = true;
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(295, 72);
			textBox1.TabIndex = 0;
			button1.Location = new System.Drawing.Point(164, 90);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(143, 23);
			button1.TabIndex = 1;
			button1.Text = "Отправить";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			button2.Location = new System.Drawing.Point(12, 90);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(146, 23);
			button2.TabIndex = 2;
			button2.Text = "Тестировать";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(319, 124);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(textBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "Speaker";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Синтезатор речи";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
