using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using InventoryManagementSystem;
using Newtonsoft.Json;

public partial class RegistrationForm : Form
{
    public RegistrationForm()
    {
        InitializeComponent();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        var user = new User
        {
            Username = txtUsername.Text,
            Password = txtPassword.Text,
           
        };

        var users = LoadUsers();
        users.Add(user);
        SaveUsers(users);
        MessageBox.Show("User registered successfully!");
    }

    private List<User> LoadUsers()
    {
        if (!File.Exists("users.json"))
            return new List<User>();

        var json = File.ReadAllText("users.json");
        return JsonConvert.DeserializeObject<List<User>>(json);
    }

    private void SaveUsers(List<User> users)
    {
        var json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText("users.json", json);
    }

        private System.Windows.Forms.TextBox txtUsername;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnRegister; 



    private void InitializeComponent()
    {
        this.txtUsername = new System.Windows.Forms.TextBox();
        this.txtPassword = new System.Windows.Forms.TextBox();
        this.btnRegister = new System.Windows.Forms.Button();

        // Инициализация и настройка элементов управления
        //this.txtUsername.Location = new System.Drawing.Point(100, 50);
        //this.txtUsername.Name = "txtUsername";
        //this.txtUsername.Size = new System.Drawing.Size(200, 20);

        //this.txtPassword.Location = new System.Drawing.Point(100, 90);
        // this.txtPassword.Name = "txtPassword";
        //this.txtPassword.Size = new System.Drawing.Size(200, 20);
        //this.txtPassword.UseSystemPasswordChar = true;

        this.btnRegister.Location = new System.Drawing.Point(150, 130);
        this.btnRegister.Name = "btnRegister";
        this.btnRegister.Size = new System.Drawing.Size(100, 30);
        this.btnRegister.Text = "Register";
        this.btnRegister.UseVisualStyleBackColor = true;
        this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

        // Добавляем элементы управления в форму
        this.Controls.Add(this.txtUsername);
        this.Controls.Add(this.txtPassword);
        this.Controls.Add(this.btnRegister);
    }
}

