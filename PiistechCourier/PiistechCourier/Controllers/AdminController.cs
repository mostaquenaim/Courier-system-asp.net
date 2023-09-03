using System;
using System.Collections.Generic;
using BLL.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PiistechCourier.Auth;
using System.Web.Http.Cors;

namespace PiistechCourier.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Admins()
        {
            try
            {
                var data = AdminService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Admin(int id)
        {
            try
            {
                var data = AdminService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //[Logged]
        /* [HttpGet]
        [Route("api/shippers/{id}/comments")]
        public HttpResponseMessage AdminComments(int id)
        {
            try
            {
                var data = AdminService.GetwithComments(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        } */

        [AdminAccess]
        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteAdmin(int id)
        {
            var res = AdminService.DeleteAdmin(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}