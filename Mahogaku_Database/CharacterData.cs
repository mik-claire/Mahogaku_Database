using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		/// ID
		/// </summary>
		public string ID { get; set; }

		/// <summary>
		/// 属性
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
        /// 部活
        /// </summary>
        public string Club { get; set; }

        /// <summary>
        /// 組織
        /// </summary>
        public string Organization { get; set; }

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
    }
}
