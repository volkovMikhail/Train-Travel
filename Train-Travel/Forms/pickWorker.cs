using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Train_Travel.Utils;

namespace Train_Travel.Forms
{


    public partial class pickWorker : Form
    {
        SqlConnection conn;
        public int workerID;
        public pickWorker()
        {
            workerID = -1;
            InitializeComponent();
        }

        private void listViewWorkers_Click(object sender, EventArgs e)
        {
            
        }

        private void pickWorker_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            outputWorkers();
            updateComboBrigades();
        }
        private void outputWorkers()
        {
            workersParams workersParams;
            workersParams.otdel = Convert.ToString(comboBoxOtdel.SelectedItem);
            workersParams.brigada = Convert.ToString(comboBoxBrigades.SelectedItem);
            workersParams.phone = maskedTextBoxPhoneSearchWorker.Text;
            SqlCommand cmd = new SqlCommand(QueryBuilder.workers(workersParams), conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                listViewWorkers.Items.Clear();
                dataReader = cmd.ExecuteReader();
                ListViewItem viewItem;
                int count = 0;
                double sumZp = 0;
                while (dataReader.Read())
                {
                    string type;
                    if (Convert.ToBoolean(dataReader[8]))
                    {
                        type = "Рудоводитель";
                    }
                    else
                    {
                        type = "Работник";
                    }
                    viewItem = new ListViewItem(new string[]
                    {
                        Convert.ToString(dataReader[1]),
                        Convert.ToString(dataReader[2]),
                        Convert.ToString(dataReader[3]),
                        Convert.ToString(dataReader[4]),
                        Convert.ToString(dataReader[5]),
                        Convert.ToString(dataReader[6]),
                        Convert.ToString(dataReader[7]),
                        type,
                    });
                    viewItem.Tag = dataReader[0];
                    listViewWorkers.Items.Add(viewItem);
                    count++;
                    sumZp += Convert.ToDouble(dataReader[7]);
                }
                
                
                
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                conn.Close();
            }
        }

        private void comboBoxOtdel_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputWorkers();
        }

        private void comboBoxBrigades_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputWorkers();
        }

        private void maskedTextBoxPhoneSearchWorker_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            outputWorkers();
        }

        private void checkBoxMed_CheckedChanged(object sender, EventArgs e)
        {
            outputWorkers();
        }

        private void updateComboBrigades()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Brigades", conn);
            SqlDataReader dataReader = null;
            try
            {
                conn.Open();
                comboBoxBrigades.Items.Clear();
                comboBoxBrigades.Items.Add("Все");
           
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    comboBoxBrigades.Items.Add(Convert.ToString(dataReader[0]));
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
                conn.Close();

            }
            comboBoxOtdel.SelectedIndex = 0;
            comboBoxBrigades.SelectedIndex = 0;
           
        }

        private void listViewWorkers_Click_1(object sender, EventArgs e)
        {
            if (listViewWorkers.SelectedItems.Count > 0)
            {
                workerID = Convert.ToInt32(listViewWorkers.SelectedItems[0].Tag);
                this.Close();
            }
        }
    }
}
