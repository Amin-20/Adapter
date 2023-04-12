using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
using System.Xml.Serialization;
using WpfApp1.Command;
using WpfApp1.Helpers;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        interface IAdapter
        {
            void Write(Human user);
            //List<Human> Read();
        }
        class JsonAdapter : IAdapter
        {
            private Json _json;

            public JsonAdapter(Json json)
            {
                _json = json;
            }

            //public List<Human> Read()
            //{
            //    return _json.Read();
            //}

            public void Write(Human user)
            {
                _json.Write(user);
            }

     
        }
        class XmlAdapter : IAdapter
        {
            private XML _xml { get; set; }
            public XmlAdapter(XML xml)
            {
                _xml = xml;
            }

            //public List<Human> Read()
            //{
            //    return _xml.Read();
            //}

            public void Write(Human user)
            {
                _xml.Write(user);
            }
        }
        class Json
        {
            public List<Human> Read()
            {

                List<Human> users = null;
                var serializer = new JsonSerializer();
                using (var sr = new StreamReader("humans.json"))
                {
                    using (var jr = new JsonTextReader(sr))
                    {
                        users = serializer.Deserialize<List<Human>>(jr);
                    }
                }
                return users;

            }
            public void Write(Human users)
            {
                FileHelper.WriteHumans(users);
            }
        }
        class XML
        {
            public List<Human> Read()
            {
                List<Human> users = null;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Human>));
                using (TextReader reader = new StreamReader("humans.xml"))
                {
                    users = (List<Human>)serializer.Deserialize(reader);
                }
                return users;
            }

            public void Write(List<Human> users)
            {
                FileHelper.WriteHumansXml(users);
            }
        }
        class Converter
        {
            private readonly IAdapter _adapter;
            public Converter(IAdapter adapter)
            {
                _adapter = adapter;
            }
            public void Write(List<Human> users)
            {
                _adapter.Write(users);
            }
            //public List<Human> Read()
            //{
            //    return _adapter.Read();
            //}
        }
        class Application
        {
            private readonly Converter _converter;
            public Application(IAdapter adapter)
            {
                _converter = new Converter(adapter);
            }
            public void Write(List<Human> users)
            {
                _converter.Write(users);

            }
            //public List<Human> Read()
            //{
            //    return _converter.Read();
            //}
        }
        public RelayCommand SaveCommand { get; set; }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; OnPropertyChanged(); }
        }


        public MainWindowViewModel()
        {
            SaveCommand = new RelayCommand(obj =>
            {
                Name = String.Empty;
                Surname = String.Empty;
            });
        }

    }
}
