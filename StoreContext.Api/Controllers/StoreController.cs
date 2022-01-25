using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreContext.Api.Dtos.Requests;
using StoreContext.Domain.Entities;
using StoreContext.Domain.Repositories;

namespace StoreContext.Api.Controllers
{
    [ApiController]
    [Route("v1/stores")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [HttpGet]
        public async Task<List<Store>> GetAll()
        {
            return await _storeRepository.GetAllAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Store> GetById(int id)
        {
            return await _storeRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateStoreRequest request)
        {
            Store store = new Store(request.Name);
            await _storeRepository.SaveAsync(store);
            return Created("/myUri", store);
        }
    }
}