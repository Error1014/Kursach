//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursach
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vizov
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vizov()
        {
            this.Othot = new HashSet<Othot>();
        }
    
        public int id { get; set; }
        public Nullable<int> pacient { get; set; }
        public Nullable<System.DateTime> date_vizov { get; set; }
        public Nullable<System.TimeSpan> time_vizov { get; set; }
        public Nullable<int> vrach { get; set; }
        public string symptom { get; set; }
        public string type { get; set; }
        public string phone { get; set; }
        public string adres { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Othot> Othot { get; set; }
        public virtual Pacient Pacient1 { get; set; }
        public virtual User User { get; set; }
    }
}
