using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Schema;
using Microsoft.EntityFrameworkCore;
using WeatherNotifierBot.DAL.Context;
using WeatherNotifierBot.Domain.Entries;
using WeatherNotifierBot.Logic.Servces.Interfaces;

namespace WeatherNotifierBot.Logic.Servces
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
        /// <param name="channelAccount">Channel acciunt.</param>
        /// <returns><see cref="OperationResponse"/> true if successfull, false if failed.</returns>
        public async Task<OperationResponse> AddNewUserAsync(ChannelAccount channelAccount)
        {
            var response = new OperationResponse();
            User newUserToBeAdded = new User()
            {
                Id = channelAccount.Id,
                Name = channelAccount.Name,
                AadObjectId = channelAccount.AadObjectId,
                Role = channelAccount.Role,
                Properties = channelAccount.Properties.ToString()
            };

            _telegramContext.Users.Add(newUserToBeAdded);

            try
            {
                var entitiesAdded = await _telegramContext.SaveChangesAsync();
                response.Success = true;
                return response;
            }
            catch (System.Exception ex)
            {
                response.ErrorMessage = string.IsNullOrEmpty(ex.InnerException.Message) ? ex.InnerException.Message : ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Sets user notification type.
        /// </summary>
        /// <param name="channelAccount">Channel acciunt</param>
        /// <param name="userNotificationType">Notification type.</param>
        /// <returns><see cref="OperationResponse"/> true if successfull, false if failed.</returns>
        public async Task<OperationResponse> SetUserNotificationTypeAsync(ChannelAccount channelAccount, UserNotificationType userNotificationType)
        {
            var response = new OperationResponse();
            User user = _telegramContext.Users.FirstOrDefault(x => x.Id == channelAccount.Id);
            user.NotificationType = userNotificationType;

            try
            {
                _telegramContext.Users.Update(user);
                await _telegramContext.SaveChangesAsync();

                response.Success = true;
                return response;
            }
            catch (System.Exception ex)
            {
                response.ErrorMessage = string.IsNullOrEmpty(ex.InnerException.Message) ? ex.InnerException.Message : ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Sets user status. 
        /// Usecase: Setting user status of what we are expecting from user, for instance
        /// we are expecting from user to enter city name, so we are setting user status UserStatusEnum.HAS_TO_ENTER_CITY_NAME
        /// </summary>
        /// <param name="channelAccount">Channel account.</param>
        /// /// <param name="userStatusEnum">User status.</param>
        /// <returns><see cref="OperationResponse"/>True if successfull, False if failed.</returns>
        public async Task<OperationResponse> SetUserStatusAsync(ChannelAccount channelAccount, string userStatusLabel)
        {
            var response = new OperationResponse();
            User user = _telegramContext.Users.Include(x => x.UserStatus).FirstOrDefault(x => x.Id == channelAccount.Id);
            UserStatus userStatus = _telegramContext.UserStatuses.FirstOrDefault(x => x.Label == userStatusLabel);
            user.UserStatus = userStatus;

            try
            {
                _telegramContext.Users.Update(user);
                await _telegramContext.SaveChangesAsync();

                response.Success = true;
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
