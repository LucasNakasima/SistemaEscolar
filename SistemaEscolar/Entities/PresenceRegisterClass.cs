//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class PresenceRegisterClass
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PresenceRegisterClass()
        {
            this.PresenceStudent = new HashSet<PresenceStudent>();
        }
    
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int UserId { get; set; }
        public int BimesterId { get; set; }
        public int DisciplineContentId { get; set; }
        public System.DateTime DateRegister { get; set; }
        public string DescriptionContent { get; set; }
    
        public virtual Bimester Bimester { get; set; }
        public virtual Class Class { get; set; }
        public virtual DisciplineContent DisciplineContent { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PresenceStudent> PresenceStudent { get; set; }
    }
}
