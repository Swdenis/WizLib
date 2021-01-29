using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizLib_Models.Models
{
    public class FluentBook
    {
        public FluentBook()
        {
        }
      
        public int Book_Id { get; set; }

        
        public string Title { get; set; }

        public string ISBN { get; set; }

        public double Price { get; set; }

        public int BookDetail_Id { get; set; }

        public FluentBookDetail FluentBookDetail { get; set; }

        public int Publisher_IdBook { get; set; }

        public FluentPublisher FluentPublisher { get; set; }

        public ICollection<FluentBookAuthor> FluentBookAuthors { get; set; }

    }
}
