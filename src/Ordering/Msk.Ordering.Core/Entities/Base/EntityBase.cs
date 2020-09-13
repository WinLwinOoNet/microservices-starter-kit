namespace Msk.Ordering.Core.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get; protected set; }

        private int? _requestedHashCode;

        public bool IsTransient() => Id.Equals(default(TId));

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is EntityBase<TId>))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            var item = (EntityBase<TId>) obj;

            if (item.IsTransient() || IsTransient())
                return false;

            return item == this;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> left, EntityBase<TId> right)
            => Equals(left, null) ? Equals(right, null) : left.Equals(right);

        public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
            => !(left == right);
    }
}