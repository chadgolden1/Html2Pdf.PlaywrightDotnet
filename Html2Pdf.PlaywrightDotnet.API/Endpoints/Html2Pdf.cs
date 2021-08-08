using Microsoft.AspNetCore.Mvc;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace Html2Pdf.PlaywrightDotnet.API.Endpoints.Html2Pdf
{
    [ApiController]
    [Route("[controller]")]
    public class Html2PdfController : ControllerBase
    {
        private readonly Html2PdfConversionService _conversionService;

        public Html2PdfController(Html2PdfConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost]
        public async Task<IActionResult> Convert([FromBody] Html2PdfConversionRequest request)
        {
            var pdf = await _conversionService.Html2Pdf(request.Html);
            return File(pdf, "application/pdf", Guid.NewGuid().ToString() + ".pdf");
        }
    }

    public class Html2PdfConversionService
    {
        private static readonly IBrowser _browser;

        static Html2PdfConversionService()
        {
            var playwright = Playwright.CreateAsync().GetAwaiter().GetResult();
            _browser = playwright.Chromium.LaunchAsync().GetAwaiter().GetResult();
        }

        public async Task<byte[]> Html2Pdf(string html)
        {
            IBrowserContext context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                JavaScriptEnabled = false
            });
            IPage page = await context.NewPageAsync();
            try
            {
                await page.SetContentAsync(html);
                byte[] bytes = await page.PdfAsync();
                return bytes;
            }
            finally
            {
                await context.CloseAsync();
            }
        }
    }

    public class Html2PdfConversionRequest
    {
        public string Html { get; set; }
    }
}
