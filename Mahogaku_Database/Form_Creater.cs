﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
            this.connectionString = "Server=mikserver.ms-18e.com;Database=archive;Uid=myUser;Pwd=1RewT3vf";
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
                string message = @"Error!!

" + ex.Message;
                if (ex.Message.StartsWith("Unable to connect to any of the specified "))
                {
                    message = @"データベースに接続できませんでした。
サーバーが立ち上がっていない可能性がありますので、今しばらくお待ち下さい。
現在のサーバーの状況は、以下のTwitterアカウントにて随時報告されております。

https://twitter.com/mikaze_Atlantis";
                    MessageBox.Show(message,
                        "Error!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(message,
                        "Error!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
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
select
  id,
  name,
  password as pass,
  pixiv_id as pixiv,
  twitter_id as twitter
from
  creater
order by
  name asc
;";
                reader = cmd.ExecuteReader();

                List<CreaterData> data = new List<CreaterData>();
                while (reader.Read())
                {
                    CreaterData doc = new CreaterData();
                    doc.ID = reader["id"].ToString();
                    doc.Name = reader["name"].ToString();
                    doc.PixivID = reader["pixiv"].ToString();
                    doc.TwitterID = reader["twitter"].ToString();
                    doc.Password = reader["pass"].ToString();
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

        private void button_Update_Click(object sender, EventArgs e)
        {
            if (this.listView_Display.SelectedItems.Count < 1)
            {
                MessageBox.Show("項目が選択されていません。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            ListViewItem item = this.listView_Display.SelectedItems[0];

            using (Form_UpdateCreater f = new Form_UpdateCreater())
            {
                f.ID = item.SubItems[4].Text;
                f.UserName = item.SubItems[0].Text;
                f.Pass = item.SubItems[3].Text;
                f.Pixiv = item.SubItems[1].Text;
                f.Twitter = item.SubItems[2].Text.Substring(1, item.SubItems[2].Text.Length - 1);

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
