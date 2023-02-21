namespace HorrorFlux.Common.DTOs;

public record ClickModel(string PageType, int Id);
public record ClickModelReferens<TDto>(string PageType, TDto dto);
