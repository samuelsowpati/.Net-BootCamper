using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    //BaseApiController is a base class for all API controllers
    //it is used to define a common route prefix for all API controllers
    //ActivitiesController will derive from this class
    //so it will inherit the route prefix and other common functionality
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

    }
}
