// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

namespace SaarWorld.Brokers.Serializations
{
    public interface ISerializationBroker
    {
        string Serialize<TSource>(TSource obj);
        TResult Deserialize<TResult>(string value);
    }
}