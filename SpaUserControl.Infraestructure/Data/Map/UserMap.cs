﻿using SpaUserControl.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaUserControl.Infraestructure.Data.Map
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasMaxLength(80)
                .IsRequired();

            Property(x => x.Email)
                .HasMaxLength(160)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_EMAIL", 1) { IsUnique = true }))
                .IsRequired();

            Property(x => x.Password)
                .HasMaxLength(32)
                .IsFixedLength();
        }
    }
}
