namespace QuanLyNongSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string OrderID { get; set; }

        public int? Quantity { get; set; }

        [StringLength(50)]
        public string ThanhTien { get; set; }

        public virtual NongSan NongSan { get; set; }

        public virtual Order Order { get; set; }
    }
}
