using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Greeting.Models;
using Greeting.Services;
using System.Configuration;
namespace Greeting.API.Controllers
{
    [RoutePrefix("api/greeting")]
    public class GreetingController : ApiController
    {
        public GreetingController() { }
        
        [System.Web.Http.HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                GreetingService greetingService = new GreetingService();
                IEnumerable<IGreeting> greetingList;
                greetingList = greetingService.Fetch().ToList();
                if (greetingList != null)
                {
                    return Ok(greetingList);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception e)
            {
                return Json(e.Message + " " + e.InnerException);
            }
        }
        [System.Web.Http.HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            //Implementation of Get By Id
            try
            {
                GreetingService greetingService = new GreetingService();
                IGreeting greeting = greetingService.Fetch(id);
                if (greeting != null)
                {
                    return Ok(greeting);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return Json(e.Message + " " + e.InnerException);
            }
        }
        [System.Web.Http.HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            //Implementation of Delete
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return Json(e.Message + " " + e.InnerException);
            }


        }
        [System.Web.Http.HttpPost]
        public IHttpActionResult Post(IGreeting greeting)
        {
            //Implementation of Post 
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return Json(e.Message + " " + e.InnerException);
            }
        }
        [System.Web.Http.HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult Put(IGreeting greeting)
        {
            //Implementation of Put Request
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return Json(e.Message + " " + e.InnerException);
            }
        }
    }
}
