using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Mahogaku_Database
{
	/// <summary>
	/// 所属
    /// </summary>
    [BsonIgnoreExtraElements]
	public class AffiliationsData
	{
		/// <summary>
		/// 部活
		/// </summary>
		public string Club { get; set; }

		/// <summary>
		/// 組織
		/// </summary>
		public string Organization { get; set; }

        public string[] getStringArray()
        {
            if (Club == null &&
                Organization == null)
            {
                return new string[] { string.Empty, string.Empty };
            }

            if (Club == null)
            {
                return new string[] { string.Empty, Organization };
            }

            if (Organization == null)
            {
                return new string[] { Club, string.Empty };
            }

            return new string[] { Club, Organization };
        }
	}
}
