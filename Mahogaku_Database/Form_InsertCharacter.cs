using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mahogaku_Database
{
    public partial class Form_InsertCharacter : Form
    {
        private string connectionString = string.Empty;
        private string picturePath = string.Empty;

        List<string> sexID = new List<string>();
        List<string> typeID = new List<string>();
        List<string> createrID = new List<string>();

        public Form_InsertCharacter()
        {
            InitializeComponent();
            this.connectionString = "Server=mikserver.ms-18e.com;Database=archive;Uid=guest;Pwd=password";
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Insert_Load(object sender, EventArgs e)
        {
            try
            {
                // データセット
                setData();
            }
            catch (Exception ex)
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
        }

        /// <summary>
        /// データセット
        /// </summary>
        private void setData()
        {
            // 性別
            List<string[]> sex = getSex();
            this.sexID.Clear();
            this.comboBox_Sex.Items.Clear();
            foreach(string[] doc in sex)
            {
                this.sexID.Add(doc[0]);
                this.comboBox_Sex.Items.Add(doc[1]);
            }
            this.comboBox_Sex.SelectedIndex = 0;

            // 属性
            List<string[]> type = getType();
            this.typeID.Clear();
            this.comboBox_Type.Items.Clear();
            foreach (string[] doc in type)
            {
                this.typeID.Add(doc[0]);
                this.comboBox_Type.Items.Add(doc[1]);
            }
            this.comboBox_Type.SelectedIndex = 0;

            // 親御さん
            List<string[]> creater = getCreater();
            this.createrID.Clear();
            this.comboBox_Creater.Items.Clear();
            foreach (string[] doc in creater)
            {
                this.createrID.Add(doc[0]);
                this.comboBox_Creater.Items.Add(doc[1]);
            }
            this.comboBox_Creater.SelectedIndex = 0;
        }

        private List<string[]> getSex()
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
  *
FROM
  SEX S
ORDER BY
  S.ID ASC
;
";
                reader = cmd.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    string[] doc = {
                                       reader["ID"].ToString(),
                                       reader["NAME"].ToString()
                                   };
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

        private List<string[]> getType()
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
  *
FROM
  TYPE T
ORDER BY
  T.ID ASC
;
";
                reader = cmd.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    string[] doc = {
                                       reader["ID"].ToString(),
                                       reader["NAME"].ToString()
                                   };
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

        private List<string[]> getCreater()
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
  ID,
  NAME,
  PASSWORD
FROM
  CREATER C
ORDER BY
  C.NAME ASC
;
";
                reader = cmd.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    string[] doc = {
                                       reader["ID"].ToString(),
                                       reader["NAME"].ToString(),
                                       reader["PASSWORD"].ToString()
                                   };
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
        /// 「OK」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            validateAndInsert();
        }

        private void validateAndInsert()
        {
            #region 入力チェック
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
            string age = this.textBox_Age.Text.Trim();
            if (age == string.Empty)
            {
                MessageBox.Show("年齢が未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            age = Strings.StrConv(age, VbStrConv.Narrow);

            // 学年
            string grade = this.textBox_Grade.Text.Trim();
            if (grade == string.Empty)
            {
                MessageBox.Show("学年が未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            grade = Strings.StrConv(grade, VbStrConv.Narrow);

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

            // 部活
            string club = string.Empty;
            if (this.textBox_Club.Text.Trim() != string.Empty)
            {
                club = this.textBox_Club.Text.Trim();
            }

            // 組織
            string organization = string.Empty;
            if (this.textBox_Organization.Text.Trim() != string.Empty)
            {
                organization = this.textBox_Organization.Text.Trim();
            }

            // 親御さん情報
            CreaterData creater = new CreaterData();
            creater.ID = this.createrID[this.comboBox_Creater.SelectedIndex];

            // キャラクターシートURL
            if (this.textBox_URLToPixiv.Text.Trim() == string.Empty)
            {
                MessageBox.Show("キャラクターシートURLが未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            string url = this.textBox_URLToPixiv.Text.Trim();
            #endregion

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
備考 :
{10}
キャラクターシートURL :
{11}
WikiURL : {12}

親御さん情報
名前 : {13}",
                 this.textBox_Name.Text.Trim(),
                 this.textBox_Kana.Text.Trim(),
                 this.comboBox_Sex.SelectedItem.ToString(),
                 this.comboBox_Type.SelectedItem.ToString(),
                 this.textBox_Race.Text.Trim(),
                 age,
                 grade,
                 skill,
                 club,
                 organization,
                 this.textBox_Remarks.Text.Trim(),
                 url,
                 this.textBox_Wiki.Text.Trim() != string.Empty ? this.textBox_Wiki.Text.Trim() : "なし",
                 this.comboBox_Creater.Text.Trim()
                 ),
                "Question.",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (dr != DialogResult.OK)
            {
                return;
            }
            
            CharacterData doc = new CharacterData();
            doc.Type = this.typeID[this.comboBox_Type.SelectedIndex];
            doc.Name = this.textBox_Name.Text.Trim();
            doc.Kana = this.textBox_Kana.Text.Trim();
            doc.Sex = this.sexID[this.comboBox_Sex.SelectedIndex];
            doc.Race = this.textBox_Race.Text.Trim();
            doc.Age = age;
            doc.Grade = grade;
            doc.Skill = skill;
            doc.Club = club;
            doc.Organization = organization;
            doc.Remarks = this.textBox_Remarks.Text.Trim().Replace(Environment.NewLine, ",");
            doc.URLToWiki = this.textBox_Wiki.Text.Trim();
            doc.URLToPixiv = url.Replace(Environment.NewLine, ",");
            doc.Creater = new CreaterData();
            doc.Creater.ID = this.createrID[this.comboBox_Creater.SelectedIndex];
            doc.ImageData = this.picturePath != string.Empty ? File.ReadAllBytes(this.picturePath) : new byte[] { };

            try
            {
                // データ登録
                insert(doc);
                MessageBox.Show("Success!!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
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
        }

        /// <summary>
        /// データ登録
        /// </summary>
        /// <param name="doc">入力された情報</param>
        private void insert(CharacterData doc)
        {
            string sql = @"
INSERT INTO
`CHARACTER` (
  NAME,
  KANA,
  TYPE_ID,
  SEX_ID,
  RACE,
  AGE,
  GRADE,
  SKILL,
  CLUB,
  ORGANIZATION,
  REMARKS,
  CREATER_ID,
  WIKI,
  URL,
  IMAGE
)
VALUES (
  @name,
  @kana,
  @type,
  @sex,
  @race,
  @age,
  @grade,
  @skill,
  @club,
  @organization,
  @remarks,
  @createrId,
  @urlToWiki,
  @urlToPixiv,
  @image
);
";

            List<string[]> param = new List<string[]>();
            param.Add(new string[] { "name", doc.Name });
            param.Add(new string[] { "kana", doc.Kana });
            param.Add(new string[] { "type", doc.Type });
            param.Add(new string[] { "sex", doc.Sex });
            param.Add(new string[] { "race", doc.Race });
            param.Add(new string[] { "age", doc.Age });
            param.Add(new string[] { "grade", doc.Grade });
            param.Add(new string[] { "skill", doc.Skill });
            param.Add(new string[] { "club", doc.Club });
            param.Add(new string[] { "organization", doc.Organization });
            param.Add(new string[] { "remarks", doc.Remarks });
            param.Add(new string[] { "createrId", doc.Creater.ID });
            param.Add(new string[] { "urlToWiki", doc.URLToWiki });
            param.Add(new string[] { "urlToPixiv", doc.URLToPixiv });

            executeQuery(sql, param, doc.ImageData);
        }

        private void executeQuery(string sql, List<string[]> data, byte[] image)
        {
            MySqlConnection cn = null;
            MySqlCommand cmd = null;

            try
            {
                cn = new MySqlConnection(this.connectionString);
                cn.Open();
                cmd = cn.CreateCommand();

                cmd.CommandText = sql;

                foreach (string[] ary in data)
                {
                    MySqlParameter param = new MySqlParameter(ary[0], ary[1]);
                    cmd.Parameters.Add(param);
                }

                cmd.Parameters.Add(new MySqlParameter("image", image));

                cmd.ExecuteNonQuery();
            }
            finally
            {
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
        /// 「Cancel」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_ShowCreaters_Click(object sender, EventArgs e)
        {
            using (Form_Creater f = new Form_Creater())
            {
                DialogResult dr = f.ShowDialog();
                setData();
            }
        }

        private void comboBox_Creater_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }

            validateAndInsert();
        }

        private void button_Picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "画像ファイル(*.png, *.jpg, *.gif)|*.png;*.jpg;*.gif";
            DialogResult dr = ofd.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }

            try
            {
                this.picturePath = ofd.FileName;
                refleshImage(ofd.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Error!!");
            }
        }

        private void refleshImage(string fileName)
        {
            Bitmap img = null;

            try
            {
                img = new Bitmap(fileName);
                this.pictureBox_Character.Image = (Image)img;
                this.pictureBox_Character.Refresh();
            }
            finally
            {
                if (img != null)
                {
                    img.Dispose();
                }
            }
        }

        /// <summary>
        /// Image -> byte[]
        /// </summary>
        /// <param name="img">変換元Image</param>
        /// <returns>変換後byte[]</returns>
        private byte[] convertImageToByteArray(Image img)
        {
            ImageConverter converter = new ImageConverter();
            byte[] data = (byte[])converter.ConvertTo(img, typeof(byte[]));

            return data;
        }
    }
}
