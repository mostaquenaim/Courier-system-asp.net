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
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Customers()
        {
            try
            {
                var data = CustomerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Customer(int id)
        {
            try
            {
                var data = CustomerService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        }

        //[Logged]
        /* [HttpGet]
        [Route("api/customers/{id}/comments")]
        public HttpResponseMessage CustomerComments(int id)
        {
            try
            {
                var data = CustomerService.GetwithComments(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = ex.Message });
            }
        } */

        //[AdminAccess]
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            var res = CustomerService.DeleteCustomer(id);
            return Request.CreateResponse(HttpStatusCode.OK, res);

        }

        // Add a customer
        [HttpPost]
        [Route("create")]
        public HttpResponseMessage CreateCustomer(CustomerDTO dto)
        {
            try
            {
                
                var data = CustomerService.Create(dto);

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