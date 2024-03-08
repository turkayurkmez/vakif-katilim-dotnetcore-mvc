using BookStore.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class UserService : IUserService
    {

        private List<User> _users = new List<User>()
        {
            new(){ Id=1, UserName="turkay", Name="Türkay Ürkmez", Password="123", Email="turkay.urkmez@dinamikzihin.com", Role="Admin"},
            new(){ Id=2, UserName="erdem", Name="Erdem Kozluk", Password="123", Email="erdem.kozluk@vakifkatilim.com", Role="Editor"},
            new(){ Id=3, UserName="armagan", Name="Armağan Göçmen", Password="123", Email="armagan.gocmen@vakifkatilim.com", Role="Client"},

        };
        public User ValidateUser(string username, string password)
        {
            return _users.SingleOrDefault(p => p.UserName == username && p.Password == password);
        }
    }
}
