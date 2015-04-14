using System.ComponentModel.DataAnnotations;

namespace RabbitFarm.WebAPI.DataModels
{
    public class FarmModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}