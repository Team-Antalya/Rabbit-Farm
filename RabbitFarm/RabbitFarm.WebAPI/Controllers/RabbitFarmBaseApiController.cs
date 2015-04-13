namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.WebAPI.Infrastructure;

    public class RabbitFarmBaseApiController: ApiController
    {
        protected IRabbitFarmData data;
        protected IUserProvider userProvider;       

        public RabbitFarmBaseApiController(IRabbitFarmData data, IUserProvider userProvider)
        {
            this.data = data;
            this.userProvider = userProvider;
        }
    }
}