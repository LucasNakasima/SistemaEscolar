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
    
    public partial class DisciplineContent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DisciplineContent()
        {
            this.PresenceRegisterClass = new HashSet<PresenceRegisterClass>();
        }
    
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public string Title { get; set; }
    
        public virtual Discipline Discipline { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PresenceRegisterClass> PresenceRegisterClass { get; set; }
    }
}
