namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class AcquisitionController : RabbitFarmBaseApiController<Acquisition, AcquisitionModel>
    {
        public AcquisitionController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AcquisitionModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var acquisitionInDb = this.data.Acquisitions.Find(id);
            if (acquisitionInDb == null)
            {
                return BadRequest("No acquisition with the given id found!");
            }
            var acquisition = Mapper.Map<Acquisition>(obj);
            acquisitionInDb.AcquisitionDate = acquisition.AcquisitionDate;
            acquisitionInDb.Source = acquisition.Source;
            acquisitionInDb.RabbitId = acquisition.RabbitId;
            acquisitionInDb.FarmId = acquisition.FarmId;
            if (acquisition.Cost != 0)
            {
                acquisitionInDb.Cost = acquisition.Cost;
            }
            
            this.data.SaveChanges();
            return Ok("Acquisition updated!");
        }
    }
}
