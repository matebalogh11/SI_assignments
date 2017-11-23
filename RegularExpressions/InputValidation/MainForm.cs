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
            if (Logic.checkName(txtName.Text)) MessageBox.Show("The name is invalid only alphabetical characters are allowed!");
            if (Logic.checkPhone(txtPhone.Text)) MessageBox.Show("Not valid US phone number!");
            if (Logic.checkEmail(txtEmail.Text)) MessageBox.Show("The e-mail address is not valid.");
        }
    }
}
