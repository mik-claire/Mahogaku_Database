using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mahogaku_Database
{
    public partial class Form_UpdateCharacter : Form
    {
        public CharacterData Character { get; set; }
        public string Pass { get; set; }

        private string connectionString = string.Empty;

        List<string> sexID = new List<string>();
        List<string> typeID = new List<string>();
        List<string> createrID = new List<string>();

        public Form_UpdateCharacter()
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
            this.textBox_URLToPixiv.Text = this.Character.URLToPixiv;

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
            string url = this.textBox_URLToPixiv.Text.Trim().Replace(",", Environment.NewLine);
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

親御さん情報
名前 : {12}",
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
            doc.Remarks = this.textBox_Remarks.Text.Trim();
            doc.URLToPixiv = this.textBox_URLToPixiv.Text.Trim();
            doc.Creater = new CreaterData();
            doc.Creater.ID = this.createrID[this.comboBox_Creater.SelectedIndex];

            try
            {
                // データ更新
                update(doc, this.Character.ID);
                MessageBox.Show("Success!!");
                this.DialogResult = DialogResult.OK;
                this.Close();
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

            this.Close();
        }

        /// <summary>
        /// データ更新
        /// </summary>
        /// <param name="doc">入力された情報</param>
        /// <param name="id">更新するID</param>
        private void update(CharacterData doc, string id)
        {
            string sql = @"
UPDATE
  `CHARACTER`
SET
  NAME = '{0}',
  KANA = '{1}',
  TYPE_ID = {2},
  SEX_ID = {3},
  RACE = '{4}',
  AGE = '{5}',
  GRADE = '{6}',
  SKILL = '{7}',
  CLUB = '{8}',
  ORGANIZATION = '{9}',
  REMARKS = '{10}',
  CREATER_ID = '{11}',
  URL = '{12}'
WHERE
  ID = '{13}'
;
";
            sql = string.Format(sql,
                doc.Name,
                doc.Kana,
                doc.Type,
                doc.Sex,
                doc.Race,
                doc.Age,
                doc.Grade,
                doc.Skill,
                doc.Club,
                doc.Organization,
                doc.Remarks,
                doc.Creater.ID,
                doc.URLToPixiv,
                id);

            executeQuery(sql);
        }

        private void executeQuery(string sql)
        {
            MySqlConnection cn = null;
            MySqlCommand cmd = null;

            try
            {
                cn = new MySqlConnection(this.connectionString);
                cn.Open();
                cmd = cn.CreateCommand();

                cmd.CommandText = sql;
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
    }
}
