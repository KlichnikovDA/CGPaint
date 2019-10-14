using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CG_Paint
{
    public static class Files
    {
        // Функция чтения данных из файла
        public static List<Primitive> ReadFile(string Path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            List<Primitive> PrimitiveList = new List<Primitive>();

            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                PrimitiveList = (List<Primitive>)formatter.Deserialize(fs);
            }

            return PrimitiveList;
        }

        // Функция записи данных в файл
        public static void WriteFile(string Path, List<Primitive> PrimitiveList)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                // сериализуем весь массив people
                formatter.Serialize(fs, PrimitiveList);

                Console.WriteLine("Объект сериализован");
            }
        }
    }
}
