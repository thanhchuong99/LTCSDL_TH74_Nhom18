using System;
using System.Collections.Generic;

namespace TraCuuDiemThiTHPTQG.DAL.Models
{
    public partial class AnhThiSinh
    {
        public int Id { get; set; }
        public string SoBaoDanh { get; set; }
        public string Url { get; set; }

        public virtual ThiSinh SoBaoDanhNavigation { get; set; }
    }
}
