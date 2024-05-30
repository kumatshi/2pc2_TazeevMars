using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace InventoryManagementSystem
{
    public partial class MainForm : Form
    {
        private List<User> users;
        private List<InventoryItem> inventory;



        public MainForm()
        {
            InitializeComponent();
            LoadData();
            InitializeUI();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Перезапуск приложения
            Application.Restart();
        }
    

        private void LoadData()
        {
            if (File.Exists("users.json"))
                users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("users.json")) ?? new List<User>();
            else
                users = new List<User>();

            if (File.Exists("inventory.json"))
                inventory = JsonConvert.DeserializeObject<List<InventoryItem>>(File.ReadAllText("inventory.json")) ?? new List<InventoryItem>();
            else
                inventory = new List<InventoryItem>();
        }

        private void SaveData()
        {
            File.WriteAllText("users.json", JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented));
            File.WriteAllText("inventory.json", JsonConvert.SerializeObject(inventory, Newtonsoft.Json.Formatting.Indented));
        }

        private void InitializeUI()
        {
            this.Text = "Система учета и управления инвентарем";
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ForeColor = System.Drawing.Color.Black;

            // Меню
            var menu = new MenuStrip();
            var fileMenu = new ToolStripMenuItem("Меню");
            var exitMenuItem = new ToolStripMenuItem("Выход", null, (s, e) => this.Close());
            fileMenu.DropDownItems.Add(exitMenuItem);
            menu.Items.Add(fileMenu);
            this.MainMenuStrip = menu;
            this.Controls.Add(menu);

            // Вкладки для управления пользователями и инвентарем
            var tabControl = new TabControl();
            tabControl.Dock = DockStyle.Fill;

            // Вкладка «Управление пользователями»
            var userTabPage = new TabPage("Пользователи");
            var userLayoutPanel = new TableLayoutPanel { Dock = DockStyle.Fill };
            userTabPage.Controls.Add(userLayoutPanel);
            var addUserButton = new Button { Text = "Добавить пользователя" };
            addUserButton.Click += (s, e) => AddUser();
            userLayoutPanel.Controls.Add(addUserButton);
            var userListView = new ListView { View = View.Details, Dock = DockStyle.Fill };
            userListView.Columns.Add("ID", 50);
            userListView.Columns.Add("Имя", 150);
            userListView.Columns.Add("Email", 150);
            userLayoutPanel.Controls.Add(userListView);

            // Вкладка «Управление запасами»
            var inventoryTabPage = new TabPage("Инвентарь");
            var inventoryLayoutPanel = new TableLayoutPanel { Dock = DockStyle.Fill };
            inventoryTabPage.Controls.Add(inventoryLayoutPanel);
            var addInventoryButton = new Button { Text = "Добавить инвентарь" };
            addInventoryButton.Click += (s, e) => AddInventory();
            inventoryLayoutPanel.Controls.Add(addInventoryButton);
            var inventoryListView = new ListView { View = View.Details, Dock = DockStyle.Fill };
            inventoryListView.Columns.Add("ID", 50);
            inventoryListView.Columns.Add("Название", 150);
            inventoryListView.Columns.Add("Описание", 150);
            inventoryListView.Columns.Add("Категория", 100);
            inventoryListView.Columns.Add("Дата приобретения", 100);
            inventoryListView.Columns.Add("Статус", 100);
            inventoryListView.Columns.Add("ID пользователя", 100);
            inventoryLayoutPanel.Controls.Add(inventoryListView);

            tabControl.TabPages.Add(userTabPage);
            tabControl.TabPages.Add(inventoryTabPage);
            this.Controls.Add(tabControl);

            LoadUsersToListView(userListView);
            LoadInventoryToListView(inventoryListView);
        }

        private void LoadUsersToListView(ListView listView)
        {
            listView.Items.Clear();
            foreach (var user in users)
            {
                var item = new ListViewItem(user.Id.ToString());
                item.SubItems.Add(user.Name);
                item.SubItems.Add(user.Email);
                listView.Items.Add(item);
            }
        }

        private void LoadInventoryToListView(ListView listView)
        {
            listView.Items.Clear();
            foreach (var item in inventory)
            {
                var listItem = new ListViewItem(item.Id.ToString());
                listItem.SubItems.Add(item.Name);
                listItem.SubItems.Add(item.Description);
                listItem.SubItems.Add(item.Category);
                listItem.SubItems.Add(item.AcquisitionDate.ToString("dd-MM-yyyy"));
                listItem.SubItems.Add(item.Status);
                listItem.SubItems.Add(item.UserId.ToString());
                listView.Items.Add(listItem);
            }

        }

        private void YourMethod()
        {
            try
            {
                if (this.Controls.Count > 1 && this.Controls[1] is TabControl tabControl && tabControl.Controls.Count > 1)
                {
                    TabPage tabPage = tabControl.Controls[1] as TabPage;
                    if (tabPage.Controls.Count > 1 && tabPage.Controls[1] is ListView listView)
                    {
                        LoadInventoryToListView(listView);
                    }
                    else
                    {
                        MessageBox.Show("ListView не найден.");
                    }
                }
                else
                {
                    MessageBox.Show("TabControl или TabPage не найден.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
        private void AddUser()
        {
            var form = new Form { Text = "Добавить пользователя", Size = new System.Drawing.Size(500, 500) };
            var nameLabel = new Label { Text = "Имя", Dock = DockStyle.Top };
            var nameTextBox = new TextBox { Dock = DockStyle.Top };
            var emailLabel = new Label { Text = "Email", Dock = DockStyle.Top };
            var emailTextBox = new TextBox { Dock = DockStyle.Top };
            var passwordLabel = new Label { Text = "Пароль", Dock = DockStyle.Top };
            var passwordTextBox = new TextBox { Dock = DockStyle.Top, PasswordChar = '*' };
            var addButton = new Button { Text = "Добавить", Dock = DockStyle.Top };
            addButton.Click += (s, e) =>
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = nameTextBox.Text,
                    Email = emailTextBox.Text,
                    PasswordHash = ComputeSha256Hash(passwordTextBox.Text)
                };
                users.Add(user);
                SaveData();
                form.Close();
           
            };

            form.Controls.Add(addButton);
            form.Controls.Add(passwordTextBox);
            form.Controls.Add(passwordLabel);
            form.Controls.Add(emailTextBox);
            form.Controls.Add(emailLabel);
            form.Controls.Add(nameTextBox);
            form.Controls.Add(nameLabel);
            form.ShowDialog();
        }

        private void AddInventory()
        {
            var form = new Form { Text = "Добавить инвентарь", Size = new System.Drawing.Size(500, 500) };
            var nameLabel = new Label { Text = "Название", Dock = DockStyle.Top };
            var nameTextBox = new TextBox { Dock = DockStyle.Top };
            var descriptionLabel = new Label { Text = "Описание", Dock = DockStyle.Top };
            var descriptionTextBox = new TextBox { Dock = DockStyle.Top };
            var categoryLabel = new Label { Text = "Категория", Dock = DockStyle.Top };
            var categoryTextBox = new TextBox { Dock = DockStyle.Top };
            var dateLabel = new Label { Text = "Дата приобретения (дд-мм-гггг)", Dock = DockStyle.Top };
            var dateTextBox = new TextBox { Dock = DockStyle.Top };
            var statusLabel = new Label { Text = "Статус", Dock = DockStyle.Top };
            var statusTextBox = new TextBox { Dock = DockStyle.Top };
            var userIdLabel = new Label { Text = "ID пользователя", Dock = DockStyle.Top };
            var userIdTextBox = new TextBox { Dock = DockStyle.Top };
            var addButton = new Button { Text = "Добавить", Dock = DockStyle.Top };
            addButton.Click += (s, e) =>
            {
                var item = new InventoryItem
                {
                    Id = Guid.NewGuid(),
                    Name = nameTextBox.Text,
                    Description = descriptionTextBox.Text,
                    Category = categoryTextBox.Text,
                    AcquisitionDate = DateTime.Parse(dateTextBox.Text),
                    Status = statusTextBox.Text,
                    UserId = Guid.Parse(userIdTextBox.Text)
                };
                inventory.Add(item);
                SaveData();
                form.Close();
             
            };

            form.Controls.Add(addButton);
            form.Controls.Add(userIdTextBox);
            form.Controls.Add(userIdLabel);
            form.Controls.Add(statusTextBox);
            form.Controls.Add(statusLabel);
            form.Controls.Add(dateTextBox);
            form.Controls.Add(dateLabel);
            form.Controls.Add(categoryTextBox);
            form.Controls.Add(categoryLabel);
            form.Controls.Add(descriptionTextBox);
            form.Controls.Add(descriptionLabel);
            form.Controls.Add(nameTextBox);
            form.Controls.Add(nameLabel);
            form.ShowDialog();
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        //private void btnAddInventory_Click(object sender, EventArgs e)
        //{
            // Добавьте логику в открытую форму добавления инвентаря
        //}

        //private void btnViewInventory_Click(object sender, EventArgs e)
        //{
           
        //}

        //private void btnEditDeleteInventory_Click(object sender, EventArgs e)
        //{
            // Добавить логику для открытия формы редактирования/удаления инвентаря
        //}

        //private void btnSearchInventory_Click(object sender, EventArgs e)
        
            // Добавить логику для открытия формы поиска/фильтрации инвентаря
        //}
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }

      

    }
}
