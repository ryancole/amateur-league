using System;

namespace League.Entity.Utility
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SqlColumnAttribute : Attribute
    {
        public SqlColumnAttribute(string name)
        {
            Name = name;
        }

        #region Properties

        public string Name { get; }

        #endregion
    }
}