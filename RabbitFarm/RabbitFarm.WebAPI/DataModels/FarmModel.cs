namespace RabbitFarm.WebAPI.DataModels
{
    using System.ComponentModel.DataAnnotations;
    public class FarmModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Farm Name is required")]
        [StringLength(3, ErrorMessage = "Farm Name must be more than 3 characters")]
        public string Name { get; set; }
    }
}