using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using WeatherNotifierBot.DAL.Context;
using WeatherNotifierBot.Domain.Entries;
using WeatherNotifierBot.Enums;
using WeatherNotifierBot.Logic;
using WeatherNotifierBot.Logic.Services.Interfaces;
using WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandAbstraction;
using WeatherNotifierBot.Logic.Telegram.CommandLogic.CommandFactories;
using WeatherNotifierBot.Logic.Telegram.UserStatusLogic.UserStatusAbstraction;

namespace WeatherNotifierBot.Bots
{
    public class TelegramBot : ActivityHandler
    {
        private readonly IUserLogic _userLogic;
        private readonly INotificationLogic _weatherNotifierLogic;
        private readonly TelegramContext _telegramContext;

        public TelegramBot(IUserLogic userLogic, TelegramContext telegramContext, INotificationLogic weatherNotifierLogic)
        {
            _userLogic = userLogic;
            _telegramContext = telegramContext;
            _weatherNotifierLogic = weatherNotifierLogic;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string text = turnContext.Activity.Text;
            List<string> commands = _telegramContext.TelegramCommands.Select(x => x.CommandName).ToList();

            if (!commands.Contains(text))
            {
                UserStatusFactory userStatusFactory = null;

                switch (text)
                {
                    case 
                }

                return;
            }

            TelegramCommandFactory commandFactory = null;
            switch (text)
            {
                case nameof(TelegramCommandEnum.HELP):
                    commandFactory = new TelegramHelpCommandFactory(turnContext, cancellationToken);
                    break;
                case nameof(TelegramCommandEnum.SET_CITY):
                    commandFactory = new TelegramSetCityCommandFactory(turnContext, cancellationToken);
                    break;
            }

            ITelegramCommandFactory telegramCommandFactory = commandFactory.FactoryMethod();
            await telegramCommandFactory.GenerateResponse();

            await turnContext.SendActivityAsync(MessageFactory.Text("Test", "Test"), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            if (membersAdded is null)
                return;

            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var welcomeText = "Hello and welcome! Please enter your city name.";
                    OperationResponse result;
                    
                    result = await _userLogic.AddNewUserAsync(member);
                    
                    if (result.Success)
                    {
                        result = await _userLogic.SetUserStatusAsync(member, nameof(UserStatusEnum.HAS_TO_ENTER_CITY_NAME));
                    }

                    if (result.Success)
                        await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
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
