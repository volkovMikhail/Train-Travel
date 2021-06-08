
namespace Train_Travel.Forms
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.columnHeader27 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader36 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader37 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader38 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader39 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.перейтиВМенюАдминистратораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.активироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деактивироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.толькоАдминистраторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewUsers
            // 
            this.listViewUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader27,
            this.columnHeader36,
            this.columnHeader37,
            this.columnHeader38,
            this.columnHeader39,
            this.columnHeader40,
            this.columnHeader1,
            this.columnHeader2});
            this.listViewUsers.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.GridLines = true;
            this.listViewUsers.HideSelection = false;
            this.listViewUsers.Location = new System.Drawing.Point(0, 24);
            this.listViewUsers.MultiSelect = false;
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(925, 466);
            this.listViewUsers.TabIndex = 1;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            this.listViewUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader27
            // 
            this.columnHeader27.Text = "id";
            // 
            // columnHeader36
            // 
            this.columnHeader36.Text = "Имя";
            this.columnHeader36.Width = 124;
            // 
            // columnHeader37
            // 
            this.columnHeader37.Text = "Фамилия";
            this.columnHeader37.Width = 139;
            // 
            // columnHeader38
            // 
            this.columnHeader38.Text = "Отчество";
            this.columnHeader38.Width = 136;
            // 
            // columnHeader39
            // 
            this.columnHeader39.Text = "Телефон";
            this.columnHeader39.Width = 129;
            // 
            // columnHeader40
            // 
            this.columnHeader40.Text = "Email";
            this.columnHeader40.Width = 123;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.перейтиВМенюАдминистратораToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(925, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // перейтиВМенюАдминистратораToolStripMenuItem
            // 
            this.перейтиВМенюАдминистратораToolStripMenuItem.Name = "перейтиВМенюАдминистратораToolStripMenuItem";
            this.перейтиВМенюАдминистратораToolStripMenuItem.Size = new System.Drawing.Size(204, 20);
            this.перейтиВМенюАдминистратораToolStripMenuItem.Text = "Перейти в меню администратора";
            this.перейтиВМенюАдминистратораToolStripMenuItem.Click += new System.EventHandler(this.перейтиВМенюАдминистратораToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.активироватьToolStripMenuItem,
            this.деактивироватьToolStripMenuItem,
            this.toolStripSeparator1,
            this.толькоАдминистраторыToolStripMenuItem,
            this.toolStripSeparator2,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 104);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // активироватьToolStripMenuItem
            // 
            this.активироватьToolStripMenuItem.Name = "активироватьToolStripMenuItem";
            this.активироватьToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.активироватьToolStripMenuItem.Text = "Активировать";
            this.активироватьToolStripMenuItem.Click += new System.EventHandler(this.активироватьToolStripMenuItem_Click);
            // 
            // деактивироватьToolStripMenuItem
            // 
            this.деактивироватьToolStripMenuItem.Name = "деактивироватьToolStripMenuItem";
            this.деактивироватьToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.деактивироватьToolStripMenuItem.Text = "Деактивировать";
            this.деактивироватьToolStripMenuItem.Click += new System.EventHandler(this.деактивироватьToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(207, 6);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Роль";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Статус";
            this.columnHeader2.Width = 101;
            // 
            // толькоАдминистраторыToolStripMenuItem
            // 
            this.толькоАдминистраторыToolStripMenuItem.CheckOnClick = true;
            this.толькоАдминистраторыToolStripMenuItem.Name = "толькоАдминистраторыToolStripMenuItem";
            this.толькоАдминистраторыToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.толькоАдминистраторыToolStripMenuItem.Text = "Только администраторы";
            this.толькоАдминистраторыToolStripMenuItem.Click += new System.EventHandler(this.толькоАдминистраторыToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(207, 6);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 490);
            this.Controls.Add(this.listViewUsers);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование аккаунтов";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.ColumnHeader columnHeader27;
        private System.Windows.Forms.ColumnHeader columnHeader36;
        private System.Windows.Forms.ColumnHeader columnHeader37;
        private System.Windows.Forms.ColumnHeader columnHeader38;
        private System.Windows.Forms.ColumnHeader columnHeader39;
        private System.Windows.Forms.ColumnHeader columnHeader40;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem перейтиВМенюАдминистратораToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem активироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem деактивироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripMenuItem толькоАдминистраторыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}