using Microsoft.EntityFrameworkCore;
using proyectoef.Models;
namespace proyectoef;


public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext (DbContextOptions<TareasContext> options): base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit= new List<Categoria> ();
        //add datos semillas o iniciales
        categoriasInit.Add(new Categoria (){CategoriaId= Guid.Parse("444d704f-9ef9-430e-89d1-9520c2bc507a"),Nombre= "Actividades pendientes", Peso=20 });
        categoriasInit.Add(new Categoria (){CategoriaId= Guid.Parse("444d704f-9ef9-430e-89d1-9520c2bc5002"),Nombre= "Actividades personales", Peso=50 });
        //utilizando fluent api para restricciones
        modelBuilder.Entity<Categoria>(categoria=> 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=>p.CategoriaId);

            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p => p.Descripcion).IsRequired(false);

            categoria.Property(p => p.Peso);

            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit= new List<Tarea> ();
        //datos semilla
        tareasInit.Add(new Tarea () { TareaId= Guid.Parse("444d704f-9ef9-430e-89d1-9520c2bc5010"),CategoriaId=Guid.Parse ("444d704f-9ef9-430e-89d1-9520c2bc507a"), PrioridadTarea=Prioridad.Media, Titulo="Pago de servicios públicos", FechaCreacion=DateTime.UtcNow});
        
        tareasInit.Add(new Tarea () { TareaId= Guid.Parse("444d704f-9ef9-430e-89d1-9520c2bc5011"),CategoriaId=Guid.Parse ("444d704f-9ef9-430e-89d1-9520c2bc5002"), PrioridadTarea=Prioridad.Baja, Titulo="Terminar de ver peliculas en Netflix", FechaCreacion=DateTime.UtcNow});
        //fluent api 
        modelBuilder.Entity<Tarea>(tarea=> 
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=>p.TareaId);

            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p=>p.CategoriaId);
            
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            
            tarea.Property(p => p.Descripcion).IsRequired(false);

            tarea.Property(p => p.PrioridadTarea);

            tarea.Property(p => p.FechaCreacion);

            tarea.Ignore(p => p.Resumen);

            tarea.HasData(tareasInit);
        });
    }
}
