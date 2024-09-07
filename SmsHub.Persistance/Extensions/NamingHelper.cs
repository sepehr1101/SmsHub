using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using SmsHub.Persistence.Migrations.Enums;

namespace SmsHub.Persistence.Extensions
{
    internal static class NamingHelper
    {
        internal static string Fk(TableName referenceTable, TableName primaryTable, [Optional] string? primaryColumn)
            => primaryColumn is null ?
                    $"FK_{GetName(referenceTable)}_{GetName(primaryTable)}_{GetName(primaryTable)}Id" :
                    $"FK_{GetName(referenceTable)}_{GetName(primaryTable)}_{primaryColumn}";

        internal static string Unique(TableName tableName, string columnName) =>
            $"IX_Unique_{GetName(tableName)}_{columnName}";

        private static string GetName([NotNull]TableName tableName) =>
            Enum.GetName(typeof(TableName), tableName);
    }
}
