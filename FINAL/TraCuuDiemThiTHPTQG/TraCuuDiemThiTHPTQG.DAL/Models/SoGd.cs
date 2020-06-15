using System;
using System.Collections.Generic;

namespace TraCuuDiemThiTHPTQG.DAL.Models
{
    public partial class SoGd
    {
        public SoGd()
        {
            Diem = new HashSet<Diem>();
        }

        public string MaSoGd { get; set; }
        public string TenSoGd { get; set; }

        public virtual ICollection<Diem> Diem { get; set; }
    }
}
