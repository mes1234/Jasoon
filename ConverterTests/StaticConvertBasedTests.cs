using AutoFixture;
using Jasoon.DTO.StaticConverterBased;
using Newtonsoft.Json;
using Xunit;

namespace ConverterTests;

public class StaticConvertBasedTests
{
    private readonly Fixture _fixture;

    public StaticConvertBasedTests()
    {
        _fixture = new Fixture();
    }


    [Fact]
    public void Test_SimpleType()
    {
        //Arrange
        var obj = _fixture.Create<Item>();

        //Act
        var serialized = JsonConvert.SerializeObject(obj);
        var deserialized = JsonConvert.DeserializeObject<Item>(serialized); 

        //Assert

        Assert.Equal(obj, deserialized);
    }

    [Fact]
    public void Test_FirstDerivedType()
    {
        //Arrange
        var obj = _fixture.Create<ItemWithPreviewDetails>();

        //Act
        var serialized = JsonConvert.SerializeObject(obj);
        var deserialized = JsonConvert.DeserializeObject<Item>(serialized); 

        //Assert

        Assert.Equal(obj, deserialized);
    }

    [Fact]
    public void Test_SecondDerivedType()
    {
        //Arrange
        var obj = _fixture.Create<ItemWithFullDetails>();

        //Act
        var serialized = JsonConvert.SerializeObject(obj);
        var deserialized = JsonConvert.DeserializeObject<Item>(serialized); 

        //Assert

        Assert.Equal(obj, deserialized);
    }
}
