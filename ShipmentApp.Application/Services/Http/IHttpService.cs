namespace ShipmentApp.Application.Services.Http
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string url);
    }
}
