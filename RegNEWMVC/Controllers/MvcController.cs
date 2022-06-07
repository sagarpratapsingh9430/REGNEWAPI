using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegNEWMVC.Models;
namespace RegNEWMVC.Controllers
{
    public class MvcController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<MvcModel> emp = new List<MvcModel>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7098/");

            var res = await client.GetAsync("api/Api/get");
            if (res.IsSuccessStatusCode)
            {
                var Result = res.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<List<MvcModel>>(Result);
            }
            return View(emp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MvcModel mac)
        {
            if(ModelState.IsValid)
            {
                return View();
            }
            else
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:7098/");
                var res = client.PostAsJsonAsync<MvcModel>("api/Api/create", mac);
                res.Wait();

                var res1 = res.Result;
                if (res1.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
                return View();
            }
            
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var student = new MvcModel();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7098/");
            HttpResponseMessage res = await client.DeleteAsync($"api/Api/Delete/{Id}");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var student = new MvcModel();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7098/");
            HttpResponseMessage res = await client.GetAsync($"api/Api/Edit/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var Result = res.Content.ReadAsStringAsync().Result;
                student = JsonConvert.DeserializeObject<MvcModel>(Result);
            }
            return View(student);
        }
    }
}
