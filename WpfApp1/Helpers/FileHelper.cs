using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using WpfApp1.Models;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace WpfApp1.Helpers
{
    public class FileHelper
    {
        public static void WriteHumans(Human users)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter($"{users.Name}.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    serializer.Serialize(jw, users);
                }
            }
        }
        public static Human ReadHumans()
        {
            Human user = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader("humans.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    user = serializer.Deserialize<Human>(jr);
                }
            }-
            return user;
        }
        public static void WriteHumansXml(List<Human> Users)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
            using (TextWriter writer = new StreamWriter("humans.xml"))
            {
                serializer.Serialize(writer, Users);
            }
        }
        public static List<Human> ReadHumanXml()
        {
            List<Human> users = null;
            XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
            using (TextReader reader = new StreamReader("humans.xml"))
            {
                users = (List<Human>)serializer.Deserialize(reader);
            }
            return users;
        }
    }
}
