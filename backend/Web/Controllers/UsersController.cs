using Domain.Entities;
using Infra.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICrudRepository<User> _userCrudRepo;

        public UsersController(ICrudRepository<User> userCrudRepo) => _userCrudRepo = userCrudRepo;

        [HttpPost]
        public ActionResult<UserDTO> Post(User user)
        {
            try
            {
                _userCrudRepo.Create(user);
                var saved = _userCrudRepo.Commit() > 0;
                if (saved) return CreatedAtAction(nameof(GetById), new { id = user.Id }, new UserDTO(user));
                return BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public ActionResult<UserDTO> Put(User user)
        {   
            try
            {
                _userCrudRepo.Update(user);
                var updated = _userCrudRepo.Commit() > 0;
                if (updated) return NoContent();
                return BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetById(int id)
        {
            var user = _userCrudRepo.Read(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> Delete(int id)
        {
            var user = _userCrudRepo.Read(id);
            if (user == null) return NotFound();

            try
            {
                _userCrudRepo.Delete(user);
                var deleted = _userCrudRepo.Commit() > 0;
                if (deleted) return Ok();
                return BadRequest();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public ActionResult<UserDTO> GetAll()
        {
            var users = _userCrudRepo.Read();
            return Ok(users);
        }
    }
}
