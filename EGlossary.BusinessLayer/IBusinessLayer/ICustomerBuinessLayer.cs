using EGlossary.BusinessLayer.Models;

namespace EGlossary.BusinessLayer.IBusinessLayer
{
    public interface ICustomerBuinessLayer
    {
        Task<List<CategoryViewModel>> GetLandingDetails();

        Task<object> GetCustomers();
    }
}