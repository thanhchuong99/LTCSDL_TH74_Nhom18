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
    using Microsoft.OpenApi.Any;
    using System.Linq.Expressions;
    using Microsoft.CodeAnalysis;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ThiSinhController : ControllerBase
    {
        public ThiSinhController()
        {
            _svc = new ThiSinhSvc();
        }
        [HttpPost("search-ThiSinh")]
        public IActionResult SearchTS([FromBody]SearchThiSinhReq req)
        {
            try
            {
                var res = new SingleRsp();
                var SoGD = _svc.SearchTS(req.Keyword, req.Page, req.Size);
                if (!(SoGD is null))
                {
                    res.Data = SoGD;
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [HttpPost("Create-ThiSinh")]
        public IActionResult CreateThiSinh([FromBody]ThiSinhReq req)
        {
            var res = _svc.CreateThiSinh(req);
            return Ok(res);
        }
        [HttpPost("Update-ThiSinh")]
        public IActionResult UpdateThiSinh([FromBody]ThiSinhReq req)
        {
            var res = _svc.UpdateThiSinh(req);
            return Ok(res);
        }
        [HttpPost("Delete-ThiSinh")]
        public IActionResult DeleteThiSinh([FromBody]SimpleReq req)
        {
            var res = _svc.DeleteThiSinh(req.Keyword);
            return Ok(res);
        }
        private readonly ThiSinhSvc _svc;
    }
}