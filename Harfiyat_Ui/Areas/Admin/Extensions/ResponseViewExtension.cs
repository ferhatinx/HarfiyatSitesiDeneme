
using Harfiyat_Common.ResponseObjects;
using Microsoft.AspNetCore.Mvc;


namespace Harfiyat_Ui.Areas.Admin.Extensions;

public static class ResponseViewExtension
{
    public static IActionResult ResponseRedirectToView(this Controller controller, IResponse response, string actionName, string? controllerName, object? routeValue)
    {
        if (response.ResponseType == ResponseType.Success)
        {
            return controller.RedirectToAction(actionName, controllerName, routeValue);
        }
        else if (response.ResponseType == ResponseType.ValidationError)
        {
            foreach (var error in response.Errors)
            {
                controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            return controller.View();

        }
        else if (response.ResponseType == ResponseType.NotFound)
        {
            return controller.NotFound();
        }
        else if (response.ResponseType == ResponseType.NoData)
        {

        }
        return controller.RedirectToAction(actionName, controllerName);
    }
    public static IActionResult ResponseView(this Controller controller, IResponse response, string actionName, string? controllerName, object? routeValue = null)
    {
        if (response.ResponseType == ResponseType.Success)
        {
            return controller.RedirectToAction(actionName: actionName, controllerName: controllerName, routeValue);
        }
        else
        {
            foreach (var error in response.Errors)
            {
                controller.ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
            }
            return controller.View();
        }

    }
    public static IActionResult ResponseView<T>(this Controller controller, IResponse<T> response, object? routeValue = null)
    {
        if (response.ResponseType == ResponseType.Success)
        {
            if(routeValue is not null)
            {
                return controller.View(routeValue);
            }
            return controller.View(response.Data);
        }
        if(response.ResponseType == ResponseType.NoData)
        {
            return controller.View();
        }
        if(response.ResponseType == ResponseType.ValidationError)
        {
            foreach (var error in response.Errors)
            {
                controller.ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
            }
            return controller.View();
        }
        return controller.NotFound();

    }
}
