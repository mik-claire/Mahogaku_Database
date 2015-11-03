using MySql.Data.MySqlClient;
using System;
using System.Configuration;
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
            this.connectionString = ConfigurationManager.ConnectionStrings["mhgk"].ConnectionString;
        }

        private void button_OK_Click(object sender, EventArgs e)
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

            string message = string.Format(@"
以下の内容で登録します。
よろしいですか？

名前 : {0}
パスワード : {1}
PixivID : {2}
TwitterID : {3}",
                name,
                pass,
                pixiv,
                twitter != string.Empty ? twitter : "なし"
);
            DialogResult dr = MessageBox.Show(message,
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
                MessageBox.Show("Error!!" + Environment.NewLine + ex.Message,
                    "Error!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void insertCreater(CreaterData doc)
        {
            string sql = string.Format(@"
INSERT INTO
CREATER (
NAME,
PASSWORD,
PIXIV,
TWITTER
) VALUES (
'{0}',
'{1}',
'{2}',
'{3}'
);
",
            doc.Name,
            doc.Password,
            doc.PixivID,
            doc.TwitterID);

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

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
