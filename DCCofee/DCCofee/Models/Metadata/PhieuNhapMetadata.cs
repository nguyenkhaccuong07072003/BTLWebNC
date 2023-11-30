using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class PhieuNhapMetadata
    {
        [DisplayName("Mã Phiếu Nhập")]
        public int Id { get; set; }
        [Required(ErrorMessage = " Vui lòng chọn nhà cung cấp")]
        public Nullable<int> IdNCC { get; set; }
        [Required(ErrorMessage = " Vui lòng nhập tên nhân viên")]
        public Nullable<int> IdNV { get; set; }
        [DisplayName("Ngày Nhập")]
        [Required(ErrorMessage = " Vui lòng nhập ngày nhập")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> NgayNhap { get; set; } = DateTime.Now;
        [DisplayName("Tổng tiền")]
        public Nullable<double> TongTien { get; set; } = 0;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPN> CTPN { get; set; }
        public virtual NCC NCC { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}