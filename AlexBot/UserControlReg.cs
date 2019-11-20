using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AlexBot
{
	public class UserControlReg : Form
	{
		private IContainer components = null;

		private PictureBox pictureBox1;

		private TextBox textBox1;

		private TextBox textBox2;

		private TextBox textBox3;

		private PictureBox pictureBox2;

		public UserControlReg()
		{
			InitializeComponent();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlexBot.UserControlReg));
			pictureBox1 = new System.Windows.Forms.PictureBox();
			textBox1 = new System.Windows.Forms.TextBox();
			textBox2 = new System.Windows.Forms.TextBox();
			textBox3 = new System.Windows.Forms.TextBox();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			SuspendLayout();
			pictureBox1.Image = (System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(325, 482);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox1.Font = new System.Drawing.Font("Segoe UI Light", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			textBox1.Location = new System.Drawing.Point(70, 193);
			textBox1.Name = "textBox1";
			textBox1.Size = new System.Drawing.Size(232, 22);
			textBox1.TabIndex = 4;
			textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox2.Font = new System.Drawing.Font("Segoe UI Light", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			textBox2.Location = new System.Drawing.Point(70, 257);
			textBox2.Name = "textBox2";
			textBox2.Size = new System.Drawing.Size(232, 22);
			textBox2.TabIndex = 5;
			textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			textBox3.Font = new System.Drawing.Font("Segoe UI Light", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
			textBox3.Location = new System.Drawing.Point(70, 320);
			textBox3.Name = "textBox3";
			textBox3.Size = new System.Drawing.Size(232, 22);
			textBox3.TabIndex = 6;
			pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
			pictureBox2.Image = (System.Drawing.Image)resources.GetObject("pictureBox2.Image");
			pictureBox2.Location = new System.Drawing.Point(18, 365);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(287, 42);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			pictureBox2.TabIndex = 7;
			pictureBox2.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(324, 482);
			base.Controls.Add(pictureBox2);
			base.Controls.Add(textBox3);
			base.Controls.Add(textBox2);
			base.Controls.Add(textBox1);
			base.Controls.Add(pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "UserControlReg";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Регистрация";
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
