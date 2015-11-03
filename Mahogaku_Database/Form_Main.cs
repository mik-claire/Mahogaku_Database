﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Mahogaku_Database
{
    public partial class Form_Main : Form
    {
        private string connectionString = string.Empty;

        private List<string> characterID = new List<string>();

        private List<string> createrID = new List<string>();

        public Form_Main()
        {
            InitializeComponent();
            //this.connectionString = ConfigurationManager.ConnectionStrings["mhgk"].ConnectionString;
            this.connectionString = "Server=mikserver.ms-18e.com;Database=archive;Uid=guest;Pwd=password";
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
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

        /// <summary>
        /// 「取得」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_GetData_Click(object sender, EventArgs e)
        {
            try
            {
                // 更新
                loadDisplay();

                MessageBox.Show("Success!");
            }
            catch(Exception ex)
            {
                string message = "Error!!" + Environment.NewLine + ex.Message; 
                MessageBox.Show(message,
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        private void loadDisplay()
        {
            // データ取得
            List<CharacterData> data = getData();

            // 表示
            display(data);
        }

        /// <summary>
        /// データ取得
        /// </summary>
        /// <returns></returns>
        private List<CharacterData> getData()
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
SELECT
  CH.ID AS ID, CH.NAME AS NAME, CH.KANA AS KANA,
  T.NAME AS TYPE, S.NAME AS SEX,
  CH.RACE AS RACE, CH.AGE AS AGE, CH.GRADE AS GRADE,
  CH.SKILL AS SKILL, CH.CLUB AS CLUB, CH.ORGANIZATION AS ORG,
  CH.REMARKS AS REM, CR.ID AS CRID, CR.NAME AS CRNAME,
  CR.PIXIV AS PIXIV, CR.TWITTER AS TWITTER, CH.URL AS SHEET,
  CR.PASSWORD AS PASSWORD
FROM
  `CHARACTER` CH JOIN CREATER CR
  ON CH.CREATER_ID = CR.ID JOIN TYPE T
  ON CH.TYPE_ID = T.ID JOIN SEX S
  ON CH.SEX_ID = S.ID
ORDER BY
  T.ID ASC,
  CH.KANA ASC
;
";
                reader = cmd.ExecuteReader();
                
                List<CharacterData> data = new List<CharacterData>();
                while (reader.Read())
                {
                    CharacterData doc = new CharacterData();
                    doc.ID = reader["ID"].ToString();
                    doc.Name = reader["NAME"].ToString();
                    doc.Kana = reader["KANA"].ToString();
                    doc.Type = reader["TYPE"].ToString();
                    doc.Race = reader["RACE"].ToString();
                    doc.Sex = reader["SEX"].ToString();
                    doc.Age = reader["AGE"].ToString();
                    doc.Grade = reader["GRADE"].ToString();
                    doc.Skill = reader["SKILL"].ToString();
                    doc.Club = reader["CLUB"].ToString();
                    doc.Organization = reader["ORG"].ToString();
                    doc.Remarks = reader["REM"].ToString();
                    doc.URLToPixiv = reader["SHEET"].ToString();

                    CreaterData creater = new CreaterData();
                    creater.ID = reader["CRID"].ToString();
                    creater.Name = reader["CRNAME"].ToString();
                    creater.PixivID = reader["PIXIV"].ToString();
                    creater.TwitterID = reader["TWITTER"].ToString();
                    creater.Password = reader["PASSWORD"].ToString();
                    doc.Creater = creater;

                    data.Add(doc);

                    this.characterID.Add(doc.ID);
                    this.createrID.Add(doc.Creater.ID);
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
        private void display(List<CharacterData> data)
        {
            this.listView_Display.Items.Clear();

            foreach(CharacterData doc in data)
            {
                string[] record = {
                                      doc.Type,
                                      doc.Name,
                                      doc.Kana,
                                      doc.Sex,
                                      doc.Race,
                                      doc.Age,
                                      doc.Grade,
                                      doc.Skill,
                                      doc.Club,
                                      doc.Organization,
                                      doc.Remarks,
                                      doc.Creater.Name,
                                      doc.ID,
                                      doc.Creater.ID,
                                      doc.Creater.Password
                                  };
                ListViewItem item = new ListViewItem(record);
                item.UseItemStyleForSubItems = false;

                // Linkをタグで保持
                string tag = @"http://www.pixiv.net/member.php?id=" + doc.Creater.PixivID + ",";
                if (doc.Creater.TwitterID != null)
                {
                    tag += @"https://twitter.com/" + doc.Creater.TwitterID;
                }
                tag += "," + doc.URLToPixiv;
                item.Tag = tag;

                switch (doc.Type)
                {
                    case "力":
                        item.SubItems[0].ForeColor = Color.Crimson;
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            item.SubItems[i].BackColor = Color.SeaShell;
                        }
                        break;
                    case "魔":
                        item.SubItems[0].ForeColor = Color.SteelBlue;
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            item.SubItems[i].BackColor = Color.AliceBlue;
                        }
                        break;
                    case "技":
                        item.SubItems[0].ForeColor = Color.Green;
                        for (int i = 0; i < item.SubItems.Count; i++)
                        {
                            item.SubItems[i].BackColor = Color.Honeydew;
                        }
                        break;
                    default:
                        break;
                }

                this.listView_Display.Items.Add(item);
            }
        }

        /// <summary>
        /// 「登録」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Insert_Click(object sender, EventArgs e)
        {
            using (Form_InsertCharacter f = new Form_InsertCharacter())
            {
                DialogResult dr = f.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    return;
                }

                // 更新
                loadDisplay();
            }
        }

        /// <summary>
        /// 「編集」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            using (Form_UpdateCharacter f = new Form_UpdateCharacter())
            {
                CharacterData doc = new CharacterData();
                doc.ID = item.SubItems[12].Text;
                doc.Name = item.SubItems[1].Text;
                doc.Kana = item.SubItems[2].Text;
                doc.Sex = item.SubItems[3].Text;
                doc.Type = item.SubItems[0].Text;
                doc.Race = item.SubItems[4].Text;
                doc.Age = item.SubItems[5].Text;
                doc.Grade = item.SubItems[6].Text;
                doc.Skill = item.SubItems[7].Text;
                doc.Club = item.SubItems[8].Text;
                doc.Organization = item.SubItems[9].Text;
                doc.Remarks = item.SubItems[10].Text;
                CreaterData creater = new CreaterData();
                creater.ID = item.SubItems[13].Text;
                doc.Creater = creater;
                string[] urlArray = item.Tag.ToString().Split(',');
                string url = string.Empty;
                for (int i = 2; i < urlArray.Length; i++)
                {
                    url += urlArray[i] + ",";
                }
                doc.URLToPixiv = url.Substring(0, url.Length - 1);
                f.Character = doc;
                f.Pass = item.SubItems[14].Text;

                DialogResult dr = f.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    return;
                }

                // 更新
                loadDisplay();
            }
        }

        /// <summary>
        /// 右クリックメニュー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            // 設定されているキャラクターシート
            ToolStripMenuItem menuItem_CharacterSheets = new ToolStripMenuItem();
            menuItem_CharacterSheets.Text = "キャラクターシートを開く";
            foreach (string url in urlArray)
            {
                if (url == urlArray[0] ||
                    url == urlArray[1])
                {
                    continue;
                }
                ToolStripMenuItem characterSheet = new ToolStripMenuItem();
                characterSheet.Text = url;
                characterSheet.Click += delegate
                {
                    System.Diagnostics.Process.Start(url);
                };
                menuItem_CharacterSheets.DropDownItems.Add(characterSheet);
            }
            menu.Items.Add(menuItem_CharacterSheets);

            menu.Show(Cursor.Position);
        }
    }
}
