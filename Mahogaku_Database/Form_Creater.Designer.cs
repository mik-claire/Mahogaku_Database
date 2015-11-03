namespace Mahogaku_Database
{
    partial class Form_Creater
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView_Display = new System.Windows.Forms.ListView();
            this.columnHeader_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Pixiv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Twitter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_GetData = new System.Windows.Forms.Button();
            this.button_Insert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_Display
            // 
            this.listView_Display.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Name,
            this.columnHeader_Pixiv,
            this.columnHeader_Twitter});
            this.listView_Display.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listView_Display.FullRowSelect = true;
            this.listView_Display.GridLines = true;
            this.listView_Display.Location = new System.Drawing.Point(16, 15);
            this.listView_Display.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView_Display.Name = "listView_Display";
            this.listView_Display.Size = new System.Drawing.Size(465, 296);
            this.listView_Display.TabIndex = 0;
            this.listView_Display.UseCompatibleStateImageBehavior = false;
            this.listView_Display.View = System.Windows.Forms.View.Details;
            this.listView_Display.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_Display_MouseClick);
            // 
            // columnHeader_Name
            // 
            this.columnHeader_Name.Text = "名前";
            this.columnHeader_Name.Width = 110;
            // 
            // columnHeader_Pixiv
            // 
            this.columnHeader_Pixiv.Text = "PixivID";
            this.columnHeader_Pixiv.Width = 100;
            // 
            // columnHeader_Twitter
            // 
            this.columnHeader_Twitter.Text = "TwitterID";
            this.columnHeader_Twitter.Width = 170;
            // 
            // button_GetData
            // 
            this.button_GetData.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_GetData.Location = new System.Drawing.Point(383, 320);
            this.button_GetData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_GetData.Name = "button_GetData";
            this.button_GetData.Size = new System.Drawing.Size(100, 29);
            this.button_GetData.TabIndex = 1;
            this.button_GetData.Text = "取得";
            this.button_GetData.UseVisualStyleBackColor = true;
            this.button_GetData.Click += new System.EventHandler(this.button_GetData_Click);
            // 
            // button_Insert
            // 
            this.button_Insert.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Insert.Location = new System.Drawing.Point(275, 320);
            this.button_Insert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Insert.Name = "button_Insert";
            this.button_Insert.Size = new System.Drawing.Size(100, 29);
            this.button_Insert.TabIndex = 2;
            this.button_Insert.Text = "登録";
            this.button_Insert.UseVisualStyleBackColor = true;
            this.button_Insert.Click += new System.EventHandler(this.button_Insert_Click);
            // 
            // Form_Creater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 364);
            this.Controls.Add(this.button_Insert);
            this.Controls.Add(this.button_GetData);
            this.Controls.Add(this.listView_Display);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form_Creater";
            this.Text = "Form_Creater";
            this.Load += new System.EventHandler(this.Form_Creater_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_Display;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_Pixiv;
        private System.Windows.Forms.ColumnHeader columnHeader_Twitter;
        private System.Windows.Forms.Button button_GetData;
        private System.Windows.Forms.Button button_Insert;
    }
}