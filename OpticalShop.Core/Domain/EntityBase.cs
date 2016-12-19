using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Core.Domain
{
    /// <summary>
    /// Represent Entity object everywhere in the system
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Identity of Entity, Automatic generate when insert into repository
        /// </summary>
        private string _id;
        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(_id))
                    _id = Guid.NewGuid().ToString();

                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as EntityBase);
        }

        private static bool IsTransient(EntityBase obj)
        {
            return obj != null && Equals(obj.Id, default(int));
        }

        public Type GetUnproxiedType()
        {
            Type type = this.GetType();
            if (type.BaseType != null && type.Namespace == "System.Data.Entity.DynamicProxies")
            {
                type = type.BaseType;
            }

            return type;
        }

        public virtual bool Equals(EntityBase other)
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
            if (Equals(Id, default(int)))
                return base.GetHashCode();
            return Id.GetHashCode();
        }

        public static bool operator ==(EntityBase x, EntityBase y)
        {
            return Equals(x, y);
        }

        public static bool operator !=(EntityBase x, EntityBase y)
        {
            return !(x == y);
        }

        /// <summary>
        /// Get with GetUnproxiedType class
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.GetUnproxiedType().FullName;
        }
    }
}
