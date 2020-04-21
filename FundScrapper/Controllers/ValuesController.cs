using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeleniumStuff;
using SeleniumStuff.Sources;

namespace FundScrapper.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        /*
        public IHttpActionResult Get()
        {
            TradingView t = new TradingView();
            return Json(t.SearchItens(new List<string> { "BIDI11" }));  
        }
        */
        // GET api/values/5
        public IHttpActionResult Get(string s)
        {
            List<string> list = new List<string>();
            return Json(TradingView.SearchItens(new List<string> {s}));
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
