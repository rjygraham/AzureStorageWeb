# AzureStorageWeb

This is a File -> New Project of an ASP.NET MVC web app and provides capabilities to create, list, and read blobs within an Azure Storage account.

## Usage

For local development/testing, you can use Storage Account Emulator or an Azure Storage Account. For Storage Emulator, change the constructor initializing `BlobServiceClient` on line 16 of `HomeController` to `"UseDevelopmentStorage=true"`.

Otherwise, for using an actual Azure Storage Account, replace the `<storageaccount>` on line 16 of `HomeController` and assign the `Storage Blob Contributor` role assignment to the appopriate identity:

- Local: Assign your user account `Storage Blob Contributor` role assignment on the Storage account and then follow these instructions for enabling Visual Studio to authenticate the application using your credentials: [Authenticating via Visual Studio](https://docs.microsoft.com/en-us/dotnet/api/overview/azure/identity-readme#authenticating-via-visual-studio)
- Azure: Enable system or user assigned managed identity on your App Service and assign that identity  `Storage Blob Contributor` role assignment on the Storage account.

## License

The MIT License (MIT)

Copyright © 2020 Ryan Graham

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.