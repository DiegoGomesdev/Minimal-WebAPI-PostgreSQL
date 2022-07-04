using Microsoft.EntityFrameworkCore;
using WebAPI_Equipamentos.Contexto;
using WebAPI_Equipamentos.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<Contexto>(options 
=> options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

#region Equipment Actions
app.MapPost("AdicionarEquipamento", async(Equipment equipment, Contexto contexto) =>
{
    contexto.Equipment.Add(equipment);
    await contexto.SaveChangesAsync();
    return Results.Created($"/Equipamento Adicionado/{equipment.Id}", equipment);

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

app.MapGet("PesquisarEquipamento/{id}", async (Guid id,Contexto contexto) =>

    await contexto.Equipment.FindAsync(id) is Equipment equipmento
    ? Results.Ok(equipmento)
    : Results.NotFound());

app.MapPut("AtualizarEquipamento/{id}", async (Guid id, Equipment inputEquip, Contexto contexto) =>
{
    var AtualizarEquipamento = await contexto.Equipment.FindAsync(id);
    if (AtualizarEquipamento is null) return Results.NotFound();
    AtualizarEquipamento.Name = inputEquip.Name;

    await contexto.SaveChangesAsync();

    return Results.NoContent();
});
#endregion

#region Equipment_model Actions

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

app.MapGet("PesquisarModeloEquipamento/{id}", async (Guid id, Contexto contexto) =>

    await contexto.Equipment_model.FindAsync(id) is Equipment_model equipmentModel
    ? Results.Ok(equipmentModel)
    : Results.NotFound())
    .WithTags("Modelos Equipamentos");

app.MapPut("AtualizarModeloEquipamento/{id}", async (Guid id, Contexto contexto) =>
{
    var modeloEquipamentoAtualizar = await contexto.Equipment_model.FirstOrDefaultAsync(eq => eq.Id == id);
    if (modeloEquipamentoAtualizar != null)
    {
        contexto.Equipment_model.Update(modeloEquipamentoAtualizar);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Modelos Equipamentos");
#endregion

#region Equipment_model_state_hourly_earnings Actions
app.MapPost("Adicionar EquipmentModel_SHE ", async (Equipment_model_state_hourly_earnings equipment_mshe, Contexto contexto) =>
{
    contexto.Equipment_model_state_hourly_earnings.Add(equipment_mshe);
    await contexto.SaveChangesAsync();
    return Results.Created($"/Equipamento Adicionado/{equipment_mshe.Equipment_model_id}", equipment_mshe);

}) .WithTags("Equipment_model_state_hourly_earnings");

app.MapDelete("Excluir EquipmentModel_SHE/{id}", async (Guid id, Contexto contexto) =>
{
    var equipModelsheExcluir = await contexto.Equipment_model_state_hourly_earnings.FirstOrDefaultAsync(eq => eq.Equipment_model_id == id);
    if (equipModelsheExcluir != null)
    {
        contexto.Equipment_model_state_hourly_earnings.Remove(equipModelsheExcluir);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Equipment_model_state_hourly_earnings");

app.MapGet("Listar EquipmentModel_SHE", async (Contexto contexto) => 
{ 
    return await contexto.Equipment_model_state_hourly_earnings.ToListAsync(); 
})
   .WithTags("Equipment_model_state_hourly_earnings");

app.MapGet("Pesquisar EquipmentModel_SHE/{id}", async (Guid id, Contexto contexto) =>

    await contexto.Equipment_model_state_hourly_earnings.FindAsync(id) is Equipment_model_state_hourly_earnings equipment_mshe
    ? Results.Ok(equipment_mshe)
    : Results.NotFound("Resultado nao encontrado !!"))
    .WithTags("Equipment_model_state_hourly_earnings");

app.MapPut("Atualizar EquipmentModel_SHE/{id}", async (Guid id, Equipment_model_state_hourly_earnings inputEquip, Contexto contexto) =>
{
    var AtualizarequipModelshe = await contexto.Equipment_model_state_hourly_earnings.FindAsync(id);
    if (AtualizarequipModelshe is null) return Results.NotFound("Resultado nao encontrado !!");
    AtualizarequipModelshe.Value = inputEquip.Value;

    await contexto.SaveChangesAsync();

    return Results.NoContent()
    ;
})
    .WithTags("Equipment_model_state_hourly_earnings");
#endregion

#region Equipment Position History Actions
app.MapPost("Adicionar Equipment Position History ", async (Equipment_position_history equipment_position, Contexto contexto) =>
{
    contexto.Equipment_position_history.Add(equipment_position);
    await contexto.SaveChangesAsync();
    return Results.Created($"/Equipamento Adicionado/{equipment_position.Equipment_id}", equipment_position);

}).WithTags("Equipment Position History");

app.MapDelete("Excluir Equipment Position History/{id}", async (Guid id, Contexto contexto) =>
{
    var equipPositionExcluir = await contexto.Equipment_position_history.FirstOrDefaultAsync(eq => eq.Equipment_id == id);
    if (equipPositionExcluir != null)
    {
        contexto.Equipment_position_history.Remove(equipPositionExcluir);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Equipment Position History");

app.MapGet("Listar Equipment Position History", async (Contexto contexto) =>
{
    return await contexto.Equipment_position_history.ToListAsync();
})
   .WithTags("Equipment Position History");

app.MapGet("Pesquisar Equipment Position History/{id}", async (Guid id, Contexto contexto) =>

    await contexto.Equipment_position_history.FindAsync(id) is Equipment_position_history equipment_position
    ? Results.Ok(equipment_position)
    : Results.NotFound("Resultado nao encontrado !!"))
    .WithTags("Equipment Position History");

app.MapPut("Atualizar Equipment Position History/{id}", async (Guid id, Equipment_position_history inputEquip, Contexto contexto) =>
{
    var AtualizarequipPosition = await contexto.Equipment_position_history.FindAsync(id);
    if (AtualizarequipPosition is null) return Results.NotFound("Resultado nao encontrado !!");
    //AtualizarequipPosition.Value = inputEquip.Value;

    await contexto.SaveChangesAsync();

    return Results.NoContent()
    ;
})
    .WithTags("Equipment Position History");
#endregion

app.Run();