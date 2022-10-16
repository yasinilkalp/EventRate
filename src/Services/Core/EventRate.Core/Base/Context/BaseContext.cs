using EventRate.Core.Base.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace EventRate.Core.Base.Context
{
    public abstract class BaseContext : DbContext
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        public BaseContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public override int SaveChanges()
        {
            UpdateAuditEntities();
            return base.SaveChanges();
        }


        private void UpdateAuditEntities()
        {
            int? CurrentUserId = GetCurrenctUser();

            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));


            foreach (var entry in modifiedEntries)
            {
                var entity = (BaseEntity)entry.Entity;
                var now = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = now;
                    entity.CreatedBy = CurrentUserId;
                }
                else if (entry.State == EntityState.Deleted && entry.Entity is not IHardDelete)
                {
                    // Varlığı değiştirilmedi olarak ayarlıyoruz.
                    // (tüm varlığı Değiştirildi olarak işaretlersek, her alan güncelleme olarak Db'ye gönderilir)
                    entry.State = EntityState.Unchanged;

                    // Yalnızca IsDeleted alanını güncelleyin - yalnızca bu Db'ye gönderilir
                    entity.IsDelete = true;
                }
                else
                {
                    base.Entry(entity).Property(x => x.CreatedBy).IsModified = false;
                    base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                }

                entity.UpdatedDate = now;
                entity.UpdatedBy = CurrentUserId;

            }

        }

        private int? GetCurrenctUser()
        {
            if (HttpContextAccessor?.HttpContext?.User?.Identity == null) return null;

            var claims = (ClaimsIdentity)HttpContextAccessor.HttpContext.User.Identity;

            var CurrentUser = claims?.Claims?.FirstOrDefault(a => a.Type.Contains("/sid"))?.Value ?? null;

            int? CurrentUserId = string.IsNullOrEmpty(CurrentUser) ? null : int.Parse(CurrentUser);

            return CurrentUserId;
        }


    }
}
