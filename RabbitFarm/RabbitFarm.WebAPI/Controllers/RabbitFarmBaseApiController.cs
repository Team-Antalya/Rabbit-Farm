namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;
    using System;
    using System.Collections.Generic;

    using AutoMapper;

    using RabbitFarm.Data;
    using RabbitFarm.WebAPI.Infrastructure;
    using RabbitFarm.Data.Repositories;

    [Authorize]
    public class RabbitFarmBaseApiController<I, O> : ApiController
        where I : class
        where O : class
    {
        private string inputTypeName = typeof(I).Name;
        protected IRabbitFarmData data;
        protected IUserProvider userProvider;

        public RabbitFarmBaseApiController(IRabbitFarmData data, IUserProvider userProvider)
        {
            this.data = data;
            this.userProvider = userProvider;
        }

        [AllowAnonymous]
        [HttpGet]
        public virtual IHttpActionResult All()
        {
            var inputModelObjects = GetDataProperty(inputTypeName).All();
            var outputModelObjects = Mapper.Map<ICollection<O>>(inputModelObjects);

            return Ok(outputModelObjects);
        }

        [HttpGet]
        public virtual IHttpActionResult Get(int id)
        {
            var inputModelObject = GetDataProperty(inputTypeName).Find(id);
            if (inputModelObject == null)
            {
                return BadRequest(String.Format("No {0} with this id!", inputTypeName));
            }
            var outputModelObject = Mapper.Map<O>(inputModelObject);
            return Ok(outputModelObject);
        }

        [HttpPost]
        public virtual IHttpActionResult Add(O obj)
        {
            var inputModelObject = Mapper.Map<I>(obj);
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            GetDataProperty(inputTypeName).Add(inputModelObject);
            this.data.SaveChanges();
            return Ok(obj);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(int id)
        {
            var inputModelObject = GetDataProperty(inputTypeName).Find(id);
            if (inputModelObject == null)
            {
                return BadRequest(String.Format("No {0} with the given id found!", inputTypeName));
            }
            GetDataProperty(inputTypeName).Delete(inputModelObject);
            this.data.SaveChanges();
            return Ok(String.Format("{0} deleted!", inputTypeName));
        }

        private IRepository<I> GetDataProperty(string inputTypeName)
        {
            var prop = this.data.GetType().GetProperty(inputTypeName + "s");
            return (IRepository<I>)prop.GetValue(data);
        }
    }
}