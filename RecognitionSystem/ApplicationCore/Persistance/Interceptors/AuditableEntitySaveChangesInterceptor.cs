using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecognitionCore.Domain.Shared;

namespace ApplicationCore.Persistance.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
   public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
   {
      AuditEntityChanges(eventData.Context);
      return base.SavingChanges(eventData, result);
   }

   public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
      CancellationToken cancellationToken = new CancellationToken())
   {
      AuditEntityChanges(eventData.Context);
      return base.SavingChangesAsync(eventData, result, cancellationToken);
   }

   public void AuditEntityChanges(DbContext? context)
   {
      if(context == null) return;
      foreach (var entity in context.ChangeTracker.Entries<IAuditableEntity>())      
      {
         if (entity.State == EntityState.Added)
         {
            entity.Entity.Created = DateTime.Now;
         }
         else if (entity.State == EntityState.Added || entity.State == EntityState.Modified ||
                                 entity.HasChangedOwnedEntities())
         {
            entity.Entity.LastModified = DateTime.Now;
         }
      }
   }
}
public static class Extensions
{
   public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
      entry.References.Any(r => 
         r.TargetEntry != null && 
         r.TargetEntry.Metadata.IsOwned() && 
         (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
}