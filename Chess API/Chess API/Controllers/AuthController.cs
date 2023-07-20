using Chess_API.Models;
using Chess_API.Security;
using Chess_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Chess_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly JwtConverter _converter;
        private readonly UserManager<AppUser> _userManager;
        private readonly PlayerService _playerService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(
            SignInManager<AppUser> signInManager,
            JwtConverter converter,
            UserManager<AppUser> userManager,
            PlayerService playerService,
            ILogger<AuthController> logger)
        {
            _signInManager = signInManager;
            _converter = converter;
            _userManager = userManager;
            _playerService = playerService;
            _logger = logger;
        }

        [HttpPost("create_account")]
        public async Task<IActionResult> CreateAccount([FromBody] Dictionary<string, string> credentials)
        {
            try
            {
                string username = credentials["username"];
                string password = credentials["password"];

                var appUser = new AppUser { UserName = username };
                var createResult = await _userManager.CreateAsync(appUser, password);

                if (!createResult.Succeeded)
                {
                    return BadRequest(new { message = string.Join(", ", createResult.Errors) });
                }

                string firstName = credentials["firstName"];
                string lastName = credentials["lastName"];
                string email = credentials["email"];
                PlayerProfile playerProfile = new PlayerProfile
                {
                    ProfileId = appUser.Id,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PlayerStats = new PlayerStats()
                };
                _playerService.UpdatePlayer(playerProfile);

                var responseData = new Dictionary<string, int>
                {
                    { "appUserId", appUser.Id }
                };

                return CreatedAtAction(nameof(CreateAccount), responseData);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidDataException e)
            {
                _logger.LogError(e, "Error occurred while creating account.");
                return StatusCode(500, new { message = "An internal server error occurred" });
            }
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Dictionary<string, string> credentials)
        {
            try
            {
                string username = credentials["username"];
                string password = credentials["password"];

                var signInResult = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    var appUser = await _userManager.FindByNameAsync(username);
                    string jwtToken = _converter.GetTokenFromUser(appUser);

                    var responseData = new Dictionary<string, string>
                    {
                        { "jwt_token", jwtToken }
                    };

                    return Ok(responseData);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during authentication.");
            }

            return Forbid();
        }
    }
}
