using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Model
{
    public class Currency
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("version")]
        public int? Version { get; set; }

        [Column("code")]
        [Required]
        public string Code { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("is_disabled")]
        public bool Disabled { get; set; }

        [Column("decimal_digits")]
        public int DecimalDigits { get; set; }

        [Column("uid")]
        public string UID { get; set; }

        [Column("sort_order")]
        public int SortOrder { get; set; }
    }

    public class CurrencyDTO
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int DecimalDigits { get; set; }
    }
}