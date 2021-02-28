using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsWebApi.Controllers
{
    /// <summary>
    /// The values controller that was auto generated
    /// </summary>
    public class ValuesController : ApiController
    {
        /// <summary>
        /// returns an array of strings. Nothing fancy.
        /// </summary>
        /// <returns></returns>
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// return a simple string value
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// posts from body
        /// </summary>
        /// <param name="value"></param>
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// puts with an id and a string value from body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// just delete for the given id
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
