using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class HangHoaMetadata
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Tên hàng")]
        [Required(ErrorMessage = " Vui lòng nhập tên hàng hóa")]
        public string TenH { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = " Vui lòng nhập số lượng")]
        public Nullable<int> SoLuong { get; set; }
        [DisplayName("Hạn sử dụng")]
        [Required(ErrorMessage = " Vui lòng nhập hạn sử dụng")]
        public Nullable<System.DateTime> HSD { get; set; }
        [DisplayName("Đơn vị tính")]
        [Required(ErrorMessage = " Vui lòng nhập đơn vị tính")]
        public string DonViTinh { get; set; }
        [DisplayName("Đơn giá")]
        [Required(ErrorMessage = " Vui lòng nhập đơn giá")]
        public Nullable<double> DonGia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPN> CTPN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPX> CTPX { get; set; }
    }
}