// ---------------------------------------------------------------
// Copyright (c) 2023 Mabrouk Mahdhi. All rights reserved.
// This is a prototype implementing eCommerce app using .NET MAUI
// ---------------------------------------------------------------

using Newtonsoft.Json;

namespace SaarWorld.Brokers.Serializations
{
    public class SerializationBroker : ISerializationBroker
    {
        public string Serialize<TSource>(TSource obj) =>
            JsonConvert.SerializeObject(obj);

        public TResult Deserialize<TResult>(string value) =>
            JsonConvert.DeserializeObject<TResult>(value);
    }
}