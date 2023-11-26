using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class NCCMetadata
    {
        [DisplayName("Mã Nhà Cung Cấp")]
        public int Id { get; set; }
        [DisplayName("Tên nhà cung cấp")]
        [Required(ErrorMessage = " Vui lòng nhập tên nhà cung cấp")]
        public string TenNCC { get; set; }
        [DisplayName("Địa chỉ")]
        [Required(ErrorMessage = " Vui lòng nhập địa chỉ")]
        [StringLength(50, ErrorMessage = "Địa chỉ quá dài, vui lòng nhập không quá 50 ký tự")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Sdt { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = " Vui lòng nhập email")]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAP { get; set; }
    }


}