using Entekhab.Common.Functions;
using Entekhab.Common.Objects;
using Entekhab.Ui.WebApi.Infrastructures.Extensions;
using Entekhab.UIServices.ViewModels.HRSalaryViewModels;

namespace Entekhab.Ui.WebApi.Infrastructures.Functions;

internal class RequestDataDeserializer
{
    public static SysResult DeserializeDataToModel(string dataType, string data)
    {
        HREmployeeViewModel model = new();

        switch (dataType)
        {
            case "json":
                var deserializedJsonDataModel = data.DeserializeJsonData<HREmployeeViewModel>();

                if (deserializedJsonDataModel != null)
                {
                    model = deserializedJsonDataModel;
                }
                else
                {
                    return Result.Error($"خطا: اطلاعات داده شده در فرمت {dataType} صحیح نمی باشد");
                }

                break;

            case "xml":
                var deserializedJXmlDataModel = data.DeserializeXmlData<HREmployeeViewModel>();

                if (deserializedJXmlDataModel != null)
                {
                    model = deserializedJXmlDataModel;
                }
                else
                {
                    return Result.Error($"خطا: اطلاعات داده شده در فرمت {dataType} صحیح نمی باشد");
                }

                break;

            case "custom":

                if (!data.ValidateCustomData())
                {
                    return Result.Error($"خطا: اطلاعات داده شده در فرمت {dataType} صحیح نمی باشد");
                }

                Dictionary<string, string> employeeInfo = data.DeserializeCustomData();
                model = DictionaryTools.DictionaryToModelMapper<HREmployeeViewModel>(employeeInfo);
                break;

            default:
                return Result.Error("خطا: فرمت داده موردنظر شما معتبر نمی باشد");
        }

        return Result.Success("دیتای ورودی با موفقیت به مدل تبدیل شد", model);
    }
}
