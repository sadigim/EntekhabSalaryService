using Entekhab.Common.Attributes;
using Entekhab.Domain.Entities.Infrastructures.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Entekhab.Domain.Entities.HumanResourceModels;

[Serializable]
public class HREmployeeModel: EntityBase
{
    //********************************************************************************************************************
    [Display(Name = "نام")]
    [EntekhabRequired()]
    [EntekhabMaxLength(30)]
    public string FirstName { get; set; }
    //********************************************************************************************************************
    [Display(Name = "نام خانوادگی")]
    [EntekhabRequired()]
    [EntekhabMaxLength(50)]
    public string LastName { get; set; }
    //********************************************************************************************************************
    [Display(Name = "تاریخ")]
    [EntekhabRequired()]
    [EntekhabMaxLength(8)]
    public string Date { get; set; }
    //********************************************************************************************************************
    [Display(Name = "حقوق پایه")]
    [EntekhabRequired()]
    [EntekhabRange(0, int.MaxValue)]
    public double BasicSalary { get; set; }
    //********************************************************************************************************************
    [Display(Name = "فوق العاده جذب")]
    [EntekhabRequired()]
    [EntekhabRange(0, int.MaxValue)]
    public double Allowance { get; set; }
    //********************************************************************************************************************
    [Display(Name = "ایاب و ذهاب")]
    [EntekhabRequired()]
    [EntekhabRange(0, int.MaxValue)]
    public double Transportation { get; set; }
    //********************************************************************************************************************
    [Display(Name = "مبلغ اضافه کار")]
    [EntekhabRequired()]
    [EntekhabRange(0, int.MaxValue)]
    public double OverTime { get; set; }
    //********************************************************************************************************************
    [Display(Name = "مالیات")]
    [EntekhabRequired()]
    [EntekhabRange(0, int.MaxValue)]
    public double TaxValue { get; set; }
    //********************************************************************************************************************
    [Display(Name = "حقوق خالص")]
    [EntekhabRequired()]
    [EntekhabRange(0, int.MaxValue)]
    public double FinalSalary { get; set; }
    //********************************************************************************************************************
}