using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharedClass;
using System.Net.Http.Headers;
using System.Text;

namespace RESTpractice.Controllers
{
    public class MyServiceController : ApiController
    {
        [HttpGet]
        [Route("api/myclass")]
        public IEnumerable<string> Read()
        {
            string[] mystring = new string[] { "one" };
            return mystring;
        }

        [HttpPut]
        [Route("api/myclass")]
        public IHttpActionResult Update([FromBody]string str)
        {
            Customer customer = new Customer { FirstName = "Kazeem", LastName = "Odukale", DOB = new DateTime(2000, 10, 10) };
            return Ok(customer);
        }

        [HttpPost]
        [Route("api/myclass/{str}")]
        public HttpResponseMessage Create([FromBody]string str)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue() { MaxAge = TimeSpan.FromMinutes(20) };
            return response;
        }

        [HttpDelete]
        [Route("api/myclass/{str}")]
        public HttpResponseMessage Delete(string str)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");
            response.Content = new StringContent("hello", Encoding.Unicode);
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };
            return response;
        }

        [HttpGet]
        [Route("api/inclass/removed")]
        public void Removed()
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);

            //var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            //    {
            //        Content = new StringContent("Resource has been removed."),
            //        ReasonPhrase = "Removed"
            //    };
            //throw new HttpResponseException(resp);

        }
    }
}
