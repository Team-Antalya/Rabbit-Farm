namespace RabbitFarm.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class CageController : RabbitFarmBaseApiController
    {
        public CageController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var cages = this.data.Cages.All().Include(a => a.Farm).Include(a => a.CageChanges);
            var cagesViewModel = Mapper.Map<ICollection<CageModel>>(cages);

            return Ok(cagesViewModel);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cage = this.data.Cages.Find(id);
            if (cage == null)
            {
                return BadRequest("No cage with this id!");
            }
            var cageViewModel = Mapper.Map<CageModel>(cage);
            return Ok(cageViewModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]CageModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var cageInDb = this.data.Cages.Find(id);
            if (cageInDb == null)
            {
                return BadRequest("No cage with given id found!");
            }
            var cage = Mapper.Map<Cage>(obj);
            cageInDb.Width= cage.Width;
            cageInDb.Height = cage.Height;
            cageInDb.Length = cage.Length;
            cageInDb.FarmId = cage.FarmId;
            this.data.SaveChanges();
            return Ok("Cage updated!");
        }

        [HttpPost]
        public IHttpActionResult Add(CageModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var cage = Mapper.Map<Cage>(obj);
            this.data.Cages.Add(cage);
            return Ok(obj);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var cageInDb = this.data.Cages.Find(id);
            if (cageInDb == null)
            {
                return BadRequest("No cage with given id found!");
            }
            this.data.Cages.Delete(cageInDb);
            return Ok("Cage deleted!");
        }
    }
}
