//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonalCars
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cars
    {
        public int CarId { get; set; }
        public string RegNumber { get; set; }
        public Nullable<int> OwnerId { get; set; }
        public string StateNumber { get; set; }
        public int ReleaseYear { get; set; }
        public Nullable<int> ColorId { get; set; }
        public Nullable<int> MarkId { get; set; }
        public bool IsForeign { get; set; }
    
        public virtual Colors Colors { get; set; }
        public virtual Marks Marks { get; set; }
        public virtual Owners Owners { get; set; }
    }
}
