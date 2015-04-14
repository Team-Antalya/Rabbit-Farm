using System.ComponentModel.DataAnnotations;

namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;

    public class LitterModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "MotherId is required")]
        public int MotherId { get; set; }

        public RabbitModel Mother { get; set; }

        [Required(ErrorMessage = "FatherId is required")]
        public int FatherId { get; set; }

        public RabbitModel Father { get; set; }

        public ICollection<RabbitModel> Rabbits { get; set; }

        [Required(ErrorMessage = "FarmId is required")]
        public int FarmId { get; set; }
    }
}