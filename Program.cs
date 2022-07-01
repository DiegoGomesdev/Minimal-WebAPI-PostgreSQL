using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using WebAPI_Equipamentos.Contexto;
using WebAPI_Equipamentos.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Contexto>(options 
=> options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);

/*builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Contexto>(option
    => option.UseNpgsql("User ID=postgres;Password=2915;Server=localhost;Port=5432;Database=dbequipamentos;Pooling=true;SearchPath=operation;"));*/

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapPost("AdicionarEquipamento", async(Equipment equipment, Contexto contexto) =>
{
    contexto.Equipment.Add(equipment);
    await contexto.SaveChangesAsync();
})
  .Produces<Equipment>(StatusCodes.Status201Created)
  .Produces(StatusCodes.Status400BadRequest);

app.MapDelete("ExcluirEquipamento/{id}", async (Guid id, Contexto contexto) =>
{
    var equipamentoExcluir = await contexto.Equipment.FirstOrDefaultAsync(eq => eq.Id == id);
    if (equipamentoExcluir != null)
    {
        contexto.Equipment.Remove(equipamentoExcluir);
        await contexto.SaveChangesAsync();
    }     
});
app.MapGet("ListarEquipamentos", async (Contexto contexto) =>
{
     return await contexto.Equipment.ToListAsync();
}); 

app.MapGet("ListarEquipamento/{id}", async (Guid id,Contexto contexto) =>
{
    var equipamentoLista = await contexto.Equipment.FirstOrDefaultAsync(eq => eq.Id == id);

        return  equipamentoLista;
});

app.MapPut("AtualizarEquipamento/{id}", async (Guid id, Contexto contexto) =>
{
    var equipamentoAtualizar = await contexto.Equipment.FirstOrDefaultAsync(eq => eq.Id == id);
    if (equipamentoAtualizar != null)
    {
        contexto.Equipment.Update(equipamentoAtualizar);
        await contexto.SaveChangesAsync();
    }   
});

app.MapPost("AdicionarModelosEquipamento", async (Equipment_model equipment_model, Contexto contexto) =>
{
    contexto.Equipment_model.Add(equipment_model);
    await contexto.SaveChangesAsync();
}).WithTags("Modelos Equipamentos");

app.MapDelete("ExcluirModeloEquipamento/{id}", async (Guid id, Contexto contexto) =>
{
    var modeloEquipamentoExcluir = await contexto.Equipment_model.FirstOrDefaultAsync(p => p.Id == id);
    if (modeloEquipamentoExcluir != null)
    {
        contexto.Equipment_model.Remove(modeloEquipamentoExcluir);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Modelos Equipamentos");

app.MapGet("ListarModelosEquipamentos", async (Contexto contexto) =>
{
    return await contexto.Equipment_model.ToListAsync();
}).WithTags("Modelos Equipamentos");

app.MapPut("AtualizarModeloEquipamento/{id}", async (Guid id, Contexto contexto) =>
{
    var modeloEquipamentoAtualizar = await contexto.Equipment_model.FirstOrDefaultAsync(eq => eq.Id == id);
    if (modeloEquipamentoAtualizar != null)
    {
        contexto.Equipment_model.Update(modeloEquipamentoAtualizar);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Modelos Equipamentos");

app.Run();