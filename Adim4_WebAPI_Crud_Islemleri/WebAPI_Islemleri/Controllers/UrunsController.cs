using Database_Islemleri_Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;      //ResponseType için

namespace WebAPI_Islemleri.Controllers
{
    public class UrunsController : ApiController
    {
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------

        UrunDAL urunDAL = new UrunDAL();

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //public IEnumerable<Uruns> Get()           //Temel Listeleme İşlemi
        //{
        //    return urunDAL.TumUrunleriGetir();
        //}



        //public HttpResponseMessage Get()          //Uzun kod ile(HttpResponseMessage)
        //{
        //    var urun = urunDAL.TumUrunleriGetir();
        //    return Request.CreateResponse(HttpStatusCode.OK, urun);     //Veri dönerse, Response(cevap) olarak OK(200) kodunu vericek ve tüm ürünleri gösterecek.
        //}


        [ResponseType(typeof(IEnumerable<Uruns>))]
        public IHttpActionResult Get()      //Güncel kısa kod ile(IHttpActionResult)
        {
            var urun = urunDAL.TumUrunleriGetir();
            return Ok(urun);     //Veri dönerse, Response(cevap) olarak OK(200) kodunu vericek ve tüm ürünleri gösterecek.
        }



        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //public Uruns Get(int id)          //Temel 1 nesneyi Listeleme İşlemi
        //{
        //    return urunDAL.UrunDetayi(id);
        //}



        //public HttpResponseMessage Get(int id)            //Uzun kod ile(HttpResponseMessage)
        //{
        //    var urun = urunDAL.UrunDetayi(id);
        //    if (urun == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, "Böyle bir kayıt bulunamadı...");    //Veri dönmezse, Response(cevap) olarak Not Found(404) kodunu ve bu mesajı vericek.
        //    }
        //    return Request.CreateResponse(HttpStatusCode.OK, urun);     //Veri dönerse, Response(cevap) olarak OK(200) kodunu vericek ve ilgili ürünü gösterecek.
        //}


        [ResponseType(typeof(Uruns))]
        public IHttpActionResult Get(int id)            //Güncel kısa kod ile(IHttpActionResult)
        {
            var urun = urunDAL.UrunDetayi(id);
            if (urun == null)
            {
                return NotFound();    //Veri dönmezse, Response(cevap) olarak Not Found(404) kodunu ve bu mesajı vericek.
            }
            return Ok(urun);     //Veri dönerse, Response(cevap) olarak OK(200) kodunu vericek ve ilgili ürünü gösterecek.
        }



        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //public Uruns Post(Uruns urun)     //Temel Ekleme İşlemi
        //{
        //    return urunDAL.UrunEkle(urun);
        //}



        //public HttpResponseMessage Post(Uruns urun)     //Web API ile Post işlemi               //Uzun kod ile(HttpResponseMessage)
        //{
        //    if (ModelState.IsValid)     //Modelin şartları istediğim gibiyse
        //    {
        //        var createdUrun = urunDAL.UrunEkle(urun);
        //        return Request.CreateResponse(HttpStatusCode.Created, createdUrun);     //Created kodunu döndür(201)
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);       //Validasyon hata kodunu döndür(400) döndür.
        //    }
        //}


        [ResponseType(typeof(Uruns))]
        public IHttpActionResult Post(Uruns urun)     //Web API ile Post işlemi               //Güncel kısa kod ile(IHttpActionResult)
        {
            if (ModelState.IsValid)     //Modelin şartları istediğim gibiyse
            {
                var createdUrun = urunDAL.UrunEkle(urun);
                return CreatedAtRoute("DefaultApi", new { id = createdUrun.UrunID }, createdUrun);     //Created kodunu döndür(201)
            }
            else
            {
                return BadRequest(ModelState);       //Validasyon hata kodunu döndür(400) döndür.
            }
        }



        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //public Uruns Put(int id, Uruns urun)          //Temel Güncelleme İşlemi
        //{
        //    return urunDAL.UrunuGuncelle(id, urun);
        //}



        //public HttpResponseMessage Put(int id, Uruns urun)          //Uzun kod ile(HttpResponseMessage)
        //{
        //    if (urunDAL.IsThereAnyUrun(id) == false)    // Gönderilen id ile kayıtlı bir Ürün yoksa 
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı...");
        //    }
        //    else if (ModelState.IsValid == false)       //Modelin şartları istediğim gibi değilse
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //    else    //Modelin şartları istediğim gibiyse ve Gönderilen id ile kayıtlı bir Ürün varsa
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, urunDAL.UrunuGuncelle(id, urun));
        //    }
        //}


        [ResponseType(typeof(Uruns))]
        public IHttpActionResult Put(int id, Uruns urun)          //Güncel kısa kod ile(IHttpActionResult)
        {
            if (urunDAL.IsThereAnyUrun(id) == false)    // Gönderilen id ile kayıtlı bir Ürün yoksa 
            {
                return NotFound();
            }
            else if (ModelState.IsValid == false)       //Modelin şartları istediğim gibi değilse
            {
                return BadRequest(ModelState);
            }
            else    //Modelin şartları istediğim gibiyse ve Gönderilen id ile kayıtlı bir Ürün varsa
            {
                return Ok(urunDAL.UrunuGuncelle(id, urun));
            }
        }



        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------



        //public void Delete(int id)            //Temel Silme İşlemi
        //{
        //    urunDAL.UrunuSil(id);
        //}



        //public HttpResponseMessage Delete(int id)         //Uzun kod ile(HttpResponseMessage)
        //{
        //    if (urunDAL.IsThereAnyUrun(id) == false)    // Gönderilen id ile kayıtlı bir Ürün yoksa 
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kayıt Bulunamadı...");
        //    }
        //    else    //Modelin şartları istediğim gibiyse ve Gönderilen id ile kayıtlı bir Ürün varsa
        //    {
        //        urunDAL.UrunuSil(id);
        //        return Request.CreateResponse(HttpStatusCode.NoContent);
        //    }
        //}



        public IHttpActionResult Delete(int id)             //Güncel kısa kod ile(IHttpActionResult)
        {
            if (urunDAL.IsThereAnyUrun(id) == false)    // Gönderilen id ile kayıtlı bir Ürün yoksa 
            {
                return NotFound();
            }
            else    //Modelin şartları istediğim gibiyse ve Gönderilen id ile kayıtlı bir Ürün varsa
            {
                urunDAL.UrunuSil(id);
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
    }
}
