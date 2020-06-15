    using TraCuuDiemThiTHPTQG.Common.DAL;
using System.Linq;

namespace TraCuuDiemThiTHPTQG.DAL
{
    using Models;
    using System;
    using TraCuuDiemThiTHPTQG.Common.Rsp;

    public class ThiSinhRep: GenericRep<QL_DIEMContext,ThiSinh>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override ThiSinh Read(string id)
        {
            var res = All.FirstOrDefault(p => p.SoBaoDanh == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public string Remove(string id)
        {
            var m = base.All.First(i => i.SoBaoDanh == id);
            m = base.Delete(m); //TODO
            return m.SoBaoDanh;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SingleRsp CreateThiSinh(ThiSinh ts)
        {
            var res = new SingleRsp();
            using(var context = new QL_DIEMContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.ThiSinh.Add(ts);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateThiSinh(ThiSinh ts)
        {
            var res = new SingleRsp();
            using (var context = new QL_DIEMContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.ThiSinh.Update(ts);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteThiSinh(string id)
        {
            var res = new SingleRsp();
            using (var context = new QL_DIEMContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        {
                            var t = context.ThiSinh.Remove(context.ThiSinh.FirstOrDefault(e => e.SoBaoDanh == id));
                            context.SaveChanges();
                            tran.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
        #endregion
    }
}