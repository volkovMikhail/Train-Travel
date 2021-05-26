
namespace Train_Travel
{
    partial class mainUser
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listViewVoyages = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEndPrice = new System.Windows.Forms.TextBox();
            this.textBoxStartPrice = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 533);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(776, 507);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Рейсы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listViewVoyages);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(770, 501);
            this.splitContainer1.SplitterDistance = 374;
            this.splitContainer1.TabIndex = 0;
            // 
            // listViewVoyages
            // 
            this.listViewVoyages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader7,
            this.columnHeader3,
            this.columnHeader8,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewVoyages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewVoyages.FullRowSelect = true;
            this.listViewVoyages.GridLines = true;
            this.listViewVoyages.HideSelection = false;
            this.listViewVoyages.Location = new System.Drawing.Point(0, 0);
            this.listViewVoyages.Name = "listViewVoyages";
            this.listViewVoyages.Size = new System.Drawing.Size(770, 374);
            this.listViewVoyages.TabIndex = 0;
            this.listViewVoyages.UseCompatibleStateImageBehavior = false;
            this.listViewVoyages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Место отправления";
            this.columnHeader1.Width = 139;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Место прибытия";
            this.columnHeader2.Width = 132;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Тип рейса";
            this.columnHeader7.Width = 107;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Дата отправления";
            this.columnHeader3.Width = 112;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Время отправления";
            this.columnHeader8.Width = 118;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Прибытие              ";
            this.columnHeader4.Width = 106;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Кол-во билетов";
            this.columnHeader5.Width = 91;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Цена";
            this.columnHeader6.Width = 79;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск рейса";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.textBoxEndPrice);
            this.groupBox4.Controls.Add(this.textBoxStartPrice);
            this.groupBox4.Location = new System.Drawing.Point(578, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(180, 90);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Поиск по цене";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "До";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "От";
            // 
            // textBoxEndPrice
            // 
            this.textBoxEndPrice.Location = new System.Drawing.Point(53, 50);
            this.textBoxEndPrice.Name = "textBoxEndPrice";
            this.textBoxEndPrice.Size = new System.Drawing.Size(108, 20);
            this.textBoxEndPrice.TabIndex = 5;
            this.textBoxEndPrice.TextChanged += new System.EventHandler(this.textBoxEndPrice_TextChanged);
            this.textBoxEndPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxEndPrice_KeyPress);
            // 
            // textBoxStartPrice
            // 
            this.textBoxStartPrice.Location = new System.Drawing.Point(53, 23);
            this.textBoxStartPrice.Name = "textBoxStartPrice";
            this.textBoxStartPrice.Size = new System.Drawing.Size(108, 20);
            this.textBoxStartPrice.TabIndex = 4;
            this.textBoxStartPrice.TextChanged += new System.EventHandler(this.textBoxStartPrice_TextChanged);
            this.textBoxStartPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxStartPrice_KeyPress_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dateTimePickerStartDate);
            this.groupBox3.Location = new System.Drawing.Point(282, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 90);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Поиск по времени";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 54);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(170, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Включить поиск по времени";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Дата отправления";
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.CustomFormat = "dd.MM.yyyy";
            this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(149, 23);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(121, 20);
            this.dateTimePickerStartDate.TabIndex = 2;
            this.dateTimePickerStartDate.Value = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStartDate.ValueChanged += new System.EventHandler(this.dateTimePickerStartDate_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.comboBoxFrom);
            this.groupBox2.Controls.Add(this.comboBoxTo);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 90);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поиск по месту";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Место прибытия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Место отправления";
            // 
            // comboBoxFrom
            // 
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.Location = new System.Drawing.Point(128, 23);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(123, 21);
            this.comboBoxFrom.TabIndex = 0;
            this.comboBoxFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxFrom_SelectedIndexChanged);
            // 
            // comboBoxTo
            // 
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Location = new System.Drawing.Point(128, 50);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.Size = new System.Drawing.Size(123, 21);
            this.comboBoxTo.TabIndex = 1;
            this.comboBoxTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTo_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(776, 507);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Личный кабинет";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 533);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "mainUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Train Travel";
            this.Load += new System.EventHandler(this.mainUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewVoyages;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.TextBox textBoxStartPrice;
        private System.Windows.Forms.TextBox textBoxEndPrice;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}

