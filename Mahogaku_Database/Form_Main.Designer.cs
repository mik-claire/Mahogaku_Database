namespace Mahogaku_Database
{
    partial class Form_Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.button_GetData = new System.Windows.Forms.Button();
            this.listView_Display = new System.Windows.Forms.ListView();
            this.columnHeader_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Sex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Grade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Skill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Creater = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_Insert = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.checkBox_Power = new System.Windows.Forms.CheckBox();
            this.checkBox_Castor = new System.Windows.Forms.CheckBox();
            this.checkBox_Technical = new System.Windows.Forms.CheckBox();
            this.checkBox_Unknown = new System.Windows.Forms.CheckBox();
            this.button_ShowCreaters = new System.Windows.Forms.Button();
            this.label_01 = new System.Windows.Forms.Label();
            this.label_03 = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.pictureBox_Character = new System.Windows.Forms.PictureBox();
            this.textBox_Kana = new System.Windows.Forms.TextBox();
            this.label_04 = new System.Windows.Forms.Label();
            this.textBox_Sex = new System.Windows.Forms.TextBox();
            this.label_05 = new System.Windows.Forms.Label();
            this.textBox_Type = new System.Windows.Forms.TextBox();
            this.label_06 = new System.Windows.Forms.Label();
            this.textBox_Race = new System.Windows.Forms.TextBox();
            this.label_07 = new System.Windows.Forms.Label();
            this.textBox_Age = new System.Windows.Forms.TextBox();
            this.label_08 = new System.Windows.Forms.Label();
            this.textBox_Grade = new System.Windows.Forms.TextBox();
            this.label_09 = new System.Windows.Forms.Label();
            this.textBox_Skill = new System.Windows.Forms.TextBox();
            this.label_10 = new System.Windows.Forms.Label();
            this.textBox_Club = new System.Windows.Forms.TextBox();
            this.label_11 = new System.Windows.Forms.Label();
            this.textBox_Organization = new System.Windows.Forms.TextBox();
            this.label_12 = new System.Windows.Forms.Label();
            this.textBox_Remarks = new System.Windows.Forms.TextBox();
            this.label_13 = new System.Windows.Forms.Label();
            this.textBox_Sheet = new System.Windows.Forms.TextBox();
            this.label_14 = new System.Windows.Forms.Label();
            this.textBox_Wiki = new System.Windows.Forms.TextBox();
            this.label_15 = new System.Windows.Forms.Label();
            this.button_CharacterLink = new System.Windows.Forms.Button();
            this.label_16 = new System.Windows.Forms.Label();
            this.label_02 = new System.Windows.Forms.Label();
            this.label_17 = new System.Windows.Forms.Label();
            this.textBox_CreaterTwitter = new System.Windows.Forms.TextBox();
            this.label_20 = new System.Windows.Forms.Label();
            this.textBox_CreaterPixiv = new System.Windows.Forms.TextBox();
            this.label_19 = new System.Windows.Forms.Label();
            this.textBox_CreaterName = new System.Windows.Forms.TextBox();
            this.label_18 = new System.Windows.Forms.Label();
            this.button_CreaterLink = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Character)).BeginInit();
            this.SuspendLayout();
            // 
            // button_GetData
            // 
            this.button_GetData.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_GetData.Location = new System.Drawing.Point(797, 218);
            this.button_GetData.Name = "button_GetData";
            this.button_GetData.Size = new System.Drawing.Size(75, 23);
            this.button_GetData.TabIndex = 3;
            this.button_GetData.Text = "取得";
            this.button_GetData.UseVisualStyleBackColor = true;
            this.button_GetData.Click += new System.EventHandler(this.button_GetData_Click);
            // 
            // listView_Display
            // 
            this.listView_Display.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Type,
            this.columnHeader_Name,
            this.columnHeader_Sex,
            this.columnHeader_Grade,
            this.columnHeader_Skill,
            this.columnHeader_Creater});
            this.listView_Display.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Display.FullRowSelect = true;
            this.listView_Display.GridLines = true;
            this.listView_Display.Location = new System.Drawing.Point(12, 12);
            this.listView_Display.MultiSelect = false;
            this.listView_Display.Name = "listView_Display";
            this.listView_Display.Size = new System.Drawing.Size(860, 200);
            this.listView_Display.TabIndex = 0;
            this.listView_Display.UseCompatibleStateImageBehavior = false;
            this.listView_Display.View = System.Windows.Forms.View.Details;
            this.listView_Display.SelectedIndexChanged += new System.EventHandler(this.listView_Display_SelectedIndexChanged);
            this.listView_Display.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Display_MouseClick);
            // 
            // columnHeader_Type
            // 
            this.columnHeader_Type.Text = "属性";
            this.columnHeader_Type.Width = 50;
            // 
            // columnHeader_Name
            // 
            this.columnHeader_Name.Text = "名前";
            this.columnHeader_Name.Width = 160;
            // 
            // columnHeader_Sex
            // 
            this.columnHeader_Sex.Text = "性別";
            this.columnHeader_Sex.Width = 50;
            // 
            // columnHeader_Grade
            // 
            this.columnHeader_Grade.Text = "学年";
            this.columnHeader_Grade.Width = 125;
            // 
            // columnHeader_Skill
            // 
            this.columnHeader_Skill.Text = "魔砲";
            this.columnHeader_Skill.Width = 354;
            // 
            // columnHeader_Creater
            // 
            this.columnHeader_Creater.Text = "親御さん";
            this.columnHeader_Creater.Width = 100;
            // 
            // button_Insert
            // 
            this.button_Insert.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Insert.Location = new System.Drawing.Point(12, 218);
            this.button_Insert.Name = "button_Insert";
            this.button_Insert.Size = new System.Drawing.Size(75, 23);
            this.button_Insert.TabIndex = 1;
            this.button_Insert.Text = "登録";
            this.button_Insert.UseVisualStyleBackColor = true;
            this.button_Insert.Click += new System.EventHandler(this.button_Insert_Click);
            // 
            // button_Update
            // 
            this.button_Update.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Update.Location = new System.Drawing.Point(93, 218);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(75, 23);
            this.button_Update.TabIndex = 2;
            this.button_Update.Text = "編集";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Update_Click);
            // 
            // checkBox_Power
            // 
            this.checkBox_Power.AutoSize = true;
            this.checkBox_Power.Checked = true;
            this.checkBox_Power.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Power.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox_Power.Location = new System.Drawing.Point(248, 221);
            this.checkBox_Power.Name = "checkBox_Power";
            this.checkBox_Power.Size = new System.Drawing.Size(38, 19);
            this.checkBox_Power.TabIndex = 4;
            this.checkBox_Power.Text = "力";
            this.checkBox_Power.UseVisualStyleBackColor = true;
            this.checkBox_Power.CheckedChanged += new System.EventHandler(this.checkBox_Type_CheckedChanged);
            // 
            // checkBox_Castor
            // 
            this.checkBox_Castor.AutoSize = true;
            this.checkBox_Castor.Checked = true;
            this.checkBox_Castor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Castor.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox_Castor.Location = new System.Drawing.Point(290, 221);
            this.checkBox_Castor.Name = "checkBox_Castor";
            this.checkBox_Castor.Size = new System.Drawing.Size(38, 19);
            this.checkBox_Castor.TabIndex = 5;
            this.checkBox_Castor.Text = "魔";
            this.checkBox_Castor.UseVisualStyleBackColor = true;
            this.checkBox_Castor.CheckedChanged += new System.EventHandler(this.checkBox_Type_CheckedChanged);
            // 
            // checkBox_Technical
            // 
            this.checkBox_Technical.AutoSize = true;
            this.checkBox_Technical.Checked = true;
            this.checkBox_Technical.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Technical.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox_Technical.Location = new System.Drawing.Point(332, 221);
            this.checkBox_Technical.Name = "checkBox_Technical";
            this.checkBox_Technical.Size = new System.Drawing.Size(38, 19);
            this.checkBox_Technical.TabIndex = 6;
            this.checkBox_Technical.Text = "技";
            this.checkBox_Technical.UseVisualStyleBackColor = true;
            this.checkBox_Technical.CheckedChanged += new System.EventHandler(this.checkBox_Type_CheckedChanged);
            // 
            // checkBox_Unknown
            // 
            this.checkBox_Unknown.AutoSize = true;
            this.checkBox_Unknown.Checked = true;
            this.checkBox_Unknown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Unknown.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox_Unknown.Location = new System.Drawing.Point(376, 221);
            this.checkBox_Unknown.Name = "checkBox_Unknown";
            this.checkBox_Unknown.Size = new System.Drawing.Size(50, 19);
            this.checkBox_Unknown.TabIndex = 7;
            this.checkBox_Unknown.Text = "不明";
            this.checkBox_Unknown.UseVisualStyleBackColor = true;
            this.checkBox_Unknown.CheckedChanged += new System.EventHandler(this.checkBox_Type_CheckedChanged);
            // 
            // button_ShowCreaters
            // 
            this.button_ShowCreaters.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_ShowCreaters.Location = new System.Drawing.Point(675, 218);
            this.button_ShowCreaters.Name = "button_ShowCreaters";
            this.button_ShowCreaters.Size = new System.Drawing.Size(116, 23);
            this.button_ShowCreaters.TabIndex = 66;
            this.button_ShowCreaters.Text = "親御さん情報一覧";
            this.button_ShowCreaters.UseVisualStyleBackColor = true;
            this.button_ShowCreaters.Click += new System.EventHandler(this.button_ShowCreaters_Click);
            // 
            // label_01
            // 
            this.label_01.AutoSize = true;
            this.label_01.Location = new System.Drawing.Point(6, 242);
            this.label_01.Name = "label_01";
            this.label_01.Size = new System.Drawing.Size(873, 12);
            this.label_01.TabIndex = 67;
            this.label_01.Text = resources.GetString("label_01.Text");
            // 
            // label_03
            // 
            this.label_03.AutoSize = true;
            this.label_03.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_03.Location = new System.Drawing.Point(193, 289);
            this.label_03.Name = "label_03";
            this.label_03.Size = new System.Drawing.Size(31, 15);
            this.label_03.TabIndex = 68;
            this.label_03.Text = "名前";
            // 
            // textBox_Name
            // 
            this.textBox_Name.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Name.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Name.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Name.Location = new System.Drawing.Point(258, 286);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.ReadOnly = true;
            this.textBox_Name.Size = new System.Drawing.Size(240, 23);
            this.textBox_Name.TabIndex = 69;
            // 
            // pictureBox_Character
            // 
            this.pictureBox_Character.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Character.Location = new System.Drawing.Point(12, 286);
            this.pictureBox_Character.Name = "pictureBox_Character";
            this.pictureBox_Character.Size = new System.Drawing.Size(150, 200);
            this.pictureBox_Character.TabIndex = 70;
            this.pictureBox_Character.TabStop = false;
            // 
            // textBox_Kana
            // 
            this.textBox_Kana.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Kana.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Kana.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Kana.Location = new System.Drawing.Point(258, 315);
            this.textBox_Kana.Name = "textBox_Kana";
            this.textBox_Kana.ReadOnly = true;
            this.textBox_Kana.Size = new System.Drawing.Size(240, 23);
            this.textBox_Kana.TabIndex = 72;
            // 
            // label_04
            // 
            this.label_04.AutoSize = true;
            this.label_04.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_04.Location = new System.Drawing.Point(193, 318);
            this.label_04.Name = "label_04";
            this.label_04.Size = new System.Drawing.Size(47, 15);
            this.label_04.TabIndex = 71;
            this.label_04.Text = "よみがな";
            // 
            // textBox_Sex
            // 
            this.textBox_Sex.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Sex.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Sex.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Sex.Location = new System.Drawing.Point(258, 344);
            this.textBox_Sex.Name = "textBox_Sex";
            this.textBox_Sex.ReadOnly = true;
            this.textBox_Sex.Size = new System.Drawing.Size(79, 23);
            this.textBox_Sex.TabIndex = 74;
            // 
            // label_05
            // 
            this.label_05.AutoSize = true;
            this.label_05.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_05.Location = new System.Drawing.Point(193, 347);
            this.label_05.Name = "label_05";
            this.label_05.Size = new System.Drawing.Size(31, 15);
            this.label_05.TabIndex = 73;
            this.label_05.Text = "性別";
            // 
            // textBox_Type
            // 
            this.textBox_Type.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Type.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Type.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Type.Location = new System.Drawing.Point(258, 373);
            this.textBox_Type.Name = "textBox_Type";
            this.textBox_Type.ReadOnly = true;
            this.textBox_Type.Size = new System.Drawing.Size(79, 23);
            this.textBox_Type.TabIndex = 76;
            // 
            // label_06
            // 
            this.label_06.AutoSize = true;
            this.label_06.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_06.Location = new System.Drawing.Point(193, 376);
            this.label_06.Name = "label_06";
            this.label_06.Size = new System.Drawing.Size(31, 15);
            this.label_06.TabIndex = 75;
            this.label_06.Text = "属性";
            // 
            // textBox_Race
            // 
            this.textBox_Race.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Race.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Race.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Race.Location = new System.Drawing.Point(258, 402);
            this.textBox_Race.Name = "textBox_Race";
            this.textBox_Race.ReadOnly = true;
            this.textBox_Race.Size = new System.Drawing.Size(240, 23);
            this.textBox_Race.TabIndex = 78;
            // 
            // label_07
            // 
            this.label_07.AutoSize = true;
            this.label_07.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_07.Location = new System.Drawing.Point(193, 405);
            this.label_07.Name = "label_07";
            this.label_07.Size = new System.Drawing.Size(31, 15);
            this.label_07.TabIndex = 77;
            this.label_07.Text = "種族";
            // 
            // textBox_Age
            // 
            this.textBox_Age.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Age.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Age.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Age.Location = new System.Drawing.Point(258, 431);
            this.textBox_Age.Name = "textBox_Age";
            this.textBox_Age.ReadOnly = true;
            this.textBox_Age.Size = new System.Drawing.Size(240, 23);
            this.textBox_Age.TabIndex = 80;
            // 
            // label_08
            // 
            this.label_08.AutoSize = true;
            this.label_08.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_08.Location = new System.Drawing.Point(193, 434);
            this.label_08.Name = "label_08";
            this.label_08.Size = new System.Drawing.Size(31, 15);
            this.label_08.TabIndex = 79;
            this.label_08.Text = "年齢";
            // 
            // textBox_Grade
            // 
            this.textBox_Grade.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Grade.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Grade.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Grade.Location = new System.Drawing.Point(258, 460);
            this.textBox_Grade.Name = "textBox_Grade";
            this.textBox_Grade.ReadOnly = true;
            this.textBox_Grade.Size = new System.Drawing.Size(240, 23);
            this.textBox_Grade.TabIndex = 82;
            // 
            // label_09
            // 
            this.label_09.AutoSize = true;
            this.label_09.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_09.Location = new System.Drawing.Point(193, 463);
            this.label_09.Name = "label_09";
            this.label_09.Size = new System.Drawing.Size(31, 15);
            this.label_09.TabIndex = 81;
            this.label_09.Text = "学年";
            // 
            // textBox_Skill
            // 
            this.textBox_Skill.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Skill.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Skill.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Skill.Location = new System.Drawing.Point(596, 286);
            this.textBox_Skill.Name = "textBox_Skill";
            this.textBox_Skill.ReadOnly = true;
            this.textBox_Skill.Size = new System.Drawing.Size(276, 23);
            this.textBox_Skill.TabIndex = 84;
            // 
            // label_10
            // 
            this.label_10.AutoSize = true;
            this.label_10.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_10.Location = new System.Drawing.Point(530, 289);
            this.label_10.Name = "label_10";
            this.label_10.Size = new System.Drawing.Size(31, 15);
            this.label_10.TabIndex = 83;
            this.label_10.Text = "魔砲";
            // 
            // textBox_Club
            // 
            this.textBox_Club.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Club.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Club.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Club.Location = new System.Drawing.Point(596, 315);
            this.textBox_Club.Name = "textBox_Club";
            this.textBox_Club.ReadOnly = true;
            this.textBox_Club.Size = new System.Drawing.Size(276, 23);
            this.textBox_Club.TabIndex = 86;
            // 
            // label_11
            // 
            this.label_11.AutoSize = true;
            this.label_11.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_11.Location = new System.Drawing.Point(530, 318);
            this.label_11.Name = "label_11";
            this.label_11.Size = new System.Drawing.Size(43, 15);
            this.label_11.TabIndex = 85;
            this.label_11.Text = "部活動";
            // 
            // textBox_Organization
            // 
            this.textBox_Organization.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Organization.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Organization.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Organization.Location = new System.Drawing.Point(596, 344);
            this.textBox_Organization.Name = "textBox_Organization";
            this.textBox_Organization.ReadOnly = true;
            this.textBox_Organization.Size = new System.Drawing.Size(276, 23);
            this.textBox_Organization.TabIndex = 88;
            // 
            // label_12
            // 
            this.label_12.AutoSize = true;
            this.label_12.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_12.Location = new System.Drawing.Point(530, 347);
            this.label_12.Name = "label_12";
            this.label_12.Size = new System.Drawing.Size(31, 15);
            this.label_12.TabIndex = 87;
            this.label_12.Text = "組織";
            // 
            // textBox_Remarks
            // 
            this.textBox_Remarks.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Remarks.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Remarks.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Remarks.Location = new System.Drawing.Point(596, 373);
            this.textBox_Remarks.Multiline = true;
            this.textBox_Remarks.Name = "textBox_Remarks";
            this.textBox_Remarks.ReadOnly = true;
            this.textBox_Remarks.Size = new System.Drawing.Size(276, 110);
            this.textBox_Remarks.TabIndex = 90;
            // 
            // label_13
            // 
            this.label_13.AutoSize = true;
            this.label_13.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_13.Location = new System.Drawing.Point(530, 376);
            this.label_13.Name = "label_13";
            this.label_13.Size = new System.Drawing.Size(31, 15);
            this.label_13.TabIndex = 89;
            this.label_13.Text = "備考";
            // 
            // textBox_Sheet
            // 
            this.textBox_Sheet.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Sheet.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Sheet.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Sheet.Location = new System.Drawing.Point(258, 489);
            this.textBox_Sheet.Multiline = true;
            this.textBox_Sheet.Name = "textBox_Sheet";
            this.textBox_Sheet.ReadOnly = true;
            this.textBox_Sheet.Size = new System.Drawing.Size(614, 81);
            this.textBox_Sheet.TabIndex = 92;
            // 
            // label_14
            // 
            this.label_14.AutoSize = true;
            this.label_14.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_14.Location = new System.Drawing.Point(193, 492);
            this.label_14.Name = "label_14";
            this.label_14.Size = new System.Drawing.Size(59, 30);
            this.label_14.TabIndex = 91;
            this.label_14.Text = "キャラクター\r\nシートURL\r\n";
            // 
            // textBox_Wiki
            // 
            this.textBox_Wiki.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_Wiki.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Wiki.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_Wiki.Location = new System.Drawing.Point(258, 576);
            this.textBox_Wiki.Name = "textBox_Wiki";
            this.textBox_Wiki.ReadOnly = true;
            this.textBox_Wiki.Size = new System.Drawing.Size(614, 23);
            this.textBox_Wiki.TabIndex = 94;
            // 
            // label_15
            // 
            this.label_15.AutoSize = true;
            this.label_15.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_15.Location = new System.Drawing.Point(193, 572);
            this.label_15.Name = "label_15";
            this.label_15.Size = new System.Drawing.Size(59, 30);
            this.label_15.TabIndex = 93;
            this.label_15.Text = "キャラクター\r\nwikiURL";
            // 
            // button_CharacterLink
            // 
            this.button_CharacterLink.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_CharacterLink.Location = new System.Drawing.Point(797, 605);
            this.button_CharacterLink.Name = "button_CharacterLink";
            this.button_CharacterLink.Size = new System.Drawing.Size(75, 23);
            this.button_CharacterLink.TabIndex = 95;
            this.button_CharacterLink.Text = "リンクを開く";
            this.button_CharacterLink.UseVisualStyleBackColor = true;
            this.button_CharacterLink.Click += new System.EventHandler(this.button_CharacterLink_Click);
            // 
            // label_16
            // 
            this.label_16.AutoSize = true;
            this.label_16.Location = new System.Drawing.Point(6, 629);
            this.label_16.Name = "label_16";
            this.label_16.Size = new System.Drawing.Size(873, 12);
            this.label_16.TabIndex = 98;
            this.label_16.Text = resources.GetString("label_16.Text");
            // 
            // label_02
            // 
            this.label_02.AutoSize = true;
            this.label_02.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_02.Location = new System.Drawing.Point(12, 265);
            this.label_02.Name = "label_02";
            this.label_02.Size = new System.Drawing.Size(83, 15);
            this.label_02.TabIndex = 99;
            this.label_02.Text = "キャラクター情報";
            // 
            // label_17
            // 
            this.label_17.AutoSize = true;
            this.label_17.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_17.Location = new System.Drawing.Point(12, 652);
            this.label_17.Name = "label_17";
            this.label_17.Size = new System.Drawing.Size(73, 15);
            this.label_17.TabIndex = 100;
            this.label_17.Text = "親御さん情報";
            // 
            // textBox_CreaterTwitter
            // 
            this.textBox_CreaterTwitter.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_CreaterTwitter.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_CreaterTwitter.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_CreaterTwitter.Location = new System.Drawing.Point(560, 679);
            this.textBox_CreaterTwitter.Name = "textBox_CreaterTwitter";
            this.textBox_CreaterTwitter.ReadOnly = true;
            this.textBox_CreaterTwitter.Size = new System.Drawing.Size(147, 23);
            this.textBox_CreaterTwitter.TabIndex = 106;
            // 
            // label_20
            // 
            this.label_20.AutoSize = true;
            this.label_20.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_20.Location = new System.Drawing.Point(491, 682);
            this.label_20.Name = "label_20";
            this.label_20.Size = new System.Drawing.Size(63, 15);
            this.label_20.TabIndex = 105;
            this.label_20.Text = "TwitterID";
            // 
            // textBox_CreaterPixiv
            // 
            this.textBox_CreaterPixiv.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_CreaterPixiv.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_CreaterPixiv.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_CreaterPixiv.Location = new System.Drawing.Point(297, 679);
            this.textBox_CreaterPixiv.Name = "textBox_CreaterPixiv";
            this.textBox_CreaterPixiv.ReadOnly = true;
            this.textBox_CreaterPixiv.Size = new System.Drawing.Size(147, 23);
            this.textBox_CreaterPixiv.TabIndex = 108;
            // 
            // label_19
            // 
            this.label_19.AutoSize = true;
            this.label_19.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_19.Location = new System.Drawing.Point(243, 682);
            this.label_19.Name = "label_19";
            this.label_19.Size = new System.Drawing.Size(48, 15);
            this.label_19.TabIndex = 107;
            this.label_19.Text = "PixivID";
            // 
            // textBox_CreaterName
            // 
            this.textBox_CreaterName.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_CreaterName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_CreaterName.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox_CreaterName.Location = new System.Drawing.Point(49, 679);
            this.textBox_CreaterName.Name = "textBox_CreaterName";
            this.textBox_CreaterName.ReadOnly = true;
            this.textBox_CreaterName.Size = new System.Drawing.Size(147, 23);
            this.textBox_CreaterName.TabIndex = 110;
            // 
            // label_18
            // 
            this.label_18.AutoSize = true;
            this.label_18.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_18.Location = new System.Drawing.Point(12, 682);
            this.label_18.Name = "label_18";
            this.label_18.Size = new System.Drawing.Size(31, 15);
            this.label_18.TabIndex = 109;
            this.label_18.Text = "名前";
            // 
            // button_CreaterLink
            // 
            this.button_CreaterLink.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_CreaterLink.Location = new System.Drawing.Point(797, 678);
            this.button_CreaterLink.Name = "button_CreaterLink";
            this.button_CreaterLink.Size = new System.Drawing.Size(75, 23);
            this.button_CreaterLink.TabIndex = 111;
            this.button_CreaterLink.Text = "リンクを開く";
            this.button_CreaterLink.UseVisualStyleBackColor = true;
            this.button_CreaterLink.Click += new System.EventHandler(this.button_CreaterLink_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 712);
            this.Controls.Add(this.button_CreaterLink);
            this.Controls.Add(this.textBox_CreaterName);
            this.Controls.Add(this.label_18);
            this.Controls.Add(this.textBox_CreaterPixiv);
            this.Controls.Add(this.label_19);
            this.Controls.Add(this.textBox_CreaterTwitter);
            this.Controls.Add(this.label_20);
            this.Controls.Add(this.label_17);
            this.Controls.Add(this.label_02);
            this.Controls.Add(this.label_16);
            this.Controls.Add(this.button_CharacterLink);
            this.Controls.Add(this.textBox_Wiki);
            this.Controls.Add(this.label_15);
            this.Controls.Add(this.textBox_Sheet);
            this.Controls.Add(this.label_14);
            this.Controls.Add(this.textBox_Remarks);
            this.Controls.Add(this.label_13);
            this.Controls.Add(this.textBox_Organization);
            this.Controls.Add(this.label_12);
            this.Controls.Add(this.textBox_Club);
            this.Controls.Add(this.label_11);
            this.Controls.Add(this.textBox_Skill);
            this.Controls.Add(this.label_10);
            this.Controls.Add(this.textBox_Grade);
            this.Controls.Add(this.label_09);
            this.Controls.Add(this.textBox_Age);
            this.Controls.Add(this.label_08);
            this.Controls.Add(this.textBox_Race);
            this.Controls.Add(this.label_07);
            this.Controls.Add(this.textBox_Type);
            this.Controls.Add(this.label_06);
            this.Controls.Add(this.textBox_Sex);
            this.Controls.Add(this.label_05);
            this.Controls.Add(this.textBox_Kana);
            this.Controls.Add(this.label_04);
            this.Controls.Add(this.pictureBox_Character);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.label_03);
            this.Controls.Add(this.label_01);
            this.Controls.Add(this.button_ShowCreaters);
            this.Controls.Add(this.checkBox_Unknown);
            this.Controls.Add(this.checkBox_Technical);
            this.Controls.Add(this.checkBox_Castor);
            this.Controls.Add(this.checkBox_Power);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Insert);
            this.Controls.Add(this.listView_Display);
            this.Controls.Add(this.button_GetData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.Text = "まほがくでーたべーす！";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Character)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GetData;
        private System.Windows.Forms.ListView listView_Display;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_Type;
        private System.Windows.Forms.ColumnHeader columnHeader_Skill;
        private System.Windows.Forms.Button button_Insert;
        private System.Windows.Forms.ColumnHeader columnHeader_Grade;
        private System.Windows.Forms.ColumnHeader columnHeader_Creater;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.CheckBox checkBox_Power;
        private System.Windows.Forms.CheckBox checkBox_Castor;
        private System.Windows.Forms.CheckBox checkBox_Technical;
        private System.Windows.Forms.CheckBox checkBox_Unknown;
        private System.Windows.Forms.Button button_ShowCreaters;
        private System.Windows.Forms.ColumnHeader columnHeader_Sex;
        private System.Windows.Forms.Label label_01;
        private System.Windows.Forms.Label label_03;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.PictureBox pictureBox_Character;
        private System.Windows.Forms.TextBox textBox_Kana;
        private System.Windows.Forms.Label label_04;
        private System.Windows.Forms.TextBox textBox_Sex;
        private System.Windows.Forms.Label label_05;
        private System.Windows.Forms.TextBox textBox_Type;
        private System.Windows.Forms.Label label_06;
        private System.Windows.Forms.TextBox textBox_Race;
        private System.Windows.Forms.Label label_07;
        private System.Windows.Forms.TextBox textBox_Age;
        private System.Windows.Forms.Label label_08;
        private System.Windows.Forms.TextBox textBox_Grade;
        private System.Windows.Forms.Label label_09;
        private System.Windows.Forms.TextBox textBox_Skill;
        private System.Windows.Forms.Label label_10;
        private System.Windows.Forms.TextBox textBox_Club;
        private System.Windows.Forms.Label label_11;
        private System.Windows.Forms.TextBox textBox_Organization;
        private System.Windows.Forms.Label label_12;
        private System.Windows.Forms.TextBox textBox_Remarks;
        private System.Windows.Forms.Label label_13;
        private System.Windows.Forms.TextBox textBox_Sheet;
        private System.Windows.Forms.Label label_14;
        private System.Windows.Forms.TextBox textBox_Wiki;
        private System.Windows.Forms.Label label_15;
        private System.Windows.Forms.Button button_CharacterLink;
        private System.Windows.Forms.Label label_16;
        private System.Windows.Forms.Label label_02;
        private System.Windows.Forms.Label label_17;
        private System.Windows.Forms.TextBox textBox_CreaterTwitter;
        private System.Windows.Forms.Label label_20;
        private System.Windows.Forms.TextBox textBox_CreaterPixiv;
        private System.Windows.Forms.Label label_19;
        private System.Windows.Forms.TextBox textBox_CreaterName;
        private System.Windows.Forms.Label label_18;
        private System.Windows.Forms.Button button_CreaterLink;
    }
}

