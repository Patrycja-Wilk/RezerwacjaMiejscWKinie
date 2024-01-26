using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kino
{
    [Serializable]
    public class RezerwacjaNowa : ISerialize1
    {
        static int index;
        string numerRezerwacji;
        Sala sala;
        string zarezerwowaneMiejsca;
        decimal cena;
        Klient klient;
        bool oplacona;
        public string Film { get; set; }
        public string DzienTygodnia { get; set; }
        public string Godzina { get; set; }
        public List<string> Miejsca { get; set; }


        public int LiczbaBiletowNormalnych { get; set; }
        public int LiczbaBiletowUlgowych { get; set; }

        #region Wlasciwosci
        public string NumerRezerwacji { get => numerRezerwacji; set => numerRezerwacji = value; }
        public decimal Cena { get => cena; set => cena = value; }
        public bool Oplacona { get => oplacona; set => oplacona = value; }
        public Sala Sala { get => sala; set => sala = value; }
        public string ZarezerwowaneMiejsca { get => zarezerwowaneMiejsca; set => zarezerwowaneMiejsca = value; }
        public Klient Klient { get => klient; set => klient = value; }
        #endregion

        #region Konstruktory
        static RezerwacjaNowa()
        {
            index = 1;
        }
        public RezerwacjaNowa(Sala sala, string zarezerwowaneMiejsca, decimal cena, Klient klient, bool oplacona, int liczbaBiletowNormalnych, int liczbaBiletowUlgowych)
        {
            NumerRezerwacji = $"{index:D5}";
            index++;
            Sala = sala;
            ZarezerwowaneMiejsca = zarezerwowaneMiejsca;
            Cena = cena;
            Klient = klient;
            Oplacona = oplacona;
            LiczbaBiletowNormalnych = liczbaBiletowNormalnych;
            LiczbaBiletowUlgowych = liczbaBiletowUlgowych;
        }

        public void SaveToXml(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RezerwacjaNowa));
            using (TextWriter writer = new StreamWriter(file))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static RezerwacjaNowa? LoadFromXML(string file)
        {
            if (!File.Exists(file))
            {
                return null;
            }
            using StreamReader sw = new(file);
            XmlSerializer xs = new(typeof(RezerwacjaNowa));
            return xs.Deserialize(sw) as RezerwacjaNowa;
        }

        #endregion

    }
}

