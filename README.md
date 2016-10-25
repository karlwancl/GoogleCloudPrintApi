# GoogleCloudPrintApi (Beta)
A .NET wrapper for Google Cloud Print API, currently supports only Google Cloud Print 1.0. This library is based on .NET standard 1.1, supports .NET Core, .NET Framework, Xamarin.iOS, Xamarin.Android & Universal Windows Platform.

### Features
* Allows printer registration to Google Cloud
* Allows printer manipulation on Google Cloud
* Allows printer sharing to Google Accounts
* Allows job retrieval from Google Cloud

### Supported Platforms
* .NET Core 1.0 or above
* .NET framework 4.5 or above
* Xamarin.iOS
* Xamarin.Android
* Universal Windows Platform

### How To Use

#### First-time token generation
	var provider = new GoogleCloudPrintOAuth2Provider(clientId, clientSecret);
	var url = provider.BuildAuthorizationUrl();
	/* Your method to retrieve authorization code from the above url */
	var token = await provider.GenerateRefreshTokenAsync(authorizationCode);
	

#### Initialize Google Cloud Print Client
	var client = new GoogleCloudPrintClient(provider, token);
	
#### Register printer to Google Cloud
	var request = new RegisterRequest
	{
		Name = name,
		Proxy = proxy,
		Capabilities = capabilities
	};
	var response = await client.RegisterPrinterAsync(request);
	
#### List printers from Google Cloud
	var request = new ListRequest { Proxy = proxy };
	var response = await client.ListPrinterAsync(request);
	
#### Update printer from Google Cloud
	var request = new UpdateRequest
	{
		PrinterId = printerId,
		Name = nameToUpdate
	};
	var response = await client.UpdatePrinterAsync(request);
	
#### Delete printer from Google Cloud
	var request = new DeleteRequest { PrinterId = printerId };
	var response = await client.DeletePrinterAsync(request);
	
#### Fetch print job from Google Cloud
Under construction

#### Get ticket document for print job
Under construction

#### Get print job from Google Cloud
Under construction

#### Update print job status
Under construction

#### Share printer to Google User
Under construction

#### Unshare printer from Google User
Under construction

### Reference
[Google Cloud Print API Reference](https://developers.google.com/cloud-print/docs/proxyinterfaces)
	
	
