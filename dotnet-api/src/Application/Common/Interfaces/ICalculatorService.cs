namespace Application.Common.Interfaces;

public interface ICalculatorService
{
    decimal Sum(decimal a, decimal b);
    decimal Subtract(decimal a, decimal b);
    decimal Multiply(decimal a, decimal b);
    decimal Divide(decimal a, decimal b);
}