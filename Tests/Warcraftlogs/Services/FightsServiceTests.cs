using Cooldown_Usage_Comparator.Warcraftlogs.Services;
using Xunit;

namespace Cooldown_Usage_Comparator.Tests.Warcraftlogs.Services;

public class FightsServiceTests
{
    [Fact]
    public void ExtractFights_ValidJson_ReturnsTwoFights()
    {
        const string input = @"
            {
              ""data"": {
                ""reportData"": {
                  ""report"": {
                    ""fights"": [
                      {
                        ""difficulty"": 10,
                        ""encounterID"": 12648,
                        ""endTime"": 1935438,
                        ""friendlyPlayers"": [
                          46,
                          35,
                          42,
                          39,
                          45
                        ],
                        ""id"": 1,
                        ""keystoneBonus"": 1,
                        ""keystoneLevel"": 8,
                        ""keystoneTime"": 1620775,
                        ""name"": ""The Rookery"",
                        ""startTime"": 361559
                      },
                      {
                        ""difficulty"": 10,
                        ""encounterID"": 61594,
                        ""endTime"": 6947958,
                        ""friendlyPlayers"": [
                          494,
                          484,
                          46,
                          469,
                          35
                        ],
                        ""id"": 3,
                        ""keystoneBonus"": 0,
                        ""keystoneLevel"": 8,
                        ""keystoneTime"": 2019239,
                        ""name"": ""The MOTHERLODE!!"",
                        ""startTime"": 4975721
                      }
                    ]
                  }
                }
              }
            }";

        var service = new FightsService();

        var actualValue = service.ExtractFights(input);

        Assert.NotNull(actualValue);
        Assert.Equal(2, actualValue.Count);
        Assert.Equal(10, actualValue[0].Difficulty);
        Assert.Equal(12648, actualValue[0].EncounterId);
        Assert.Equal(1935438, actualValue[0].EndTime);
        Assert.Equal([46, 35, 42, 39, 45], actualValue[0].FriendlyPlayers);
        Assert.Equal(1, actualValue[0].Id);
        Assert.Equal(1, actualValue[0].KeystoneBonus);
        Assert.Equal(8, actualValue[0].KeystoneLevel);
        Assert.Equal(1620775, actualValue[0].KeystoneTime);
        Assert.Equal("The Rookery", actualValue[0].Name);
        Assert.Equal(361559, actualValue[0].StartTime);
    }

    [Fact]
    public void ExtractFights_ValidJsonEmptyFights_ReturnEmptyList()
    {
        const string input = @"
            {
              ""data"": {
                ""reportData"": {
                  ""report"": {
                    ""fights"": [
                    ]
                  }
                }
              }
            }";
        
        var service = new FightsService();

        var actualValue = service.ExtractFights(input);

        Assert.NotNull(actualValue);
        Assert.Equal([], actualValue);
    }
}