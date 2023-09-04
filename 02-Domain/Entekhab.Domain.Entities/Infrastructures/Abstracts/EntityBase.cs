using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entekhab.Domain.Entities.Infrastructures.Abstracts;

public abstract class EntityBase
{
    /// <summary>
    /// شناسه سيستمي
    /// </summary>
    [Key]
    [Column("Id", Order = 1)]
    public int Id { get; set; }
    //--------------------------
    /// <summary>
    /// شناسه کاربر ايجاد کننده
    /// </summary>
    [MaxLength(50)]
    [Required(ErrorMessage = "لطفاً کاربر ایجاد کننده را مشخص نمایید")]
    public string CreatorUserId { get; set; }
    //--------------------------
    /// <summary>
    /// تاريخ ايجاد براساس فرمت ساعت جهاني
    /// </summary>
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
    [Required(ErrorMessage = "لطفاً تاریخ و زمان ایجاد را مشخص نمایید")]
    public DateTime CreateDateTime { get; set; }
    //--------------------------
    /// <summary>
    /// شناسه کاربر ويرايش کننده
    /// </summary>
    [DefaultValue("")]
    public string EditorUserId { get; set; }
    /// <summary>
    /// تاريخ ويرايش براساس فرمت ساعت جهاني
    /// </summary>
    [DataType(DataType.DateTime)]
    public DateTime EditDateTime { get; set; }
    //--------------------------
}