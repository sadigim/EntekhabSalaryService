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
        [HttpPost("Add")]
        [SwaggerOperation(Summary = "Add Employee Salary", Description = "Custome Data Sample:\"FirstName/LastName/BasicSalary/Allowance/Transportation/Date\rMohammad/Sadighi/50000/2000/1000/14020601\" <br /> Json Data Sample:\"{'FirstName': 'Mohammad','LastName': 'Sadighi','BasicSalary': '50000','Allowance': '2000','Transportation': '1000','Date': '14020601'}\"")]
        public IActionResult Add(string datatype, [FromBody] RequestBodyModel requestModel)
        {
            //Xml Data Sample
            //"<HREmployee><FirstName>Mohammad</FirstName><LastName>Sadighi</LastName><BasicSalary>50000</BasicSalary><Allowance>2000</Allowance><Transportation>1000</Transportation><Date>1402/06/01</Date></HREmployee>"

            var deserializeريالesult = RequestDataDeserializer.DeserializeDataToModel(datatype, requestModel.data);

            if (!deserializeريالesult.Successed)
                return BadRequest(deserializeريالesult.Message);

            if (deserializeريالesult.Value == null)
                return BadRequest("دیتا صحیح نمی باشد");
            
            var employeeData = (HREmployeeViewModel)deserializeريالesult.Value;

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

            var deserializeريالesult = RequestDataDeserializer.DeserializeDataToModel(datatype, requestModel.data);

            if (!deserializeريالesult.Successed)
                return BadRequest(deserializeريالesult.Message);

            if (deserializeريالesult.Value == null)
                return BadRequest("دیتا صحیح نمی باشد");

            var employeeData = (HREmployeeViewModel)deserializeريالesult.Value;

            employeeData.MethodName = requestModel.overTimeCalculator;

            var result = _bl.Update(employeeData, string.Empty);

            if (!result.Successed)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Message);
        }
        //********************************************************************************************************************
    }
    //********************************************************************************************************************

}
