using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeiDream.SbsAbp.Web.Model.TokenAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeiDream.SbsAbp.Web.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenAuthController : SbsAbpControllerBase
    {
        //[HttpPost]
        public async Task<AuthenticateResultModel> Authenticate(AuthenticateModel model)
        {
            return new AuthenticateResultModel();
        }
}
}