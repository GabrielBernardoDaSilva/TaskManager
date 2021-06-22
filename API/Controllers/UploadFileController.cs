using System.Threading.Tasks;
using Application.FileUpload;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UploadFileController:BaseController
    {
        [HttpPost]
        public async Task<ActionResult<Unit>> Add([FromForm] Add.Command command){
            return await Mediator.Send(command);
        }
    }
}