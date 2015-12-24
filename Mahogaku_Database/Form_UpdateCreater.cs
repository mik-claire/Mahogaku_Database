using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mahogaku_Database
{
    public partial class Form_UpdateCreater : Form
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Pixiv { get; set; }
        public string Twitter { get; set; }

        private string connectionString = string.Empty;

        public Form_UpdateCreater()
        {
            InitializeComponent();
            this.connectionString = "Server=mikserver.ms-18e.com;Database=archive;Uid=guest;Pwd=password";
        }

        private void Form_UpdateCreater_Load(object sender, EventArgs e)
        {
            this.textBox_Name.Text = this.UserName;
            this.textBox_Pixiv.Text = this.Pixiv;
            this.textBox_Twitter.Text = this.Twitter;
        }

        private void validateAndUpdate()
        {
            string name = this.textBox_Name.Text.Trim();
            string pass = this.textBox_Pass.Text.Trim();
            string pixiv = this.textBox_Pixiv.Text.Trim();
            string twitter = this.textBox_Twitter.Text.Trim();

            if (name == string.Empty ||
                pass == string.Empty ||
                pixiv == string.Empty)
            {
                MessageBox.Show("未入力の項目があります。",
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

            // TwitterIDから @ を削除
            if (twitter.Length != 0 &&
                twitter[0] == '@')
            {
                twitter = twitter.Substring(1, twitter.Length - 1);
            }

            string confirmMessage = string.Format(@"
以下の内容で編集します。
よろしいですか？

名前 : {0}
PixivID : {1}
TwitterID : {2}",
                name,
                pixiv,
                twitter != string.Empty ? "@" + twitter : "なし"
);
            DialogResult dr = MessageBox.Show(confirmMessage,
                "Question.",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (dr != DialogResult.OK)
            {
                return;
            }

            CreaterData doc = new CreaterData();
            doc.Name = name;
            doc.PixivID = pixiv;
            doc.TwitterID = twitter;
            doc.ID = this.ID;

            try
            {
                // 登録
                updateCreater(doc);

                MessageBox.Show("Success!");
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
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            validateAndUpdate();
        }

        private void updateCreater(CreaterData doc)
        {
            string sql = @"
update
 CREATER 
set
  NAME = @name,
  PIXIV = @pixiv,
  TWITTER = @twitter
where
  ID = @id
;";
            List<string[]> param = new List<string[]>();
            param.Add(new string[] { "name", doc.Name });
            param.Add(new string[] { "pixiv", doc.PixivID });
            param.Add(new string[] { "twitter", doc.TwitterID });
            param.Add(new string[] { "id", doc.ID });

            executeQuery(sql, param);
        }

        private void executeQuery(string sql, List<string[]> data)
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

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_Pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }

            validateAndUpdate();
        }
    }
}
