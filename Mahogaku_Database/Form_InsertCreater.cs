using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mahogaku_Database
{
    public partial class Form_InsertCreater : Form
    {
        private string connectionString = string.Empty;

        public Form_InsertCreater()
        {
            InitializeComponent();
            this.connectionString = "Server=mikserver.ms-18e.com;Database=archive;Uid=myUser;Pwd=1RewT3vf";
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            validateAndInsert();
        }

        private void validateAndInsert()
        {
            string name = this.textBox_Name.Text.Trim();
            string pass = this.textBox_Pass.Text.Trim();
            string confirm = this.textBox_Confirm.Text.Trim();
            string pixiv = this.textBox_Pixiv.Text.Trim();
            string twitter = this.textBox_Twitter.Text.Trim();

            if (name == string.Empty ||
                pass == string.Empty ||
                confirm == string.Empty ||
                pixiv == string.Empty)
            {
                MessageBox.Show("未入力の項目があります。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(this.textBox_Pass.Text.Trim(), "[a-zA-Z0-9]{8,16}"))
            {
                MessageBox.Show("パスワードは、半角英数のみで、8～16文字にしてください。",
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!pass.Equals(confirm))
            {
                MessageBox.Show("パスワードと確認文字列が一致しません。",
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
以下の内容で登録します。
よろしいですか？

名前 : {0}
パスワード : {1}
PixivID : {2}
TwitterID : {3}",
                name,
                pass,
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
            doc.Password = pass;
            doc.PixivID = pixiv;
            doc.TwitterID = twitter;

            try
            {
                // 登録
                insertCreater(doc);

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

        private void insertCreater(CreaterData doc)
        {
            string sql = @"
insert into
  creater
values (
  null,
  @name,
  @pass,
  @pixiv,
  @twitter
);";

            List<string[]> param = new List<string[]>();
            param.Add(new string[] { "name", doc.Name });
            param.Add(new string[] { "pass", doc.Password });
            param.Add(new string[] { "pixiv", doc.PixivID });
            param.Add(new string[] { "twitter", doc.TwitterID });

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

        private void textBox_Twitter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }

            validateAndInsert();
        }
    }
}
