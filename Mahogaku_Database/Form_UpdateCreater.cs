using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Mahogaku_Database
{
    public partial class Form_UpdateCreater : Form
    {
        public string ID { get; set; }
        public string Name { get; set; }
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
            this.textBox_Name.Text = this.Name;
            this.textBox_Pixiv.Text = this.Pixiv;
            this.textBox_Twitter.Text = this.Twitter;
        }

        private void button_OK_Click(object sender, EventArgs e)
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

            string message = string.Format(@"
以下の内容で編集します。
よろしいですか？

名前 : {0}
PixivID : {1}
TwitterID : {2}",
                name,
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
            doc.PixivID = pixiv;
            doc.TwitterID = twitter;
            doc.ID = this.ID;

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
                string errorMessage = "Error!!" + Environment.NewLine + ex.Message;
                if (ex.Message.StartsWith("Unable to connect to any of the specified "))
                {
                    errorMessage = "データベースに接続できませんでした。" + Environment.NewLine +
                        "サーバーが立ち上がっていない可能性がありますので、今しばらくお待ち下さい。" + Environment.NewLine +
                        "現在のサーバーの状況は、以下のTwitterアカウントにて随時報告されております。" + Environment.NewLine +
                        Environment.NewLine +
                        "https://twitter.com/mikaze_Atlantis";
                    MessageBox.Show(errorMessage,
                        "Error!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(errorMessage,
                        "Error!!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void insertCreater(CreaterData doc)
        {
            string sql = string.Format(@"
UPDATE
 CREATER 
SET
  NAME = '{0}',
  PIXIV = '{1}',
  TWITTER = '{2}'
WHERE
  ID = '{3}'
;
",
            doc.Name,
            doc.PixivID,
            doc.TwitterID,
            doc.ID);

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
