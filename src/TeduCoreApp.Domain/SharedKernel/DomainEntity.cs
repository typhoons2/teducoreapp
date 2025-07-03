using System;
namespace TeduCoreApp.Domain.SharedKernel
{
    public abstract class DomainEntity<T>
    {
        public virtual T Id { get; set; }
        public bool IsTransient()
        {
            return Id == null || Id.Equals(default(T));
        }
    }
} 