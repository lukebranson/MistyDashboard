using MistyDashboard.ApplicationState;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
List<string> initTasks = new List<string> {
    "Conversation",
    "Dancing",
    "DetectingObj",
    "FaceRecognition",
    "Reaction",
    "RockPaperScissors",
    "SecurityCamera",
    "SoundToTextGoogle",
    "TextToSoundGoogle",
    "TicTacToe",
    "Translation"
};
builder.Services.Add(new ServiceDescriptor(typeof(IAppState), new AppState(initTasks)));
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();



app.Run();
