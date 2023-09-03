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
    [RoutePrefix("api/status")]
    public class StatusController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Statuses()
        {
            try
            {
                var data = StatusService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Status(int id)
        {
            try
            {
                var data = StatusService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //[Logged]
        /* [HttpGet]
        [Route("api/statuses/{id}/comments")]
        public HttpResponseMessage StatusComments(int id)
        {
            try
            {
                var data = StatusService.GetwithComments(id);
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
        public HttpResponseMessage DeleteStatus(int id)
        {
            var res = StatusService.DeleteStatus(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }
    }
}