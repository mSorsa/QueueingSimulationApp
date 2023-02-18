using MMCNQueueParameters;

namespace TestQueueingModels
{
    public class MMCNTests
    {
        private readonly IMMCN _mmcn = new MMCNParametersCalculator(new MathematicalHelper.FactorialCalculator());

    }
}
