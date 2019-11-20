using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlexBot
{
	public class OpenPortDialog : Form
	{
		public int FuturePort = 3601;

		private IContainer components = null;

		private PictureBox pictureBox1;

		private TextBox textBox1;

		private PictureBox pictureBox2;

		private PictureBox pictureBox3;

		public OpenPortDialog()
		{
			InitializeComponent();
		}

		private void PictureBox3Click(object sender, EventArgs e)
		{
			int num = (!(textBox1.Text != "")) ? FuturePort : int.Parse(textBox1.Text);
			if (num > 1 && num < 65000)
			{
				if (!ToolSocket.PortInUse(num))
				{
					FuturePort = num;
					Close();
				}
				else
				{
					MessageBox.Show("Этот порт уже используется в системе", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Порт не должен быть меньше \"1\" или больше \"65000\"", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void PictureBox2Click(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlexBot.OpenPortDialog));
			pictureBox1 = new System.Windows.Forms.PictureBox();
			textBox1 = new System.Windows.Forms.TextBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			SuspendLayout();
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(475, 348);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Font = new System.Drawing.Font("Segoe UI", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			textBox1.Location = new System.Drawing.Point(113, 194);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(120, 27);
			textBox1.TabIndex = 1;
			textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(59, 184);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(184, 46);
			pictureBox2.TabIndex = 4;
			pictureBox2.TabStop = false;
			pictureBox2.Click += new System.EventHandler(PictureBox2Click);
			pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
			pictureBox3.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
			pictureBox3.Location = new System.Drawing.Point(256, 186);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(175, 42);
			pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox3.TabIndex = 5;
			pictureBox3.TabStop = false;
			pictureBox3.Click += new System.EventHandler(PictureBox3Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(474, 347);
			base.Controls.Add(pictureBox3);
			base.Controls.Add(textBox1);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "OpenPortDialog";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Укажите порт";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
