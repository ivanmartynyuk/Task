using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Test_App.Models;
namespace Test_App.Controllers
{
    public class ValuesController : ApiController
    {
 
        //System.Web.HttpContext.Server.MapPath("~/App_Data/somedata.xml");
        static Manager_Directory manager = new Manager_Directory(@System.Web.HttpRuntime.AppDomainAppPath);

        // GET api/values
        public MyDirectory Get()
        {
           
            MyDirectory mydirec = new MyDirectory() { Path = manager.Directory, PidDerictories = manager.GetDirectories(), Counts = manager.Get_Sort_Files(), Files = manager.GetFiles() };
            return mydirec;
        }



        // POST api/values
        public void Post([FromBody]Direct_Mod value)
        {
            manager.Step_To_other_Directory(value.@Value);
        }

    }
}