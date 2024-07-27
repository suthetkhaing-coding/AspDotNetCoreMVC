using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using AspDotNetCoreMVC.Models;

namespace AspDotNetCoreMVC.Controllers
{
    public class PersonController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7219");
        //Uri baseAddress = new Uri("http://192.168.192.100/");
        private readonly HttpClient _client;

        public PersonController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        // GET: Person
        [HttpGet]
        public IActionResult Index()
        {
            List<PersonModel> lst = new List<PersonModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "Person/GetPersons").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                lst = JsonConvert.DeserializeObject<List<PersonModel>>(data)!;
            }

            return View(lst);
        }

        // GET: Person/Details/5
        [HttpGet]
        public IActionResult Details(int? id)
        {
            try
            {
                PersonModel personModel = new PersonModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "Person/GetPersonModel/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    personModel = JsonConvert.DeserializeObject<PersonModel>(data)!;
                }
                return View(personModel);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Person/Create
        [HttpGet]
        public IActionResult Create()
        {
            List<string> bloodTypes = new List<string>
        {
            "A",
            "B",
            "AB",
            "O"
        };

            ViewBag.BloodTypes = bloodTypes;

            List<string> religiousOptions = new List<string>
        {
            "ဗုဒ္ဓဘာသာ",
            "အစ္စလာမ်",
            "ခရစ်ယာန်",
            "ဟိန္ဒူ",
            "အခြား"
        };

            ViewBag.ReligiousOptions = religiousOptions;

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([FromForm] PersonModel reqModel)
        {
            ResponseModel responseModel = new ResponseModel();
            string filePath = "";
            try
            {
                if (reqModel.Photo1 != null && reqModel.Photo1.Length > 0)
                {
                    var fileName = $"{Guid.NewGuid()}_{reqModel.Photo1.FileName}";

                    filePath = Path.Combine("wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        reqModel.Photo1.CopyTo(stream);
                    }
                }
                reqModel.Photo = filePath;
                reqModel.PersonNo = "1";
                reqModel.IsDeleted = false;
                reqModel.CreatedDate = DateTime.Now;
                reqModel.UpdatedDate = DateTime.Now;
                string data = JsonConvert.SerializeObject(reqModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "Person/AddPerson", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    responseModel.respCode = "000";
                    responseModel.respMsg = "";
                }
                else
                {
                    responseModel.respCode = "999";
                    responseModel.respMsg = "Fail!!";
                }
            }
            catch (Exception ex)
            {
                responseModel.respCode = "999";
                responseModel.respMsg = "Error: " + ex.Message;
            }
            return Json(responseModel);
        }

        // GET: Person/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            try
            {
                PersonModel personModel = new PersonModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "Person/GetPersonModel/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    personModel = JsonConvert.DeserializeObject<PersonModel>(data)!;
                }
                return View(personModel);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

         [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(int id, PersonModel personModel)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                string data = JsonConvert.SerializeObject(personModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "Person/UpdatePerson/" + id, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    responseModel.respCode = "000";
                    responseModel.respMsg = "Update Successful!!!";
                }
                else
                {
                    responseModel.respCode = "999";
                    responseModel.respMsg = "Fail!!";
                }
            }
            catch (Exception ex)
            {
                responseModel.respCode = "999";
                responseModel.respMsg = "Error: " + ex.Message;
            }
            return Json(responseModel);
        }

        // GET: Person/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            try
            {
                PersonModel personModel = new PersonModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "Person/GetPersonModel/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    personModel = JsonConvert.DeserializeObject<PersonModel>(data)!;
                }
                return View(personModel);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }


        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        //[HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "Person/DeletePerson/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    responseModel.respCode = "000";
                    responseModel.respMsg = "Delete Successful!!!";
                }
                else
                {
                    responseModel.respCode = "999";
                    responseModel.respMsg = "Fail!!";
                }
            }
            catch (Exception ex)
            {
                responseModel.respCode = "999";
                responseModel.respMsg = "Error: " + ex.Message;
            }
            return Json(responseModel);
        }
    }
}
