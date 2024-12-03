using api_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_2.Models;

namespace api_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class courseController : ControllerBase
    {
        coursesContext db = new coursesContext();

        [HttpGet]
        public ActionResult getall()
        {
            List<Course> sts = db.Courses.ToList();
            if (sts.Count > 0)
                return Ok(sts);
            else
                return NotFound();
        }


        [HttpDelete("{id}")]
        public IActionResult delete(int id)
        {
            Course s = db.Courses.Where(n => n.ID == id).FirstOrDefault();
            if (s == null) return NotFound();
            db.Courses.Remove(s);
            db.SaveChanges();
            return Ok(s);
        }

        [HttpGet("{id:int}")]
        public IActionResult getbyid(int id)
        {
            Course s = db.Courses.Where(n => n.ID == id).FirstOrDefault();
            if (s == null)
                return NotFound();//404
            else
                return Ok(s);//200+student
        }
        // [HttpGet("/api/sts/{name}")]
        [HttpGet("{name}")]
        public IActionResult getbyname(string name)
        {
            Course s = db.Courses.Where(n => n.Crs_name == name).FirstOrDefault();
            if (s == null)
                return NotFound();//404
            else
                return Ok(s);//200+student
        }

        [HttpPost]
        public IActionResult add(Course s)
        {
            if (s == null) return BadRequest();
            db.Courses.Add(s);
            db.SaveChanges();
            return CreatedAtAction("getbyid", new { id = s.ID }, s);
            //    return Created($"https://localhost:7203/api/students/{s.ID}", s);
        }

        [HttpPut("{id}")]
        public IActionResult edit(int id, Course s)
        {
            if (s == null) return BadRequest();
            if (id != s.ID) return BadRequest();
            db.Entry(s).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //Student st = db.Students.Where(n => n.ID == s.ID).SingleOrDefault();
            //st.name = s.name;
            //st.age = s.age; 
            //st.adddress=s.adddress;
            //st.deptid = s.deptid;

            db.SaveChanges();
            return NoContent();
        }
    }

     
    }
