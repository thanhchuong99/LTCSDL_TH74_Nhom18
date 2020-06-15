
using TraCuuDiemThiTHPTQG.BLL;
using TraCuuDiemThiTHPTQG.Common.Rsp;
using TraCuuDiemThiTHPTQG.Common.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TraCuuDiemThiTHPTQG.BLL
{
    using DAL;
    using DAL.Models;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.DependencyInjection;
    using System.Data;
    using TraCuuDiemThiTHPTQG.Common.Req;

    public class DiemSvc : GenericSvc<DiemRep, Diem>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>
        public override SingleRsp Update(Diem m)
        {
            var res = new SingleRsp();

            var m1 = m.MaDiem > 0 ? _rep.Read(m.MaDiem) : _rep.Read(m.MaDiem);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        #region -- Methods --


        /// <summary>
        /// Search SoGD
        /// </summary>
        /// <param name="id">The model</param>
        /// <returns>Return list SoGD</returns>
        public object SearchDiem(string keyword, int page, int size)
        {
            var diems = _rep.All;
            if (!string.IsNullOrEmpty(keyword))
            {
                diems = diems.Where(e => e.SoBaoDanh.Contains(keyword) || e.MaDiem.ToString().Contains(keyword) );
            }
            var offset = (page - 1) * size;
            var total = diems.Count();
            int totalPage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = diems.Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPage = totalPage,
                Page = page,
                Size = size
            };
            if (diems.Any())
            {
                return res;
            }
            return null;
        }
//       
        
        public SingleRsp CreateDiem(DiemReq d)
        {
            var res = new SingleRsp();
            Diem diem = new Diem();
            diem.MaDiem = d.MaDiem;
            diem.SoBaoDanh = d.SoBaoDanh;
            diem.MaSoGd = d.SoBaoDanh.Substring(0, 2);
            diem.DiemToan = d.DiemToan;
            diem.DiemVan = d.DiemVan;
            diem.DiemNgoaiNgu = d.DiemNgoaiNgu;
            diem.DiemHoa = d.DiemHoa;
            diem.DiemLy = d.DiemLy;
            diem.DiemSinh = d.DiemSinh;
            diem.DiemDia = d.DiemDia;
            diem.DiemSu = d.DiemSu;
            diem.DiemGdcd = d.DiemGdcd;
            res = _rep.CreateDiem(diem);
            return res;
        }
        public SingleRsp DeleteDiem(string d)
        {
            var res = new SingleRsp();
            res = _rep.DeleteDiem(d);
            return res;
        }
        public SingleRsp UpdateDiem(DiemReq d)
        {
            var res = new SingleRsp();
            Diem diem = new Diem();
            diem.MaDiem = d.MaDiem;
            diem.SoBaoDanh = d.SoBaoDanh;
            diem.MaSoGd = d.SoBaoDanh.Substring(0, 2);
            diem.DiemToan = d.DiemToan;
            diem.DiemVan = d.DiemVan;
            diem.DiemNgoaiNgu = d.DiemNgoaiNgu;
            diem.DiemHoa = d.DiemHoa;
            diem.DiemLy = d.DiemLy;
            diem.DiemSinh = d.DiemSinh;
            diem.DiemDia = d.DiemDia;
            diem.DiemSu = d.DiemSu;
            diem.DiemGdcd = d.DiemGdcd;
            res = _rep.UpdateDiem(diem);
            return res;
        }
        public object GetBySBD(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                var diems = _rep.All.FirstOrDefault(e => e.SoBaoDanh == keyword);
                var soGd = _rep.Context.SoGd.FirstOrDefault(e => e.MaSoGd == diems.MaSoGd);
                var diem = new
                {
                    diems.SoBaoDanh,
                    soGd.TenSoGd,
                    diems.DiemToan,
                    diems.DiemVan,
                    diems.DiemNgoaiNgu,
                    diems.DiemHoa,
                    diems.DiemLy,
                    diems.DiemSinh,
                    diemKHTN = Math.Round(Convert.ToDecimal((diems.DiemLy + diems.DiemHoa + diems.DiemSinh) / 3), 2),
                    diems.DiemSu,
                    diems.DiemDia,
                    diems.DiemGdcd,
                    diemKHXH = Math.Round(Convert.ToDecimal((diems.DiemSu + diems.DiemDia + diems.DiemGdcd) / 3), 2)
                };
                return diem;
            }
            return null;
        }
        public List<object> top100(string monhoc)
        {
            return _rep.top100(monhoc);
        }
        public List<object> per100(string monhoc)
        {
            return _rep.per100(monhoc);
        }
        public DiemSvc() { }


        #endregion

    }
}