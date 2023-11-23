using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class SanPhamMetadata
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }
        [DisplayName("Mô tả")]
        public string Mota { get; set; }
        [DisplayName("Đơn giá")]
        public Nullable<double> DonGia { get; set; }
        [DisplayName("Ảnh sản phẩm")]
        public string AnhSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDH { get; set; }
    }
}