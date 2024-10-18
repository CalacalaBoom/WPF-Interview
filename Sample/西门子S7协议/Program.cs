using S7.Net;

namespace 西门子S7协议
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Plc plc = new Plc(CpuType.S7300, "127.0.0.1", 0, 1);

            plc.Open();

            if (plc.IsConnected)
            {
                //读Single
                var result = (Int16)plc?.Read("DB1.DBW1");
                //读string
                var strResult = plc?.Read(DataType.DataBlock, 1, 0, VarType.DWord, 20);
                //读结构体
                var mystruct = plc?.ReadStruct(typeof(MyStruct), 1, 0);

                //写Single
                plc?.Write("DB1.DBW1", 1);
                //写String
                plc?.Write(DataType.DataBlock, 1, 1, "Hello S7");
                //写结构体
                plc?.WriteStruct(new MyStruct(), 1);
            }

            plc?.Close();

            Console.ReadLine();
        }
    }

    public struct MyStruct
    {
        public string Name;
        public int Age;
    }
}
