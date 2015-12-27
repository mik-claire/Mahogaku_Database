using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mahogaku_Database
{
    public partial class Form_UpdateCharacter : Form
    {
        public CharacterData Character { get; set; }
        public string Pass { get; set; }

        private string connectionString = string.Empty;
        private string picturePath = string.Empty;

        List<string> sexID = new List<string>();
        List<string> typeID = new List<string>();
        List<string> createrID = new List<string>();

        public Form_UpdateCharacter()
        {
            InitializeComponent();
            this.connectionString = "Server=mikserver.ms-18e.com;Database=archive;Uid=myUser;Pwd=1RewT3vf";
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
        /// データセット
        /// </summary>
        private void setData()
        {
            // 性別
            List<string[]> sex = getSex();
            this.sexID.Clear();
            this.comboBox_Sex.Items.Clear();
            foreach (string[] doc in sex)
            {
                this.sexID.Add(doc[0]);
                this.comboBox_Sex.Items.Add(doc[1]);
            }

            // 属性
            List<string[]> type = getType();
            this.typeID.Clear();
            this.comboBox_Type.Items.Clear();
            foreach (string[] doc in type)
            {
                this.typeID.Add(doc[0]);
                this.comboBox_Type.Items.Add(doc[1]);
            }

            // 親御さん
            List<string[]> creater = getCreater();
            this.createrID.Clear();
            this.comboBox_Creater.Items.Clear();
            foreach (string[] doc in creater)
            {
                this.createrID.Add(doc[0]);
                this.comboBox_Creater.Items.Add(doc[1]);
            }

            this.textBox_Name.Text = this.Character.Name;
            this.textBox_Kana.Text = this.Character.Kana;
            int selectedSex = 0;
            for (int i = 0; i < sex.Count; i++)
            {
                if (sex[i][1] != this.Character.Sex)
                {
                    continue;
                }

                selectedSex = i;
                break;
            }
            this.comboBox_Sex.SelectedIndex = selectedSex;
            int selectedType = 0;
            for (int i = 0; i < type.Count; i++)
            {
                if (type[i][1] != this.Character.Type)
                {
                    continue;
                }

                selectedType = i;
                break;
            }
            this.comboBox_Type.SelectedIndex = selectedType;
            this.textBox_Race.Text = this.Character.Race;
            this.textBox_Age.Text = this.Character.Age;
            this.textBox_Grade.Text = this.Character.Grade;
            this.textBox_Skill.Text = this.Character.Skill;
            this.textBox_Club.Text = this.Character.Club;
            this.textBox_Organization.Text = this.Character.Organization;
            this.textBox_Remarks.Text = this.Character.Remarks;
            this.textBox_Wiki.Text = this.Character.URLToWiki;
            this.textBox_URLToPixiv.Text = this.Character.URLToPixiv;

            if (this.Character.ImageData.Length != 0)
            {
                refleshImage(this.Character.ImageData);
            }

            int selectedCreater = 0;
            for (int i = 0; i < creater.Count; i++)
            {
                if (creater[i][0] != this.Character.Creater.ID)
                {
                    continue;
                }

                selectedCreater = i;
                break;
            }
            this.comboBox_Creater.SelectedIndex = selectedCreater;
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
select
  *
from
  gender
order by
  id asc
;
";
                reader = cmd.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    string[] doc = {
                                       reader["id"].ToString(),
                                       reader["name"].ToString()
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
select
  *
from
  type
order by
  id asc
;
";
                reader = cmd.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    string[] doc = {
                                       reader["id"].ToString(),
                                       reader["name"].ToString()
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
select
  id,
  name,
  password as pass
from
  creater
order by
  name asc
;";
                reader = cmd.ExecuteReader();

                List<string[]> data = new List<string[]>();
                while (reader.Read())
                {
                    string[] doc = {
                                       reader["id"].ToString(),
                                       reader["name"].ToString(),
                                       reader["pass"].ToString()
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

        private void validateAndUpdate()
        {
            #region 入力チェック
            // パスワード
            string pass = this.textBox_Pass.Text.Trim();
            if (pass == string.Empty)
            {
                MessageBox.Show("パスワードが未入力です。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (!pass.Equals(this.Pass))
            {
                MessageBox.Show("登録時のパスワードと一致しません。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

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
備考 : {10}
キャラクターシートURL :
{11}
WikiURL :
{12}

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
            byte[] imageData = new byte[0];
            if (this.picturePath != string.Empty)
            {
                imageData = File.ReadAllBytes(this.picturePath);
            }
            else if (this.pictureBox_Character.Image != null)
            {
                imageData = convertImageToByteArray(this.pictureBox_Character.Image);
            }
            doc.ImageData = imageData;

            try
            {
                // データ更新
                update(doc, this.Character.ID);
                MessageBox.Show("Success!!");
                this.DialogResult = DialogResult.OK;
                this.Close();
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

            this.Close();
        }

        /// <summary>
        /// 「OK」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_OK_Click(object sender, EventArgs e)
        {
            validateAndUpdate();
        }

        /// <summary>
        /// データ更新
        /// </summary>
        /// <param name="doc">入力された情報</param>
        /// <param name="id">更新するID</param>
        private void update(CharacterData doc, string id)
        {
            string sql = @"
update
  chara
set
  name = @name,
  kana = @kana,
  type_id= @type,
  gender_id = @sex,
  race = @race,
  age = @age,
  grade = @grade,
  skill = @skill,
  club = @club,
  organization = @organization,
  remarks = @remarks,
  creater_id = @createrId,
  wiki_url = @urlToWiki,
  sheet_url = @urlToPixiv,
  image = @image
where
  id = @id
;";

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
            param.Add(new string[] { "id", id });

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

        private void textBox_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }

            validateAndUpdate();
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

        /// <summary>
        /// ファイルパスから画像を表示
        /// </summary>
        /// <param name="fileName"></param>
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
        /// byte[]データから画像を表示
        /// </summary>
        /// <param name="imageData"></param>
        private void refleshImage(byte[] imageData)
        {
            this.pictureBox_Character.Image = convertByteArrayToImage(imageData);
            this.pictureBox_Character.Refresh();
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

        private byte[] convertPicturePathToByteArray(string filePath)
        {
            ImageConverter converter = new ImageConverter();
            Image img = Image.FromFile(filePath);
            byte[] data = (byte[])converter.ConvertTo(img, typeof(byte[]));

            return data;
        }

        private void button_PictureReset_Click(object sender, EventArgs e)
        {
            this.picturePath = string.Empty;
            this.pictureBox_Character.Image = null;
        }
    }
}
