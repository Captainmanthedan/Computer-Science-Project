using System;
using System.Windows.Forms;

namespace Switch_forms_drop_down_bar
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void waveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Form2 Form2 = new Form2();

			Form2.Show();

			Hide();
		}

		private void openToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Open Open = new Open();

			Open.ShowDialog();
		}
	}
}
