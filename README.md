# GoogleCloudPrintApi
[![Build status](https://ci.appveyor.com/api/projects/status/anj9864jo6fhg871?svg=true)](https://ci.appveyor.com/project/lppkarl/googlecloudprintapi)
[![NuGet](https://img.shields.io/nuget/v/GoogleCloudPrintApi.svg)](https://www.nuget.org/packages/GoogleCloudPrintApi/)
[![license](https://img.shields.io/github/license/lppkarl/GoogleCloudPrintApi.svg)](https://github.com/lppkarl/GoogleCloudPrintApi/blob/master/LICENSE)

A .NET wrapper for Google Cloud Print API. This library is based on .NET standard 1.4, can be run on .NET Core, .NET Framework, Xamarin.iOS, Xamarin.Android & Universal Windows Platform.

### Features
* Allows printer registration to Google Cloud
* Allows printer manipulation on Google Cloud
* Allows printer search on Google Cloud (Thanks to [@elacy](https://github.com/elacy) for providing the search implementation)
* Allows job retrieval from Google Cloud
* Allows printer sharing to Google Accounts
* Allows subscribing to new job notification from Google Cloud (Thanks to [@Jezternz](https://github.com/Jezternz) for providing the xmpp implementation)
* Allows job submission to Google Cloud (Thanks to [@elacy](https://github.com/elacy) for providing the submission implementation)

### Supported Platforms
* .NET Core 1.0
* .NET framework 4.6.1 or above
* Xamarin.iOS
* Xamarin.Android
* Universal Windows Platform

### How To Install
You can find the package through Nuget

	PM> Install-Package GoogleCloudPrintApi

### How To Use

* Initialization
	* [Using the library](#UsingTheLibrary)
	* [First Time Token Generation](#FirstTimeTokenGeneration)
	* [Initialize Google Cloud Print Client](#InitializeGoogleCloudPrintClient)
	* [Subscribe To Job Notification](#SubscribeToJobNotification)

* Printer Management
	* [Register Printer](#RegisterPrinter)
	* [List Printers](#ListPrinters)
	* [Get Printer Information](#GetPrinterInformation)
	* [Update Printer](#UpdatePrinter)
	* [Delete Printer](#DeletePrinter)
	* [Search Printer](#SearchPrinter)

* Job Management
	* [Download Printed Job](#DownloadPrintedJob)
	* [Submit Print Job](#SubmitPrintJob)

* Sharing/Unsharing
	* [Share Printer to Google User](#SharePrinter)
	* [Unshare Printer to Google User](#UnsharePrinter)

* Misc
	* [Customized Web Call Using Internal Access Token](#CustomizedCall)
	* [Create Cloud Device Description (CDD) for printer registration](#Cdd)]

<a name="UsingTheLibrary"></a>
#### Using the Library
	// Add the following statement on top of the file
	using GoogleCloudPrintApi;

<a name="FirstTimeTokenGeneration"></a>
#### First-time token generation
	var provider = new GoogleCloudPrintOAuth2Provider(clientId, clientSecret);

	// You should have your redirect uri here if your app is a server application, o.w. leaving blank is ok
	var url = provider.BuildAuthorizationUrl(redirectUri);

	/* Your method to retrieve authorization code from the above url */
	var token = await provider.GenerateRefreshTokenAsync(authorizationCode, redirectUri);
	
<a name="InitializeGoogleCloudPrintClient"></a>
#### Initialize Google Cloud Print Client
	var client = new GoogleCloudPrintClient(provider, token);

	// You can also subscribe to the OnTokenUpdated event for token update notification
	client.OnTokenUpdated += (sender, e) => 
	{
		// Do what you want with the updated token (Save the new token/ log, etc.)
	};

<a name="SubscribeToJobNotification"></a>
#### Subscribe job notification
	// You can subscibe to job notification by the following steps
	client.OnIncomingPrintJobs += (sender, e) => Console.WriteLine(e.PrinterId);
	await client.InitXmppAsync(<Your xmppJid here, e.g. 'admin' for 'admin@gmail.com'>);

	// Also, you can terminate the subscription by using the StopXmppAndCleanUp method
	client.StopXmppAndCleanUp();

<a name="RegisterPrinter"></a>
#### Register printer
	var request = new RegisterRequest
	{
		Name = name,
		Proxy = proxy,
		Capabilities = capabilities,
		UseCdd = true	// If you're using the old xps format, you should ignore this property. o.w. it's required to set true. For more info on cdd format, please refer to "Create Cloud Device Description (CDD) for printer registration" topic
	};
	var response = await client.RegisterPrinterAsync(request);
	
<a name="ListPrinters"></a>
#### List printers
	var request = new ListRequest { Proxy = proxy };
	var response = await client.ListPrinterAsync(request);
	
<a name="GetPrinterInformation"></a>
#### Get printer information
	var request = new PrinterRequest { PrinterId = printerId };
	var response = await client.GetPrinterAsync(request);
	
<a name="UpdatePrinter"></a>
#### Update printer
	var request = new UpdateRequest
	{
		PrinterId = printerId,
		Name = nameToUpdate
	};
	var response = await client.UpdatePrinterAsync(request);

<a name="DeletePrinter"></a>
#### Delete printer
	var request = new DeleteRequest { PrinterId = printerId };
	var response = await client.DeletePrinterAsync(request);

<a name="SearchPrinter"></a>
#### Search Printer
	// ^recent for recent used printers, ^own for printer owned by, ^shared for printer shared with user
	var request = new SearchRequest { Q = "^recent" };
	var response = await client.SearchPrinterAsync(request);
	
<a name="DownloadPrintedJob"></a>
#### Download printed job
	// Retrieve printed job list
	var fetchRequest = new FetchRequest { PrinterId = printerId };
	var fetchResponse = await client.FetchJobAsync(fetchRequest);
	var printJobs = fetchResponse.Jobs;
	
	// Select a printed job
	var printJob = printJobs.ElementAt(i);
	
	// Download and process ticket for the printed job

	// For printer with XPS capabilities
	var ticket = await client.GetTicketAsync(printJob.TicketUrl, proxy);

	// For printer with CDD capabilities
	var request = new TicketRequest
	{
		JobId = printJob.Id
	};
	var ticket = await client.GetCloudJobTicketAsync(request);

	/* Your method to process the ticket */
	
	// Download and save the document (in pdf format) for the printed job
	using (var documentStream = await client.GetDocumentAsync(printJob.FileUrl, proxy))
	using (var fs = File.Create(/* Your path for the document */))
	{
		documentStream.CopyTo(fs);
	}
	
	// Notify Google the printed job has completed processing
	var controlRequest = new ControlRequest
	{
		JobId = printJob.Id,
		Status = Models.Job.LegacyJobStatus.DONE
	};
	var controlResponse = await client.UpdateJobStatusAsync(controlRequest);
		
	/* Please notice that the FetchJobAsync call will behave as follows:
	
		1. If the printer does not exist in Google Cloud, throws "No print job available on specified printer." exception
		2. If there is no print job in the queue, throws "No print job available on specified printer." exception
		3. If there is job available in the queue, returns the job list.
		
	If you'd like to distinguish the difference between case 1 & 2, you'd be better off calling GetPrinterAsync before this method. It will throw you "The printer is not found" exception if the printer does not exist.
	*/

<a name="SubmitPrintJob"></a>
#### Submit Print Job
	// Create a cloud job ticket first, it contains the printer setting of the document
	var cjt = new CloudJobTicket
	{
		Print = new PrintTicketSection
		{
			Color = new ColorTicketItem { Type = Color.Type.STANDARD_MONOCHROME },
			Duplex = new DuplexTicketItem { Type = Duplex.Type.LONG_EDGE },
			PageOrientation = new PageOrientationTicketItem { Type = PageOrientation.Type.LANDSCAPE },
			Copies = new CopiesTicketItem { Copies = 3 }
		}
	};

	// Create a request for file submission, you can either submit a url with SubmitFileLink class, or a local file with SubmitFileStream class
	var request = new SubmitRequest
	{
		PrinterId = printer.Id,
		Title = title,
		Ticket = cjt,
		Content = new SubmitFileLink(url) // or new SubmitFileStream(contentType, fileName, fileStream)
	};

	// Submit request
	var response = await client.SubmitJobAsync(request);

<a name="SharePrinter"></a>
#### Share printer to Google User
	var request = new ShareRequest
	{
		PrinterId = printerId,
		Scope = /* Google account you want to share to */,
		Role = Role.USER
	};
	var response = await client.SharePrinterAsync(request);

<a name="UnsharePrinter"></a>
#### Unshare printer from Google User
	var request = new UnshareRequest
	{
		PrinterId = printerId,
		Scope = /* Google account you want to unshare from */
	};
	var response = await client.UnsharePrinterAsync(request);
	
<a name="CustomizedCall"></a>
#### Customized Web Call Using the Internal Access Token
	var googClient = new GoogleCloudPrintClient(provider, token);
	using (var client = new HttpClient())
	{
		client.DefaultRequestHeaders.Add("X-CloudPrint-Proxy", proxy);
		var accessToken = (await googClient.GetTokenAsync()).AccessToken;
		client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
		using (var response = await client.GetAsync(/* some uri */))
		{
			/* Do what you want here for the response */		
		}
	}

<a name="Cdd"></a>
#### Create Cloud Device Description (CDD) for printer registration
	// You can define your printer's capabilities by creating a cdd document for it
	var cdd = new CloudDeviceDescription
	{
		Version = "1.0",
		Printer = new PrinterDescriptionSection
		{
			SupportedContentType = new List<SupportedContentType>
			{
				new SupportedContentType{ ContentType = "application/pdf", MinVersion = "1.5"},
				new SupportedContentType{ ContentType = "image/jpeg"},
				new SupportedContentType{ ContentType = "text/plain"}
			},
			InputTrayUnit = new List<InputTrayUnit>
			{
				new InputTrayUnit{ VendorId ="tray", Type = InputTrayUnit.TypeType.INPUT_TRAY}
			},
			Marker = new List<Marker>
			{
				new Marker{ VendorId = "black", Type = Marker.TypeType.INK, Color = new Marker.ColorType{ Type = Marker.ColorType.TypeType.BLACK}},
				new Marker{ VendorId= "color", Type = Marker.TypeType.INK, Color = new Marker.ColorType{ Type = Marker.ColorType.TypeType.COLOR}}
			},
			Cover = new List<Cover>
			{
				new Cover{VendorId = "front", Type = Cover.TypeType.CUSTOM, CustomDisplayName = "front cover"}
			},
			VendorCapability = new List<VendorCapability>(),
			Color = new Color
			{
				Option = new List<Color.OptionType> {
					new Color.OptionType {Type = Color.Type.STANDARD_MONOCHROME},
					new Color.OptionType {Type = Color.Type.STANDARD_COLOR, IsDefault = true},
					new Color.OptionType{VendorId = "ultra-color", Type = Color.Type.CUSTOM_COLOR, CustomDisplayName = "Best Color"}
				}
			},
			Copies = new Copies { Default = 1, Max = 100 },
			MediaSize = new MediaSize
			{
				Option = new List<MediaSize.OptionType>
				{
					new MediaSize.OptionType{ Name = MediaSize.Name.ISO_A4, WidthMicrons = 210000, HeightMicrons = 297000, IsDefault = true},
					new MediaSize.OptionType{Name = MediaSize.Name.NA_LEGAL, WidthMicrons = 215900, HeightMicrons = 355600},
					new MediaSize.OptionType{Name = MediaSize.Name.NA_LETTER, WidthMicrons = 215900, HeightMicrons = 279400}
				}
			}
		}
	} 

	// The above cdd is equivalent to the example found in 
	https://developers.google.com/cloud-print/docs/cdd#cdd

	// After you get your cdd here, you may register the printer with it using
	var request = new RegisterRequest
	{
		Name = name,
		Proxy = proxy,
		Capabilities = cdd.ToCapabilities(),
		UseCdd = true
	};
	var response = await client.RegisterPrinterAsync(request);


### Powered by
* [Flurl](https://github.com/tmenier/Flurl) ([@tmenier](https://github.com/tmenier)) - A very nice fluent-style rest api library

### Reference
[Google Cloud Print API Reference](https://developers.google.com/cloud-print/docs/proxyinterfaces)