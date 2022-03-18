using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuggestionAppLibrary.Models
{

    public class SuggestionModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Suggestion { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public BasicUserModel Author { get; set; }
        public string OwnerNotes { get; set; }
        public bool ApprovedForRelease { get; set; } = false;
        public bool Archived { get; set; } = false;
        public bool Rejected { get; set; } = false;
        public CategoryModel Category { get; set; }
        public StatusModel SuggestionStatus { get; set; }
        public HashSet<string> UserVotes { get; set; } = new();


    }

}
