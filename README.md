# Copilot Studio Speech Bot

Sample of connecting Bot Framework v4 bot to a Copilot Studio bot. The goal of this sample is to have a Speech Enabled Copilot Studio bot
published on a DirectLine Speech Channel.

***NOTE:***
A feature called ***Allowlists*** is upcoming that will eliminate the need for custom implementation and allow Azure Bot Framework to call a Copilot Studion bot as a skill
This feature is today only available for classic Copilots
[Use a classic chatbot as a skill](https://learn.microsoft.com/en-us/microsoft-copilot-studio/advanced-use-pva-as-a-skill)

This bot has been created based on [Bot Framework](https://dev.botframework.com), it shows how to create an Azure Bot Service bot that connects to a Copilot Studio bot via Direct Line API

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) version 2.1

  ```bash
  # determine dotnet version
  dotnet --version
  ```
- [Power Platform CLI](https://learn.microsoft.com/en-us/power-platform/developer/cli/introduction?tabs=windows#install-microsoft-power-platform-cli)

  ```bash
  # install PAC CLI via dotnet tool
  dotnet tool install --global Microsoft.PowerApps.CLI.Tool
  ```
- [Aure Command Line Interface](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?tabs=azure-cli#install-or-update)


## Setup

### Compile the bot

- Clone the repository

    ```bash
    git clone https://github.com/microsoft/xxx.git
    ```

- In a terminal, navigate to `SpeechRelayBot/`
- Update the file `appsettings.json` with your Copilot Studio bot id, tenant id, bot name and other settings.
    
    To retrieve your Copilot Studio bot's token endpoint, click on left side pane's ***Manage***, click ***Channels*** and click on the Direct Line Speech channel.
    Copy and save the token endpoint value by clicking Copy.

    To retrieve your tenant ID, use the following command in a terminal connected with PAC CLI

    ```bash
    pac auth who
    ```
    To retrieve your Copilot Studio bot ID and name, use the following command in a terminal connected with PAC CLI

    ```bash
    pac copilot list
    ```

    
    ```json
    "BotService": {
      "BotName": "<Name of your CPS bot>",
      "BotId": "<Bot ID copied from CLI output>",
      "TenantId": "<Tenant copied from CLI output>",
      "TokenEndPoint": "<Token endpoint copied from channel panel>"
    }
   ``` 
    

- Build the bot and prepare it for deployment.

  ```bash
  # Build
  dotnet build -c release 
  # Prepare
  az bot prepare-deploy --lang CSharp --code-dir . --proj-file-path .\EchoBot.csproj
  Compress-Archive * .\CopilotSpeechBot.zip -force
  ```
### Setup required resources in Microsoft Azure

The following sets up Azure Cognitive Services for speech as well as an App Service plan, a web app and an Azure Bot.

## Testing the bot using Bot Framework Emulator

[Bot Framework Emulator](https://github.com/microsoft/botframework-emulator) is a desktop application that allows bot developers to test and debug their bots on localhost or running remotely through a tunnel.

- Install the Bot Framework Emulator version 4.3.0 or greater from [here](https://github.com/Microsoft/BotFramework-Emulator/releases)

### Connect to the bot using Bot Framework Emulator

- Launch Bot Framework Emulator
- File -> Open Bot
- Enter a Bot URL of `http://localhost:3978/api/messages`

## Deploy the bot to Azure

To learn more about deploying a bot to Azure, see [Deploy your bot to Azure](https://aka.ms/azuredeployment) for a complete list of deployment instructions.

## Further reading

- [Bot Framework Documentation](https://docs.botframework.com)
- [Bot Basics](https://docs.microsoft.com/azure/bot-service/bot-builder-basics?view=azure-bot-service-4.0)
- [Activity processing](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-concept-activity-processing?view=azure-bot-service-4.0)
- [Azure Bot Service Introduction](https://docs.microsoft.com/azure/bot-service/bot-service-overview-introduction?view=azure-bot-service-4.0)
- [Azure Bot Service Documentation](https://docs.microsoft.com/azure/bot-service/?view=azure-bot-service-4.0)
- [.NET Core CLI tools](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
- [Azure CLI](https://docs.microsoft.com/cli/azure/?view=azure-cli-latest)
- [Azure Portal](https://portal.azure.com)
- [Language Understanding using LUIS](https://docs.microsoft.com/en-us/azure/cognitive-services/luis/)
- [Channels and Bot Connector Service](https://docs.microsoft.com/en-us/azure/bot-service/bot-concepts?view=azure-bot-service-4.0)
- [Restify](https://www.npmjs.com/package/restify)
- [dotenv](https://www.npmjs.com/package/dotenv)
