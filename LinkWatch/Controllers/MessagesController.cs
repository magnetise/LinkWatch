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
        public ActionResult Index(string from, string to, string tags, string message)
        {
            var response = client.Send(new SmsMessage
                {
                    From = from,
                    To = to,
                    Tags = tags,
                    Message = message
                });
            return View("Sent",response);
        }
    }

    public class CallbackController : Controller
    {
        readonly Magnetise client = new Magnetise();

        [HttpPost]
        public ActionResult Index(RedirectCallback callback)
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