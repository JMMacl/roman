using Microsoft.AspNetCore.Mvc;
using sample002.models;

namespace sample002.Controllers;

public class ErrorController : ControllerBase
{
    public ActionResult JsonErrorResponse (string responseRoute, string responseCode, string responseDescription )
    {
        return ValidationProblem(responseDescription,"",Convert.ToInt32(responseCode),responseRoute +" request invalid",null,null);        
    }
}