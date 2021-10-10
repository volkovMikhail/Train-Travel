
namespace Train_Travel.Forms
{
    partial class pickWorker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pickWorker));
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listViewWorkers = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBoxPhoneSearchWorker = new System.Windows.Forms.MaskedTextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxBrigades = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxOtdel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewWorkers);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox6);
            this.splitContainer2.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer2.Size = new System.Drawing.Size(891, 521);
            this.splitContainer2.SplitterDistance = 408;
            this.splitContainer2.TabIndex = 1;
            // 
            // listViewWorkers
            // 
            this.listViewWorkers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.listViewWorkers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewWorkers.FullRowSelect = true;
            this.listViewWorkers.GridLines = true;
            this.listViewWorkers.HideSelection = false;
            this.listViewWorkers.Location = new System.Drawing.Point(0, 0);
            this.listViewWorkers.MultiSelect = false;
            this.listViewWorkers.Name = "listViewWorkers";
            this.listViewWorkers.Size = new System.Drawing.Size(891, 408);
            this.listViewWorkers.TabIndex = 0;
            this.listViewWorkers.UseCompatibleStateImageBehavior = false;
            this.listViewWorkers.View = System.Windows.Forms.View.Details;
            this.listViewWorkers.Click += new System.EventHandler(this.listViewWorkers_Click_1);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Отдел";
            this.columnHeader9.Width = 88;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Бригада";
            this.columnHeader10.Width = 91;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Имя";
            this.columnHeader11.Width = 105;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Фамилия";
            this.columnHeader12.Width = 115;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Отчество";
            this.columnHeader13.Width = 127;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Телефон";
            this.columnHeader14.Width = 137;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Зарплата";
            this.columnHeader15.Width = 113;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Тип";
            this.columnHeader16.Width = 111;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Controls.Add(this.maskedTextBoxPhoneSearchWorker);
            this.groupBox6.Location = new System.Drawing.Point(267, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(212, 96);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Поиск";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Телефон";
            // 
            // maskedTextBoxPhoneSearchWorker
            // 
            this.maskedTextBoxPhoneSearchWorker.Location = new System.Drawing.Point(84, 31);
            this.maskedTextBoxPhoneSearchWorker.Mask = "+375(00)000-00-00";
            this.maskedTextBoxPhoneSearchWorker.Name = "maskedTextBoxPhoneSearchWorker";
            this.maskedTextBoxPhoneSearchWorker.Size = new System.Drawing.Size(108, 20);
            this.maskedTextBoxPhoneSearchWorker.TabIndex = 2;
            this.maskedTextBoxPhoneSearchWorker.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBoxPhoneSearchWorker_MaskInputRejected);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxBrigades);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.comboBoxOtdel);
            this.groupBox5.Location = new System.Drawing.Point(5, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(256, 96);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Группировка";
            // 
            // comboBoxBrigades
            // 
            this.comboBoxBrigades.FormattingEnabled = true;
            this.comboBoxBrigades.Location = new System.Drawing.Point(103, 58);
            this.comboBoxBrigades.Name = "comboBoxBrigades";
            this.comboBoxBrigades.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBrigades.TabIndex = 1;
            this.comboBoxBrigades.SelectedIndexChanged += new System.EventHandler(this.comboBoxBrigades_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Бригада";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Отдел";
            // 
            // comboBoxOtdel
            // 
            this.comboBoxOtdel.FormattingEnabled = true;
            this.comboBoxOtdel.Items.AddRange(new object[] {
            "Все",
            "Водители подвижного состава",
            "Диспетчеры",
            "Ремонтники подвижного состава",
            "Кассиры",
            "Служба подготовки составов",
            "Справочная служба",
            "Ремонтники путей"});
            this.comboBoxOtdel.Location = new System.Drawing.Point(103, 31);
            this.comboBoxOtdel.Name = "comboBoxOtdel";
            this.comboBoxOtdel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxOtdel.TabIndex = 0;
            this.comboBoxOtdel.SelectedIndexChanged += new System.EventHandler(this.comboBoxOtdel_SelectedIndexChanged);
            // 
            // pickWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 521);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "pickWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбрать работника";
            this.Load += new System.EventHandler(this.pickWorker_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewWorkers;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPhoneSearchWorker;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxBrigades;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxOtdel;
    }
}