using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TraCuuDiemThiTHPTQG.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using System.Collections.Generic;
    //using BLL.Req;
    using Common.Rsp;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Data.SqlClient;
    using System.Data;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using Microsoft.AspNetCore.Authorization;

   
    [Route("api/[controller]")]
    [ApiController]
    public class DiemController : ControllerBase
    {
        public DiemController()
        {
            _svc = new DiemSvc();
        }
        [HttpPost("top100")]
        public IActionResult top100([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.top100(req.Keyword).ToList() ;
            return Ok(res);
        }
        [HttpPost("per100")]
        public IActionResult per100([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.per100(req.Keyword).ToList();
            return Ok(res);
        }
        [Authorize]
        [HttpPost("search-Diem")]
        public IActionResult SearchDiem([FromBody]SearchDiemReq req)
        {
            try
            {
                var res = new SingleRsp();
                var Diem = _svc.SearchDiem(req.Keyword, req.Page, req.Size);
                if (!(Diem is null))
                {
                    res.Data = Diem;
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [Authorize]
        [HttpPost("Create-Diem")]
        public IActionResult CreateDiem([FromBody]DiemReq req)
        {
                var res = _svc.CreateDiem(req);
                return Ok(res);
        }
        [Authorize]
        [HttpPost("Update-Diem")]
        public IActionResult UpdateDiem([FromBody]DiemReq req)
        {
            var res = _svc.UpdateDiem(req);
            return Ok(res);
        }
        [Authorize]
        [HttpPost("Delete-Diem")]
        public IActionResult DeleteDiem([FromBody]SimpleReq req)
        {
            var res = _svc.DeleteDiem(req.Keyword);
            return Ok(res);
        }
        [HttpPost("get-Diem-by-SBD")]
        public IActionResult getDiembySBD([FromBody]SimpleReq req)
        {
            try
            {
                var res = new SingleRsp();
                var diem = _svc.GetBySBD(req.Keyword);
                if (!(diem is null))
                {
                    res.Data = diem;
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        private readonly DiemSvc _svc;
    }
}