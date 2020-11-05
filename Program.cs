using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IMDBDataService.Objects;
using IMDBDataService.Repositories;

namespace IMDBDataService
{
    class Program
    {
        static void Main()
        {
            DataService dataService = new DataService();

            var response3 = dataService.CreateUser("jakob2", "jakob2", "jakob2", "jakob");

            Console.WriteLine(response3.Result.user_name);

            var response4 = dataService.UpdateUser(response3.Result.user_id, "jakobi");
            Console.WriteLine(response4.Result.user_name);
            Console.WriteLine(dataService.GetUserById(1).Result.Comments.Count);
            var response = dataService.GetAllUsers().Result;
            Console.WriteLine(response.Count);
            Console.WriteLine(response.First().user_name);
            Console.WriteLine(response.Last().user_name);

            var response5 = dataService.DeleteUser(response3.Result.user_id);
            Console.WriteLine(response5.Result);

            var response2 = dataService.GetAllTitles().Result;
            Console.WriteLine(response2.First().primary_title);

        }
    }
}
