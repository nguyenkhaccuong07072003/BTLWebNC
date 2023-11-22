using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DCCofee.Models.Metadata
{
    [MetadataTypeAttribute(typeof(NCCMetadata))]
    public partial class NCCMetada
    {
        internal class NCCMetadata
        {
            public int Id { get; set; }
            [DisplayName("Tên nhà cung cấp")]
            [Required(ErrorMessage = "{0} Hãy nhập tên nhà cung cấp")]
            public string TenNCC { get; set; }

            public string DiaChi { get; set; }
            public string Sdt { get; set; }
            public string Email { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<PHIEUNHAP> PHIEUNHAP { get; set; }
        }
    }


}