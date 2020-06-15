using System;
using System.Collections.Generic;
using System.Text;

namespace TraCuuDiemThiTHPTQG.Common.Req
{
    public class SearchDiemReq
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Keyword { get; set; }

    }
}
