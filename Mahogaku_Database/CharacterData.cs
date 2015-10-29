using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mahogaku_Database
{
	/// <summary>
	/// キャラクターデータ
	/// DBのフィールド名はこれと同じものにすること
	/// </summary>
    public class CharacterData
    {
		// TODO: クラスにあってDBにないフィールド

		/// <summary>
		/// オブジェクトID（使わないんじゃね）
		/// </summary>
		public BsonObjectId id { get; set; }

		/// <summary>
		/// 属性
		/// int にするかも
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// 名前
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 読み仮名
		/// </summary>
		public string Kana { get; set; }

		/// <summary>
		/// 性別
		/// </summary>
		public string Sex { get; set; }

		/// <summary>
		/// 種族
		/// </summary>
		public string Race { get; set; }

		/// <summary>
		/// 年齢
		/// </summary>
		public string Age { get; set; }

		/// <summary>
		/// 学年
		/// </summary>
		public string Grade { get; set; }

		/// <summary>
		/// 魔砲
		/// </summary>
		public string Skill { get; set; }

		/// <summary>
		/// 「,」区切りのフリータグ
		/// </summary>
		public AffiliationsData Affiliation { get; set; }

		/// <summary>
		/// 備考
		/// </summary>
		public string Remarks { get; set; }

		/// <summary>
		/// 親御さん
		/// </summary>
		public CreaterData Creater { get; set; }

		/// <summary>
		/// PixivへのURL
		/// 「,」区切りで複数設定可能
		/// </summary>
		public string URLToPixiv { get; set; }

		public string[] ConvertToArray()
		{
			string[] record = new string[14];

            string[] affiliation = new string[2];
            if (Affiliation != null)
            {
                affiliation = Affiliation.getStringArray();
            }

            string creater = Creater.GetString();

            record[0] = Type;
            record[1] = Name;
            record[2] = Kana;
            record[3] = Sex;
            record[4] = Race;
            record[5] = Age;
            record[6] = Grade;
            record[7] = Skill;
            record[8] = affiliation[0];
            record[9] = affiliation[1];
            record[10] = Remarks;
            record[11] = creater;
            record[12] = URLToPixiv;
            record[13] = id.ToString();

			return record;
		}
    }
}
