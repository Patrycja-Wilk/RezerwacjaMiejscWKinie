using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Kino
{
    #region Wyjatki
    public class ZleImieException : Exception
        {
        public ZleImieException(string message):base(message) { }   
    }
    public class ZleNazwiskoException : Exception
    {
        public ZleNazwiskoException(string message) : base(message) { }
    }
    public class ZlyTelefonException : Exception
    {
        public ZlyTelefonException(string message) : base(message) { }
    }
    public class ZlyMailException : Exception
    {
        public ZlyMailException(string message) : base(message) { }
    }

    #endregion

    [Serializable]
    public class Klient : ISerialize1
    {
        public string imie;
        public string nazwisko;
        public string telefon;
        public string mail;

        #region Wlasciwosci
        public string Imie
        {
            get => imie;
            set
            {
                if (!Regex.IsMatch(value, @"^[\p{L}]+$"))
                {
                    throw new ZleImieException("Imię powinno składać się z samych liter (w tym polskich).");
                }
                imie = value;
            }
        }
        public string Nazwisko
        {
            get => nazwisko;
            set
            {
                if (!Regex.IsMatch(value, @"^[\p{L}-]+$"))
                {
                    throw new ZleNazwiskoException("Nazwisko powinno składać się z liter (w tym polskich) i myślników.");
                }
                nazwisko = value;
            }
        }
        public string Telefon
        {
            get => telefon;
            set
            {
                if (!Regex.IsMatch(value, @"^\d{9}$"))
                {
                    throw new ZlyTelefonException("Numer telefonu powinien składać się z 9 cyfr.");
                }
                telefon = value;
            }
        }
        public string Mail
        {
            get => mail;
            set
            {
                if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    throw new ZlyMailException("Nieprawidłowy format adresu e-mail.");
                }
                mail = value;
            }
        }
        #endregion

        #region Konstruktory
        public Klient()
        {
            Imie = string.Empty;
            Nazwisko = string.Empty;
            Telefon = string.Empty;
            Mail = string.Empty;
        }

        public Klient(string imie, string nazwisko, string telefon, string mail)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Telefon = telefon;
            Mail = mail;
        }
        #endregion
        

        public void SaveToXml(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Klient));
            using (TextWriter writer = new StreamWriter(file))
            {
                serializer.Serialize(writer, this);
            }
        }

        public static Klient? LoadFromXML(string file)
        {
            if (!File.Exists(file))
            {
                return null;
            }
            using StreamReader sw = new(file);
            XmlSerializer xs = new(typeof(Klient));
            return xs.Deserialize(sw) as Klient;
        }

    }
}
