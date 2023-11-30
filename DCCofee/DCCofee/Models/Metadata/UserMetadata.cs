using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class UserMetadata
    {
        [DisplayName("Mã Người Dùng")]
        public int Id { get; set; }
        [DisplayName("Họ tên")]
        public string HoTen { get; set; }
        [DisplayName("Ngày sinh")]
        public Nullable<System.DateTime> NgaySinh { get; set; }
        [DisplayName("Giới tính")]
        public Nullable<int> GioiTinh { get; set; }
        [DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }
        [DisplayName("Số điện thoại")]
        public string Sdt { get; set; }
        [DisplayName("Vai Trò")]
        public Nullable<int> VaiTro { get; set; }
        [DisplayName("Tài Khoản")]
        [Required(ErrorMessage = " Tài khoản không được để trống")]
        public string TaiKhoan { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = " Mật khẩu không được để trống")]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DONHANG> DONHANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUXUAT> PHIEUXUAT { get; set; }
    }
}