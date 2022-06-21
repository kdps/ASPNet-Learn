namespace Example.Controllers
{
    public class ApiController : ControllerBase
    {
        public ApiController(UserManager<UserStore> userManager, SignInManager<UserStore> signInManager, ILogger<ApiController> logger, IHostingEnvironment env)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        
        [HttpGet | HttpPost | HttpPost("{argument}") | HttpPut...]
        public void VoidAction()
        {
        }

        public IActionResult ResultAction()
        {
            // File Output
            string filePath = Path.Combine(_env.WebRootPath, "images", "test.jpg");
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/force-download", fileName);
            
            // StatusCode
            return StatusCode(200, "Code");
            
            // Redirect
            return RedirectToPage("/URL");
        }
    }
}
