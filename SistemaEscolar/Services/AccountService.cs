using SitemaUnicesumar.Entities;
using SitemaUnicesumar.Models;
using System.Linq;

namespace SitemaUnicesumar.Services
{
    public class AccountService
    {
        public UserViewModel AuthUser(LoginViewModel viewModel)
        {
            using (var context = new SchoolEntities())
            {
              var userData = context.ListUser
                    .Where(p => p.Email == viewModel.Email && p.Password == viewModel.Password)
                    .Select(p => new UserViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Email = p.Email
                    })
                    .FirstOrDefault();

                return userData;
            }
        }
    }
}