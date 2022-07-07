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
}).WithTags("Modelo dos Equipamentos");

app.MapDelete("ExcluirModeloEquipamento/{id}", async (Guid id, Contexto contexto) =>
{
    var modeloEquipamentoExcluir = await contexto.Equipment_model.FirstOrDefaultAsync(p => p.Id == id);
    if (modeloEquipamentoExcluir != null)
    {
        contexto.Equipment_model.Remove(modeloEquipamentoExcluir);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Modelo dos Equipamentos");

app.MapGet("ListarModelosEquipamentos", async (Contexto contexto) =>
{
    return await contexto.Equipment_model.ToListAsync();
}).WithTags("Modelo dos Equipamentos");

app.MapGet("PesquisarModeloEquipamento/{id}", async (Guid id, Contexto contexto) =>

    await contexto.Equipment_model.FindAsync(id) is Equipment_model equipmentModel
    ? Results.Ok(equipmentModel)
    : Results.NotFound())
    .WithTags("Modelo dos Equipamentos");

app.MapPut("AtualizarModeloEquipamento/{id}", async (Guid id, Contexto contexto) =>
{
    var modeloEquipamentoAtualizar = await contexto.Equipment_model.FirstOrDefaultAsync(eq => eq.Id == id);
    if (modeloEquipamentoAtualizar != null)
    {
        contexto.Equipment_model.Update(modeloEquipamentoAtualizar);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Modelo dos Equipamentos");
#endregion

#region Equipment_model_state_hourly_earnings Actions
app.MapPost("Adicionar EquipmentModel_SHE", async (Equipment_model_state_hourly_earnings equipment_mshe, Contexto contexto) =>
{
    contexto.Equipment_model_state_hourly_earnings.Add(equipment_mshe);
    await contexto.SaveChangesAsync();
    return Results.Created($"/Equipamento Adicionado/{equipment_mshe.Equipment_model_id}", equipment_mshe);

}) .WithTags("Ganhos por Hora/Equipamentos");

app.MapDelete("Excluir EquipmentModel_SHE/{id}", async (Guid id, Contexto contexto) =>
{
    var equipModelsheExcluir = await contexto.Equipment_model_state_hourly_earnings.FirstOrDefaultAsync(eq => eq.Equipment_model_id == id);
    if (equipModelsheExcluir != null)
    {
        contexto.Equipment_model_state_hourly_earnings.Remove(equipModelsheExcluir);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Ganhos por Hora/Equipamentos");

app.MapGet("Listar EquipmentModel_SHE", async (Contexto contexto) => 
{ 
    return await contexto.Equipment_model_state_hourly_earnings.ToListAsync(); 
})
   .WithTags("Ganhos por Hora/Equipamentos");

app.MapGet("Pesquisar EquipmentModel_SHE/{id}", async (Guid id, Contexto contexto) =>

    await contexto.Equipment_model_state_hourly_earnings.Where(e => e.Equipment_model_id == id).ToListAsync() is List<Equipment_model_state_hourly_earnings> equipment_mshe
    ? Results.Ok(equipment_mshe)
    : Results.NotFound("Resultado nao encontrado !!"))
    .WithTags("Ganhos por Hora/Equipamentos");

app.MapPut("Atualizar EquipmentModel_SHE/{id}", async (Guid id, Equipment_model_state_hourly_earnings inputEquip, Contexto contexto) =>
{
    var AtualizarequipModelshe = await contexto.Equipment_model_state_hourly_earnings.FindAsync(id);
    if (AtualizarequipModelshe is null) return Results.NotFound("Resultado nao encontrado !!");
    AtualizarequipModelshe.Value = inputEquip.Value;

    await contexto.SaveChangesAsync();

    return Results.NoContent()
    ;
})
    .WithTags("Ganhos por Hora/Equipamentos");
#endregion

#region Equipment Position History Actions
app.MapPost("Adicionar Equipment Position History", async (Equipment_position_history equipment_position, Contexto contexto) =>
{
    contexto.Equipment_position_history.Add(equipment_position);
    await contexto.SaveChangesAsync();
    return Results.Created($"/Equipamento Adicionado/{equipment_position.Equipment_id}", equipment_position);

}).WithTags("Historico de Posiçao Equipamentos");

app.MapDelete("Excluir Equipment Position History/{id}", async (Guid id, Contexto contexto) =>
{
    var equipPositionExcluir = await contexto.Equipment_position_history.FirstOrDefaultAsync(eq => eq.Equipment_id == id);
    if (equipPositionExcluir != null)
    {
        contexto.Equipment_position_history.Remove(equipPositionExcluir);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Historico de Posiçao Equipamentos");

app.MapGet("Listar Equipment Position History", async (Contexto contexto) =>

    await contexto.Equipment_position_history.ToListAsync())
   .WithTags("Historico de Posiçao Equipamentos");

app.MapGet("Pesquisar Equipment Position History/{id}", async (Guid id, Contexto contexto) =>

    await contexto.Equipment_position_history.Where(e => e.Equipment_id == id).ToListAsync() is List<Equipment_position_history> equipment_position
    ? Results.Ok(equipment_position)
    : Results.NotFound("Resultado nao encontrado !!"))
    .WithTags("Historico de Posiçao Equipamentos");

app.MapPut("Atualizar Equipment Position History/{id}", async (Guid id, Equipment_position_history inputEquip, Contexto contexto) =>
{
    var AtualizarequipPosition = await contexto.Equipment_position_history.FindAsync(id);
    if (AtualizarequipPosition is null) return Results.NotFound("Resultado nao encontrado !!");
    //AtualizarequipPosition.Value = inputEquip.Value;

    await contexto.SaveChangesAsync();

    return Results.NoContent()
    ;
})
    .WithTags("Historico de Posiçao Equipamentos");
#endregion

#region Equipment_state Actions
app.MapPost("Adicionar Estado do Equipamento", async (Equipment_state equipment_state, Contexto contexto) =>
{
    contexto.Equipment_state.Add(equipment_state);
    await contexto.SaveChangesAsync();
    return Results.Created($"/Adicionado/{equipment_state.Id}", equipment_state);

}).WithTags("Estado do Equipamento");

app.MapDelete("Excluir Estado do Equipamento/{id}", async (Guid id, Contexto contexto) =>
{
    var equipStateExcluir = await contexto.Equipment_state.FirstOrDefaultAsync(e => e.Id == id);
    if (equipStateExcluir != null)
    {
        contexto.Equipment_state.Remove(equipStateExcluir);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Estado do Equipamento");

app.MapGet("Listar Estado do Equipamento", async (Contexto contexto) =>

    await contexto.Equipment_state.ToListAsync())
   .WithTags("Estado do Equipamento");

app.MapGet("Pesquisar Estado do Equipamento/{id}", async (Guid id, Contexto contexto) =>

    await contexto.Equipment_state.Where(e => e.Id == id).ToListAsync() is List<Equipment_state> equipment_state
    ? Results.Ok(equipment_state)
    : Results.NotFound("Resultado nao encontrado !!"))
    .WithTags("Estado do Equipamento");

app.MapPut("Atualizar Estado do Equipamento/{id}", async (Guid id, Equipment_state inputEquip, Contexto contexto) =>
{
    var equipStateAtualizar = await contexto.Equipment_state.FindAsync(id);
    if (equipStateAtualizar is null) return Results.NotFound("Resultado nao encontrado !!");
    //AtualizarequipPosition.Value = inputEquip.Value;

    await contexto.SaveChangesAsync();

    return Results.NoContent()
    ;
})
    .WithTags("Estado do Equipamento");
#endregion

#region Equipment_state_history Actions
app.MapPost("Adicionar Historico de Estado do Equipamento", async (Equipment_state_history equipment_state_history, Contexto contexto) =>
{
    contexto.Equipment_state_history.Add(equipment_state_history);
    await contexto.SaveChangesAsync();
    return Results.Created($"/Adicionado/{equipment_state_history.Equipment_id}", equipment_state_history);

}).WithTags("Historico de Estado do Equipamento");

app.MapDelete("Excluir Historico de Estado do Equipamento/{id}", async (Guid id, Contexto contexto) =>
{
    var equipStateHistoryExcluir = await contexto.Equipment_state_history.FirstOrDefaultAsync(e => e.Equipment_id == id);
    if (equipStateHistoryExcluir != null)
    {
        contexto.Equipment_state_history.Remove(equipStateHistoryExcluir);
        await contexto.SaveChangesAsync();
    }
}).WithTags("Historico de Estado do Equipamento");

app.MapGet("Listar Historico de Estado do Equipamento", async (Contexto contexto) =>

    await contexto.Equipment_state_history.ToListAsync())
   .WithTags("Historico de Estado do Equipamento");

app.MapGet("Pesquisar Historico de Estado do Equipamento/{id}", async (Guid id, Contexto contexto) =>

    await contexto.Equipment_state_history.Where(e => e.Equipment_id == id).ToListAsync() is List<Equipment_state_history> equipment_state_history
    ? Results.Ok(equipment_state_history)
    : Results.NotFound("Resultado nao encontrado !!"))
    .WithTags("Historico de Estado do Equipamento");

app.MapPut("Atualizar Historico de Estado do Equipamento/{id}", async (Guid id, Equipment_state_history inputEquip, Contexto contexto) =>
{
    var equipStateAtualizar = await contexto.Equipment_state_history.FindAsync(id);
    if (equipStateAtualizar is null) return Results.NotFound("Resultado nao encontrado !!");
    //AtualizarequipPosition.Value = inputEquip.Value;

    await contexto.SaveChangesAsync();

    return Results.NoContent()
    ;
})
    .WithTags("Historico de Estado do Equipamento");
#endregion



app.Run();