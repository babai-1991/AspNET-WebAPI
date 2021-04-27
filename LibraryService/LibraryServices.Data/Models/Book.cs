using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryServices.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
        public string CallNumber { get; set; }

        [ForeignKey("Cost")]
        //book may or may not have a cost related to it. so nullable
        public int? CostId { get; set; }
        //navigation property
        public virtual Cost Cost  { get; set; }

    }
}