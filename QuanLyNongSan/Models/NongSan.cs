namespace QuanLyNongSan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NongSan")]
    public partial class NongSan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NongSan()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        [Required]
        [Display(Name = "Mã loại nông sản")]
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [Display(Name = "Tên nông sản")]
        [StringLength(50)]
        public string TenNS { get; set; }

        [Display(Name = "Loại nông sản")]
        public int IDLoaiNS { get; set; }

        [StringLength(550)]
        [Display(Name = "Mô tả ngắn")]
        public string MoTaNgan { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Bài viết chi tiết")]
        public string MotaChiTiet { get; set; }


        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime NgayTao { get; set; }

        [Required]
        [Display(Name = "Người tạo")]
        [StringLength(50)]
        public string NguoiTao { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày cập nhật")]
        public DateTime? NgayCapNhat { get; set; }

        [StringLength(50)]
        [Display(Name = "Người cập nhật")]
        public string NguoiCapNhat { get; set; }

        [StringLength(350)]
        [Display(Name = "Ảnh đại diện")]
        public string HinhAnhDaiDien { get; set; }
        [Display(Name = "Giá")]
        [DisplayFormat(DataFormatString = "{0:n0}", ApplyFormatInEditMode = true)]
        [StringLength(50)]
        public string Price { get; set; }

        public virtual LoaiN LoaiN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
