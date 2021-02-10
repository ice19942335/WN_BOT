using System.Threading.Tasks;
using Microsoft.Bot.Schema;
using WeatherNotifierBot.Domain.Entries;

namespace WeatherNotifierBot.Logic.Servces.Interfaces
{
    /// <summary>
    /// Operations with <see cref="User"/>.
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// Adds a new user into database.
        /// </summary>
        /// <param name="newUser">Channel account.</param>
        /// <returns><see cref="OperationResponse"/>True if successfull, False if failed.</returns>
        Task<OperationResponse> AddNewUserAsync(ChannelAccount channelAccount);

        /// <summary>
        /// Sets user notification type.
        /// </summary>
        /// <param name="userNotificationType">User notification type.</param>
        /// <returns><see cref="OperationResponse"/>True if successfull, False if failed.</returns>
        Task<OperationResponse> SetUserNotificationTypeAsync(ChannelAccount user, UserNotificationType userNotificationType);

        /// <summary>
        /// Sets user status. 
        /// Usecase: Setting user status of what we are expecting from user, for instance
        /// we are expecting from user to enter city name, so we are setting user status UserStatusEnum.HAS_TO_ENTER_CITY_NAME
        /// </summary>
        /// <param name="channelAccount">Channel account.</param>
        /// /// <param name="userStatus">User status.</param>
        /// <returns><see cref="OperationResponse"/>True if successfull, False if failed.</returns>
        Task<OperationResponse> SetUserStatusAsync(ChannelAccount channelAccount, string userStatusLabel);
    }
}