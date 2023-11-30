using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class DonHangMetadata
    {
        [DisplayName("Mã Đơn Hàng")]
        public int Id { get; set; }
        [Required(ErrorMessage = " Vui lòng chọn nhân viên")]
        public Nullable<int> IdNV { get; set; }
        [DisplayName("Ngày đặt")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> NgayDat { get; set; }
        [DisplayName("Trạng thái")]
        public Nullable<int> TrangThai { get; set; }
        [DisplayName("Tổng tiền")]
        public Nullable<double> TongTien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDH> CTDH { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}