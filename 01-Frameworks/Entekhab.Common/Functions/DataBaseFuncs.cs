namespace Entekhab.Common.Functions;

public static class DataBaseFuncs
{
    //********************************************************************************************************************
    /// <summary>
    /// رشته اتصال به ديتابيس اصلي سيستم
    /// </summary>
    /// <returns></returns>
    //public static string GetConnectionstring() => "Data Source=(local);Initial Catalog=EntekhabDB;Persist Security Info=false;User ID=dn;pwd=123456";

    public static string GetConnectionstring() => "Data Source=(local);initial catalog = EntekhabDB; persist security info=True; Integrated Security = SSPI;";
    //********************************************************************************************************************
}
