using System.Drawing;

namespace InventoryManagementSystem
{
    partial class MainForm
    {
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnAddInventory;
        private System.Windows.Forms.Button btnViewInventory;
        private System.Windows.Forms.Button btnEditDeleteInventory;
        private System.Windows.Forms.Button btnSearchInventory;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button btnRefresh;
        private void InitializeComponent()
        {
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRefresh.Location = new System.Drawing.Point(750, 33); //  нужные координаты
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90 , 25);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // MainForm
            // 
            this.Controls.Add(this.btnRefresh);

            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(870, 434);
            this.Name = "MainForm";
            this.ResumeLayout(false);


        }

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        /// 


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

     




    }
}

