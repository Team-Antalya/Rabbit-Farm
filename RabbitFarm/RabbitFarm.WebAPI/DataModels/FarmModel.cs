namespace RabbitFarm.WebAPI.DataModels
{
    using System.Collections.Generic;

    using RabbitFarm.Models;

    public class FarmModel
    {
        public string Name { get; set; }

        /*public static Expression<Func<Farm, FarmModel>> PurchasesToViewModel
        {
            get
            {
                return f => new FarmModel
                {

                };
            }
        }*/
    }
}