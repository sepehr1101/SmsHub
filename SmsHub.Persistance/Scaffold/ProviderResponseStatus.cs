using System;
using System.Collections.Generic;

namespace SmsHub.Persistence.Scaffold;

public partial class ProviderResponseStatus
{
    public int Id { get; set; }

    public short ProviderId { get; set; }

    public int StatusCode { get; set; }

    public string Message { get; set; } = null!;

    public bool IsSuccess { get; set; }
}
