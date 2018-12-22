using System;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Threading.Tasks;

using League.Entity.Utility;

namespace League.Data.Sql.Utility
{
    public static class SqlDataReaderExtensions
    {
        #region Methods

        public static T MapToType<T>(this SqlDataReader reader) where T : class, new()
        {
            var type = typeof(T);
            var result = new T();

            // up front, lets fetch all public properties off of the given type
            // so that we can pluck from them as we scan our query results, but
            // we also want to exclude any with the exclude attribute
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.GetCustomAttributes<SqlExcludeAttribute>().Any() == false);

            // instead of looping over the properties on our type, we will
            // instead loop over columns in the sql results because that look
            // up is more expensive to do in a loop
            for (var x = 0; x < reader.FieldCount; x++)
            {
                if (reader.IsDBNull(x))
                {
                    continue;
                }

                var value = reader.GetValue(x);

                // we want to get the column name for this particular column
                // because we're going to then check our type if it has a
                // matching column for us
                var field = reader.GetName(x);

                try
                {
                    foreach (var property in properties)
                    {
                        var attribute = property.GetCustomAttribute<SqlColumnAttribute>();

                        // if this property has our sql column attribute, we will
                        // honor that and will not simply compare by property name
                        if (attribute != null && field.Equals(attribute.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(result, value);
                        }

                        // if the property does not have the custom attribute, we
                        // can just compare the property name to cut down on code
                        else if (field.Equals(property.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(result, value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"failed to set {field}", ex);
                }
            }

            return result;
        }

        public static T MapToType<T>(this SqlDataReader reader, string ColumnPrefix) where T : class, new()
        {
            var type = typeof(T);
            var result = new T();

            // up front, lets fetch all public properties off of the given type
            // so that we can pluck from them as we scan our query results, but
            // we also want to exclude any with the exclude attribute
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.GetCustomAttributes<SqlExcludeAttribute>().Any() == false);

            // instead of looping over the properties on our type, we will
            // instead loop over columns in the sql results because that look
            // up is more expensive to do in a loop
            for (var x = 0; x < reader.FieldCount; x++)
            {
                if (reader.IsDBNull(x))
                {
                    continue;
                }

                var value = reader.GetValue(x);

                // we want to get the column name for this particular column
                // because we're going to then check our type if it has a
                // matching column for us
                var field = reader.GetName(x);

                try
                {
                    foreach (var property in properties)
                    {
                        var attribute = property.GetCustomAttribute<SqlColumnAttribute>();

                        // if this property has our sql column attribute, we will
                        // honor that and will not simply compare by property name
                        if (attribute != null && field.Equals($"{ColumnPrefix}{attribute.Name}", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(result, value);
                        }

                        // if the property does not have the custom attribute, we
                        // can just compare the property name to cut down on code
                        else if (field.Equals($"{ColumnPrefix}{property.Name}", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(result, value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"failed to set {field}", ex);
                }
            }

            return result;
        }

        async public static Task<T> MapToTypeAsync<T>(this SqlDataReader reader) where T : class, new()
        {
            var type = typeof(T);
            var result = new T();

            // up front, lets fetch all public properties off of the given type
            // so that we can pluck from them as we scan our query results, but
            // we also want to exclude any with the exclude attribute
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.GetCustomAttributes<SqlExcludeAttribute>().Any() == false);

            // instead of looping over the properties on our type, we will
            // instead loop over columns in the sql results because that look
            // up is more expensive to do in a loop
            for (var x = 0; x < reader.FieldCount; x++)
            {
                if (await reader.IsDBNullAsync(x))
                {
                    continue;
                }

                var value = reader.GetValue(x);

                // we want to get the column name for this particular column
                // because we're going to then check our type if it has a
                // matching column for us
                var field = reader.GetName(x);

                try
                {
                    foreach (var property in properties)
                    {
                        var attribute = property.GetCustomAttribute<SqlColumnAttribute>();

                        // if this property has our sql column attribute, we will
                        // honor that and will not simply compare by property name
                        if (attribute != null && field.Equals(attribute.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(result, value);
                        }

                        // if the property does not have the custom attribute, we
                        // can just compare the property name to cut down on code
                        else if (field.Equals(property.Name, StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(result, value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"failed to set {field}", ex);
                }
            }

            return result;
        }

        async public static Task<T> MapToTypeAsync<T>(this SqlDataReader reader, string ColumnPrefix) where T : class, new()
        {
            var type = typeof(T);
            var result = new T();

            // up front, lets fetch all public properties off of the given type
            // so that we can pluck from them as we scan our query results, but
            // we also want to exclude any with the exclude attribute
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.GetCustomAttributes<SqlExcludeAttribute>().Any() == false);

            // instead of looping over the properties on our type, we will
            // instead loop over columns in the sql results because that look
            // up is more expensive to do in a loop
            for (var x = 0; x < reader.FieldCount; x++)
            {
                if (await reader.IsDBNullAsync(x))
                {
                    continue;
                }

                var value = reader.GetValue(x);

                // we want to get the column name for this particular column
                // because we're going to then check our type if it has a
                // matching column for us
                var field = reader.GetName(x);

                try
                {
                    foreach (var property in properties)
                    {
                        var attribute = property.GetCustomAttribute<SqlColumnAttribute>();

                        // if this property has our sql column attribute, we will
                        // honor that and will not simply compare by property name
                        if (attribute != null && field.Equals($"{ColumnPrefix}{attribute.Name}", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(result, value);
                        }

                        // if the property does not have the custom attribute, we
                        // can just compare the property name to cut down on code
                        else if (field.Equals($"{ColumnPrefix}{property.Name}", StringComparison.OrdinalIgnoreCase))
                        {
                            property.SetValue(result, value);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"failed to set {field}", ex);
                }
            }

            return result;
        }

        #endregion
    }
}