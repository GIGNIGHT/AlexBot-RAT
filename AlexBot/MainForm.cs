using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlexBot
{
	public class MainForm : Form
	{
		public const string Login = "admin";

		public const string Password = "admin";

		private IContainer components = null;

		private PictureBox pictureBox1;

		private PictureBox pictureBox2;

		private PictureBox pictureBox3;

		private TextBox textBox1;

		private TextBox textBox2;

		public MainForm()
		{
			InitializeComponent();
		}

		private void PictureBox2Click(object sender, EventArgs e)
		{
			if ("admin" == textBox1.Text && "admin" == textBox2.Text)
			{
				Hide();
				Main main = new Main();
				main.ShowDialog();
			}
			else
			{
				MessageBox.Show("Неверный E-mail или Пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void PictureBox3Click(object sender, EventArgs e)
		{
			MessageBox.Show("Регистрация временно недоступна", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			UserControlReg userControlReg = new UserControlReg();
			userControlReg.ShowDialog();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlexBot.MainForm));
			pictureBox1 = new System.Windows.Forms.PictureBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			SuspendLayout();
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(689, 483);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(202, 311);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(127, 42);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox2.TabIndex = 1;
			pictureBox2.TabStop = false;
			pictureBox2.Click += new System.EventHandler(PictureBox2Click);
			pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
			pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
			pictureBox3.Location = new System.Drawing.Point(335, 311);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(152, 42);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox3.TabIndex = 2;
			pictureBox3.TabStop = false;
			pictureBox3.Click += new System.EventHandler(PictureBox3Click);
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Font = new System.Drawing.Font("Segoe UI Light", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			textBox1.Location = new System.Drawing.Point(255, 203);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(232, 22);
			textBox1.TabIndex = 3;
			textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox2.Font = new System.Drawing.Font("Segoe UI Light", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			textBox2.Location = new System.Drawing.Point(255, 265);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(232, 22);
			textBox2.TabIndex = 4;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(687, 482);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(pictureBox3);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "MainForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "AlexBot";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
