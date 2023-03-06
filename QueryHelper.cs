using Jees.Sdk.Data.Core.Operations;
using Jees.Sdk.Data.Interface;
//using Rainbird.Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace CESATAutomationDevelop
{
    internal static class QueryHelper
    {
        private static Lazy<IFactory> Lazy => new Lazy<IFactory>(() => new MQuery(
            ConfigurationManager.AppSettings["ConnectionString"],
            Enum.TryParse(ConfigurationManager.AppSettings["ConnectionType"], out MQuery.ConnectionType type) ?
                type :
                throw new NotImplementedException($"Invalid ConnectionType {ConfigurationManager.AppSettings["ConnectionType"]}")
        ));
        private static IFactory Query => Lazy.Value;

        public static IEnumerable<T> Read<T>(params Field[] fields) where T : IModel
        {
            var sql = $"SELECT * FROM {typeof(T).Name}";
            if (fields.Any())
            {
                sql += $" WHERE {string.Join(fields.Any(f => f.Type == Field.FieldType.OrWhere) ? " OR " : " AND ", fields.Select(f => $"{f.Name} {f.Operator} @{f.Name}"))}";
            }

            var result = Query.Execute<T>(sql, fields);
            return result;
        }
        public static T Create<T>(T instance) where T : IModel
        {
            try
            {
                var type = typeof(T);
                var properties = type.GetProperties().Where(p => p.Name != instance.IdName && p.Name != "Id" && p.Name != "IdName" && !p.GetMethod.IsVirtual && !p.GetMethod.IsStatic);
                var fields = properties.Select(p => new Field(p.Name, p.GetValue(instance)));
                var result = Query.Execute<NonQueryResult>($"INSERT INTO {type.Name} ({string.Join(", ", properties.Select(p => p.Name))}) VALUES ({string.Join(", ", properties.Select(p => $"@{p.Name}"))}); SELECT SCOPE_IDENTITY() NewId", fields.ToArray());
                if (result.FirstOrDefault() is NonQueryResult inserted && inserted.NewId > 0)
                {
                    type.GetProperty(instance.IdName).SetValue(instance, inserted.NewId);
                }
                return instance;
            }
            catch
            {
                return default;
            }
        }
        public static T Update<T>(T instance, params string[] fields) where T : IModel
        {
            try
            {
                var type = typeof(T);
                var properties = type.GetProperties().Where(p => fields.Contains(p.Name));

                var fieldList = new List<Field> { new Field(instance.IdName, instance.Id) };
                fieldList.AddRange(properties.Select(p => new Field(p.Name, p.GetValue(instance))));

                var result = Query.Execute<NonQueryResult>($"UPDATE {type.Name} SET {string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"))} WHERE {instance.IdName} = @{instance.IdName}; SELECT @@ROWCOUNT AffectedRows", fieldList.ToArray());
                return result.FirstOrDefault() is NonQueryResult updated && updated.AffectedRows > 0 ? instance : default;
            }
            catch
            {
                return default;
            }
        }
        public static T Delete<T>(T instance) where T : IModel
        {
            try
            {
                var type = typeof(T);
                var result = Query.Execute<NonQueryResult>($"DELETE FROM {type.Name} WHERE {instance.IdName} = @{instance.IdName}; SELECT @@ROWCOUNT AffectedRows", new Field[] { new Field(instance.IdName, instance.Id) });
                return result.FirstOrDefault() is NonQueryResult updated && updated.AffectedRows > 0 ? instance : default;
            }
            catch
            {
                return default;
            }
        }

        public static IEnumerable<T> Execute<T>(string sql, params Field[] fields) => Query.Execute<T>(sql, fields);
        public static IEnumerable<dynamic> Execute(string sql, params Field[] fields) => Query.Execute(sql, fields);

        private class NonQueryResult
        {
            public int NewId { get; set; }
            public int AffectedRows { get; set; }
        }
    }

    internal static class Extensions
    {
        internal static BindingSource ToBindingSource<T>(this IEnumerable<T> enumerable) => new BindingSource() { DataSource = enumerable };
    }
}
