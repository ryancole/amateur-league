using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Azure.WebJobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using League.Entity.WebApi;
using LeagueApiFunction.Handlers;

namespace LeagueApiFunction.Functions
{
    public static class HandleApiRequest
    {
        #region Methods

        [FunctionName("HandleApiRequest")]
        public static async Task<IActionResult> Run([HttpTrigger("post")] HttpRequest req, ILogger log)
        {
            var body = string.Empty;

            using (var reader = new StreamReader(req.Body))
            {
                body = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrWhiteSpace(body))
            {
                var result = new BadRequestObjectResult("expected request body");

                return result;
            }

            // we expect to receive our command data via the http request body
            var request = JsonConvert.DeserializeObject<LeagueApiRequest>(body);

            // execute the desired command and receive the result
            var response = await ExecuteCommand(request.Command, request.SerializedParameters);

            return new JsonResult(response);
        }

        private static async Task<object> ExecuteCommand(LeagueApiRequestCommand command, string parameters)
        {
            if (CommandHandlerMap.ContainsKey(command) == false)
            {
                throw new Exception("unknown command");
            }

            // get the handler function from our handler map
            var handler = CommandHandlerMap[command];

            // execute the handler function, with parameters, and get result object
            var result = await handler(parameters);

            return result;
        }

        /// <summary>
        /// mapping of command names to handler functions
        /// </summary>
        private static Dictionary<LeagueApiRequestCommand, Func<string, Task<object>>> CommandHandlerMap = new Dictionary<LeagueApiRequestCommand, Func<string, Task<object>>>
        {
            { LeagueApiRequestCommand.TeamCreate, TeamHandlers.Create },
            { LeagueApiRequestCommand.TeamGetAll, TeamHandlers.GetAll },

            { LeagueApiRequestCommand.SeasonCreate, SeasonHandlers.Create },
            { LeagueApiRequestCommand.SeasonGetAll, SeasonHandlers.GetAll },

            { LeagueApiRequestCommand.SeasonMembershipCreate, SeasonMembershipHandlers.Create },
            { LeagueApiRequestCommand.SeasonMembershipGetByTeam, SeasonMembershipHandlers.GetByTeam },
            { LeagueApiRequestCommand.SeasonMembershipGetBySeason, SeasonMembershipHandlers.GetBySeason }
        };

        #endregion
    }
}
