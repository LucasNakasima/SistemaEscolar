using SitemaUnicesumar.Entities;
using SitemaUnicesumar.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SitemaUnicesumar.Services
{
    public class RegistryClassService
    {
        public List<RegisterPresenceViewModel> GetListRegistersClass(int userId)
        {
            using (var context = new SchoolEntities())
            {
                return context.ListPresenceRegisterClass
                    .Include(p => p.Class)
                    .Where(p => p.UserId == userId)
                    .Select(p => new RegisterPresenceViewModel
                    {
                        Id = p.Id,
                        ClassTitle = p.Class.Title,
                        DateRegister = p.DateRegister,
                    })
                    .OrderByDescending(p => p.DateRegister)
                    .ToList();
            }
        }

        public RegisterPresenceViewModel GetRegistryClass(int registryId)
        {
            using (var context = new SchoolEntities())
            {
                var viewModel = context.ListPresenceRegisterClass
                    .Include(p => p.Class)
                    .Include(p => p.Bimester)
                    .Include(p => p.DisciplineContent)
                    .Include(p => p.PresenceStudent)
                    .Include(p => p.PresenceStudent.Select(x => x.Student))
                    .Where(p => p.Id == registryId)
                    .Select(p => new RegisterPresenceViewModel
                    {
                        Id = p.Id,
                        BimesterId = p.BimesterId,
                        DisciplineContentId = p.DisciplineContentId,
                        DisciplineId = p.DisciplineContent.Discipline.Id,
                        DateRegister = p.DateRegister,
                        DescriptionContent = p.DescriptionContent,
                        Class = p.Class.ClassStudent.Select(c => new ClassViewModel 
                        {
                            Id = c.ClassId,
                            Title = c.Class.Title,
                        })
                        .FirstOrDefault(),
                        ListStudent = p.PresenceStudent.Select(x => new StudentViewModel
                        {
                            Id = x.Id,
                            Name = x.Student.Name,
                            WasPresent = x.WasPresent,
                        })
                        .ToList()
                    })
                    .FirstOrDefault();

                viewModel.ListBimester = context.ListBimester
                    .Select(b => new BimesterViewModel
                    {
                        Id = b.Id,
                        Title = b.Title,
                    })
                    .ToList();

                viewModel.ListDisciplineContent = context.ListDisciplineContent
                 .Where(u => u.DisciplineId == viewModel.DisciplineId)
                 .Select(u => new DisciplineContentViewModel
                 {
                     Id = u.Id,
                     Title = u.Title,
                 })
                 .ToList();

                return viewModel;
            }
        }
    }
}