using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using University.API.Data;
using University.API.Models.Dtos;
using University.API.Models.Entities;

namespace University.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class StudentsController : ControllerBase
    {

        private readonly UniversityContext _context;
        private readonly IMapper mapper;

        public StudentsController(UniversityContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
            //var c = _context.Course.Where(c => c.Title.StartsWith("Hej"));
            //var s = _context.Student.ToList();
            //var b = _context.Book.Include(b => b.Author);
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudent(bool includeCourses = false)
        {
            //Not Address
            // return await _context.Student.ToListAsync();

            //Include Address
            //return await _context.Student.Include(s => s.Address).ToListAsync();

            //Transform to DTO, no need for include!
            // var dto = includeCourses ? "" : "";

            var dto = _context.Student/*.Include(s => s.Address)*/.Select(s => new StudentDto(s.Id, s.FullName, s.Avatar, s.Address.City));

            return Ok(await dto.ToListAsync());

        }

        // GET: api/Students/5
        [HttpGet("{id:int}", Name = "RouteNameForGetOne")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentDetailsDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [SwaggerOperation(Summary = "Get a student by id", Description = "Get a student by id", OperationId = "GetStudentById")]
        [SwaggerResponse(StatusCodes.Status200OK, "The student was found", Type = typeof(StudentDetailsDto))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "The student was not found")]
        public async Task<ActionResult<StudentDetailsDto>> GetStudent(int id)
        {

            //var r1 = await _context.Student.Include(s => s.Enrollments).ThenInclude(e => e.Course).ToListAsync();
            //var r2 = await _context.Course.Include(c => c.CourseBooks).ToListAsync();

            //var dto = await _context.Student
            //    .Where(s => s.Id == id)
            //    .Select(s => new StudentDetailsDto
            //    {
            //        Id = s.Id,
            //        AddressCity = s.Address.City,
            //        Avatar = s.Avatar,
            //        Courses = s.Enrollments.Select(e => new CourseDto(e.Course.Title, e.Grade)),
            //        FullName = s.FullName
            //    })
            //   .FirstOrDefaultAsync();


            var dto = await mapper.ProjectTo<StudentDetailsDto>(_context.Student.Where(s => s.Id == id)).FirstOrDefaultAsync();
            
            //var dto = await _context.Student
                                     //.Where(s => s.Id == id)
                                     //.ProjectTo<StudentDetailsDto>(mapper.ConfigurationProvider)
                                     //.FirstOrDefaultAsync();

            if (dto == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }


            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(StudentCreateDto dto)
        {
            var student = mapper.Map<Student>(dto);

            _context.Student.Add(student);
            await _context.SaveChangesAsync();

            var studentDto = mapper.Map<StudentDto>(student);

            return CreatedAtAction(nameof(GetStudent), new { id = studentDto.Id }, studentDto);
        }

        // DELETE: api/Students/5
        /// <summary>
        /// Deleta a student row from the database
        /// </summary>
        /// <param name="id">The id of the student to delete</param>
        /// <returns>An HTTP 204 No Content response successfully deleted</returns>
        /// <response code="204">The student was deleted</response>
        /// <response code="404">The student was not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Student.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
    }
}
