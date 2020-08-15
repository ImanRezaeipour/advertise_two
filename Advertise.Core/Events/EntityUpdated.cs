namespace Advertise.Core.Events
{
    /// <summary>
    /// A container for entities that are updated.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityUpdated<T> where T : class
    {
        #region Public Constructors

        public EntityUpdated(T entity)
        {
            this.Entity = entity;
        }

        #endregion Public Constructors

        #region Public Properties

        public T Entity { get; private set; }

        #endregion Public Properties
    }
}