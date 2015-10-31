using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atenda.Web.Controllers
{
    public class TempDataActionResult : ActionResult
    {
        private readonly ActionResult _actionResult;
        private readonly string _mensagem;
        private readonly string _type;

        public TempDataActionResult(ActionResult actionResult, string mensagem, string type)
        {
            _actionResult = actionResult;
            _mensagem = mensagem;
            _type = type;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.Controller.TempData["Mensagem"] = _mensagem;
            context.Controller.TempData["Tipo"] = _type;
            _actionResult.ExecuteResult(context);
        }
    }
    public static class ActionResultExtensions
    {
        public static ActionResult ComMensagemDeSucesso(this ActionResult actionResult, string mensagem)
        {
            return new TempDataActionResult(actionResult, mensagem, "ok");
        }
        public static ActionResult ComMensagemDeErro(this ActionResult actionResult, string mensagem)
        {
            return new TempDataActionResult(actionResult, mensagem, "bad");
        }
    }
}