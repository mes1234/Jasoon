using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarking;
public class Benchmarks
{
    [Benchmark]
    public object? PocoSerializeAndDeserialze()
    {
        var input = new Jasoon.DTO.Poco.ItemWithFullDetails
        {
            FullName = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Id = Guid.NewGuid(),
        };

        var serialized = JsonConvert.SerializeObject(input);
        var deserialized = JsonConvert.DeserializeObject < Jasoon.DTO.Poco.ItemWithFullDetails>(serialized);

        return deserialized;
    }
    [Benchmark]
    public object? ConverterSerializeAndDeserialze()
    {
        var input = new Jasoon.DTO.ConverterBased.ItemWithFullDetails
        {
            FullName = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Id = Guid.NewGuid(),
        };

        var serialized = JsonConvert.SerializeObject(input);
        var deserialized = JsonConvert.DeserializeObject < Jasoon.DTO.ConverterBased.Item>(serialized);

        return deserialized;
    }
    [Benchmark]
    public object? StaticConverterSerializeAndDeserialze()
    {
        var input = new Jasoon.DTO.StaticConverterBased.ItemWithFullDetails
        {
            FullName = Guid.NewGuid().ToString(),
            Name = Guid.NewGuid().ToString(),
            Id = Guid.NewGuid(),
        };

        var serialized = JsonConvert.SerializeObject(input);
        var deserialized = JsonConvert.DeserializeObject < Jasoon.DTO.StaticConverterBased.Item>(serialized);

        return deserialized;
    }
}
