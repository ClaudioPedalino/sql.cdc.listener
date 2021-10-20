using System.Linq;

namespace sql.cdc.listener.Helper
{
    public static class TableExtension<TEntity> where TEntity : class
    {
        public static string GetTableName()
        {
            var tableName = typeof(TEntity).CustomAttributes.FirstOrDefault();
            var schema = tableName.NamedArguments.FirstOrDefault().TypedValue;
            var name = tableName.ConstructorArguments.FirstOrDefault().Value;
            return $"{schema.Value}.{name}";
        }
    }
}
