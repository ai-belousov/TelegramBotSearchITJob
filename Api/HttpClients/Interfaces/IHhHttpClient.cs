using System.Collections;
using Api.DTO.Request;

namespace Api.HttpClients.Interfaces;

public interface IHhHttpClient
{
    public Task AuthClient(AuthDTO authDto);
}