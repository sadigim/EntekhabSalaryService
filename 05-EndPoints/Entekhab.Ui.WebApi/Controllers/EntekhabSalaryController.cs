using Entekhab.Domain.BusinessLogics.HRSalaryBusinessLogics.BusinessLogic;
using Entekhab.Ui.WebApi.Infrastructures.Functions;
using Entekhab.UIServices.ViewModels.HRSalaryViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Entekhab.Ui.WebApi.Controllers
{
    //********************************************************************************************************************
    public class RequestBodyModel
    {
        public string data { get; set; }
        public string overTimeCalculator { get; set; }
    }

    public class HRRangeRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    //********************************************************************************************************************




    [Route("api/{datatype}/[controller]")]
    [ApiController]
    public class EntekhabSalaryController : ControllerBase
    {
        private readonly HREmployeeBl _bl;
        //********************************************************************************************************************
        public EntekhabSalaryController(HREmployeeBl hrEmployeeBl)
        {
            _bl = hrEmployeeBl;
        }
        //********************************************************************************************************************
        [HttpGet("Welcome")]
        [SwaggerOperation(Summary = "Welcome Message", Description = "Returns a welcome message for testing purposes.")]
        public IActionResult Welcome()
        {
            return Ok("Welcome to the EntekhabSalary API. This is a test endpoint.");
        }
        //********************************************************************************************************************
        [HttpPost("Add")]
        [SwaggerOperation(Summary = "Add Employee Salary", Description = "Custome Data Sample:\"FirstName/LastName/BasicSalary/Allowance/Transportation/Date\rMohammad/Sadighi/50000/2000/1000/14020601\" <br /> Json Data Sample:\"{'FirstName': 'Mohammad','LastName': 'Sadighi','BasicSalary': '50000','Allowance': '2000','Transportation': '1000','Date': '14020601'}\"")]
        public IActionResult Add(string datatype, [FromBody] RequestBodyModel requestModel)
        {
            //Xml Data Sample
            //"<HREmployee><FirstName>Mohammad</FirstName><LastName>Sadighi</LastName><BasicSalary>50000</BasicSalary><Allowance>2000</Allowance><Transportation>1000</Transportation><Date>1402/06/01</Date></HREmployee>"

            var deserializeResult = RequestDataDeserializer.DeserializeDataToModel<HREmployeeViewModel>(datatype, requestModel.data);

            if (!deserializeResult.Successed)
                return BadRequest(deserializeResult.Message);

            if (deserializeResult.Value == null)
                return BadRequest("دیتا صحیح نمی باشد");
            
            var employeeData = (HREmployeeViewModel)deserializeResult.Value;

            employeeData.MethodName = requestModel.overTimeCalculator;

            var result= _bl.Add(employeeData, string.Empty);

            if (!result.Successed)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
        //********************************************************************************************************************
        [HttpPost("Update")]
        [SwaggerOperation(Summary = "Edit Employee Salary", Description = "Custome Data Sample:\"FirstName/LastName/BasicSalary/Allowance/Transportation/Date\rMohammad/Sadighi/50000/2000/1000/14020601\" <br /> Json Data Sample:\"{'FirstName': 'Mohammad','LastName': 'Sadighi','BasicSalary': '50000','Allowance': '2000','Transportation': '1000','Date': '14020601'}\"")]
        public IActionResult Update(string datatype, [FromBody] RequestBodyModel requestModel)
        {
            //Xml Data Sample
            //"<HREmployee><FirstName>Mohammad</FirstName><LastName>Sadighi</LastName><BasicSalary>50000</BasicSalary><Allowance>2000</Allowance><Transportation>1000</Transportation><Date>1402/06/01</Date></HREmployee>"

            var deserializeResult = RequestDataDeserializer.DeserializeDataToModel<HREmployeeViewModel>(datatype, requestModel.data);

            if (!deserializeResult.Successed)
                return BadRequest(deserializeResult.Message);

            if (deserializeResult.Value == null)
                return BadRequest("دیتا صحیح نمی باشد");

            var employeeData = (HREmployeeViewModel)deserializeResult.Value;

            employeeData.MethodName = requestModel.overTimeCalculator;

            var result = _bl.Update(employeeData, string.Empty);

            if (!result.Successed)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
        //********************************************************************************************************************
        [HttpPost("Delete")]
        [SwaggerOperation(Summary = "Delete Employee Salary", Description = "Custome Data Sample:\"FirstName/LastName/Date\rMohammad/Sadighi/14020601\" <br /> Json Data Sample:\"{'FirstName': 'Mohammad','LastName': 'Sadighi','Date': '14020601'}\"")]
        public IActionResult Delete(string datatype, [FromBody] string data)
        {
            //Xml Data Sample
            //"<HREmployee><FirstName>Mohammad</FirstName><LastName>Sadighi</LastName><Date>1402/06/01</Date></HREmployee>"

            var deserializeResult = RequestDataDeserializer.DeserializeDataToModel<HREmployeeViewModel>(datatype, data);

            if (!deserializeResult.Successed)
                return BadRequest(deserializeResult.Message);

            if (deserializeResult.Value == null)
                return BadRequest("دیتا صحیح نمی باشد");

            var employeeData = (HREmployeeViewModel)deserializeResult.Value;

            var result = _bl.Delete(employeeData);

            if (!result.Successed)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
        //********************************************************************************************************************
        [HttpPost("Get")]
        [SwaggerOperation(Summary = "Get Employee Salary Info", Description = "Custome Data Sample:\"FirstName/LastName/Date\rMohammad/Sadighi/14020601\" <br /> Json Data Sample:\"{'FirstName': 'Mohammad','LastName': 'Sadighi','Date': '14020601'}\"")]
        public IActionResult Get(string datatype, [FromBody] string data)
        {
            //Xml Data Sample
            //"<HREmployee><FirstName>Mohammad</FirstName><LastName>Sadighi</LastName><Date>1402/06/01</Date></HREmployee>"

            var deserializeResult = RequestDataDeserializer.DeserializeDataToModel<HREmployeeViewModel>(datatype, data);

            if (!deserializeResult.Successed)
                return BadRequest(deserializeResult.Message);

            if (deserializeResult.Value == null)
                return BadRequest("دیتا صحیح نمی باشد");

            var employeeData = (HREmployeeViewModel)deserializeResult.Value;

            var result = _bl.Get(employeeData);

            if (!result.Successed)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Value);
        }
        //********************************************************************************************************************
        [HttpPost("Getrange")]
        [SwaggerOperation(Summary = "Getrange Employee Salary Info", Description = "Custome Data Sample:\"FirstName/LastName/StartDate/EndDate\rMohammad/Sadighi/14020101/14020601\" <br /> Json Data Sample:\"{'FirstName': 'Mohammad','LastName': 'Sadighi','StartDate': '14020101','EndDate': '14020601'}\"")]
        public IActionResult Getrange(string datatype, [FromBody] string data)
        {
            //Xml Data Sample
            //"<HREmployee><FirstName>Mohammad</FirstName><LastName>Sadighi</LastName><StartDate>1402/01/01</StartDate><EndDate>1402/06/01</EndDate></HREmployee>"

            var deserializeResult = RequestDataDeserializer.DeserializeDataToModel<HRRangeRequestModel>(datatype, data);

            if (!deserializeResult.Successed)
                return BadRequest(deserializeResult.Message);

            if (deserializeResult.Value == null)
                return BadRequest("دیتا صحیح نمی باشد");

            var rangeRequestData = (HRRangeRequestModel)deserializeResult.Value;

            var result = _bl.GetRange(rangeRequestData.FirstName, rangeRequestData.LastName, rangeRequestData.StartDate, rangeRequestData.EndDate);

            if (!result.Successed)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Value);
        }
        //********************************************************************************************************************

    }
    //********************************************************************************************************************

}
