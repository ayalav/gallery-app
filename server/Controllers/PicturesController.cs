namespace Server.Controllers;

using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

[ApiController]
public class PicturesController : ControllerBase
{
    [HttpGet]
    [Route("/api/pictures")]
    public ActionResult<List<Picture>> GetPictures()
    {
        return GalleryService.GetPictures();
    }
}

