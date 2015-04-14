namespace RabbitFarm.WebAPI.DataModels
{
    using System.ComponentModel.DataAnnotations;

    using RabbitFarm.Models;

    public class RabbitModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Rabbit Mark is required")]
        [StringLength(3, ErrorMessage = "Rabbit Mark must be at least 3 characters")]
        public string Mark { get; set; }

        [Required(ErrorMessage = "Rabbit Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Rabbit Status is required")]
        public RabbitStatus Status { get; set; }

        [Required(ErrorMessage = "LitterId is required")]
        public int LitterId { get; set; }

        public LitterModel Litter { get; set; }

        [Required(ErrorMessage = "AcquisitionId is required")]
        public int AcquisitionId { get; set; }

        public AcquisitionModel Acquisition { get; set; }

        [Required(ErrorMessage = "FarmId is required")]
        public int FarmId { get; set; }
    }
}