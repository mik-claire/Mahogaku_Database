using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mahogaku_Database
{
    public partial class Form_Insert : Form
    {
        //private string connectionString = "mongodb://localhost:27017";
        private string connectionString = "mongodb://localhost:51001";

        public Form_Insert()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Insert_Load(object sender, EventArgs e)
        {
            // データセット
            setData();
        }

        /// <summary>
        /// データセット
        /// </summary>
        private void setData()
        {
            // 性別
            string[] itemSex = { "男", "女" };
            this.comboBox_Sex.Items.AddRange(itemSex);
            this.comboBox_Sex.SelectedIndex = 0;

            // 属性
            string[] itemType = { "力", "魔", "技", "不明" };
            this.comboBox_Type.Items.AddRange(itemType);
            this.comboBox_Type.SelectedIndex = 0;
        }

        /// <summary>
        /// 「OK」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            // 名前
            if (this.textBox_Name.Text.Trim() == string.Empty)
            {
                MessageBox.Show("名前が未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // よみがな
            if (this.textBox_Kana.Text.Trim() == string.Empty)
            {
                MessageBox.Show("よみがなが未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 種族
            if (this.textBox_Race.Text.Trim() == string.Empty)
            {
                MessageBox.Show("種族が未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 年齢
            if (this.textBox_Age.Text.Trim() == string.Empty)
            {
                MessageBox.Show("年齢が未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 学年
            if (this.textBox_Grade.Text.Trim() == string.Empty)
            {
                MessageBox.Show("学年が未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // キャラクターシートURL
            if (this.textBox_URLToPixiv.Text.Trim() == string.Empty)
            {
                MessageBox.Show("キャラクターシートURLが未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 魔砲
            string skill = this.textBox_Skill.Text.Trim();
            if (skill == string.Empty)
            {
                skill = "NoData";
            }

            // 所属
            AffiliationsData affiliation = new AffiliationsData();
            string club = "未所属";
            if (this.textBox_Club.Text.Trim() != string.Empty)
            {
                club = this.textBox_Club.Text.Trim();
                affiliation.Club = club;
            }

            string organization = "未所属";
            if (this.textBox_Organization.Text.Trim() != string.Empty)
            {
                organization = this.textBox_Organization.Text.Trim();
                affiliation.Organization = organization;
            }

            // 親御さんの名前
            if (this.textBox_CreaterName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("親御さんの名前が未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            CreaterData creater = new CreaterData();
            creater.Name = this.textBox_CreaterName.Text.Trim();

            // 親御さんのPixiv
            if (this.textBox_CreaterPixiv.Text.Trim() == string.Empty)
            {
                MessageBox.Show("親御さんのPixivURLが未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            creater.PixivID = this.textBox_CreaterPixiv.Text.Trim();

            // 親御さんのTwitter
            string urlToTwitter = "なし";
            if (this.textBox_CreaterTwitter.Text.Trim() != string.Empty)
            {
                urlToTwitter = this.textBox_CreaterTwitter.Text.Trim();
                creater.TwitterID = urlToTwitter;
            }

            // キャラクターシートURL
            if (this.textBox_URLToPixiv.Text.Trim() == string.Empty)
            {
                MessageBox.Show("キャラクターシートURLが未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            DialogResult dr = MessageBox.Show(string.Format(@"
以下の情報で登録してよろしいですか？
名前 : {0}
よみがな : {1}
性別 : {2}
属性 : {3}
種族 : {4}
年齢 : {5}
学年 : {6}
魔砲 : {7}
部活 : {8}
組織 : {9}
備考 : {10}
キャラクターシートURL :
{11}

親御さん情報
名前 : {12}
PixivID : {13}
TwitterID : {14}",
                 this.textBox_Name.Text.Trim(),
                 this.textBox_Kana.Text.Trim(),
                 this.comboBox_Sex.SelectedItem.ToString(),
                 this.comboBox_Type.SelectedItem.ToString(),
                 this.textBox_Race.Text.Trim(),
                 this.textBox_Age.Text.Trim(),
                 this.textBox_Grade.Text.Trim(),
                 skill,
                 club,
                 organization,
                 this.textBox_Remarks.Text.Trim(),
                 this.textBox_URLToPixiv.Text.Trim(),
                 this.textBox_CreaterName.Text.Trim(),
                 this.textBox_CreaterPixiv.Text.Trim(),
                 urlToTwitter
                 ),
                "Question.",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (dr != DialogResult.OK)
            {
                return;
            }

            CharacterData doc = new CharacterData();
            doc.Type = this.comboBox_Type.SelectedItem.ToString();
            doc.Name = this.textBox_Name.Text.Trim();
            doc.Kana = this.textBox_Kana.Text.Trim();
            doc.Sex = this.comboBox_Sex.SelectedItem.ToString();
            doc.Race = this.textBox_Race.Text.Trim();
            doc.Age = this.textBox_Age.Text.Trim();
            doc.Grade = this.textBox_Grade.Text.Trim();
            doc.Skill = skill;
            doc.Affiliation = affiliation;
            doc.Remarks = this.textBox_Remarks.Text.Trim();
            doc.URLToPixiv = this.textBox_URLToPixiv.Text.Trim();
            doc.Creater = creater;

            try
            {
                // データ登録
                insert(doc);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                string message = "Error!!" + Environment.NewLine + ex.Message; 
                MessageBox.Show(message,
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            this.Close();
        }

        /// <summary>
        /// データ登録
        /// </summary>
        /// <param name="doc">入力された情報</param>
        private void insert(CharacterData doc)
        {
            MongoClient client = null;
            MongoServer server = null;

            try
            {
                client = new MongoClient(this.connectionString);
                server = client.GetServer();

                MongoDatabase db = server.GetDatabase("mhgk");
                MongoCollection col = db.GetCollection<CharacterData>("data");

                col.Insert<CharacterData>(doc);
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
        /// 「Cancel」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
