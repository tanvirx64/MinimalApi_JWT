using MinimalApi_JWT.Models;

namespace MinimalApi_JWT.Repositories
{
    public class UserRepository
    {
        public static List<User> users= new List<User>() 
        { 
            new (){ Username="tanvir_admin",EmailAddress="tanvir@gmail.com", GivenName="Tanvir", Surname="Ahmed", Password="MyPass_w0rd", Role="Administrator" },
            new (){ Username="rakib_standard",EmailAddress="rakib@gmail.com", GivenName="Rakib", Surname="Rahman", Password="MyPass_w0rd", Role="Standard" },
        };
    }
}
