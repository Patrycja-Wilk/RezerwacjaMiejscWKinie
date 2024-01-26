using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kino
{
    [Serializable]
    public class Sala : ISerialize1
    {

        private List<string> listaPrzyciskow;

        #region Wlasciwosci
        public List<string> ListaPrzyciskow { get => listaPrzyciskow; set => listaPrzyciskow = value; }

        #endregion

        #region Konstruktory
        public Sala()
        {
            listaPrzyciskow = new List<string>();


        }

        public void SaveToXml(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Sala));
            using (TextWriter writer = new StreamWriter(file))
            {
                serializer.Serialize(writer, this);
            }
        }

        

        public static Sala? LoadFromXML(string file)
        {
            if (!File.Exists(file))
            {
                return null;
            }
            using StreamReader sw = new(file);
            XmlSerializer xs = new(typeof(Sala));
            return xs.Deserialize(sw) as Sala;
        }

       

        #endregion


    }
}
