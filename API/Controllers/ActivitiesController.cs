using System;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;
//The activities are displayed from when accessing via api/activities
//this controller is named ActivitiesController, so the route is api/activities

//deriving from BaseApiController allows us to use the same route prefix
//we are using primary constructor syntax to inject the AppDbContext instead of using dependency injection in the constructor
//which allows us to 
//use a constructor parameter to automatically create a private field for the parameter
//this way we can use the context in the controller methods without having to create a private field i.e.
//private readonly AppDbContext _context;

public class ActivitiesController(AppDbContext context) : BaseApiController
{

    //what is Task<ActionResult<List<Activity>>>?
    //Task represents an asynchronous operation
    //ActionResult is a type that represents the result of an action method
    //List<Activity> is the type of data we are returning, in this case a list of Activity objects

    [HttpGet]
    //the above square brackets maps the method to the HTTP GET request
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        //returning the activities from the database
        return await context.Activities.ToListAsync();
    }


    [HttpGet("{id}")]

    //the id parameter in the below method should match the route parameter in the HttpGet attribute
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        if (activity == null)
            //returns a 404 Not Found response if the activity is not found
            //NotFound() method is part of the ActionResult type
            return NotFound();

        return activity;
    }
}
