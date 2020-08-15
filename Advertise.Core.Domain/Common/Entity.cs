using System;

namespace Advertise.Core.Domains.Common
{
    public abstract class Entity
    {
        #region Public Properties

        public virtual Guid Id { get; set; }

        #endregion Public Properties

        #region Public Methods

        public static bool operator !=(Entity x, Entity y)
        {
            return !(x == y);
        }

        public static bool operator ==(Entity x, Entity y)
        {
            return Equals(x, y);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity);
        }

        public virtual bool Equals(Entity other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(this) &&
                !IsTransient(other) &&
                Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                       otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(Id, Guid.Empty))
                return base.GetHashCode();
            return Id.GetHashCode();
        }

        #endregion Public Methods

        #region Private Methods

        private static bool IsTransient(Entity obj)
        {
            return obj != null && Equals(obj.Id, Guid.Empty);
        }

        private Type GetUnproxiedType()
        {
            return GetType();
        }

        #endregion Private Methods
    }
}