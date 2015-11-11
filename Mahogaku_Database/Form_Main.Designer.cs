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
            this.button_GetData = new System.Windows.Forms.Button();
            this.listView_Display = new System.Windows.Forms.ListView();
            this.columnHeader_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader_Kana = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Sex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Race = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Age = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Grade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Skill = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Club = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Organization = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Remarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Creater = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_Insert = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.checkBox_Power = new System.Windows.Forms.CheckBox();
            this.checkBox_Castor = new System.Windows.Forms.CheckBox();
            this.checkBox_Technical = new System.Windows.Forms.CheckBox();
            this.checkBox_Unknown = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button_GetData
            // 
            this.button_GetData.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_GetData.Location = new System.Drawing.Point(797, 377);
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
            this.ColumnHeader_Kana,
            this.columnHeader_Sex,
            this.columnHeader_Race,
            this.columnHeader_Age,
            this.columnHeader_Grade,
            this.columnHeader_Skill,
            this.columnHeader_Club,
            this.columnHeader_Organization,
            this.columnHeader_Remarks,
            this.columnHeader_Creater});
            this.listView_Display.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView_Display.FullRowSelect = true;
            this.listView_Display.GridLines = true;
            this.listView_Display.Location = new System.Drawing.Point(12, 12);
            this.listView_Display.MultiSelect = false;
            this.listView_Display.Name = "listView_Display";
            this.listView_Display.Size = new System.Drawing.Size(860, 359);
            this.listView_Display.TabIndex = 0;
            this.listView_Display.UseCompatibleStateImageBehavior = false;
            this.listView_Display.View = System.Windows.Forms.View.Details;
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
            this.columnHeader_Name.Width = 180;
            // 
            // ColumnHeader_Kana
            // 
            this.ColumnHeader_Kana.Text = "読み仮名";
            this.ColumnHeader_Kana.Width = 180;
            // 
            // columnHeader_Sex
            // 
            this.columnHeader_Sex.Text = "性別";
            this.columnHeader_Sex.Width = 50;
            // 
            // columnHeader_Race
            // 
            this.columnHeader_Race.Text = "種族";
            this.columnHeader_Race.Width = 90;
            // 
            // columnHeader_Age
            // 
            this.columnHeader_Age.Text = "年齢";
            this.columnHeader_Age.Width = 50;
            // 
            // columnHeader_Grade
            // 
            this.columnHeader_Grade.Text = "学年";
            this.columnHeader_Grade.Width = 85;
            // 
            // columnHeader_Skill
            // 
            this.columnHeader_Skill.Text = "魔砲";
            this.columnHeader_Skill.Width = 180;
            // 
            // columnHeader_Club
            // 
            this.columnHeader_Club.Text = "部活";
            this.columnHeader_Club.Width = 100;
            // 
            // columnHeader_Organization
            // 
            this.columnHeader_Organization.Text = "組織";
            this.columnHeader_Organization.Width = 100;
            // 
            // columnHeader_Remarks
            // 
            this.columnHeader_Remarks.Text = "備考";
            this.columnHeader_Remarks.Width = 300;
            // 
            // columnHeader_Creater
            // 
            this.columnHeader_Creater.Text = "親御さん";
            this.columnHeader_Creater.Width = 100;
            // 
            // button_Insert
            // 
            this.button_Insert.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Insert.Location = new System.Drawing.Point(12, 377);
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
            this.button_Update.Location = new System.Drawing.Point(93, 377);
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
            this.checkBox_Power.Location = new System.Drawing.Point(245, 382);
            this.checkBox_Power.Name = "checkBox_Power";
            this.checkBox_Power.Size = new System.Drawing.Size(36, 16);
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
            this.checkBox_Castor.Location = new System.Drawing.Point(287, 382);
            this.checkBox_Castor.Name = "checkBox_Castor";
            this.checkBox_Castor.Size = new System.Drawing.Size(36, 16);
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
            this.checkBox_Technical.Location = new System.Drawing.Point(329, 382);
            this.checkBox_Technical.Name = "checkBox_Technical";
            this.checkBox_Technical.Size = new System.Drawing.Size(36, 16);
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
            this.checkBox_Unknown.Location = new System.Drawing.Point(371, 382);
            this.checkBox_Unknown.Name = "checkBox_Unknown";
            this.checkBox_Unknown.Size = new System.Drawing.Size(48, 16);
            this.checkBox_Unknown.TabIndex = 7;
            this.checkBox_Unknown.Text = "不明";
            this.checkBox_Unknown.UseVisualStyleBackColor = true;
            this.checkBox_Unknown.CheckedChanged += new System.EventHandler(this.checkBox_Type_CheckedChanged);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 412);
            this.Controls.Add(this.checkBox_Unknown);
            this.Controls.Add(this.checkBox_Technical);
            this.Controls.Add(this.checkBox_Castor);
            this.Controls.Add(this.checkBox_Power);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.button_Insert);
            this.Controls.Add(this.listView_Display);
            this.Controls.Add(this.button_GetData);
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.Text = "まほがくでーたべーす！";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GetData;
        private System.Windows.Forms.ListView listView_Display;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_Sex;
        private System.Windows.Forms.ColumnHeader columnHeader_Type;
        private System.Windows.Forms.ColumnHeader columnHeader_Skill;
        private System.Windows.Forms.ColumnHeader columnHeader_Remarks;
        private System.Windows.Forms.Button button_Insert;
        private System.Windows.Forms.ColumnHeader ColumnHeader_Kana;
        private System.Windows.Forms.ColumnHeader columnHeader_Race;
        private System.Windows.Forms.ColumnHeader columnHeader_Age;
        private System.Windows.Forms.ColumnHeader columnHeader_Grade;
        private System.Windows.Forms.ColumnHeader columnHeader_Club;
        private System.Windows.Forms.ColumnHeader columnHeader_Organization;
        private System.Windows.Forms.ColumnHeader columnHeader_Creater;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.CheckBox checkBox_Power;
        private System.Windows.Forms.CheckBox checkBox_Castor;
        private System.Windows.Forms.CheckBox checkBox_Technical;
        private System.Windows.Forms.CheckBox checkBox_Unknown;
    }
}

