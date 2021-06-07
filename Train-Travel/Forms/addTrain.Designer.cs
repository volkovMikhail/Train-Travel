
namespace Train_Travel.Forms
{
    partial class addTrain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addTrain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRepairBrigade = new System.Windows.Forms.ComboBox();
            this.comboBoxBrigades = new System.Windows.Forms.ComboBox();
            this.textBoxRepairs = new System.Windows.Forms.TextBox();
            this.textBoxCompleted = new System.Windows.Forms.TextBox();
            this.comboBoxPlace = new System.Windows.Forms.ComboBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxRepairBrigade);
            this.groupBox1.Controls.Add(this.comboBoxBrigades);
            this.groupBox1.Controls.Add(this.textBoxRepairs);
            this.groupBox1.Controls.Add(this.textBoxCompleted);
            this.groupBox1.Controls.Add(this.comboBoxPlace);
            this.groupBox1.Controls.Add(this.textBoxQuantity);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBoxType);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные локоматива";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ремонтная бриагада";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Бригада";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Привязка к вокзалу";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Количество ремонтов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Завершённых рейсов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Количесто мест";
            // 
            // comboBoxRepairBrigade
            // 
            this.comboBoxRepairBrigade.FormattingEnabled = true;
            this.comboBoxRepairBrigade.Location = new System.Drawing.Point(154, 219);
            this.comboBoxRepairBrigade.Name = "comboBoxRepairBrigade";
            this.comboBoxRepairBrigade.Size = new System.Drawing.Size(154, 21);
            this.comboBoxRepairBrigade.TabIndex = 6;
            // 
            // comboBoxBrigades
            // 
            this.comboBoxBrigades.FormattingEnabled = true;
            this.comboBoxBrigades.Location = new System.Drawing.Point(154, 192);
            this.comboBoxBrigades.Name = "comboBoxBrigades";
            this.comboBoxBrigades.Size = new System.Drawing.Size(154, 21);
            this.comboBoxBrigades.TabIndex = 5;
            // 
            // textBoxRepairs
            // 
            this.textBoxRepairs.Location = new System.Drawing.Point(154, 110);
            this.textBoxRepairs.Name = "textBoxRepairs";
            this.textBoxRepairs.Size = new System.Drawing.Size(154, 20);
            this.textBoxRepairs.TabIndex = 3;
            this.textBoxRepairs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRepairs_KeyPress);
            // 
            // textBoxCompleted
            // 
            this.textBoxCompleted.Location = new System.Drawing.Point(154, 84);
            this.textBoxCompleted.Name = "textBoxCompleted";
            this.textBoxCompleted.Size = new System.Drawing.Size(154, 20);
            this.textBoxCompleted.TabIndex = 2;
            this.textBoxCompleted.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCompleted_KeyPress);
            // 
            // comboBoxPlace
            // 
            this.comboBoxPlace.FormattingEnabled = true;
            this.comboBoxPlace.Location = new System.Drawing.Point(154, 136);
            this.comboBoxPlace.Name = "comboBoxPlace";
            this.comboBoxPlace.Size = new System.Drawing.Size(154, 21);
            this.comboBoxPlace.TabIndex = 4;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(154, 58);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(154, 20);
            this.textBoxQuantity.TabIndex = 1;
            this.textBoxQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantity_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Обычный",
            "Скорый",
            "Экспресс"});
            this.comboBoxType.Location = new System.Drawing.Point(154, 31);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(154, 21);
            this.comboBoxType.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 163);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Добавить вокзал";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // addTrain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 321);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "addTrain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавить локоматив";
            this.Load += new System.EventHandler(this.addTrain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxRepairBrigade;
        private System.Windows.Forms.ComboBox comboBoxBrigades;
        private System.Windows.Forms.TextBox textBoxRepairs;
        private System.Windows.Forms.TextBox textBoxCompleted;
        private System.Windows.Forms.ComboBox comboBoxPlace;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}