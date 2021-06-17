using SitemaUnicesumar.Entities;
using SitemaUnicesumar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SitemaUnicesumar.Services
{
    public class RegisterPresenceService
    {
        public List<ClassViewModel> GetListClass()
        {
            using (var context = new SchoolEntities())
            {
                var listClasses = new List<ClassViewModel>();

                listClasses = context.ListClass
                    .Select(p => new ClassViewModel
                    {
                        Id = p.Id,
                        Title = p.Title,
                    })
                    .ToList();

                return listClasses;
            }
        }

        public RegisterPresenceViewModel LoadPresenceList(int userId, int classId)
        {
            using (var context = new SchoolEntities())
            {
                var viewModel = new RegisterPresenceViewModel();

                viewModel.Class = context.ListClass
                    .Where(c => c.Id == classId)
                    .Select(c => new ClassViewModel
                    {
                        Id = c.Id,
                        Title = c.Title,
                    })
                    .FirstOrDefault();

                viewModel.ListStudent = context.ListClassStudent
                    .Include(s => s.Student)
                    .Where(s => s.ClassId == classId)
                    .Select(s => new StudentViewModel
                    {
                        Id = s.Student.Id,
                        Name = s.Student.Name,
                    })
                    .ToList();

                viewModel.ListBimester = context.ListBimester
                    .Select(b => new BimesterViewModel
                    {
                        Id = b.Id,
                        Title = b.Title,
                    })
                    .ToList();

                var user = context.ListUser.FirstOrDefault(u => u.Id == userId);

                viewModel.ListDisciplineContent = context.ListDisciplineContent
                    .Where(u => u.DisciplineId == user.DisciplineId)
                    .Select(u => new DisciplineContentViewModel
                    {
                        Id = u.Id,
                        Title = u.Title,
                    })
                    .ToList();

                return viewModel;
            }
        }

        public async Task SaveRegisterPresenceAsync(RegisterPresenceViewModel viewModel, int userId)
        {
            using (var context = new SchoolEntities())
            {
                var isNew = viewModel.Id == 0;

                var modelPresenceRegister = isNew ?
                    new PresenceRegisterClass() :
                    await context.ListPresenceRegisterClass.FirstOrDefaultAsync(p => p.Id == viewModel.Id);

                modelPresenceRegister.ClassId = viewModel.ClassId;
                modelPresenceRegister.UserId = userId;
                modelPresenceRegister.BimesterId = viewModel.BimesterId;
                modelPresenceRegister.DisciplineContentId = viewModel.DisciplineContentId;
                modelPresenceRegister.DateRegister = viewModel.DateRegister;
                modelPresenceRegister.DescriptionContent = viewModel.DescriptionContent;

                context.Entry(modelPresenceRegister).State = isNew ? EntityState.Added : EntityState.Modified;

                if (!isNew)
                {
                    var listStudents = await context.ListPresenceStudent.Where(p => p.PresenceRegisterClassId == viewModel.Id).ToListAsync();
                    foreach (var item in listStudents)
                        context.Entry(item).State = EntityState.Deleted;
                }

                foreach (var student in viewModel.ListStudent)
                {
                    var modelPresenceStudent = new PresenceStudent
                    {
                        StudentId = student.Id,
                        PresenceRegisterClassId = modelPresenceRegister.Id,
                        WasPresent = student.WasPresent,
                    };

                    context.Entry(modelPresenceStudent).State = EntityState.Added;
                }

                await context.SaveChangesAsync();
            }
        }
    }
}