using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace iPromo.Web.Api
{
    [Produces("application/json")]
    [Route("api/FileUpload")]
    public class FileUploadController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UploadFiles(string quoteNumber)
        {
            var uploadPath = Directory.GetCurrentDirectory() + "/wwwroot/_Documents/" + quoteNumber;
            foreach (var file in Request.Form.Files)
            {
                //if directory is not avaliable create directory
                if (Directory.Exists(uploadPath) == false)
                    Directory.CreateDirectory(uploadPath);

                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploadPath, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return Ok();
        }
    }
}