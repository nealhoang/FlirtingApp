﻿using System;
using FlirtingApp.Web.Identity;
using FlirtingApp.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlirtingApp.Web.Data
{
	public class ApiDbContext: IdentityDbContext<User, Role, Guid>
	{
		public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
		{
			
		}

		public DbSet<Photo> Photos { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<User>(ConfigureUser);
			builder.Entity<RefreshToken>(ConfigureRefreshToken);

		}

		public void ConfigureUser(EntityTypeBuilder<User> builder)
		{
			builder.Metadata
				.FindNavigation(nameof(User.RefreshTokens))
				.SetPropertyAccessMode(PropertyAccessMode.Field);
			builder.Metadata
				.FindNavigation(nameof(User.Photos))
				.SetPropertyAccessMode(PropertyAccessMode.Field);
		}

		public void ConfigureRefreshToken(EntityTypeBuilder<RefreshToken> builder)
		{
			builder.HasOne(t => t.User)
				.WithMany(u => u.RefreshTokens)
				.HasForeignKey(t => t.UserId);
		}
		public void ConfigurePhoto(EntityTypeBuilder<Photo> builder)
		{
			builder.HasOne(t => t.User)
				.WithMany(u => u.Photos)
				.HasForeignKey(t => t.UserId);
		}
	}
}
