using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookClub
{
    public partial class Form_Konyvklub : Form
    {
        MySqlConnection connection;
        MySqlCommand sql = null;
        BindingList<Member> members = new BindingList<Member>();
        public Form_Konyvklub()
        {
            InitializeComponent();
        }

        private void Form_Konyvklub_Load(object sender, EventArgs e)
        {
            dataGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); // Az oszlopok automatikus méretezése a Form szélességéhez
            dataGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Mindig a teljes sor kijelölése
            Beolvasas();
            dataGV.DataSource = members;
            // Eseménykezelő hozzáadása
            buttonTiltas.Click += new EventHandler(dataGV_CellClick);
        }
        private void Beolvasas()
        {
            members.Clear();
            Console.WriteLine("Adatok beolvasása...");
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            sb.Server = "localhost";
            sb.Database = "members";
            sb.UserID = "root";
            sb.Password = "";
            sb.CharacterSet = "utf8";
            connection = new MySqlConnection(sb.ConnectionString);
            sql = connection.CreateCommand();
            try
            {
                connection.Open();
                //-- tagok tábla beolvasása -----------------------------------
                sql.CommandText = "SELECT `id`,`name`,`gender`,`birth_date`,`banned` FROM `members` WHERE 1";
                using (MySqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string gender = dr.IsDBNull(dr.GetOrdinal("gender")) ? string.Empty : dr.GetString("gender");
                        Member uj = new Member(dr.GetInt32("id"), dr.GetString("name"), gender, dr.GetDateTime("birth_date"), (dr.GetInt16("banned") == 0 ? false : true));
                        members.Add(uj);
                    }
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
        }

        // Eseménykezelő függvény
        private void dataGV_CellClick(object sender, EventArgs e)
        {
            if (dataGV.SelectedCells.Count == 0)
            {
                MessageBox.Show("Tiltás módosításához előbb" + Environment.NewLine + "válasszon ki klubtagot!");
            }
            int RowIndex = dataGV.CurrentCell.RowIndex;
            // Ellenőrizzük, hogy nem a fejléc cellára kattintottak
            if (RowIndex >= 0)
            {
                // Az adott sor kiválasztása
                DataGridViewRow row = dataGV.Rows[RowIndex];

                // Kiolvassuk a sorhoz tartozó adatokat
                int id = Convert.ToInt32(row.Cells["Id"].Value);    // Az oszlop neve alapján
                string name = row.Cells["Name"].Value.ToString();    // Vagy oszlopindex alapján is működik: row.Cells[1].Value
                bool banned = Convert.ToBoolean(row.Cells["Banned"].Value);

                //rákérdezünk a felhasználótól, hogy tényleg kitiltja-e a kiválasztott tagot
                if (!banned)
                {
                    DialogResult valasztas = MessageBox.Show($"Biztos szeretné kitiltani a kiválasztott {name} klubtagot?", "Kitiltás", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == valasztas)
                    {
                        row.Cells["Banned"].Value = false;
                        // A módosítások mentése az adatbázisban
                        KitiltasKezeles(id, false);
                    }

                }
                else
                {
                    DialogResult valasztas = MessageBox.Show($"Biztos szeretné visszavonni a kiválasztott {name} klubtag tiltását?", "Kitiltás visszavonása", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == valasztas)
                    {
                        row.Cells["Banned"].Value = true;
                        // A módosítások mentése az adatbázisban
                        KitiltasKezeles(id, true);
                    }
                }
            }
        }

        private void KitiltasKezeles(int id, bool value)
        {
            sql.CommandText = $"UPDATE `members` SET `banned` = {(value ? 1 : 0)} WHERE `id` = {id}";
            try
            {
                connection.Open();
                sql.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("A módosítások mentése sikeres!");
                Beolvasas();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hiba a módosítás folyamán" + Environment.NewLine + ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
