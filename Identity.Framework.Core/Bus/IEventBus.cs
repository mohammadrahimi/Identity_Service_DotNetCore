﻿
namespace Identity.Framework.Core.Bus;


public interface IEventBus
{
    void Publish<TEvent>(TEvent @event);
}
