using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Taskes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TaskesController: BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Taskes>>> List(){
            return await Mediator.Send(new List.Query());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Create.Command command){
            return await Mediator.Send(command);
        }
    }
}