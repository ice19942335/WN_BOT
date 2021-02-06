using System.ComponentModel.DataAnnotations.Schema;
using WeatherNotifierBot.Domain.Base;

namespace WeatherNotifierBot.Domain.Entries
{
    /// <summary>
    /// Represent <see cref="User"/> entity in entire system. 
    /// </summary>
    [Table("Users")]
    public class User : BaseEntity
    {
        /// <summary>
        /// User name in channel.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Channel account properties.
        /// </summary>
        public string Properties { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AadObjectId { get; set; }

        /// <summary>
        /// User role in channel.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Notification type.
        /// </summary>
        public virtual UserNotificationType NotificationType { get; set; }
    }
}
