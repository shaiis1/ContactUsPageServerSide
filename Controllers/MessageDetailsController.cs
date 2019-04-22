using System;
using System.Web.Http;
using System.Configuration;
using Softwave_Server_Side.Logic;
using Softwave_Server_Side.Enums;
using Softwave_Server_Side.Models;
using Softwave_Server_Side.Interfaces;

namespace Softwave_Server_Side.Controllers
{
    public class MessageDetailsController : ApiController
    {
        [HttpPost]
        [Route("createdetail")]
        public IHttpActionResult CreateDetail([FromBody] MessageDetails i_details)
        {
            try
            {
                ControllerConfigs configurations = GetDatabaseTypeFromConfigs();
                IMessageDetailsLogic messageDetailsLogic = new MessageDetailsLogic(configurations);

                messageDetailsLogic.CreateMessageDetail(i_details);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private ControllerConfigs GetDatabaseTypeFromConfigs()
        {
            return new ControllerConfigs()
            {
                Location = ConfigurationManager.AppSettings["PathType"],
                DatabaseType = (DatabaseType)int.Parse(ConfigurationManager.AppSettings["DatabaseType"])
            };
        }
    }
}