namespace RabbitFarm.WebAPI.DataModels
{
    using System.ComponentModel.DataAnnotations;

    public class CageModel
    {
        public int Id { get; set; }

        [Range(0, double.MaxValue)]
        [Required(ErrorMessage = "Cage Width is required")]
        public double Width { get; set; }

        [Range(0, double.MaxValue)]
        [Required(ErrorMessage = "Cage Height is required")]
        public double Height { get; set; }

        [Range(0, double.MaxValue)]
        [Required(ErrorMessage = "Cage Length is required")]
        public double Length { get; set; }

        [Required(ErrorMessage = "FarmId is required")]
        public int FarmId { get; set; }
    }
}