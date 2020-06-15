using System;
using System.Collections.Generic;

namespace TraCuuDiemThiTHPTQG.DAL.Models
{
    public partial class Diem
    {
        public int MaDiem { get; set; }
        public string MaSoGd { get; set; }
        public string SoBaoDanh { get; set; }
        public decimal? DiemToan { get; set; }
        public decimal? DiemVan { get; set; }
        public decimal? DiemNgoaiNgu { get; set; }
        public decimal? DiemHoa { get; set; }
        public decimal? DiemLy { get; set; }
        public decimal? DiemSinh { get; set; }
        public decimal? DiemDia { get; set; }
        public decimal? DiemSu { get; set; }
        public decimal? DiemGdcd { get; set; }

        public virtual SoGd MaSoGdNavigation { get; set; }
        public virtual ThiSinh SoBaoDanhNavigation { get; set; }
    }
}
