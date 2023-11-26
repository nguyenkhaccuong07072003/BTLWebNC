using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class CTPNMetadata
    {
        [DisplayName("Mã Chi Tiết Phiếu Nhập")]
        public int Id { get; set; }
        [DisplayName("ID phiếu nhập")]
        public Nullable<int> IdPN { get; set; }
        [Required(ErrorMessage = " Vui lòng chọn hàng cần nhập")]
        public Nullable<int> IdH { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = " Vui lòng nhập số lượng")]
        public Nullable<int> SoLuong { get; set; }

        public virtual HangHoa HangHoa { get; set; }
        public virtual PHIEUNHAP PHIEUNHAP { get; set; }
    }
}