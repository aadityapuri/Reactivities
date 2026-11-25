using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<List<Activity>> GetActivitiesAsync()
        {
            return await context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(string id)
        {
            var activity = await context.Activities.FindAsync(id);

            if(activity == null) return NotFound();

            return activity;
        }
    }
}