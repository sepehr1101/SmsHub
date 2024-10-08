using SmsHub.Infrastructure.BaseHttp.Enums;

namespace SmsHub.Infrastructure.BaseHttp.Parameters
{
    public record HeaderParameter : BaseParameter
    {       
        public HeaderParameter(string name, string value)
            : base(
                name,
                value,
                ParameterType.HttpHeader,
                false
            )
        { 
        }

        public new string Name => base.Name!;
        public new string Value => (string)base.Value!;
    }
}
