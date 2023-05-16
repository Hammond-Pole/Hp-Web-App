using Microsoft.AspNetCore.Mvc;

namespace Hp_Web_App.Client.Authentication;

public class TokenController : Controller
{
    private readonly IUserService _userService;

    public TokenController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("validate/{token}")]
    public async Task<IActionResult> ValidateToken(string token)
    {
        var _result = await _userService.VerifyToken(token);

        if (_result)
        {
            var user = await _userService.GetUserbyTokenAsync(token);
            user.IsActive = true;
            return Redirect("/login/" + token.ToString());
        }
        else
        {
            return BadRequest();
        } 
            
    }
}