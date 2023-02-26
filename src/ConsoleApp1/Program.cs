

using ConsoleApp1;
using Microsoft.Extensions.Logging;

using var factory = LoggerFactory.Create(builder =>
{
    builder.AddConsole();
});

var logger = factory.CreateLogger("Hello");

var hello = new Hello
{
    Value = "World"
};

var result = ("Cid", hello);
var x = Enumerable.Range(0, 1);
int? y = null;

logger.LogInformation("{result}", result.ToTypeExplain());
logger.LogInformation("{result}", x.ToTypeExplain());
logger.LogInformation("{result}", y?.ToTypeExplain());
