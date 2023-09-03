using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PiistechCourier.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/receiver")]
    public class ReceiverController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Receivers()
        {
            try
            {
                var data = ReceiverService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Receiver(int id)
        {
            try
            {
                var data = ReceiverService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //[Logged]
        /* [HttpGet]
        [Route("api/receivers/{id}/comments")]
        public HttpResponseMessage ReceiverComments(int id)
        {
            try
            {
                var data = ReceiverService.GetwithComments(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        } */

        //[AdminAccess]
        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteReceiver(int id)
        {
            var res = ReceiverService.DeleteReceiver(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        // Add a receiver
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateReceiver(ReceiverDTO dto)
        {
            try
            {

                var data = ReceiverService.Create(dto);

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