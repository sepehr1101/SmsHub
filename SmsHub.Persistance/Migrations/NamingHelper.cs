using System.Runtime.InteropServices;

namespace SmsHub.Persistence.Migrations
{
    internal static class NamingHelper
    {
        internal static string Fk(TableName referenceTable, TableName primaryTable, [Optional] string? primaryColumn)
            =>  primaryColumn is null?
                    $"FK_{nameof(referenceTable)}_{nameof(primaryTable)}_{nameof(primaryTable)}Id":            
                    $"FK_{nameof(referenceTable)}_{nameof(primaryTable)}_{primaryColumn}";

        internal static string Unique(TableName tableName, string columnName) =>
            $"Unique_{nameof(TableName)}_{columnName}";
    }
}
