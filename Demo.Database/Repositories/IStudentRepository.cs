using Demo.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Database.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<bool> AddStudent(Student student);
        Task<bool> UpdateStudent(Student student);
        Task<bool> RemoveStudent(Guid Id);
        Task<int> StudentCount();
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly Demo_Context DemoContext;
        public StudentRepository(Demo_Context demo_Context)
        {
            this.DemoContext = demo_Context;
        }
        public async Task<bool> AddStudent(Student student)
        {
            try
            {
                student.Id = new Guid();
                student.AddedDateTime = DateTime.UtcNow;
                this.DemoContext.Students.Add(student);
                await this.DemoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Student>> GetStudents()
        {
            try
            {
                return await this.DemoContext.Students.Where(c => c.DeletedDateTime == null).ToListAsync(); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> RemoveStudent(Guid Id)
        {
            try
            {
                var dbStudent = this.DemoContext.Students.Where(c => c.Id == Id).SingleOrDefault();
                if(dbStudent != null)
                {
                    dbStudent.DeletedDateTime = DateTime.UtcNow;
                    this.DemoContext.Entry(dbStudent).State = EntityState.Modified;
                    await this.DemoContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> StudentCount()
        {
            try
            {
                return this.DemoContext.Students.Where(c => c.DeletedDateTime == null).ToList().Count ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            try
            {
                var dbStudent = this.DemoContext.Students.Where(c => c.Id == student.Id).SingleOrDefault();
                if (dbStudent != null)
                {
                    dbStudent.FirstName = student.FirstName;
                    dbStudent.LastName = student.LastName;
                    dbStudent.FatherName = student.FatherName;
                    dbStudent.MotherName = student.MotherName;
                    dbStudent.Contact = student.Contact;
                    dbStudent.Email = student.Email;
                    this.DemoContext.Entry(dbStudent).State = EntityState.Modified;
                    await this.DemoContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
