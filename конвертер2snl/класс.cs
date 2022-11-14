using Newtonsoft.Json;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace конвертер2snl
{
    public class Figure
    {
        public string name; //имя фигуры
        public string x; //длина
        public string y; //ширина
        public static void txt_open(string path)
        {
            // здесь открываем текстик
            Text.txt = File.ReadAllText(path);
            Text.txt1 = Text.text(path);
            string a = string.Join("", Text.txt1);
            Console.WriteLine(Text.txt);
        }
        public static void json_open(string path)
        {
            // здесь открываем json`чик
            Text.txt = File.ReadAllText(path);
            Text.txt1 = JsonConvert.DeserializeObject<List<Figure>>(Text.txt);
            foreach (Figure i in Text.txt1)
            {
                Console.WriteLine(i.name);
                Console.WriteLine(i.x);
                Console.WriteLine(i.y);
            }
        }
        public static void xml_open(string path)
        {
            // здесь открываем xlm`чик
            XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
            using FileStream fs = new FileStream(path, FileMode.Open);
            Text.txt1 = (List<Figure>)xml.Deserialize(fs);
            foreach (Figure i in Text.txt1)
            {
                Console.WriteLine(i.name);
                Console.WriteLine(i.x);
                Console.WriteLine(i.y);
            }
        }
        public static void txt_save(string path)
        {
            //здесь сохраняем текстик
            string a = string.Join("", Text.txt1);
            File.WriteAllText(path, "");
            foreach (Figure i in Text.txt1)
            {
                File.AppendAllText(path, i.name + "\n");
                File.AppendAllText(path, i.x + "\n");
                File.AppendAllText(path, i.y + "\n");
            }
        }
        public static void json_save(string path)
        {
            //здесь сохраняем json`чик
            string json = JsonConvert.SerializeObject(Text.txt1);
            string a = string.Join("", json);
            File.WriteAllText(path, a);
        }
        public static void xml_save(string path)
        {
            //здесь сохраняем xml`чик
            XmlSerializer xml = new XmlSerializer(typeof(List<Figure>));
            using FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            xml.Serialize(fs, Text.txt1);
        }
    }
}