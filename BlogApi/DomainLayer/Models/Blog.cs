using DomainLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.DomainLayer.Models
{
    public class Blog : BaseModel
    {
        public string Post { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public string AuthorId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public string CategoryId { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }
        public string CommentId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
