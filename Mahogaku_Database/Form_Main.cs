using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Mahogaku_Database
{
    public partial class Form_Main : Form
    {
        private string connectionString = "mongodb://192.168.15.130:27017";
		//private string connectionString = "mongodb://localhost:51001";

        public Form_Main()
        {
            InitializeComponent();
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
                load();
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
                load();

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
        private void load()
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
            MongoClient client = null;
            MongoServer server = null;

            try
            {
                client = new MongoClient(this.connectionString);
                server = client.GetServer();

                MongoDatabase db = server.GetDatabase("mhgk");
                MongoCollection col = db.GetCollection<Character>("data");

                var filter = new CharacterData();
                var cursor = col.FindAllAs<CharacterData>().SetSortOrder(SortBy.Ascending("Type", "Kana"));

                List<CharacterData> data = new List<CharacterData>();
                foreach (CharacterData doc in cursor)
				{
					if (doc.Skill == string.Empty)
					{
						doc.Skill = "NO_DATA";
					}

                    data.Add(doc);
                }

                return data;
            }
            finally
            {
                if (server != null)
                {
                    server.Disconnect();
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
				string[] record = doc.ConvertToArray();
                record[11] = record[11].Split(',')[0];
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

				switch (record[0])
				{
					case "力":
						item.SubItems[0].ForeColor = Color.Crimson;
						break;
					case "魔":
						item.SubItems[0].ForeColor = Color.SteelBlue;
						break;
                    case "技":
						item.SubItems[0].ForeColor = Color.Green;
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
            using (Form_Insert f = new Form_Insert())
            {
                DialogResult dr = f.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    return;
                }

                // 更新
                load();
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

        private void method1(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
    }
}
