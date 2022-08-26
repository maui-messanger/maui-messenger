using AutoMapper;
using Messenger.Domains.Dtos.Chat;
using Messenger.Domains.Dtos.User;
using Messenger.Server.Extensions;
using Messenger.Server.Helpers;
using Messenger.Server.Repositories.ChatRepository;
using Messenger.Server.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen(options => Swagger.GenerateConfig(options));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();

builder.Services.AddDbContext<DataBaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => AddJwtBearer
    .GenerateConfig(options, builder));

builder.Services.AddSingleton<ITokenService>(new TokenService());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dataBase = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
    dataBase.Database.EnsureCreated();

    app.UseSwagger();
    app.UseSwaggerUI();
}

ServicesManager.InitServices(builder, app);

app.MapGet("/api/v1/chats", [Authorize] async (IChatRepository repository, IMapper mapper) =>
{
    var chats = await repository.GetAllChatsAsync();

    return Results.Ok(mapper.Map<IEnumerable<ChatReadDto>>(chats));
});

app.MapPost("/api/v1/chats", [Authorize] async (IChatRepository repository, IMapper mapper, ChatCreateDto chat) =>
{
    var chatModel = mapper.Map<Chat>(chat.Chat);
    var userModel = mapper.Map<User>(chat.User);

    var createdChat = await repository.CreateChat(userModel, chatModel);

    await repository.SaveChanges();

    return Results.Created($"/api/v1/chats/{createdChat.GlobalGuid}", mapper.Map<ChatReadDto>(createdChat));
});

app.MapGet("/", () => Results.Extensions.Html(@"HelloMessenger</br><a href=""/swagger/"">Swagger</a>"));

app.Run();


