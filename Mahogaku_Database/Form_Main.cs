using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mahogaku_Database
{
    public partial class Form_Main : Form
    {
        private string connectionString = string.Empty;

        public Form_Main()
        {
            InitializeComponent();
            this.connectionString = "Server=mikserver.ms-18e.com;Database=archive;Uid=myUser;Pwd=1RewT3vf";
        }

        private List<byte[]> imageList = new List<byte[]>();
        private bool isGettingImage = false;

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

                MessageBox.Show("ツールを終了します。",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }

            this.backgroundWorker.RunWorkerAsync();
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
                if (ex.Message.StartsWith("Unable to connect to any of the specified "))
                {
                    message = "データベースに接続できませんでした。" + Environment.NewLine +
                        "サーバーが立ち上がっていない可能性がありますので、今しばらくお待ち下さい。" + Environment.NewLine +
                        "現在のサーバーの状況は、以下のTwitterアカウントにて随時報告されております。" + Environment.NewLine +
                        Environment.NewLine +
                        "https://twitter.com/mikaze_Atlantis";
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

            this.backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 更新
        /// </summary>
        private void loadDisplay()
        {
            this.button_Update.Enabled = false;

            // データ取得
            List<CharacterData> data = getData();

            // 属性で絞り込み
            data = filterWithType(data);

            // 表示
            display(data);

            this.backgroundWorker.RunWorkerAsync();
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
select
  ch.id as id,
  ch.name as name,
  ch.kana as kana,
  t.name as type, 
  g.name as gender,
  ch.race as race, 
  ch.age as age, 
  ch.grade as grade,
  ch.skill as skill, 
  ch.club as club,
  ch.organization as org,
  ch.remarks as rem, 
  cr.id as cr_id, 
  cr.name as cr_name,
  cr.pixiv_id as pixiv, 
  cr.twitter_id as twitter, 
  ch.wiki_url as wiki, 
  ch.sheet_url as sheet,
  cr.password as pass
from
  chara ch
  join creater cr
    on ch.creater_id = cr.id
    join type t
      on ch.type_id = t.id 
      join gender g
        on ch.gender_id = g.id
order by
  t.id asc,
  ch.kana asc
;";
                reader = cmd.ExecuteReader();
                
                List<CharacterData> data = new List<CharacterData>();
                //this.imageList.Clear();
                while (reader.Read())
                {
                    CharacterData doc = new CharacterData();
                    doc.ID = reader["id"].ToString();
                    doc.Name = reader["name"].ToString();
                    doc.Kana = reader["kana"].ToString();
                    doc.Type = reader["type"].ToString();
                    doc.Race = reader["race"].ToString();
                    doc.Sex = reader["gender"].ToString();
                    doc.Age = reader["age"].ToString();
                    doc.Grade = reader["grade"].ToString();
                    doc.Skill = reader["skill"].ToString();
                    doc.Club = reader["club"].ToString();
                    doc.Organization = reader["org"].ToString();
                    doc.Remarks = reader["rem"].ToString();
                    doc.URLToWiki = reader["wiki"].ToString();
                    doc.URLToPixiv = reader["sheet"].ToString();

                    CreaterData creater = new CreaterData();
                    creater.ID = reader["cr_id"].ToString();
                    creater.Name = reader["cr_name"].ToString();
                    creater.PixivID = reader["pixiv"].ToString();
                    creater.TwitterID = reader["twitter"].ToString();
                    creater.Password = reader["pass"].ToString();
                    doc.Creater = creater;

                    data.Add(doc);
                    /*
                    byte[] imageData = new byte[0];
                    if (reader["IMAGE"].ToString() != string.Empty)
                    {
                        imageData = (byte[])reader["IMAGE"];
                    }
                    this.imageList.Add(imageData);*/
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
        /// 属性で絞り込み
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<CharacterData> filterWithType(List<CharacterData> data)
        {
            // チェックボックスからフィルターを作成
            string filter = string.Empty;
            if (this.checkBox_Power.Checked)
            {
                filter += this.checkBox_Power.Text;
            }
            if (this.checkBox_Castor.Checked)
            {
                filter += this.checkBox_Castor.Text;
            }
            if (this.checkBox_Technical.Checked)
            {
                filter += this.checkBox_Technical.Text;
            }
            if (this.checkBox_Unknown.Checked)
            {
                filter += this.checkBox_Unknown.Text;
            }

            List<CharacterData> filteredData = new List<CharacterData>();
            foreach (CharacterData doc in data)
            {
                // 属性がフィルターに存在するか判定
                if (!filter.Contains(doc.Type))
                {
                    continue;
                }

                // 存在すれば追加
                filteredData.Add(doc);
            }

            return filteredData;
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
                                      doc.Sex,
                                      doc.Grade,
                                      doc.Skill,
                                      doc.Creater.Name,
                                      doc.ID,
                                      doc.Creater.ID,
                                      doc.Creater.Password,
                                      doc.Kana,
                                      doc.Race,
                                      doc.Age,
                                      doc.Club,
                                      doc.Organization,
                                      doc.Remarks
                                  };
                ListViewItem item = new ListViewItem(record);
                item.UseItemStyleForSubItems = false;

                // Linkをタグで保持
                string tag = @"http://www.pixiv.net/member.php?id=" + doc.Creater.PixivID + ",";
                if (doc.Creater.TwitterID != null)
                {
                    tag += @"https://twitter.com/" + doc.Creater.TwitterID;
                }
                tag += ",";
                if (doc.URLToWiki != null)
                {
                    tag += doc.URLToWiki;
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

            displayDetail();
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
                doc.ID = item.SubItems[6].Text;
                doc.Name = item.SubItems[1].Text;
                doc.Kana = item.SubItems[9].Text;
                doc.Sex = item.SubItems[2].Text;
                doc.Type = item.SubItems[0].Text;
                doc.Race = item.SubItems[10].Text;
                doc.Age = item.SubItems[11].Text;
                doc.Grade = item.SubItems[3].Text;
                doc.Skill = item.SubItems[4].Text;
                doc.Club = item.SubItems[12].Text;
                doc.Organization = item.SubItems[13].Text;
                doc.Remarks = item.SubItems[14].Text.Replace(",", Environment.NewLine);
                CreaterData creater = new CreaterData();
                creater.ID = item.SubItems[7].Text;
                doc.Creater = creater;
                string[] urlArray = item.Tag.ToString().Split(',');
                doc.URLToWiki = urlArray[2];
                string url = string.Empty;
                for (int i = 3; i < urlArray.Length; i++)
                {
                    url += urlArray[i] + Environment.NewLine;
                }
                doc.URLToPixiv = url.Substring(0, url.Length - 1);
                f.Character = doc;
                f.Pass = item.SubItems[8].Text;
                doc.ImageData = this.imageList[this.listView_Display.SelectedIndices[0]];

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
                try
                {
                    System.Diagnostics.Process.Start(urlArray[0]);
                }
                catch (Exception)
                {
                    MessageBox.Show("存在しないURLです。",
                        "Error!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };
            menu.Items.Add(menuItem_CreaterPixiv);
            
            // TwitterURLが設定されていれば追加
            if (urlArray[1] != string.Empty)
            {
                ToolStripMenuItem menuItem_CreaterTwitter = new ToolStripMenuItem();
                menuItem_CreaterTwitter.Text = "Twitterユーザーページを開く";
                menuItem_CreaterTwitter.Click += delegate
                {
                    try
                    {
                        System.Diagnostics.Process.Start(urlArray[1]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("存在しないURLです。",
                            "Error!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };
                menu.Items.Add(menuItem_CreaterTwitter);
            }

            // wikiへのリンクが設定されていれば追加
            if (urlArray[2] != string.Empty)
            {
                ToolStripMenuItem menuItem_Wiki = new ToolStripMenuItem();
                menuItem_Wiki.Text = "まほがくキャラまとめwikiを開く";
                menuItem_Wiki.Click += delegate
                {
                    try
                    {
                        System.Diagnostics.Process.Start(urlArray[2]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("存在しないURLです。",
                            "Error!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };
                menu.Items.Add(menuItem_Wiki);
            }

            // 設定されているキャラクターシート
            ToolStripMenuItem menuItem_CharacterSheets = new ToolStripMenuItem();
            menuItem_CharacterSheets.Text = "キャラクターシートを開く";
            foreach (string url in urlArray)
            {
                if (url == urlArray[0] ||
                    url == urlArray[1] ||
                    url == urlArray[2])
                {
                    continue;
                }
                ToolStripMenuItem characterSheet = new ToolStripMenuItem();
                characterSheet.Text = url;
                characterSheet.Click += delegate
                {
                    try
                    {
                        System.Diagnostics.Process.Start(url);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("存在しないURLです。",
                            "Error!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };
                menuItem_CharacterSheets.DropDownItems.Add(characterSheet);
            }
            menu.Items.Add(menuItem_CharacterSheets);

            menu.Show(Cursor.Position);
        }

        /// <summary>
        /// 属性チェックボックス
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_Type_CheckedChanged(object sender, EventArgs e)
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

        /// <summary>
        /// 「親御さん情報一覧」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ShowCreaters_Click(object sender, EventArgs e)
        {
            using (Form_Creater f = new Form_Creater())
            {
                DialogResult dr = f.ShowDialog();
            }
        }

        /// <summary>
        /// 項目変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_Display_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayDetail();
        }

        /// <summary>
        /// 詳細表示
        /// </summary>
        private void displayDetail()
        {
            if (this.listView_Display.SelectedItems.Count < 1)
            {
                this.textBox_Name.Text = string.Empty;
                this.textBox_Kana.Text = string.Empty;
                this.textBox_Sex.Text = string.Empty;
                this.textBox_Type.Text = string.Empty;
                this.textBox_Race.Text = string.Empty;
                this.textBox_Age.Text = string.Empty;
                this.textBox_Grade.Text = string.Empty;
                this.textBox_Skill.Text = string.Empty;
                this.textBox_Club.Text = string.Empty;
                this.textBox_Organization.Text = string.Empty;
                this.textBox_Remarks.Text = string.Empty;
                this.textBox_Sheet.Text = string.Empty;
                this.textBox_Wiki.Text = string.Empty;
                this.textBox_CreaterName.Text = string.Empty;
                this.textBox_CreaterPixiv.Text = string.Empty;
                this.textBox_CreaterTwitter.Text = string.Empty;
                this.pictureBox_Character.Image = null;
                this.pictureBox_Character.Refresh();

                this.button_CharacterLink.Enabled = false;
                this.button_CreaterLink.Enabled = false;
                return;
            }

            ListViewItem item = this.listView_Display.SelectedItems[0];
            string remarks = item.SubItems[14].Text.Replace(",", Environment.NewLine);
            string[] urlArray = item.Tag.ToString().Split(',');
            string sheet = string.Empty;
            for (int i = 3; i < urlArray.Length; i++)
            {
                sheet += urlArray[i] + Environment.NewLine;
            }

            this.textBox_Name.Text = item.SubItems[1].Text;
            this.textBox_Kana.Text = item.SubItems[9].Text;
            this.textBox_Sex.Text = item.SubItems[2].Text;
            this.textBox_Type.Text = item.SubItems[0].Text;
            this.textBox_Race.Text = item.SubItems[10].Text;
            this.textBox_Age.Text = item.SubItems[11].Text;
            this.textBox_Grade.Text = item.SubItems[3].Text;
            this.textBox_Skill.Text = item.SubItems[4].Text;
            this.textBox_Club.Text = item.SubItems[12].Text;
            this.textBox_Organization.Text = item.SubItems[13].Text;
            this.textBox_Remarks.Text = remarks;
            this.textBox_Sheet.Text = sheet;
            this.textBox_Wiki.Text = urlArray[2];
            this.textBox_CreaterName.Text = item.SubItems[5].Text;
            this.textBox_CreaterPixiv.Text = urlArray[0].Substring(35, urlArray[0].Length - 35);
            this.textBox_CreaterTwitter.Text = urlArray[1].Substring(20, urlArray[1].Length - 20);
            
            if (!this.isGettingImage &&
                this.imageList[this.listView_Display.SelectedIndices[0]].Length != 0)
            {
                this.pictureBox_Character.Image = convertByteArrayToImage(this.imageList[this.listView_Display.SelectedIndices[0]]);
                this.pictureBox_Character.Refresh();
            }

            this.button_CharacterLink.Enabled = true;
            this.button_CreaterLink.Enabled = true;
        }

        /// <summary>
        /// キャラクター「リンクを開く」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CharacterLink_Click(object sender, EventArgs e)
        {
            if (this.listView_Display.SelectedItems.Count < 1)
            {
                return;
            }

            ListViewItem item = this.listView_Display.SelectedItems[0];

            string[] urlArray = item.Tag.ToString().Split(',');
            ContextMenuStrip menu = new ContextMenuStrip();

            // 設定されているキャラクターシート
            ToolStripMenuItem menuItem_CharacterSheets = new ToolStripMenuItem();
            int cnt = 1;
            foreach (string url in urlArray)
            {
                if (url == urlArray[0] ||
                    url == urlArray[1] ||
                    url == urlArray[2])
                {
                    continue;
                }
                ToolStripMenuItem characterSheet = new ToolStripMenuItem();
                characterSheet.Text = string.Format("{0}行目のキャラクターシートを開く", cnt);
                cnt++;
                characterSheet.Click += delegate
                {
                    try
                    {
                        System.Diagnostics.Process.Start(url);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("存在しないURLです。",
                            "Error!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };
                menu.Items.Add(characterSheet);
            }

            // wikiへのリンクが設定されていれば追加
            if (urlArray[2] != string.Empty)
            {
                ToolStripMenuItem menuItem_Wiki = new ToolStripMenuItem();
                menuItem_Wiki.Text = "まほがくキャラまとめwikiを開く";
                menuItem_Wiki.Click += delegate
                {
                    try
                    {
                        System.Diagnostics.Process.Start(urlArray[2]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("存在しないURLです。",
                            "Error!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };
                menu.Items.Add(menuItem_Wiki);
            }

            menu.Show(Cursor.Position);
        }

        /// <summary>
        /// 親御さん「リンクを開く」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CreaterLink_Click(object sender, EventArgs e)
        {
            if (this.listView_Display.SelectedItems.Count < 1)
            {
                return;
            }

            ListViewItem item = this.listView_Display.SelectedItems[0];

            string[] urlArray = item.Tag.ToString().Split(',');
            ContextMenuStrip menu = new ContextMenuStrip();
            
            // Pixivのユーザーページ
            ToolStripMenuItem menuItem_CreaterPixiv = new ToolStripMenuItem();
            menuItem_CreaterPixiv.Text = "Pixivユーザーページを開く";
            menuItem_CreaterPixiv.Click += delegate
            {
                try
                {
                    System.Diagnostics.Process.Start(urlArray[0]);
                }
                catch (Exception)
                {
                    MessageBox.Show("存在しないURLです。",
                        "Error!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            };
            menu.Items.Add(menuItem_CreaterPixiv);

            // TwitterURLが設定されていれば追加
            if (urlArray[1] != string.Empty)
            {
                ToolStripMenuItem menuItem_CreaterTwitter = new ToolStripMenuItem();
                menuItem_CreaterTwitter.Text = "Twitterユーザーページを開く";
                menuItem_CreaterTwitter.Click += delegate
                {
                    try
                    {
                        System.Diagnostics.Process.Start(urlArray[1]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("存在しないURLです。",
                            "Error!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                };
                menu.Items.Add(menuItem_CreaterTwitter);
            }

            menu.Show(Cursor.Position);
        }

        private void listView_Display_Leave(object sender, EventArgs e)
        {
            displayDetail();
        }

        /// <summary>
        /// byte[] -> Image
        /// </summary>
        /// <param name="data">変換元byte[]</param>
        /// <returns>変換後Image</returns>
        private Image convertByteArrayToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            Image img = Image.FromStream(ms);

            return img;
        }

        private List<byte[]> getImage()
        {
            string sql = @"
select
  c.image
from
  chara c
  join type t
    on c.type_id = t.id
order by
  t.id asc,
  c.kana asc
;";

            MySqlConnection cn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;

            try
            {
                cn = new MySqlConnection(this.connectionString);
                cn.Open();

                cmd = cn.CreateCommand();
                cmd.CommandText = sql;

                reader = cmd.ExecuteReader();

                List<byte[]> data = new List<byte[]>();
                while (reader.Read())
                {
                    byte[] imageData = new byte[0];
                    if (reader["image"].ToString() != string.Empty)
                    {
                        imageData = (byte[])reader["image"];
                    }

                    data.Add(imageData);
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
        /// バックグラウンド処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            this.isGettingImage = true;

            try
            {
                List<byte[]> temp = getImage();
                this.imageList = temp;
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

        /// <summary>
        /// バックグラウンド処理完了時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.isGettingImage = false;
            this.button_Update.Enabled = true;
        }
    }
}
