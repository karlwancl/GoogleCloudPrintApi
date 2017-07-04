using System;
using Xunit;
using System.IO;
using Newtonsoft.Json;
using GoogleCloudPrintApi.Models;
using GoogleCloudPrintApi.Models.Printer;
using static GoogleCloudPrintApi.Tests.Cdds;
using GoogleCloudPrintApi.Models.Application;

namespace GoogleCloudPrintApi.Tests
{
    public class Test
    {
		const string ClientId = "125548135131-6ge2gii5efpsc429qh9rrtst11fs170j.apps.googleusercontent.com";
		const string ClientSecret = "diYPHKvQ3VeCt_ky8LFQlvFS";
		public static readonly GoogleCloudPrintOAuth2Provider OAuth2Provider = new GoogleCloudPrintOAuth2Provider(ClientId, ClientSecret);

		public const string RefreshTokenPath = "token.txt";
		public const string ProxyPath = "proxy.txt";
        public const string CapabilitiesPath = "capabilities.txt";

        Lazy<Token> RefreshToken => new Lazy<Token>(() => JsonConvert.DeserializeObject<Token>(File.ReadAllText(RefreshTokenPath)));
        Lazy<string> Proxy => new Lazy<string>(() => File.ReadAllText(ProxyPath));
        Lazy<string> Capabilties => new Lazy<string>(() => File.ReadAllText(CapabilitiesPath));

		[Fact]
		public void CloudDeviceDescriptionToCapabilties()
		{
			Assert.Equal(Capabilties.Value, Cdd.Value.ToCapabilities());
		}

		[Fact]
        public void RegisterPrinterTest()
        {
            Cleanup();

            const string PrinterName = "MyCddPrinter";
            var printer = RegisterPrinter(PrinterName);

            Assert.Equal(PrinterName, printer.Name);
            Assert.Equal(Proxy.Value, printer.Proxy);
        }

        [Fact]
        public void GetPrinterTest()
        {
            Cleanup();

            const string PrinterName = "PrinterToGet";
            var printer = RegisterPrinter(PrinterName);

            var getRequest = new PrinterRequest { PrinterId = printer.Id };
            var client = new GoogleCloudPrintClient(OAuth2Provider, RefreshToken.Value);
            var p = client.GetPrinterAsync(getRequest).Result;

            Assert.Equal(PrinterName, p.Printers[0].Name);
        }

        [Fact]
        public void UpdatePrinterTest()
        {
            Cleanup();

            var printer = RegisterPrinter("hello");

            var updateRequest = new UpdateRequest { PrinterId = printer.Id, Name = "world" };
            var client = new GoogleCloudPrintClient(OAuth2Provider, RefreshToken.Value);
            var u = client.UpdatePrinterAsync(updateRequest).Result;

            Assert.Equal("world", u.Printer.Name);
        }

        [Fact]
        public void DeletePrinterTest()
        {
            Cleanup();

			var printer = RegisterPrinter("PrinterToDelete");
            var success = DeletePrinter(printer.Id);

            Assert.Equal(true, success);
        }

        [Fact]
        public void ListPrinterTest()
        {
            Cleanup();

            RegisterPrinter("hihi_one");
            RegisterPrinter("hihi_two");
            RegisterPrinter("hihi_three");

            var listRequest = new ListRequest() { Proxy = Proxy.Value };
            var client = new GoogleCloudPrintClient(OAuth2Provider, RefreshToken.Value);
            var lists = client.ListPrinterAsync(listRequest).Result;

            Assert.Equal(3, lists.Printers.Count);
        }

        [Fact]
        public void SearchPrinterTest()
        {
            Cleanup();

            RegisterPrinter("printerToSearch");

            var searchRequest = new SearchRequest() { Q = "^recent" };
            var client = new GoogleCloudPrintClient(OAuth2Provider, RefreshToken.Value);
            var lists = client.SearchPrinterAsync(searchRequest).Result;

            Assert.Equal(true, lists.Success);
        }

        public void Cleanup() 
        {
            // Cleanup the environment
            var listRequest = new ListRequest { Proxy = Proxy.Value };
            var client = new GoogleCloudPrintClient(OAuth2Provider, RefreshToken.Value);
            var lists = client.ListPrinterAsync(listRequest).Result;

            foreach (var p in lists.Printers)
            {
                var deleteRequest = new DeleteRequest { PrinterId = p.Id };
                var success = client.DeletePrinterAsync(deleteRequest).Result;
            }
        }

		public Printer RegisterPrinter(string name)
		{
			var request = new RegisterRequest
			{
				Name = name,
				Proxy = Proxy.Value,
				Capabilities = Cdd.Value.ToCapabilities(),
				UseCdd = true
			};
			var client = new GoogleCloudPrintClient(OAuth2Provider, RefreshToken.Value);
			return client.RegisterPrinterAsync(request).Result.Printers[0];
		}

		public bool DeletePrinter(string printerId)
		{
			var request = new DeleteRequest
			{
				PrinterId = printerId
			};
			var client = new GoogleCloudPrintClient(OAuth2Provider, RefreshToken.Value);
			return client.DeletePrinterAsync(request).Result.Success;
		}
    }
}
