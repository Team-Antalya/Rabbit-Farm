namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CageChangeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Starting Date is required")]
        public DateTime StartingDate { get; set; }

        [Required(ErrorMessage = "RabbitId is required")]
        public int RabbitId { get; set; }

        public RabbitModel Rabbit { get; set; }

        [Required(ErrorMessage = "FarmId is required")]
        public int FarmId { get; set; }

        public ICollection<CageModel> Cages { get; set; }
    }
}