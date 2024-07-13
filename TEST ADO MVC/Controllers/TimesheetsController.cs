using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TEST_ADO_MVC.DAL;
using TEST_ADO_MVC.Models;

namespace TEST_ADO_MVC.Controllers
{
    public class TimesheetsController : Controller
    {
        private readonly Timesheets_DAL _dal;
        public TimesheetsController(Timesheets_DAL dal)//Ссылка на слой данных БД.
        {
            _dal= dal;
        }

        [HttpGet]
        public IActionResult Index()//Основная страница с данными.
        {
            List<Timesheets> timesheets = new List<Timesheets>();
            try
            {
                timesheets = _dal.GetAll();//Вызывается метод, который заполняет таблицу на форме из БД.

            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }


            return View(timesheets);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Timesheets model)//Страница добавления данных в таблицу и БД.
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["errorMessage"] = "Model data is invalid";
                }
                bool result = _dal.Insert(model);//Вызывается метод, который добавляет данные на форму и БД.

                if (!result)
                {
                    TempData["errorMessage"] = "Unable to save data";
                    return View();
                }
                TempData["successMessage"] = "Данные сохранены";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public IActionResult Edit(int id)//Получение строки для изменения при нажатии кнопки Edit или переадресации по ссылке.
        {
            try
            {
                Timesheets timesheets = _dal.GetbyId(id);
                if (timesheets.id == 0)
                {
                    TempData["errorMessage"] = $"Запись с идентификатором ({id}) не найдена.";
                    return RedirectToAction("Index");
                }
                return View(timesheets);
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(Timesheets model)//Основной метод изменения данных в выбранной строке.
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["errorMessage"] = "Model data is invalid";
                }
                bool result = _dal.Update(model);//Вызывается метод из DAL, который обновляет данные в форме и базе.

                if (!result)
                {
                    TempData["errorMessage"] = "Unable to save data";
                    return View();
                }
                TempData["successMessage"] = "Данные сохранены";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)//Метод для получения строки для удаления.
        {
            try
            {
                Timesheets timesheets = _dal.GetbyId(id);
                if (timesheets.id == 0)
                {
                    TempData["errorMessage"] = $"Запись с идентификатором ({id}) не найдена.";
                    return RedirectToAction("Index");
                }
                return View(timesheets);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete_Conf(Timesheets model)//Метод для формы удаления строки данных из таблицы и базы.
        {
            try
            {
                bool result = _dal.Delete(model.id);

                if (!result)
                {
                    TempData["errorMessage"] = "Unable to delete data";
                    return View();
                }
                TempData["successMessage"] = "Данные удалены";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
