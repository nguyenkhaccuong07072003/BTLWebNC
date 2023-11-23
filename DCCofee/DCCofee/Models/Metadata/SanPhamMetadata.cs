using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class SanPhamMetadata
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        [Required(ErrorMessage = " Vui lòng nhập tên sản phẩm")]
        public string TenSP { get; set; }
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = " Vui lòng nhập mô tả")]
        public string Mota { get; set; }
        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = " Vui lòng nhập đơn giá")]
        public Nullable<double> DonGia { get; set; }
        [DisplayName("Ảnh sản phẩm")]
/*        [Required(ErrorMessage = " Vui lòng nhập ảnh sản phẩm")]*/
        public string AnhSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDH { get; set; }
    }
}