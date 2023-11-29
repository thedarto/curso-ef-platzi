using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
using proyectoef.Models;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//builder.Services.AddDbContext<TareasContext>(p=>p.UseInMemoryDatabase("TareasDb"));
builder.Services.AddNpgsql<TareasContext>(builder.Configuration.GetConnectionString("TareasDb"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//crea la base de datos si es que no está cread
app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: "+dbContext.Database.IsInMemory());
});
//migraciones: dotnet ef migrations add nombre_de_la migracion (sirve para llevar un registro)
//dotnet ef database update: añadir la migracion a la base de datos
//solo tiene que ver con los modelos y el contexto
app.MapGet("/api/tareas",async ([FromServices] TareasContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria));
    //.Where(p=>p.PrioridadTarea== proyectoef.Models.Prioridad.Baja)
});

app.MapPost("/api/tareas",async ([FromServices] TareasContext dbContext,[FromBody] Tarea tarea) =>
{
    tarea.TareaId=Guid.NewGuid();
    tarea.FechaCreacion=DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea); otra forma

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tareas/{id}",async ([FromServices] TareasContext dbContext,[FromBody] Tarea tarea, [FromRoute]  Guid id ) =>
{
    var tareaActual= dbContext.Tareas.Find(id);
    if(tareaActual!=null)
    {
        tareaActual.CategoriaId=tarea.CategoriaId;
        tareaActual.Titulo=tarea.Titulo;
        tareaActual.PrioridadTarea=tarea.PrioridadTarea;
        tareaActual.Descripcion=tarea.Descripcion;  

    await dbContext.SaveChangesAsync();

    return Results.Ok();
    }
    return  Results.NotFound();
});

app.MapDelete("/api/tareas/{id}",async ([FromServices] TareasContext dbContext, [FromRoute]  Guid id ) =>
{
    var tareaActual= dbContext.Tareas.Find(id);

    if(tareaActual!=null)
    {
    dbContext.Remove(tareaActual);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
    }
    return  Results.NotFound();
});
app.Run();
