using CodecTest;
using CodecTest.Compass;
using CodecTest.Instructions;
using CodecTest.Robot;
using CodecTest.Validation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IMovement, Movement>();
        services.AddSingleton<IPosition, Position>();
        services.AddSingleton<ICommand, Command>();
        services.AddSingleton<ICompassDirections, CompassDirections>();
        services.AddTransient<IInstructionCollection, InstructionCollection>();
        services.AddTransient<IInstructionExecution, InstructionExecution>();
        services.AddTransient<IGridValidation, GridValidation>();
        services.AddTransient<IInstructionValidation, InstructionValidation>();
    })
    .Build();

var instructionCollection = host.Services.GetRequiredService<IInstructionCollection>();
CommandMenu menu = new CommandMenu(instructionCollection);
menu.GameMenuSelection();
