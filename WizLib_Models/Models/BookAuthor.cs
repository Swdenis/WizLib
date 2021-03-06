﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizLib_Models.Models
{
    public class BookAuthor
    {
        public BookAuthor()
        {
        }
        [ForeignKey("Book")]
        public int Book_Id { get; set; }

        [ForeignKey("Author")]
        public int Author_Id { get; set; }

        public Book Book { get; set; }

        public Author Author { get; set; }

        
    }
}
