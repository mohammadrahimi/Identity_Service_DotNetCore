

using System;

namespace Identity.Framework.Core.Utility;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
