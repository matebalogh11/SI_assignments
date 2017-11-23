using System;
using System.Windows.Forms;


namespace InputValidation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Logic.CheckName(txtName.Text)) MessageBox.Show("The name is invalid only alphabetical characters are allowed!");
            if (!Logic.CheckPhone(txtPhone.Text))
            {
                MessageBox.Show("Not valid US phone number!");
            }
            else
            {
                txtPhone.Text = Logic.ReformatPhone(txtPhone.Text);
            }
            if (!Logic.CheckEmail(txtEmail.Text)) MessageBox.Show("The e-mail address is not valid.");
        }
    }
}
