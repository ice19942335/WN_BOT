using EasyShop.DAL.Context;
using Microsoft.Bot.Schema;
using System.Threading.Tasks;
using WeatherNotifierBot.Domain.TelegramBot;
using WeatherNotifierBot.Logic.Servcies.Interfaces;

namespace WeatherNotifierBot.Logic.Servcies
{
    /// <summary>
    /// Operations with <see cref="User"/>.
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private TelegramContext _telegramContext;

        /// <summary>
        /// Operations with <see cref="User"/>.
        /// </summary>
        public UserLogic(TelegramContext telegramContext)
        {
            _telegramContext = telegramContext;
        }

        /// <summary>
        /// Adds a new user into database.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns><see cref="OperationResponse"/> true if successfull, false if failed.</returns>
        public async Task<OperationResponse> AddNewUserAsync(ChannelAccount newUser)
        {
            var response = new OperationResponse() { Success = true };
            User newUserToBeAdded = new User()
            {
                Id = newUser.Id,
                Name = newUser.Name,
                AadObjectId = newUser.AadObjectId,
                Role = newUser.Role,
                Properties = newUser.Properties.ToString()
            };

            _telegramContext.Users.Add(newUserToBeAdded);

            try
            {
                var entitiesAdded = await _telegramContext.SaveChangesAsync();
                return response;
            }
            catch (System.Exception ex)
            {
                response.ErrorMessage = string.IsNullOrEmpty(ex.InnerException.Message) ? ex.InnerException.Message : ex.Message;
                return response;
            }
        }
    }
}
