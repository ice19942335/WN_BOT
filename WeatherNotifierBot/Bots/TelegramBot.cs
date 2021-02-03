using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyShop.DAL.Context;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using WeatherNotifierBot.Enums;
using WeatherNotifierBot.Logic;
using WeatherNotifierBot.Logic.Servcies.Interfaces;
using WeatherNotifierBot.Logic.Telegram.CommandAbstraction;
using WeatherNotifierBot.Logic.Telegram.CommandFactories;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class TelegramBot : ActivityHandler
    {
        private readonly IUserLogic _userLogic;
        private readonly INotificationLogic _weatherNotifierLogic;
        private TelegramContext _telegramContext;

        public TelegramBot(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string command = turnContext.Activity.Text;
            List<string> commands = _telegramContext.TelegramCommands.Select(x => x.CommandName).ToList();



            if (!commands.Contains(command))
            {
                await turnContext.SendActivityAsync(MessageFactory.Text($"Command: {command} does't exist. Please, check the command an try again."), cancellationToken);
                return;
            }

            TelegramCommandFactory commandFactory = command switch
            {
                nameof(TelegramCommandEnum.HELP) => new TelegramHelpCommandFactory(turnContext, cancellationToken),
                nameof(TelegramCommandEnum.SET_CITY) => new TelegramSetCityCommandFactory(turnContext, cancellationToken)
            };

            ITelegramCommand telegramCommand = commandFactory.FactoryMethod();
            await telegramCommand.GenerateResponse();

            await turnContext.SendActivityAsync(MessageFactory.Text("Test", "Test"), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome! Please enter your city name.";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    //await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                    //await SendSuggestedActionsAsync(turnContext, cancellationToken);
                    OperationResponse result = await _userLogic.AddNewUserAsync(member);
                    if (result.Success)
                    {
                        await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                    }
                }
            }
        }

        // Creates and sends an activity with suggested actions to the user. When the user
        /// clicks one of the buttons the text value from the "CardAction" will be
        /// displayed in the channel just as if the user entered the text. There are multiple
        /// "ActionTypes" that may be used for different situations.
        private static async Task SendSuggestedActionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        {
            var reply = MessageFactory.Text("What is your favorite color?");

            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction() { Title = "Red", Type = ActionTypes.ImBack, Value = "Red", Image = "https://via.placeholder.com/20/FF0000?text=R", ImageAltText = "R" },
                    new CardAction() { Title = "Yellow", Type = ActionTypes.ImBack, Value = "Yellow", Image = "https://via.placeholder.com/20/FFFF00?text=Y", ImageAltText = "Y" },
                    new CardAction() { Title = "Blue", Type = ActionTypes.ImBack, Value = "Blue", Image = "https://via.placeholder.com/20/0000FF?text=B", ImageAltText = "B"   },
                },
            };
            await turnContext.SendActivityAsync(reply, cancellationToken);
        }
    }
}
