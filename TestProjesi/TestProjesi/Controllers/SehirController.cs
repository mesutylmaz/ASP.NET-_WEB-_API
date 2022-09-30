using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;     //EnableCors için

namespace TestProjesi.Controllers
{
    [EnableCors("*","*","*")]       //Cors bu Controller'ın tamamına uygulansın dedik. Parantez içine * koyarak, hiçbir kısıt uygulanmasın-hepsine bu Cors'u uygula demiş olduk. Yani güvenlik şuan sıfır :)
    public class SehirController : ApiController
    {


        private string[] sehirler = { "Malatya", "Iğdır", "Kilis" };



        //domainadresi/api/sehir
        public string[] Get()
        {
            //return "Merhaba Web API";
            return new string[] { "Antalya", "Eskişehir", "Konya" };
        }


        public string Get(int id)
        {
            return sehirler[id];
        }
    }
}
