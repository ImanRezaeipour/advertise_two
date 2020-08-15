namespace Advertise.Core.Events
{
    /// <summary>
    /// A container for entities that have been inserted.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityInserted<T> where T : class
    {
        #region Public Constructors

        public EntityInserted(T entity)
        {
            this.Entity = entity;
        }

        #endregion Public Constructors

        #region Public Properties

        public T Entity { get; private set; }

        #endregion Public Properties
    }
}