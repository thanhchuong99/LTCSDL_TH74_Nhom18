
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
    using TraCuuDiemThiTHPTQG.Common.Req;

    public class ThiSinhSvc : GenericSvc<ThiSinhRep, ThiSinh>
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
        public override SingleRsp Update(ThiSinh m)
        {
            var res = new SingleRsp();

            var m1 = m.SoBaoDanh != null ? _rep.Read(m.SoBaoDanh) : _rep.Read(m.SoBaoDanh);
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
        public object SearchTS(string keyword, int page, int size)
        {
            var SoGDs = _rep.All;
            if (!string.IsNullOrEmpty(keyword))
            {
                SoGDs = SoGDs.Where(e => e.SoBaoDanh.Substring(0,2) == keyword || e.Ho.Contains(keyword) || e.Ten.Contains(keyword));
            }
            var offset = (page - 1) * size;
            var total = SoGDs.Count();
            int totalPage = (total % size) == 0 ? (total / size) : (int)((total / size) + 1);
            var data = SoGDs.Skip(offset).Take(size).ToList();
            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPage = totalPage,
                Page = page,
                Size = size
            };
            if (SoGDs.Any())
            {
                return res;
            }
            return null;
        }
        public SingleRsp CreateThiSinh(ThiSinhReq ts)
        {
            var res = new SingleRsp();
            ThiSinh thisinh = new ThiSinh();
            thisinh.SoBaoDanh = ts.SoBaoDanh;
            thisinh.Ho = ts.Ho;
            thisinh.Ten = ts.Ten;
            thisinh.NgaySinh = ts.NgaySinh;
            thisinh.GioiTinh = ts.GioiTinh;
            thisinh.KhoiThi = ts.KhoiThi;
            thisinh.QueQuan = ts.QueQuan;
            res = _rep.CreateThiSinh(thisinh);
            res.Data = thisinh;
            return res;
        }
        public SingleRsp UpdateThiSinh(ThiSinhReq ts)
        {
            var res = new SingleRsp();
            ThiSinh thisinh = new ThiSinh();
            thisinh.SoBaoDanh = ts.SoBaoDanh;
            thisinh.Ho = ts.Ho;
            thisinh.Ten = ts.Ten;
            thisinh.NgaySinh = ts.NgaySinh;
            thisinh.GioiTinh = ts.GioiTinh;
            thisinh.KhoiThi = ts.KhoiThi;
            thisinh.QueQuan = ts.QueQuan;
            res = _rep.UpdateThiSinh(thisinh);
            res.Data = thisinh;
            return res;
        }
        public SingleRsp DeleteThiSinh(string id)
        {
            var res = new SingleRsp();
            res = _rep.DeleteThiSinh(id);
            return res;
        }
        public ThiSinhSvc() { }


        #endregion

    }
}