using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelRequests.Domain.Entities;
using TravelRequests.Infrastructure.Persistence;

namespace Prueba_Tecnica_net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordResetController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PasswordResetController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/passwordreset/request
        [HttpPost("request")]
        public async Task<IActionResult> RequestReset([FromBody] string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return NotFound("Usuario no encontrado");

            var code = Guid.NewGuid().ToString().Substring(0, 6); // Código de 6 caracteres
            var resetCode = new PasswordResetCode
            {
                UserId = user.Id,
                Code = code,
                Expiration = DateTime.UtcNow.AddMinutes(10)
            };

            _context.PasswordResetCodes.Add(resetCode);
            await _context.SaveChangesAsync();

            // En un sistema real se enviaría por email
            return Ok(new { Message = "Código de recuperación generado.", Code = code });
        }

        // POST: api/passwordreset/confirm
        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmReset([FromBody] ResetPasswordDto dto)
        {
            var resetCode = await _context.PasswordResetCodes
                .Include(rc => rc.User)
                .FirstOrDefaultAsync(rc => rc.Code == dto.Code && rc.Expiration > DateTime.UtcNow);

            if (resetCode == null)
                return BadRequest("Código inválido o expirado");

            resetCode.User.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

            _context.PasswordResetCodes.Remove(resetCode); // borrar el código usado
            await _context.SaveChangesAsync();

            return Ok("Contraseña actualizada correctamente.");
        }
    }

    // DTO para resetear contraseña
    public class ResetPasswordDto
    {
        public string Code { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
