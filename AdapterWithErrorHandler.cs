// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder.TraceExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Microsoft.PowerVirtualAgents.Samples.RelayBotSample
{
    public class AdapterWithErrorHandler : BotFrameworkHttpAdapter
    {
        public AdapterWithErrorHandler(IConfiguration configuration, ILogger<BotFrameworkHttpAdapter> logger)
            : base(configuration, logger)
        {
            OnTurnError = async (turnContext, exception) =>
            {
                // Log any leaked exception from the application.
                logger.LogError($"Exception caught : {exception.ToString()}");

                // Send a catch-all apology to the user.
                await turnContext.SendActivityAsync($"Something went wrong. Here is the error: {exception.Message } ");
                await turnContext.TraceActivityAsync("CPS speech bot: Error trace", exception.Message, "https://www.botframework.com/schemas/error", "TurnError");
            };
        }
    }
}
