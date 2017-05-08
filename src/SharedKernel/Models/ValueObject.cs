using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SharedKernel.Models
{
    public class ValueObject<T> : IEquatable<T> where T : ValueObject<T>
    {
        public bool Equals(T other)
        {
            if (other == null)
            {
                return false;
            }

            var t = GetType();
            var otherType = other.GetType();

            if (t != otherType)
            {
                return false;
            }

            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var field in fields)
            {
                var value1 = field.GetValue(other);
                var value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                    {
                        return false;
                    }

                }

                else if (!value1.Equals(value2))
                {
                    return false;
                }
            }

            return true;
        }

        #region Overrides
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            var other = obj as T;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            var fields = GetFields();

            var startValue = 17;
            var multiplier = 59;

            return fields.Select(field => field.GetValue(this))
                .Where(value => value != null)
                .Aggregate(startValue, (current, value) => current * multiplier + value.GetHashCode());
        }

        public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
        {
            return !Equals(left, right);
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            var t = GetType();
            var fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));
                t = t.GetTypeInfo().BaseType;
            }

            return fields;
        }
        #endregion
    }
}
