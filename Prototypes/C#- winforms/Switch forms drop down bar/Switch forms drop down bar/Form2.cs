using System.Windows.Forms;

namespace Switch_forms_drop_down_bar
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			DialogResult dialog = MessageBox.Show("Do you want to exit the application without saving?", "Exit", MessageBoxButtons.YesNoCancel);

			if (dialog == DialogResult.Yes)
			{
				MessageBox.Show("Saved");
				Application.ExitThread();
			}
			else if (dialog == DialogResult.No)
			{
				Application.ExitThread();
			}
			else if (dialog == DialogResult.Cancel)
			{
				e.Cancel = true;
			}
		}
	}
}
