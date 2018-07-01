namespace CSales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("EMAIL")]

    public class Email
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IDEMAIL")]
        public int IdEmail { get; set; }

        [Column("EMAILL")]
        public string Emaill { get; set; }
    }
}
