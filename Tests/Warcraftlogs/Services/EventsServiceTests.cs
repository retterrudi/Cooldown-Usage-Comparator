using Cooldown_Usage_Comparator.Warcraftlogs.Services;
using Xunit;

namespace Cooldown_Usage_Comparator.Tests.Warcraftlogs.Services;

public class EventsServiceTests
{
    [Fact]
    public void ExtractEvents_ValidJson_ReturnListWithThreeCorrectItems()
    {
        var eventsService = new EventsService();

        const string input = @"
        {
          ""data"": {
            ""reportData"": {
              ""report"": {
                ""events"": {
                  ""data"": [
                    {
                      ""timestamp"": 365936,
                      ""type"": ""applybuff"",
                      ""sourceID"": 47,
                      ""sourceInstance"": 1,
                      ""targetID"": 46,
                      ""abilityGameID"": 192082,
                      ""fight"": 1
                    },
                    {
                      ""timestamp"": 371073,
                      ""type"": ""applybuff"",
                      ""sourceID"": 45,
                      ""targetID"": 46,
                      ""abilityGameID"": 434029,
                      ""fight"": 1
                    },
                    {
                      ""timestamp"": 376077,
                      ""type"": ""removebuff"",
                      ""sourceID"": 45,
                      ""targetID"": 46,
                      ""abilityGameID"": 434029,
                      ""fight"": 1
                    }
                  ]
                }
              }
            }
          }
        }";

        var actualValue = eventsService.ExtractEvents(input);
        
        Assert.NotNull(actualValue);
        Assert.Equal(3, actualValue.Count);
        Assert.Equal(365936, actualValue[0].Timestamp);
        Assert.Equal(47, actualValue[0].SourceId);
        Assert.Equal(46, actualValue[0].TargetId);
        Assert.Equal(192082, actualValue[0].AbilityGameId);
        Assert.Equal("applybuff", actualValue[0].Type);
    }

    [Fact]
    public void ExtractEvents_ValidJsonWithEmptyData_ReturnEmptyList()
    { 
        var eventsService = new EventsService();

        const string input = @"
        {
          ""data"": {
            ""reportData"": {
              ""report"": {
                ""events"": {
                  ""data"": [
                  ]
                }
              }
            }
          }
        }";

        var actualValue = eventsService.ExtractEvents(input);

        Assert.NotNull(actualValue);
        Assert.Equal([], actualValue);
    }
    
    [Fact]
    public void ExtractEvents_ValidJsonWithNullValues_ReturnListWithTwoItemsAllNull()
    {
        var eventsService = new EventsService();

        const string input = @"
        {
          ""data"": {
            ""reportData"": {
              ""report"": {
                ""events"": {
                  ""data"": [
                    {
                      ""timestamp"": null,
                      ""type"": null,
                      ""sourceID"": null,
                      ""sourceInstance"": null,
                      ""targetID"": null,
                      ""abilityGameID"": null,
                      ""fight"": null
                    },
                    {
                    }
                  ]
                }
              }
            }
          }
        }";

        var actualValue = eventsService.ExtractEvents(input);
        
        Assert.NotNull(actualValue);
        Assert.NotNull(actualValue[0]);
        Assert.Null(actualValue[0].AbilityGameId);
        Assert.Null(actualValue[0].SourceId);
        Assert.Null(actualValue[0].TargetId);
        Assert.Null(actualValue[0].Timestamp);
        Assert.Null(actualValue[0].Type);

        Assert.NotNull(actualValue[1]);
        Assert.Null(actualValue[1].AbilityGameId);
        Assert.Null(actualValue[1].SourceId);
        Assert.Null(actualValue[1].TargetId);
        Assert.Null(actualValue[1].Timestamp);
        Assert.Null(actualValue[1].Type);
    }
}