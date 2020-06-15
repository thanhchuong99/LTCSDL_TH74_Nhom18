
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
    public class SoGDSvc : GenericSvc<SoGDRep, SoGd>
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
        public override SingleRsp Update(SoGd m)
        {
            var res = new SingleRsp();

            var m1 = m.MaSoGd != null ? _rep.Read(m.MaSoGd) : _rep.Read(m.MaSoGd);
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
        public object SearchSoGD(string keyword, int page, int size)
        {
            var SoGDs = _rep.All;
            if (!string.IsNullOrEmpty(keyword))
            {
                SoGDs = SoGDs.Where(e => e.TenSoGd.Contains(keyword) || e.MaSoGd.Contains(keyword));
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
        /// <summary>
        /// get SoGD
        /// </summary>
        /// <param name="id">The model</param>
        /// <returns>Return list SoGD</returns>
        public SoGDSvc() { }


        #endregion

    }
}