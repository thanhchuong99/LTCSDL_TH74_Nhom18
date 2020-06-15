using System;
using System.Collections.Generic;
using System.Text;
using TraCuuDiemThiTHPTQG.Common.BLL;
using TraCuuDiemThiTHPTQG.Common.Rsp;
using TraCuuDiemThiTHPTQG.DAL;
using TraCuuDiemThiTHPTQG.DAL.Models;

namespace TraCuuDiemThiTHPTQG.BLL
{
    public class UserInfoSvc : GenericSvc<TokenRep, UserInfo>

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
        public override SingleRsp Update(UserInfo m)
        {
            var res = new SingleRsp();

            var m1 = m.UserName != null ? _rep.Read(m.UserName) : _rep.Read(m.UserName);
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
    }
}
