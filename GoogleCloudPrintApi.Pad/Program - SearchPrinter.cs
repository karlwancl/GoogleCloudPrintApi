using GoogleCloudPrintApi.Models.Application;
using System;

namespace GoogleCloudPrintApi.Pad
{
    internal partial class Program
    {
        private static void SearchPrinter()
        {
            var client = new GoogleCloudPrintClient(provider, token);
            var request = new SearchRequest()
            {
                Q = "^recent"
            };
            var result = client.SearchPrinterAsync(request).Result;
            Console.WriteLine("Success: {0}", result.Success);
            Console.WriteLine("Search Result: ");
            foreach (var printer in result.Printers)
            {
                Console.WriteLine(printer.Name);
            }
        }

        private static void GetUserProfile()
        {
            var client = new GoogleCloudPrintClient(provider, token);
            var userProfile = client.GetUserProfileAsync().Result;
            Console.WriteLine("GivenName: {0}, Email: {1}, Picture: {2}, Link: {3}", userProfile.GivenName, userProfile.Email, userProfile.Picture, userProfile.Link);
        }
    }
}