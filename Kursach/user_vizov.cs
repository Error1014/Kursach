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
    
    public partial class user_vizov
    {
        public int id { get; set; }
        public Nullable<int> id_user { get; set; }
        public Nullable<int> id_vizov { get; set; }
    
        public virtual User User { get; set; }
        public virtual Vizov Vizov { get; set; }
    }
}
