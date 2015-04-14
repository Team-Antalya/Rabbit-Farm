namespace RabbitFarm.WebAPI.DataModels
{
    using System.ComponentModel.DataAnnotations;
    public class FarmModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}