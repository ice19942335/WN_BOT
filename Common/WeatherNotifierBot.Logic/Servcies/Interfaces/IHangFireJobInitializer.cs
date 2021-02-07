using System.Threading.Tasks;

namespace WeatherNotifierBot.Logic.Servcies.Interfaces
{
    /// <summary>
    /// Repreents HangFire job initialization methods.
    /// </summary>
    public interface IHangFireJobInitializer
    {
        /// <summary>
        /// HangFire default initializer.
        /// </summary>
        void InitializeAsync();
    }
}
