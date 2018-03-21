using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspose_Demo
{
    class Program
    {
        static void Main(string[] args)
        { 
            //提示信息
            Console.WriteLine(@"正在运行......");

            //ExcelGenerator eg = new ExcelGenerator();
            //eg.Start();
            new ExcelGenerator().Start();

            Console.WriteLine(@"运行结束！按任意键结束");
            Console.ReadKey();
        }
    }
}
