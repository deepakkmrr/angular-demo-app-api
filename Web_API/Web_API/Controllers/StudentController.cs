using AutoMapper;
using Demo.Database.Model;
using Demo.Database.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.DTOModels;

namespace Web_API.Controllers
{
    [Route("api/student")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Student")]
    [ApiController]
    //[Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository StudentRepository;
        private readonly IMapper Mapper;

        public StudentController(IStudentRepository studentRepository,
            IMapper mapper)
        {
            this.StudentRepository = studentRepository;
            this.Mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await this.StudentRepository.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetStudentCount()
        {
            try
            {
                var count = await this.StudentRepository.StudentCount();
                return Ok(count);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddStudent([FromBody] DTOStudent student)
        {
            try
            {
                var dbStudent = Mapper.Map<Student>(student);
                var result  = await this.StudentRepository.AddStudent(dbStudent);
                if (result)
                    return Ok("Student added successfully!");
                else
                    return BadRequest("Error adding student!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateStudent([FromBody] DTOStudent student)
        {
            try
            {
                var dbStudent = Mapper.Map<Student>(student);
                var result = await this.StudentRepository.UpdateStudent(dbStudent);
                if (result)
                    return Ok("Student updated successfully!");
                else
                    return BadRequest("Error updating student!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("remove/{id}")]
        public async Task<IActionResult> RemoveStudent(Guid id)
        {
            try
            {
                var result = await this.StudentRepository.RemoveStudent(id);
                if (result)
                    return Ok("Student removed successfully!");
                else
                    return BadRequest("Error removing student!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
