using System;
using System.ComponentModel.DataAnnotations;

namespace WizLib_Models.Models
{
    public class BookDetail
    {
        public BookDetail()
        {
        }
        [Key]
        public int BookDetail_Id { get; set; }

        [Required]
        public int NumberOfChapters { get; set; }

        public int NumberOfPages { get; set; }

        public double Weight { get; set; }

        public Book Book { get; set; }

    }
}
