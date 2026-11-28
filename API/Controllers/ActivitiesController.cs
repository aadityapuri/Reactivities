using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController() : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivitiesAsync()
        {
            return await Mediator.Send(new GetActivityList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(string id)
        {
            var activity = await Mediator.Send(new GetActivityDetails.Query()
            {
                Id = id
            });

            return activity;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateActivity(Activity activity)
        {
            var createdActivity = await Mediator.Send(new CreateActivity.Command(){Activity = activity});

            return createdActivity;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateActivity(Activity activity)
        {
            await Mediator.Send(new UpdateActivity.Command(){ Activity = activity });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(string id)
        {
            await Mediator.Send(new DeleteActivity.Command(){ Id = id });
            return Ok();
        }
    }
}