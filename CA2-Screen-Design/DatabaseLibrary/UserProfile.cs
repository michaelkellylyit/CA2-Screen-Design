//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfile
    {
        public int ProfileID { get; set; }
        public int UserID { get; set; }
        public int Project1ID { get; set; }
        public int Project2ID { get; set; }
        public string ProfileText { get; set; }
        public int FavouritesID { get; set; }
        public int GenreID { get; set; }
    
        public virtual Favourite Favourite { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Project Project { get; set; }
        public virtual Project Project1 { get; set; }
        public virtual User User { get; set; }
        public virtual UserSearch UserSearch { get; set; }
    }
}