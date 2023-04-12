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
        public static Human ReadHumans(string filename)
        {
            Human user = null;
            var serializer = new JsonSerializer();
            using (var sr = new StreamReader($"{filename}.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    user = serializer.Deserialize<Human>(jr);
                }
            }
            return user;
        }
        public static void WriteHumansXml(Human User)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Human));
            using (TextWriter writer = new StreamWriter($"{User.Name}.xml"))
            {
                serializer.Serialize(writer, User);
            }
        }
        public static Human ReadHumanXml(string filename)
        {
            Human user = null;
            XmlSerializer serializer = new XmlSerializer(typeof(Human));
            using (TextReader reader = new StreamReader("filename.xml"))
            {
                user = (Human)serializer.Deserialize(reader);
            }
            return user;
        }
    }
}
