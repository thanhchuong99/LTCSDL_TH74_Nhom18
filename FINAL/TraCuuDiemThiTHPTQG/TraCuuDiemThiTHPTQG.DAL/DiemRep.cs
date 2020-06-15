using TraCuuDiemThiTHPTQG.Common.DAL;
using System.Linq;

namespace TraCuuDiemThiTHPTQG.DAL
{
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using TraCuuDiemThiTHPTQG.Common.Rsp;

    public class DiemRep : GenericRep<QL_DIEMContext, Diem>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override Diem Read(string id)
        {
            var res = All.FirstOrDefault(p => p.SoBaoDanh == id);
            return res;
        }


        /// <summary>
        /// Remove and not restore
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Number of affect</returns>
        public int Remove(int id)
        {
            var m = base.All.First(i => i.MaDiem == id);
            m = base.Delete(m); //TODO
            return m.MaDiem;
        }

        #endregion

        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        public SingleRsp CreateDiem(Diem diem)
        {
            var res = new SingleRsp();
            using (var context = new QL_DIEMContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Diem.Add(diem);
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
        public SingleRsp UpdateDiem(Diem diem)
        {
            var res = new SingleRsp();
            using (var context = new QL_DIEMContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Diem.Update(diem);
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
        public SingleRsp DeleteDiem(string diem)
        {
            var res = new SingleRsp();
            using (var context = new QL_DIEMContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        {
                            var t = context.Diem.Remove(context.Diem.FirstOrDefault(e => e.SoBaoDanh == diem));
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
        public List<object> top100(string monhoc)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "top100";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@monhoc", monhoc);
                da.SelectCommand = cmd;
                da.Fill(ds);
                int i = 1;
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            index = i++,
                            soBaoDanh = row["SoBaoDanh"].ToString(),
                            diemToan = row["DiemToan"].ToString(),
                            diemVan = row["DiemVan"].ToString(),
                            diemNgoaiNgu = row["DiemNgoaiNgu"].ToString(),
                            diemHoa = row["DiemHoa"].ToString(),
                            diemLy = row["DiemLy"].ToString(),
                            diemSinh = row["DiemSinh"].ToString(),
                            diemDia = row["DiemDia"].ToString(),
                            diemSu = row["DiemSu"].ToString(),
                            diemGdcd = row["DiemGDCD"].ToString(),
                            diemKHTN = row["Điểm KHTN"].ToString(),
                            diemKHXH = row["Điểm KHXH"].ToString(),

                        };
                        res.Add(x);
                    }
                }
            }
            catch
            {
                res = null;
            }
            return res;
        }
        public List<object> per100(string monhoc)
        {
            int[] per = new int[66];
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                var cmd = cnn.CreateCommand();
                cmd.CommandText = "top100";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@monhoc", monhoc);
                da.SelectCommand = cmd;
                da.Fill(ds);
                for (int i = 0; i < 66; i++)
                {
                    per[i] = 0;
                }
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        int ma = Convert.ToInt16(row["MaSoGD"]);
                        per[ma]++;
                    }
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        int maa = Convert.ToInt16(row["MaSoGD"]);
                        var x = new
                        {
                            soGD = row["TenSoGD"].ToString(),
                            per = per[maa],
                        }; res.Add(x);
                    }
                }
                res = res.Distinct().ToList();
            }
            catch
            {
                res = null;
            }
            return res;
        }
        #endregion
    }
}