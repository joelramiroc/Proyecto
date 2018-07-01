namespace ProjectSalesCore.DataBase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CSales.Database.Models;

    [Table("ASTORAGE")]
    public class AddressStorage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ADDRESSNAME")]
        public string AddressName { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [ForeignKey(nameof(Storage))]
        [Column("IDSTORAGE")]
        public int IdStorage { get; set; }

        [Column("STORAGE")]
        public virtual Storage Storage { get; set; }
    }
}
