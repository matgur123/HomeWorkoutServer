using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWorkoutBL.Models;
namespace HomeWorkoutServer.Controllers
{
    [Route("ContactsAPI")]
    [ApiController]
    public class ContactsController: ControllerBase
    {
        #region Add connection to the db context using dependency injection;
        WorkoutDBContext context;
        public ContactsController(WorkoutDBContext context)
        {
            this.context = context;
        }
        #endregion;
    }
}
