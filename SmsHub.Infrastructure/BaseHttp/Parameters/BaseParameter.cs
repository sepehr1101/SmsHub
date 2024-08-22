using SmsHub.Common;
using SmsHub.Infrastructure.BaseHttp.Enums;

namespace SmsHub.Infrastructure.BaseHttp.Parameters
{
    public abstract record BaseParameter
    {
        protected BaseParameter(string? name, object? value, ParameterType type, bool encode)
        {
            Guard.NotEmptyString(name, nameof(name));
            Guard.NotNull(value, nameof(value));

            Name = name;
            Value = value;
            Type = type;
            Encode = encode;
        }
        public ContentType ContentType { get; set; } = ContentType.Undefined;
        public string? Name { get; }
        public object? Value { get; }
        public ParameterType Type { get; }
        public bool Encode { get; }
        public sealed override string ToString() => Value == null ? $"{Name}" : $"{Name}={ValueString}";

        protected virtual string ValueString => Value?.ToString() ?? "null";
    }
}
