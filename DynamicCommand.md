public class MyController : ControllerBase
{
    private readonly IMediator _mediator;

    public MyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] JObject data)
    {
        // Dynamically determine the type of the command
        var commandType = Type.GetType(data["type"].ToString());
        if (commandType == null)
        {
            return BadRequest("Invalid command type");
        }

        // Deserialize the command data to the command type
        var command = data["data"].ToObject(commandType);

        // Use reflection to call the Send method with the command type
        var sendMethod = _mediator.GetType().GetMethod("Send");
        var genericSendMethod = sendMethod.MakeGenericMethod(commandType);
        var result = await (Task<IActionResult>)genericSendMethod.Invoke(_mediator, new[] { command });

        return result;
    }
}

# JSON Data
{
    "type": "MyNamespace.MyCommand, MyAssembly",
    "data": {
        // ...command data...
    }
}


# Generated Code
app.MapPost("/", async (IMediator mediator, JObject data) =>
{
    // Dynamically determine the type of the command
    var commandType = Type.GetType(data["type"].ToString());
    if (commandType == null)
    {
        return Results.BadRequest("Invalid command type");
    }

    // Deserialize the command data to the command type
    var command = data["data"].ToObject(commandType);

    // Use reflection to call the Send method with the command type
    var sendMethod = mediator.GetType().GetMethod("Send");
    var genericSendMethod = sendMethod.MakeGenericMethod(commandType);
    var result = await (Task<IActionResult>)genericSendMethod.Invoke(mediator, new[] { command });

    return result;
});
