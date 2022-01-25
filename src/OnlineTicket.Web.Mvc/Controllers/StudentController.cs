using Microsoft.AspNetCore.Mvc;
using System;
using OnlineTicket.Controllers;
using OnlineTicket.Web.Models.Students;
using OnlineTicket.Students;
using OnlineTicket.Students.Dto;
using System.Threading.Tasks;
using OnlineTicket.Web.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Abp.AspNetCore.Mvc.Authorization;
using OnlineTicket.Authorization;
using System.Collections.Generic;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace OnlineTicket.Web.Controllers
{
    public class StudentController : OnlineTicketControllerBase
    {
        private readonly IStudentAppService _rBAdminSettingAppService;


        public StudentController(IStudentAppService rBAdminSettingAppService)
        {
            _rBAdminSettingAppService = rBAdminSettingAppService;
        }

        //[AbpMvcAuthorize(PermissionNames.Pages_Students)]
        public IActionResult StudentsIndex()
        {
            try
            {
                StudentViewModel model = ObjectMapper.Map<StudentViewModel>(_rBAdminSettingAppService.GetDetails()) ?? new StudentViewModel();
                return View(model);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex, this.getActionName(), this.getControllerName());
                throw ex;
            }
        }

        private void LogError(string message, Exception ex, object v1, object v2)
        {
            throw new NotImplementedException();
        }

        private object getControllerName()
        {
            throw new NotImplementedException();
        }

        private object getActionName()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<JsonResult> SaveStudentForm(StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int SettId = 0;
                    if (model.Id <= 0)
                    {
                        SettId = await _rBAdminSettingAppService.CreateAsync(ObjectMapper.Map<StudentDtoInput>(model));
                    }
                    else
                    {
                        SettId = await _rBAdminSettingAppService.Update(ObjectMapper.Map<StudentDtoInput>(model));
                    }
                    return Json(SettId);
                }
                return Json(new ResponseResultViewModel(OnlineTicketConsts.ServerExceptionMessage).Failure());
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex, this.getActionName(), this.getControllerName());
                return Json(new ResponseResultViewModel(OnlineTicketConsts.ServerExceptionMessage).Failure());
            }
        }

        [HttpPost]
        public async Task<JsonResult> ResetStudentForm()
        {
            try
            {
                StudentViewModel model = ObjectMapper.Map<StudentViewModel>(_rBAdminSettingAppService.GetDetails()) ?? new StudentViewModel();
                return Json(model);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex, this.getActionName(), this.getControllerName());
                return Json(new ResponseResultViewModel(OnlineTicketConsts.ServerExceptionMessage).Failure());
            }
        }

        private class ResponseResultViewModel
        {
            private object serverExceptionMessage;

            public ResponseResultViewModel(object serverExceptionMessage)
            {
                this.serverExceptionMessage = serverExceptionMessage;
            }

            internal object Failure()
            {
                throw new NotImplementedException();
            }
        }

        public ActionResult EditModal(int studentId)
        {
            var output = _rBAdminSettingAppService.GetDetails(studentId) ?? new StudentDtoOutput();
            return PartialView("_EditModal", output);
        }
    }

    //[HttpPost]
    //    public PartialViewResult EditModal(int studentId)
    //    {
    //        try
    //        {
    //            var model = ObjectMapper.Map<EditStudentModalViewModel>(_rBAdminSettingAppService.GetDetails(studentId)) ?? new EditStudentModalViewModel();
    //            return PartialView("_editModal",model);
    //        }
    //        catch (Exception ex)
    //        {
    //            LogError(ex.Message, ex, this.getActionName(), this.getControllerName());
    //            throw ex;
    //        }
    //    }

    //}
}
