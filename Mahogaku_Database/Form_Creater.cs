using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;

namespace Mahogaku_Database
{
    public partial class Form_Creater : Form
    {
        private string connectionString = string.Empty;

        List<string> createrID = new List<string>();

        public Form_Creater()
        {
            InitializeComponent();
            this.connectionString = ConfigurationManager.ConnectionStrings["mhgk"].ConnectionString;
        }

        private void Form_Creater_Load(object sender, EventArgs e)
        {
            try
            {
                // 更新
                loadDisplay();
            }
            catch (Exception ex)
            {
                string message = "Error!!" + Environment.NewLine + ex.Message;
                MessageBox.Show(message,
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void loadDisplay()
        {
            // データ取得
            List<CreaterData> data = getData();

            // 表示
            display(data);
        }

        /// <summary>
        /// 更新
        /// </summary>
        private void load()
        {
            // データ取得
            List<CreaterData> data = getData();

            // 表示
            display(data);
        }

        /// <summary>
        /// データ取得
        /// </summary>
        /// <returns></returns>
        private List<CreaterData> getData()
        {
            MySqlConnection cn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                cn = new MySqlConnection(this.connectionString);
                cn.Open();

                cmd = cn.CreateCommand();
                cmd.CommandText = @"
SELECT ID, NAME, PASSWORD, PIXIV, TWITTER
FROM CREATER ORDER BY NAME ASC
;
";
                reader = cmd.ExecuteReader();

                List<CreaterData> data = new List<CreaterData>();
                while (reader.Read())
                {
                    CreaterData doc = new CreaterData();
                    doc.ID = reader["ID"].ToString();
                    doc.Name = reader["NAME"].ToString();
                    doc.PixivID = reader["PIXIV"].ToString();
                    doc.TwitterID = reader["TWITTER"].ToString();
                    doc.Password = reader["PASSWORD"].ToString();
                    data.Add(doc);
                }

                return data;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (cmd != null)
                {
                    cmd.Dispose();
                }
                if (cn != null)
                {
                    cn.Close();
                }
            }
        }

        /// <summary>
        /// 表示
        /// </summary>
        /// <param name="data"></param>
        private void display(List<CreaterData> data)
        {
            this.listView_Display.Items.Clear();

            foreach (CreaterData doc in data)
            {
                string twitterId = doc.TwitterID;
                if (twitterId != string.Empty)
                {
                    twitterId = "@" + twitterId;
                }

                string[] record = {
                                      doc.Name,
                                      doc.PixivID,
                                      twitterId,
                                      doc.Password,
                                      doc.ID
                                  };

                ListViewItem item = new ListViewItem(record);

                // Linkをタグで保持
                string tag = @"http://www.pixiv.net/member.php?id=" + doc.PixivID + ",";
                if (doc.TwitterID != string.Empty)
                {
                    tag += @"https://twitter.com/" + doc.TwitterID;
                }
                item.Tag = tag;

                this.listView_Display.Items.Add(item);
            }
        }

        private void button_GetData_Click(object sender, EventArgs e)
        {
            try
            {
                // 更新
                loadDisplay();

                MessageBox.Show("Success!");
            }
            catch (Exception ex)
            {
                string message = "Error!!" + Environment.NewLine + ex.Message;
                MessageBox.Show(message,
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void listView_Display_MouseClick(object sender, MouseEventArgs e)
        {
            // 右クリック判定
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            // フォーカス判定
            ListViewItem item = this.listView_Display.FocusedItem;
            if (!this.listView_Display.FocusedItem.Bounds.Contains(e.Location))
            {
                return;
            }

            string[] urlArray = item.Tag.ToString().Split(',');

            // Pixivのユーザーページ
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem menuItem_CreaterPixiv = new ToolStripMenuItem();
            menuItem_CreaterPixiv.Text = "Pixivユーザーページを開く";
            menuItem_CreaterPixiv.Click += delegate
            {
                System.Diagnostics.Process.Start(urlArray[0]);
            };
            menu.Items.Add(menuItem_CreaterPixiv);

            // TwitterURLが設定されていれば追加
            if (urlArray[1] != string.Empty)
            {
                ToolStripMenuItem menuItem_CreaterTwitter = new ToolStripMenuItem();
                menuItem_CreaterTwitter.Text = "Twitterユーザーページを開く";
                menuItem_CreaterTwitter.Click += delegate
                {
                    System.Diagnostics.Process.Start(urlArray[1]);
                };
                menu.Items.Add(menuItem_CreaterTwitter);
            }

            menu.Show(Cursor.Position);
        }

        private void button_Insert_Click(object sender, EventArgs e)
        {
            using (Form_InsertCreater f = new Form_InsertCreater())
            {
                DialogResult dr = f.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    return;
                }

                loadDisplay();
            }
        }
    }
}
