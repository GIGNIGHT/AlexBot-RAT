using System;
using System.ComponentModel;
using System.Drawing;
using System.Net.Sockets;
using System.Windows.Forms;

namespace AlexBot
{
	public class MessageView : Form
	{
		public Socket sock;

		public ToolSocket tsock;

		private IContainer components = null;

		private GroupBox groupBox1;

		private Label label1;

		private TextBox textBox1;

		private Label label2;

		private TextBox textBox2;

		private Button button1;

		private Button button2;

		private CheckBox checkBox3;

		private CheckBox checkBox2;

		private CheckBox checkBox1;

		public MessageView()
		{
			InitializeComponent();
		}

		public MessageBoxIcon MType()
		{
			if (checkBox1.Checked)
			{
				return MessageBoxIcon.Asterisk;
			}
			if (checkBox2.Checked)
			{
				return MessageBoxIcon.Hand;
			}
			if (checkBox3.Checked)
			{
				return MessageBoxIcon.Exclamation;
			}
			return MessageBoxIcon.Asterisk;
		}

		public string GenerateMessage()
		{
			return string.Join("`", textBox1.Text, textBox2.Text, Convert.ToString((int)MType()));
		}

		private void Button1Click(object sender, EventArgs e)
		{
		}

		private void Button2Click(object sender, EventArgs e)
		{
			MessageBox.Show(textBox2.Text, textBox1.Text, MessageBoxButtons.OK, MType());
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
			groupBox1 = new System.Windows.Forms.GroupBox();
			checkBox3 = new System.Windows.Forms.CheckBox();
			checkBox2 = new System.Windows.Forms.CheckBox();
			checkBox1 = new System.Windows.Forms.CheckBox();
			label1 = new System.Windows.Forms.Label();
			textBox1 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			groupBox1.SuspendLayout();
			SuspendLayout();
			groupBox1.Controls.Add(checkBox3);
			groupBox1.Controls.Add(checkBox2);
			groupBox1.Controls.Add(checkBox1);
			groupBox1.Location = new System.Drawing.Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(363, 98);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Тип сообщения";
			checkBox3.Location = new System.Drawing.Point(206, 40);
			checkBox3.Name = "checkBox3";
			checkBox3.Size = new System.Drawing.Size(125, 24);
			checkBox3.TabIndex = 2;
			checkBox3.Text = "Предупреждение";
			checkBox3.UseVisualStyleBackColor = true;
			checkBox2.Location = new System.Drawing.Point(121, 40);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new System.Drawing.Size(104, 24);
			checkBox2.TabIndex = 1;
			checkBox2.Text = "Ошибка";
			checkBox2.UseVisualStyleBackColor = true;
			checkBox1.Location = new System.Drawing.Point(29, 40);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new System.Drawing.Size(104, 24);
			checkBox1.TabIndex = 0;
			checkBox1.Text = "Стандарт";
			checkBox1.UseVisualStyleBackColor = true;
			label1.Location = new System.Drawing.Point(12, 125);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(151, 14);
			label1.TabIndex = 1;
			label1.Text = "Заголовок сообщения";
			textBox1.Location = new System.Drawing.Point(12, 142);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(363, 20);
			textBox1.TabIndex = 2;
			label2.Location = new System.Drawing.Point(12, 176);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(151, 14);
			label2.TabIndex = 3;
			label2.Text = "Текст сообщения";
			textBox2.Location = new System.Drawing.Point(12, 193);
			textBox2.Multiline = true;
			textBox2.Name = "textBox2";
			textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			textBox2.Size = new System.Drawing.Size(363, 67);
			textBox2.TabIndex = 4;
			button1.Location = new System.Drawing.Point(277, 279);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(98, 23);
			button1.TabIndex = 5;
			button1.Text = "Отправить";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			button2.Location = new System.Drawing.Point(159, 279);
			button2.Name = "button2";
			button2.Size = new System.Drawing.Size(112, 23);
			button2.TabIndex = 6;
			button2.Text = "Тестировать";
			button2.UseVisualStyleBackColor = true;
			button2.Click += new System.EventHandler(Button2Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(397, 320);
			base.Controls.Add(button2);
			base.Controls.Add(button1);
			base.Controls.Add(textBox2);
			base.Controls.Add(label2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.Controls.Add(groupBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "MessageView";
			Text = "Отправить сообщение";
			groupBox1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
