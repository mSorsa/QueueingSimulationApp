using MathematicalHelper;
using MG1QueueParameters.src;
using MGInfinityQueueParameters.src;
using MMCKKQueueParameters.src;
using MMCNQueueParameters.src;
using MMCQueueParameters.src;
using QueueingModelsInterfaces.MG1Interface;
using QueueingModelsInterfaces.MGInfinityInterface;
using QueueingModelsInterfaces.MMCKKInterface;
using QueueingModelsInterfaces.MMCNInterface;
using QueueingSimulation.Extensions;
using System.Runtime.CompilerServices;

namespace QueueingSimulation
{
    public class Program
    {
        private static readonly FactorialCalculator _factorialCalculator = new();
        private static readonly BigParenCalculator _bigParenCalculator = new(_factorialCalculator);
        private static readonly ExpectedValueCalculator _expectedValueCalculator = new();

        static void Main()
        {
            while (true)
            {
                DisplayStartMessage();
                try
                {
                    HandleUserInput();

                }
                catch (Exception e)
                {
                    Console.Error.WriteLine($"Exception during runtime: {e.Message}");
                }
            }
        }


        private static void DisplayStartMessage()
        {
            Console.WriteLine("Choose queueing model:");
            Console.WriteLine("1: MG1");
            Console.WriteLine("2: MMC");
            Console.WriteLine("3: MMCN");
            Console.WriteLine("4: MMCKK");
            Console.WriteLine("5: MGInfinity");
            Console.WriteLine("Any non-digit character to exit application");
        }

        private static void HandleUserInput()
        {
            var option = Console.ReadLine();

            if (int.TryParse(option, out var value))
            {
                if (value is < 0 or > 5)
                {
                    Console.Error.WriteLine("Exit application? (Y/N)");

                    if (!Console.ReadLine().IsEqualIgnoreCase("Y", "YES"))
                        Environment.Exit(0);

                    return;
                }

                switch (value)
                {
                    case 1:
                        HandleMG1Queue();
                        break;
                    case 2:
                        HandleMMCQueue();
                        break;
                    case 3:
                        HandleMMCNQueue();
                        break;
                    case 4:
                        HandleMMCKKQueue();
                        break;
                    case 5:
                        HandleMGInfinityQueue();
                        break;
                    default:
                        InvalidInput();
                        break;
                }
            }
        }

        private static void InvalidInput()
        {
            Console.WriteLine("Inputted value is invalid. Use only numbers 1-5");
        }

        private static void HandleMG1Queue()
        {
            Console.WriteLine("Enter ArrivalRate (Lambda): ");
            var input = ConvertStringToDouble(Console.ReadLine());
            var lam = input;
            Console.WriteLine("Enter ServiceRate (Mu): ");
            input = ConvertStringToDouble(Console.ReadLine());
            var mu = input;
            Console.WriteLine("Enter Variance (Sigma): ");
            input = ConvertStringToDouble(Console.ReadLine());
            var sigma = input*input;

            IMG1 mg1 = new MG1ParametersCalculator(lam, mu, sigma);

            ShowMG1Calculations(mg1);
        }

        private static void ShowMG1Calculations(IMG1 mG1)
        {
            Console.WriteLine("\n-----------------------------DataSet MG1--------------------------------");
            Console.WriteLine("Rho\t| (utilization):\t\t\t" + mG1.CalculateRho());
            Console.WriteLine("L\t| (mean number in system):\t\t" + mG1.CalculateL());
            Console.WriteLine("w\t| (mean time in system):\t\t" + mG1.CalculateW());
            Console.WriteLine("wQ\t| (mean time in queue):\t\t\t" + mG1.CalculateWq());
            Console.WriteLine("LQ\t| (mean number in queue):\t\t" + mG1.CalculateLq());
            Console.WriteLine("P0\t| (probability of empty system):\t" + mG1.CalculatePZero());
            Console.WriteLine("-----------------------------End of Data---------------------------------\n");
        }

        private static double ConvertStringToDouble(string valueToParse)
        {
            return double.TryParse(valueToParse, out var valueAsDouble)
                ? valueAsDouble
                : throw new ArgumentException($"Could not parse {valueToParse} to a double.");
        }

        private static void HandleMGInfinityQueue()
        {
            Console.WriteLine("Enter ArrivalRate (Lambda): ");
            var input = ConvertStringToDouble(Console.ReadLine());
            var lam = input;
            Console.WriteLine("Enter ServiceRate (Mu): ");
            input = ConvertStringToDouble(Console.ReadLine());
            var mu = input;
            Console.WriteLine("Enter N [any number 0-12] (N number of customers in system): ");
            input = ConvertStringToInt(Console.ReadLine());
            var N = (int)input;

            IMGInfinity mgInf = new MGInfinityParametersCalculator(new FactorialCalculator());

            ShowMGInfinityCalculations(mgInf, lam, mu, N);
        }

        private static int ConvertStringToInt(string? v)
        {
            return int.TryParse(v, out var valueAsInt)
                ? valueAsInt
                : throw new ArgumentException($"Could not parse {valueAsInt} to a double.");
        }

        private static void ShowMGInfinityCalculations(IMGInfinity mGInf, double lam, double mu, int N)
        {
            Console.WriteLine("\n----------------------------DataSet MGInf--------------------------------");
            Console.WriteLine("Rho\t| (utilization):\t\t\t" + mGInf.CalculatePn(lam, mu, N));
            Console.WriteLine("L\t| (mean number in system):\t\t" + mGInf.CalculateL(lam, mu));
            Console.WriteLine("w\t| (mean time in system):\t\t" + mGInf.CalculateW(mu));
            Console.WriteLine("wQ\t| (mean time in queue):\t\t\t" + mGInf.CalculateWq());
            Console.WriteLine("LQ\t| (mean number in queue):\t\t" + mGInf.CalculateLq());
            Console.WriteLine("P0\t| (probability of empty system):\t" + mGInf.CalculatePZero(lam, mu));
            Console.WriteLine("-----------------------------End of Data---------------------------------\n");
        }

