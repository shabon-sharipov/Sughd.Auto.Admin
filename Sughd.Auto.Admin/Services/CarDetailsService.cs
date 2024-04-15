﻿using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Sughd.Auto.Admin.Services.RequestModels;
using Sughd.Auto.Admin.Services.ResponseModels;

namespace Sughd.Auto.Admin.Services;

public interface ICarDetailsService
{
    Task<List<CarMarkaResponsModel>> GetCarMarka();
    Task UpdateCarMarka(long markaId, CarMarkaRequest carMarkaRequest);
    Task<HttpStatusCode> AddCarMarka(CarMarkaRequest carMarkaRequest);
    Task<List<CarModelResponseModel>> GetCarModelByMarkaId(long markaId);
    Task<List<CarModelResponseModel>> GetCarModel();
    Task<HttpStatusCode> AddCarModel(CarModelRequest carModelRequest);
    Task UpdateCarModel(long modelId, CarModelRequest carModelRequest);
    Task<List<string>> FuelType();
    Task<List<string>> CarBady();
    Task<List<string>> Transmission();
}

public class CarDetailsService : ICarDetailsService
{
    private HttpClient _httpClient;

    public CarDetailsService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    #region Marka

    public async Task<List<CarMarkaResponsModel>> GetCarMarka()
    {
        var carMarka =
            await _httpClient.GetFromJsonAsync<List<CarMarkaResponsModel>>("Marka/GetAll?offSet=0&pageSize=100");
        return carMarka;
    }

    public async Task UpdateCarMarka(long markaId, CarMarkaRequest carMarkaRequest)
    {
        await _httpClient.PutAsJsonAsync($"Marka?id={markaId}", carMarkaRequest);
    }

    public async Task<HttpStatusCode> AddCarMarka(CarMarkaRequest carMarkaRequest)
    {
        var responseMessage =  await _httpClient.PostAsJsonAsync("Marka", carMarkaRequest);
        return responseMessage.StatusCode;
    }
    public async Task<List<CarModelResponseModel>> GetCarModelByMarkaId(long markaId)
    {
        var models =
            await _httpClient.GetFromJsonAsync<List<CarModelResponseModel>>($"Model/GetByMarkaId?markaId={markaId}");
        return models;
    }

    #endregion

    #region Models

    public async Task<List<CarModelResponseModel>> GetCarModel()
    {
        var carMarka =
            await _httpClient.GetFromJsonAsync<List<CarModelResponseModel>>("Model/GetAll?offSet=0&pageSize=100");
        return carMarka;
    }

    public async Task<HttpStatusCode> AddCarModel(CarModelRequest carModelRequest)
    {
        var responseMessage =  await _httpClient.PostAsJsonAsync("Marka", carModelRequest);
        return responseMessage.StatusCode;
    }

    public async Task UpdateCarModel(long modelId, CarModelRequest carModelRequest)
    {
        await _httpClient.PutAsJsonAsync($"Model?id={modelId}", carModelRequest);
    }

    #endregion
    

    #region Get CarBady, FuelType and Transmission

    private async Task<Dictionary<string, object>> GetCarDetails()
    {
        var dictionary = await _httpClient.GetFromJsonAsync<Dictionary<string, object>>("CarDetails/GetAll");
        return dictionary;
    }

    public async Task<List<string>> CarBady()
    {
        var carDetails = await GetCarDetails();
        return (carDetails.TryGetValue("CarBody", out var detail)
            ? JsonConvert.DeserializeObject<List<string>>(detail.ToString()!)
            : null)!;
    }

    public async Task<List<string>> FuelType()
    {
        var carDetails = await GetCarDetails();
        return (carDetails.TryGetValue("FuelType", out var detail)
            ? JsonConvert.DeserializeObject<List<string>>(detail.ToString()!)
            : null)!;
    }

    public async Task<List<string>> Transmission()
    {
        var carDetails = await GetCarDetails();
        return (carDetails.TryGetValue("Transmission", out var detail)
            ? JsonConvert.DeserializeObject<List<string>>(detail.ToString()!)
            : null)!;
    }

    #endregion
}