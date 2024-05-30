using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using InventoryManagementSystem;
using Newtonsoft.Json;

public partial class LoginForm : Form
{
      
    public LoginForm()
    {
        InitializeComponent();

    }

    private void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        var users = LoadUsers();
        var user = users.FirstOrDefault(u => u.Username == txtUsername.Text && u.Password == txtPassword.Text);
        if (user != null)
        {
            var mainForm = new MainForm();
            this.Hide();
            mainForm.Show();
        }
        else
        {
            MessageBox.Show("Неправильный логин или пароль");
        }
    }
    private List<User> LoadUsers()
    {
        if (!File.Exists("users.json"))
            return new List<User>();

        var json = File.ReadAllText("users.json");
        return JsonConvert.DeserializeObject<List<User>>(json);
    }
    private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnLogin;
}