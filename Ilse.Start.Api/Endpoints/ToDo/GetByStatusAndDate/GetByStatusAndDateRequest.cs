namespace Ilse.Start.Api.Endpoints.ToDo.GetByStatusAndDate;

public record GetByStatusAndDateRequest(DateTime CreatedAt, bool Status);
