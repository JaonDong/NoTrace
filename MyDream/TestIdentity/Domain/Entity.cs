using System;
using System.Collections.Generic;

namespace TestIdentity.Domain
{
    public  class Entity<TPrimaryKey> 
    {
        /// <summary>
        /// Unique identifier for this entity.
        /// 
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }

        /// <inheritdoc/>
        public static bool operator ==(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            if (object.Equals((object)left, (object)null))
                return object.Equals((object)right, (object)null);
            return left.Equals((object)right);
        }

        /// <inheritdoc/>
        public static bool operator !=(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Checks if this entity is transient (it has not an Id).
        /// </summary>
        /// 
        /// <returns>
        /// True, if this entity is transient
        /// </returns>
        public virtual bool IsTransient()
        {
            return EqualityComparer<TPrimaryKey>.Default.Equals(this.Id, default(TPrimaryKey));
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity<TPrimaryKey>))
                return false;
            if (object.ReferenceEquals((object)this, obj))
                return true;
            Entity<TPrimaryKey> entity = (Entity<TPrimaryKey>)obj;
            if (this.IsTransient() && entity.IsTransient())
                return false;
            Type type1 = this.GetType();
            Type type2 = entity.GetType();
            if (!type1.IsAssignableFrom(type2) && !type2.IsAssignableFrom(type1))
                return false;
            return this.Id.Equals((object)entity.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("[{0} {1}]", (object)this.GetType().Name, (object)this.Id);
        }
    }
}