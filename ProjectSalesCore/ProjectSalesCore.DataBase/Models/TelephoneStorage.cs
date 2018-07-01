namespace ProjectSalesCore.DataBase.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CSales.Database.Models;

    [Table("TELSTORAGE")]
    class TelephoneStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NUMBER")]
        public string Number { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [ForeignKey(nameof(Storage))]
        [Column("IDSTR")]
        public int IdSTR { get; set; }

        [Column("STR")]
        public virtual Storage Storage { get; set; }
    }
}
