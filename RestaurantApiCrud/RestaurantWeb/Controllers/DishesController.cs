using Microsoft.AspNetCore.Mvc;
using RestaurantApi.Models; 
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

public class DishesController : Controller
{
    private readonly IHttpClientFactory _clientFactory;

    public DishesController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _clientFactory.CreateClient("RestaurantApi");
        var response = await client.GetAsync("dishes");
        if (response.IsSuccessStatusCode)
        {
            var dishes = await response.Content.ReadFromJsonAsync<List<Dish>>();
            return View(dishes);
        }
        return View(new List<Dish>());
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Dish dish)
    {
        var client = _clientFactory.CreateClient("RestaurantApi");
        var response = await client.PostAsJsonAsync("dishes", dish);
        if (response.IsSuccessStatusCode)
            return RedirectToAction(nameof(Index));
        return View(dish);
    }
}