//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cactuses.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cactuses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cactuses()
        {
            this.Cactuses_Exhibitions = new HashSet<Cactuses_Exhibitions>();
        }
    
        public int ID { get; set; }
        public string Sort { get; set; }
        public string Origin { get; set; }
        public string Age { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string Instruction { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cactuses_Exhibitions> Cactuses_Exhibitions { get; set; }
    }
}
