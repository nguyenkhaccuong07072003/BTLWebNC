using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class HangHoaMetadata
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Tên hàng")]
        public string TenH { get; set; }
        [DisplayName("Số lượng")]
        public Nullable<int> SoLuong { get; set; }
        [DisplayName("Hạn sử dụng")]
        public Nullable<System.DateTime> HSD { get; set; }
        [DisplayName("Đơn vị tính")]
        public string DonViTinh { get; set; }
        [DisplayName("Đơn giá")]
        public Nullable<double> DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPN> CTPN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPX> CTPX { get; set; }
    }
}