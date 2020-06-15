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

    [Route("api/[controller]")]
    [ApiController]
    public class SoGDController : ControllerBase
    {
        public SoGDController()
        {
            _svc = new SoGDSvc();
        }
        [HttpPost("search-SoGD"), Authorize]
        public IActionResult SearchSoGD([FromBody]SearchSoGDReq req)
        {
            try
            {
                var res = new SingleRsp();
                var SoGD = _svc.SearchSoGD(req.Keyword, req.Page, req.Size);
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
        private readonly SoGDSvc _svc;
    }
}