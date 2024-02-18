using Microsoft.AspNetCore.Mvc;
using SeminarHub.Contracts;
using SeminarHub.Data.Models;
using SeminarHub.Models.SeminarModels;
using System.Globalization;

using static SeminarHub.GlobalConstant.SeminarErrorMsg;
using static SeminarHub.GlobalConstant.ValidationConst;

namespace SeminarHub.Controllers
{
    public class SeminarController : BaseController
    {
        private readonly ISeminarService service;
        public SeminarController(ISeminarService _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<BaseSeminarViewModel> allSeminar = await service.GetAllSeminarAsync();
            return View(allSeminar);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            DetailsSeminarViewModel seminar = await service.GetSeminarDetailsByIdAsync(id);
            if(seminar == null)
            {
                return BadRequest();
            }
            return View(seminar);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var formView = new SeminarFormModel();
            formView.Categories = await service.GetCategoriesAsync();

            return View(formView);
        }
        [HttpPost]
        public async Task<IActionResult> Add (SeminarFormModel formModel)
        {
            string currentUserId = GetUserId();

            bool isValidDate;
            DateTime dateAndTime = ParseAndValidateDate(formModel.DateAndTime, out isValidDate);
            if (!isValidDate)
            {
                formModel.Categories = await service.GetCategoriesAsync();
                return View(formModel);
            }

            if (!ModelState.IsValid)
            {
                formModel.Categories = await service.GetCategoriesAsync();
                return View(formModel);
            }

            await service.AddSeminarAsync(formModel, currentUserId, dateAndTime);

            return RedirectToAction(nameof(All));
        }
        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            Seminar? thisSeminar = await service.GetSeminarByIdAsync(id);
            if(thisSeminar == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();
            
            await service.JoinSeminarAsync(thisSeminar, currentUserId);

            return RedirectToAction(nameof(Joined));
        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string currentUserId = GetUserId();
            IEnumerable<JoinedSeminarViewModel> joinedPart = await service.GetJoinedAsync(currentUserId);

            return View(joinedPart);
        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            Seminar? seminar = await service.GetSeminarByIdAsync(id);
            if(seminar == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();

            await service.LeaveSeminarAsync(seminar, currentUserId);
            return RedirectToAction(nameof(Joined));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var currentSeminar = await service.GetSeminarByIdAsync(id);
            if(currentSeminar == null)
            {
                return BadRequest();
            }
            var currentUserId = GetUserId();
            if(currentSeminar?.OrganizerId != currentUserId)
            {
                return Unauthorized();
            }

            SeminarFormModel formModel = await service.GetDataForEditAsync(currentSeminar);

            return View(formModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (SeminarFormModel formModel, int id)
        {
            var currenSeminar = await service.GetSeminarByIdAsync(id);
            if (currenSeminar == null)
            {
                return BadRequest();
            }
            string currentUserId = GetUserId();

            bool isvalidDate;
            DateTime dateTime = ParseAndValidateDate(formModel.DateAndTime, out isvalidDate);
            if(!isvalidDate)
            {
                formModel.Categories = await service.GetCategoriesAsync();
                return View(formModel);
            }

            if (!ModelState.IsValid)
            {
                formModel.Categories = await service.GetCategoriesAsync();
                return View(formModel);
            }

            await service.SaveEditAsync(formModel, dateTime, currenSeminar);

            return RedirectToAction(nameof(All));
        }
       
        public async Task<IActionResult> Delete(int id)
        {
            var currentSeminar = await service.GetSeminarByIdAsync(id);
            if (currentSeminar == null)
            {
                return BadRequest();
            }
            var currentUserId = GetUserId();
            if (currentSeminar?.OrganizerId != currentUserId)
            {
                return Unauthorized();
            }

            await service.DeleteSeminarAsync(id);

            return RedirectToAction(nameof(All));
        }


        private DateTime ParseAndValidateDate(string dateString, out bool isValid)
        {
            DateTime result;
            isValid = DateTime.TryParseExact(dateString, SeminarDateFormat,
                                CultureInfo.InvariantCulture, DateTimeStyles.None,
                                out result);

            if (!isValid)
            {
                ModelState.AddModelError(nameof(dateString), ErrorDateFormat);
                result = DateTime.MinValue;
            }

            return result;
        }
    }
}
