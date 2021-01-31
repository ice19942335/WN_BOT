using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeatherNotifierBot.Domain.Base.Interfaces;

namespace WeatherNotifierBot.Domain.Base
{
    /// <summary>
    /// Represents base entity.
    /// </summary>
    public class BaseEntity : IBaseEntity
    {
        /// <summary>
        /// Entity Id in Database.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    }
}
