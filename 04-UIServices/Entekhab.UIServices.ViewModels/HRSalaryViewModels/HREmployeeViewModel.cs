using Entekhab.Common.Attributes;
using Entekhab.UIServices.ViewModels.Infrastructures.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Entekhab.UIServices.ViewModels.HRSalaryViewModels;

[Serializable]
[XmlRoot("HREmployee", Namespace = "")]
public class HREmployeeViewModel
{
    //********************************************************************************************************************
    [ScaffoldColumn(false)]
    [Display(Name = "شناسه")]
    public int Id { get; set; }
    //********************************************************************************************************************
    [Display(Name = "نام")]
    [EntekhabRequired()]
    [EntekhabMaxLength(30)]
    [XmlElement("FirstName")]
    public string FirstName { get; set; }
    //********************************************************************************************************************
    [Display(Name = "نام خانوادگی")]
    [EntekhabRequired()]
    [EntekhabMaxLength(50)]
    [XmlElement("LastName")]
    public string LastName { get; set; }
    //********************************************************************************************************************
    [Display(Name = "تاریخ")]
    [EntekhabRequired()]
    [EntekhabMaxLength(8)]
    [XmlElement("Date")]
    public string Date { get; set; }
    //********************************************************************************************************************
    [Display(Name = "حقوق پایه")]
    [EntekhabRequired()]
    [EntekhabRange(0, int.MaxValue)]
    [XmlElement("BasicSalary")]
    public double BasicSalary { get; set; }
    //********************************************************************************************************************
    [Display(Name = "فوق العاده جذب")]
    [EntekhabRequired()]
    [EntekhabRange(0, int.MaxValue)]
    [XmlElement("Allowance")]
    public double Allowance { get; set; }
    //********************************************************************************************************************
    [Display(Name = "ایاب و ذهاب")]
    [EntekhabRequired()]
    [EntekhabRange(0, int.MaxValue)]
    [XmlElement("Transportation")]
    public double Transportation { get; set; }
    //********************************************************************************************************************
    [Display(Name = "مبلغ اضافه کار")]
    public double OverTime { get; set; }
    //********************************************************************************************************************
    [Display(Name = "مالیات")]
    public double TaxValue { get; set; }
    //********************************************************************************************************************
    [Display(Name = "حقوق خالص")]
    public double FinalSalary { get; set; }
    //********************************************************************************************************************
    public string MethodName { get; set; }
    //********************************************************************************************************************
}

public class HREmployeeListViewModel: HREmployeeViewModel
{
    //********************************************************************************************************************
    public DetailViewModel Details { get; set; }
    //********************************************************************************************************************
}