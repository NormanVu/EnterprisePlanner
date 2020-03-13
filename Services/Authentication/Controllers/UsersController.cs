using System.Threading.Tasks;
using Authentication.Contexts;
using Authentication.Models.Entities;
using Authentication.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiHelpers.Helpers;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly JsonSerializerSettings _serializerSettings;

        public UsersController(UserManager<AppUser> userManager, IMapper mapper, ApplicationDbContext appDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        // POST api/users
        [HttpPost]
        public async Task<IActionResult> Registration([FromBody]RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = _mapper.Map<AppUser>(model);

            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return new BadRequestObjectResult(Constants.Errors.AddErrorsToModelState(result, ModelState));

            await _appDbContext.AppRoles.AddAsync(new AppRoles {IdentityId = userIdentity.Id, Location = model.Location });
            await _appDbContext.SaveChangesAsync();

            var response = new
            {
                useridentity = userIdentity.Id,
                statusmessage = "User created successfully"
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);

            return new OkObjectResult(json);
        }
    }
}
