using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core;
using Infrastructure.TaxiServices.Models;

namespace Infrastructure.TaxiServices.Controllers
{
    public class ServiceRequestsController : ApiController
    {
        private List<ServiceRequest> _serviceQueue;

        public ServiceRequestsController()
        {
            // No session in WebApi without jumping through hoops
            //_serviceQueue = WebApiApplication["_serviceQueue"];

            _serviceQueue = new List<ServiceRequest>();
            _serviceQueue.Add(new ServiceRequest("222-222-2222", "Downtown 7-11"));
            _serviceQueue.Add(new ServiceRequest("555-222-5555", "Downtown Dry Cleaners"));
            _serviceQueue.Add(new ServiceRequest("888-222-8888", "Downtown Butcher Shop"));

            //WebApiApplication["_serviceQueue"] = _serviceQueue;
        }

        // GET api/servicerequest
//        public IEnumerable<string> Get()
        public IList<ServiceRequest> Get()
        {
            return _serviceQueue;
        }

        // GET api/servicerequest/5
        public ServiceRequest Get(Guid id)
        {
            return _serviceQueue.Find(x=>x.Id==id);
        }

        // POST api/servicerequest
//        public Guid Post(RequestServiceRequest request)
        public HttpResponseMessage Post(HttpRequestMessage httpRequest, RequestServiceRequest request)
        {
            var serviceRequest = new ServiceRequest(request.PhoneNumber, request.Location);
            var responseMessage = new ResponseServiceRequest() { Id = serviceRequest.Id };

            if (null == serviceRequest)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            return httpRequest.CreateResponse(HttpStatusCode.Created, serviceRequest);
        }

        // PUT api/servicerequest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/servicerequest/5
        public void Delete(Guid id)
        {
            _serviceQueue.Find(x => x.Id == id).Cancel();
        }
    }
}
