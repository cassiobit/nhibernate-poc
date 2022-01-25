using StoreContext.Domain.Entities;

namespace StoreContext.Api.Dtos.Requests
{
    public class CreateEmployeeRequest
    {
        public string Name { get; set; }
        public Store Store { get; set; }
    }
}