        private static void HandleMMCKKQueue()
        {
            Console.WriteLine("Enter ArrivalRate (Lambda): ");
            var input = ConvertStringToDouble(Console.ReadLine());
            var lam = input;
            Console.WriteLine("Enter ServiceRate (Mu): ");
            input = ConvertStringToDouble(Console.ReadLine());
            var mu = input;
            Console.WriteLine("Enter c [any number 1-12] (number of servers): ");
            input = ConvertStringToInt(Console.ReadLine());
            var c = (int)input;
            Console.WriteLine("Enter K [any number 1-12] (calling population): ");
            input = ConvertStringToInt(Console.ReadLine());
            var K = (int)input;

            var mmckk = new MMCKKParametersCalculator(_factorialCalculator, _bigParenCalculator, lam, mu, c, K);

            ShowMMCKKCalculations(mmckk);
        }

        private static void ShowMMCKKCalculations(MMCKKParametersCalculator mmckk)
        {
            Console.WriteLine("\n----------------------------DataSet MMCKK--------------------------------");
            Console.WriteLine("Rho\t| (utilization):\t\t\t" + mmckk.CalculateRho());
            Console.WriteLine("L\t| (mean number in system):\t\t" + mmckk.CalculateL());
            Console.WriteLine("w\t| (mean time in system):\t\t" + mmckk.CalculateW());
            Console.WriteLine("wQ\t| (mean time in queue):\t\t\t" + mmckk.CalculateWq());
            Console.WriteLine("LQ\t| (mean number in queue):\t\t" + mmckk.CalculateLq());
            Console.WriteLine("P0\t| (Probability of empty system):\t" + mmckk.CalculatePZero());
            Console.WriteLine("lambdaE\t| (effective arrival rate):\t\t" + mmckk.CalculateLambdaE());
            Console.WriteLine("------------------------------End of Data---------------------------------\n");
        }

        private static void HandleMMCNQueue()
        {
            Console.WriteLine("Enter ArrivalRate (Lambda): ");
            var input = ConvertStringToDouble(Console.ReadLine());
            var lam = input;
            Console.WriteLine("Enter ServiceRate (Mu): ");
            input = ConvertStringToDouble(Console.ReadLine());
            var mu = input;
            Console.WriteLine("Enter c [any number 1-12] (Number of Servers): ");
            input = ConvertStringToInt(Console.ReadLine());
            var c = (int)input;
            Console.WriteLine("Enter K [any number 1-12] (System Capacity): ");
            input = ConvertStringToInt(Console.ReadLine());
            var N = (int)input;

            var mmcn = new MMCNParametersCalculator(_factorialCalculator, lam, mu, c, N);

            ShowMMCNCalculations(mmcn);
        }

        private static void ShowMMCNCalculations(MMCNParametersCalculator mmcn)
        {
            Console.WriteLine("\n----------------------------DataSet MMCN--------------------------------");
            Console.WriteLine("Rho\t| (utilization):\t\t\t\t" + mmcn.CalculateRho());
            Console.WriteLine("L\t| (mean number in system):\t\t\t" + mmcn.CalculateL());
            Console.WriteLine("w\t| (mean time in system):\t\t\t" + mmcn.CalculateW());
            Console.WriteLine("wQ\t| (mean time in queue):\t\t\t\t" + mmcn.CalculateWQ());
            Console.WriteLine("LQ\t| (mean number in queue):\t\t\t" + mmcn.CalculateLQ());
            Console.WriteLine("P0\t| (Probability of empty system):\t\t" + mmcn.CalculatePZero());
            Console.WriteLine("PN\t| (Probability of N customers in system):\t" + mmcn.CalculatePN());
            Console.WriteLine("lambdaE\t| (effective arrival rate):\t\t\t" + mmcn.CalculateLambdaEffective());
            Console.WriteLine("------------------------------End of Data----------------------------------\n");
        }

        private static void HandleMMCQueue()
        {
            Console.WriteLine("Enter ArrivalRate (Lambda): ");
            var input = ConvertStringToDouble(Console.ReadLine());
            var lam = input;
            Console.WriteLine("Enter ServiceRate (Mu): ");
            input = ConvertStringToDouble(Console.ReadLine());
            var mu = input;
            Console.WriteLine("Enter c [any number 1-12] (Number of Servers): ");
            input = ConvertStringToInt(Console.ReadLine());
            var c = (int)input;

            var mmc = new MMCParametersCalculator(_factorialCalculator, lam, mu, c);

            ShowMMCCalculations(mmc);
        }

        private static void ShowMMCCalculations(MMCParametersCalculator mmc)
        {
            Console.WriteLine("\n----------------------------DataSet MMC--------------------------------");
            Console.WriteLine("Rho\t| (utilization):\t\t\t" + mmc.CalculateRho());
            Console.WriteLine("L\t| (mean number in system):\t\t" + mmc.CalculateL());
            Console.WriteLine("w\t| (mean time in system):\t\t" + mmc.CalculateW());
            Console.WriteLine("wQ\t| (mean time in queue):\t\t\t" + mmc.CalculateWq());
            Console.WriteLine("LQ\t| (mean number in queue):\t\t" + mmc.CalculateLq());
            Console.WriteLine("P0\t| (Probability of empty system):\t" + mmc.CalculatePZero());
            Console.WriteLine("-----------------------------End of Data---------------------------------\n");
        }
    }
}