using System;
using System.Collections.Generic;
using BLL.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PiistechCourier.Auth;
using System.Web.Http.Cors;
using BLL.DTOs;

namespace PiistechCourier.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/shipper")]
    public class ShipperController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Shippers()
        {
            try
            {
                var data = ShipperService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Shipper(int id)
        {
            try
            {
                var data = ShipperService.Get(id);
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
        public HttpResponseMessage ShipperComments(int id)
        {
            try
            {
                var data = ShipperService.GetwithComments(id);
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
        public HttpResponseMessage DeleteShipper(int id)
        {
            var res = ShipperService.DeleteShipper(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        // Add a shipper
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateShipper(ShipperDTO dto)
        {
            try
            {

                var data = ShipperService.Create(dto);

                if (data != null) return Request.CreateResponse(HttpStatusCode.Created, data);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, data);

            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}