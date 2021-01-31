using Microsoft.Bot.Schema;
using System.Threading.Tasks;

namespace WeatherNotifierBot.Logic.Servcies.Interfaces
{
    /// <summary>
    /// Operations with <see cref="User"/>.
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// Adds a new user into database.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns><see cref="OperationResponse"/> true if successfull, false if failed.</returns>
        Task<OperationResponse> AddNewUserAsync(ChannelAccount newUser);
    }
}