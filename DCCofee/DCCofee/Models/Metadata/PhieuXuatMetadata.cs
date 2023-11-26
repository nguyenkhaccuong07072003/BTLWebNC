using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    public class PhieuXuatMetadata
    {
        [DisplayName("Mã Phiếu Xuất")]
        public int Id { get; set; }
        public Nullable<int> IdNV { get; set; }
        [DisplayName("Ngày Xuất")]
        [Required(ErrorMessage = " Vui lòng nhập ngày xuất")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> NgayXuat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPX> CTPX { get; set; }
        public virtual NguoiDung NguoiDung { get; set; }
    }
}