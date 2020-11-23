using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonFileWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Старый способ
            var text1 = new FileWorker();
            var text2 = new FileWorker();

            text1.WriteText("Hello1");
            text1.WriteText("Hello2");

            text2.WriteText("Hello3");
            text2.WriteText("Hello4");

            text1.Save();
            text2.Save();

            //Одиночка
            //var text3 = new FileWorkerSingleton(); //Ай-ай-ай, доступа нет 
            var singleton1 = FileWorkerSingleton.Instance;
            var singleton2 = FileWorkerSingleton.Instance;

            singleton1.WriteText("Hello1");
            singleton2.WriteText("Hello2");

            singleton1.WriteText("Hello3");
            singleton2.WriteText("Hello4");

            singleton1.Save();
            singleton2.Save();
        }
    }
}
