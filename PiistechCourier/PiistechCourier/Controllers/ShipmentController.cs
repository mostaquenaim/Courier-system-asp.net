using System;
using System.Collections.Generic;
using BLL.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTOs;
using System.Web.Http.Cors;
using PiistechCourier.Auth;

namespace PiistechCourier.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/shipment")]
    public class ShipmentController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Shipments()
        {
            try
            {
                var data = ShipmentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
      /*  [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Shipment(string id)
        {
            try
            {
                var data = ShipmentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        } */
       

        [HttpGet]
        [Route("track/{trackingToken}")]
        public HttpResponseMessage Get(string trackingToken)
        {
            try
            {
                var data = ShipmentService.Get(trackingToken);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //[Logged]
        /* [HttpGet]
        [Route("api/shipments/{id}/comments")]
        public HttpResponseMessage ShipmentComments(int id)
        {
            try
            {
                var data = ShipmentService.GetwithComments(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        } */

        [AdminAccess]
        [HttpDelete]
        [Route("delete/{trackingToken}")]
        public HttpResponseMessage DeleteShipment(string trackingToken)
        {
            var res = ShipmentService.DeleteShipment(trackingToken);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        // Add a shipment
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateShipment(ShipmentDTO dto)
        {
            try
            {
                dto.TrackingToken = Guid.NewGuid().ToString();
                dto.CreatedAt = DateTime.Now;
                dto.StatusId = 1;

                var data = ShipmentService.Create(dto);

                if (data != null) return Request.CreateResponse(HttpStatusCode.Created, data);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, data);

            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // Update a shipment
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateShipment(ShipmentDTO dto)
        {
            try
            {
                var data = ShipmentService.Update(dto);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }

                return Request.CreateResponse(HttpStatusCode.InternalServerError, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}