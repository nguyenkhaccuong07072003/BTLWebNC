using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class CTDHMetadata
    {
        [DisplayName("Mã Chi Tiết Đơn Hàng")]
        public int Id { get; set; }
        public Nullable<int> IdDH { get; set; }
        [Required(ErrorMessage = " Vui lòng chọn sản phẩm")]
        public Nullable<int> IdSP { get; set; }
        [DisplayName("Số lượng")]
        [Required(ErrorMessage = " Vui lòng nhập số lượng")]
        public Nullable<int> SoLuong { get; set; }
        [DisplayName("Mô tả")]
        [Required(ErrorMessage = " Vui lòng nhập mô tả")]
        public string MoTa { get; set; }
        [DisplayName("Giá tiền")]
        [Required(ErrorMessage = " Vui lòng nhập giá tiền")]
        public Nullable<double> GiaTien { get; set; }

        public virtual DONHANG DONHANG { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}