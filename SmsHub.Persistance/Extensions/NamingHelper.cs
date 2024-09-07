using System.Runtime.InteropServices;
using SmsHub.Persistence.Migrations.Enums;

namespace SmsHub.Persistence.Extensions
{
    internal static class NamingHelper
    {
        internal static string Fk(TableName referenceTable, TableName primaryTable, [Optional] string? primaryColumn)
            => primaryColumn is null ?
                    $"FK_{nameof(referenceTable)}_{nameof(primaryTable)}_{nameof(primaryTable)}Id" :
                    $"FK_{nameof(referenceTable)}_{nameof(primaryTable)}_{primaryColumn}";

        internal static string Unique(TableName tableName, string columnName) =>
            $"IX_Unique_{nameof(TableName)}_{columnName}";
    }
}
