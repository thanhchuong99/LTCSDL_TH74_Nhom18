using System;
using System.Collections.Generic;

namespace TraCuuDiemThiTHPTQG.DAL.Models
{
    public partial class ThiSinh
    {
        public ThiSinh()
        {
            AnhThiSinh = new HashSet<AnhThiSinh>();
            Diem = new HashSet<Diem>();
        }

        public string SoBaoDanh { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public string GioiTinh { get; set; }
        public string KhoiThi { get; set; }

        public virtual ICollection<AnhThiSinh> AnhThiSinh { get; set; }
        public virtual ICollection<Diem> Diem { get; set; }
    }
}
