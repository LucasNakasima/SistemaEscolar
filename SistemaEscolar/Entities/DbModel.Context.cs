﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SitemaUnicesumar.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolEntities : DbContext
    {
        public SchoolEntities()
            : base("name=SchoolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bimester> ListBimester { get; set; }
        public virtual DbSet<Class> ListClass { get; set; }
        public virtual DbSet<ClassStudent> ListClassStudent { get; set; }
        public virtual DbSet<Discipline> ListDiscipline { get; set; }
        public virtual DbSet<DisciplineContent> ListDisciplineContent { get; set; }
        public virtual DbSet<PresenceRegisterClass> ListPresenceRegisterClass { get; set; }
        public virtual DbSet<PresenceStudent> ListPresenceStudent { get; set; }
        public virtual DbSet<Student> ListStudent { get; set; }
        public virtual DbSet<User> ListUser { get; set; }
    }
}