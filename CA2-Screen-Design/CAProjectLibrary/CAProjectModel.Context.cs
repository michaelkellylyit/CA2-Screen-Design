﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAProjectLibrary
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CAProjectEntities : DbContext
    {
        public CAProjectEntities(string connectionString)
            : base(connectionString)
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessLevel> AccessLevels { get; set; }
        public virtual DbSet<Favourite> Favourites { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<UserSearch> UserSearches { get; set; }
    }
}
