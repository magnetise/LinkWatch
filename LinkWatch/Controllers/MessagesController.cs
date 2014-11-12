using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using magneti.se.client;

namespace LinkWatch.Controllers
{
    [Authorize(Users = "your@email.com")]
    public class MessagesController : Controller
    {
        readonly Magnetise client = new Magnetise();

        [HttpGet]
        public ActionResult Index()
        {
            return View(new SmsMessage());
        }

        [HttpPost]
        public ActionResult Index(SmsMessage message)
        {
            var response = client.Send(message);
            return View("Sent",response);
        }

        public ActionResult Callback(RedirectCallback callback)
        {
            client.Send(new SmsMessage
            {
                From = callback.Recipient,
                To = callback.Originator,
                Message = "Link clicked"
            });

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}