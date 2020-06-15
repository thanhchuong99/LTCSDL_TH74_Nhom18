using TraCuuDiemThiTHPTQG.Common.DAL;
using System.Linq;

namespace TraCuuDiemThiTHPTQG.DAL
{
    using Models;
    public class TokenRep : GenericRep<QL_DIEMContext, UserInfo>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override UserInfo Read(string id)
        {
            var res = All.FirstOrDefault(p => p.UserName == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public string Remove(string id)
        {
            var m = base.All.First(i => i.UserName == id);
            m = base.Delete(m); //TODO
            return m.UserName;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>

        #endregion
    }
}