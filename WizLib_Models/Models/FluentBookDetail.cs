using System;
using System.ComponentModel.DataAnnotations;

namespace WizLib_Models.Models
{
    public class FluentBookDetail
    {
        public FluentBookDetail()
        {
        }
        
        public int BookDetail_Id { get; set; }

        
        public int NumberOfChapters { get; set; }

        public int NumberOfPages { get; set; }

        public double Weight { get; set; }

        public FluentBook FluentBook { get; set; }

    }
}
