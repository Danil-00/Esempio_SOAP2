using System.ServiceModel;

namespace Esempio_SOAP2.ServizioSOAP
{
    [ServiceContract]
    public interface ICalcolatrice
    {
        [OperationContract]
        public int Somma(int num1, int num2);

        [OperationContract]
        public int Sottrazione(int num1, int num2);
    }

    public class Calcolatrice : ICalcolatrice
    {
        public int Somma(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Sottrazione(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
