namespace OvertimeMethods.Core;

public class OvertimePolicies
{
    public static double CalculatorA(double baseAndAllowance, short overTimeHour) => (baseAndAllowance / 176) * overTimeHour;
    
    public static double CalculatorB(double baseAndAllowance, short overTimeHour) => (baseAndAllowance / 176 * 2) * overTimeHour;

    public static double CalculatorC(double baseAndAllowance, short overTimeHour) => (baseAndAllowance / 176 * 3) * overTimeHour;
}