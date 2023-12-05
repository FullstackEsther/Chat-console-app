using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Context;
using MyProject.Model;
using MyProject.Repository.Implementation;
using MyProject.Repository.Interface;
using MyProject.Service.Interface;

namespace MyProject.Service.Implementation
{
    public class ProfileService : IProfileService
    {
        IProfileRepository profileRepository = new ProfileRepository();

        public void Create(Profile obj)
        {
            var id = ListContext.ProfileDb.Count+1;
           Profile profile = new Profile(id, obj.Age, obj.FirstName, obj.UserEmail, obj.LastName, obj.Address, obj.PhoneNumber, obj.IsDeleted);
           profileRepository.Create(profile);
        }

        public Profile Get(string email)
        {
           var get = profileRepository.Get(email);
           if (get == null)
           {
                System.Console.WriteLine("The profile doesn't exist");
                return null;
            }
            return get;
        }

        public void Update(Profile obj)
        {
          var update = profileRepository.Update(obj);
          if (update)
          {
            System.Console.WriteLine("Updated");
          }
          
        }

         public void Delete(string email)
        {
            profileRepository.Delete(email);
        }

    }
}