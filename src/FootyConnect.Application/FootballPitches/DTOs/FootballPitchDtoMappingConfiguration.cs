using FootyConnect.Domain.Entities;

namespace FootyConnect.Application.FootballPitches.DTOs;

public static class FootballPitchDtoMappingConfiguration
{
    public static IEnumerable<FootballPitchDto> ToDtos(this IEnumerable<FootballPitch> footballPitches)
    {
        return footballPitches.Select(fp => fp.ToDto());
    }   

    public static FootballPitchDto ToDto(this FootballPitch footballPitch)
    {
        return new FootballPitchDto
        {
            Id = footballPitch.Id,
            Name = footballPitch.Name
        };
    }
}
