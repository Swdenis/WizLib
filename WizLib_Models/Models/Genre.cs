using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WizLib_Models.Models
{
    [Table("tb_Genre")]
    public class Genre
    {   
        public Genre()
        {
        }

        [Column("Name")]
        public int GenreName { get; set; }

        public int Id { get; set; }

        //public int DisplayOrder { get; set; }

    }
}
