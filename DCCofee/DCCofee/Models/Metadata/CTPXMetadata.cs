using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class CTPXMetadata
    {
        [DisplayName("Mã Chi Tiết Phiếu Xuất")]
        public int Id { get; set; }
        public Nullable<int> IdPX { get; set; }
        [Required(ErrorMessage = " Vui lòng chọn hàng hóa cần xuất")]
        public Nullable<int> IdH { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = " Vui lòng nhập số lượng")]
        public Nullable<int> SoLuong { get; set; }

        public virtual HangHoa HangHoa { get; set; }
        public virtual PHIEUXUAT PHIEUXUAT { get; set; }
    }
}