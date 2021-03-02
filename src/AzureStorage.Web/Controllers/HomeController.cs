using Azure.Identity;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AzureStorage.Web.Controllers
{
	public class HomeController : Controller
	{
		private static Lazy<BlobContainerClient> client = new Lazy<BlobContainerClient>
			(() =>
			{
				var blobServiceClient = new BlobServiceClient(new Uri("https://<storageaccount>.blob.core.windows.net/"), new DefaultAzureCredential());
				var blobContainerClient = blobServiceClient.GetBlobContainerClient("input");
				blobContainerClient.CreateIfNotExists();
				return blobContainerClient;
			});

		public async Task<ActionResult> Index()
		{
			ViewBag.Title = "Home Page";

            var blobs = new HashSet<string>();

            await foreach (var blobItem in client.Value.GetBlobsAsync())
            {
                blobs.Add(blobItem.Name);
            }

			return View(blobs);
		}

        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    var info = await client.Value.UploadBlobAsync(file.FileName, file.InputStream);
                }
                catch (Exception ex)
                {
                    // Handle exctpion and do something.
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Download(string fileName)
        {
			try
			{
                var blobClient = client.Value.GetBlobClient(fileName);

                var blobExistsResult = await blobClient.ExistsAsync();

                if (!blobExistsResult.Value)
                {
                    return HttpNotFound();
                }

                var stream = await blobClient.OpenReadAsync();
                return File(stream, "application/octet-stream", fileName);
            }
			catch (Exception)
			{
                // Handle exctpion and do something.
            }

            return HttpNotFound();
        }
    }
}
