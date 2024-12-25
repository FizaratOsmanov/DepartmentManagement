﻿using DepartmentApp.BL.DTOs.AppUserDTOs;
using DepartmentApp.BL.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        readonly IAuthService _service;
        public AccountsController(IAuthService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            ICollection<AppUserCreateDTO> users = await _service.GetAllUsersAsync();
            return Ok(users);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneUser(string user)
        {

            AppUserCreateDTO dto = await _service.GetOneUserAsync(user);
            return Ok(dto);


        }


        [HttpGet]
        [Route("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return BadRequest("Invalid email confirmation request.");
            }


            var result = await _service.ConfirmEmailAsync(userId, token);
            if (result)
            {
                return Ok("Email confirmed successfully.");
            }

            return BadRequest("Email confirmation failed.");

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(AppUserCreateDTO dto)
        {
            await _service.RegisterAsync(dto);
            return Ok();
        }



        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid input.");
            }
                await _service.ChangePasswordAsync(dto.Email, dto.OldPassword, dto.NewPassword);
                return Ok();
        }
    }
}