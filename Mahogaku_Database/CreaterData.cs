using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahogaku_Database
{
	/// <summary>
	/// 親御さんのデータ
	/// </summary>
	public class CreaterData
	{
		public string Name { get; set; }

		public string PixivID { get; set; }

		public string TwitterID { get; set; }

        public string GetString()
        {
            if (TwitterID == null)
            {
                return Name + "," + PixivID;
            }

            return Name + "," + PixivID + "," + TwitterID;
        }
	}
}
