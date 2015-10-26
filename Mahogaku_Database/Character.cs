using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Mahogaku_Database
{
    public class Character
    {
        public BsonObjectId Id { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public string Type { get; set; }

        public string Skill { get; set; }

        public string Remarks { get; set; }

        public string[] Convert(Character doc)
        {
            string[] record = 
            {
                Name,
                Sex,
                Type,
                Skill,
                Remarks
            };
            return record;
        }
    }
}
