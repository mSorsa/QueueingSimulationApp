namespace QueueingModelsInterfaces.MMCNInterface
{
    public interface IMMCN
    {
        double CalculatePZero();
        double CalculatePN();
        double CalculateLambdaEffective();
        double CalculateL();
        double CalculateLQ();
        double CalculateWQ();
        double CalculateW();
        double CalculateRho();
        double CalculateCapacityUtilization();
    }
}