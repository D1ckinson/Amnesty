using System;
using System.Collections.Generic;

namespace Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dossiersQuantity = 10;
            string crime = "Антиправительственное";

            CriminalDossierFabrik dossierFabrik = new CriminalDossierFabrik();
            List<CriminalDossier> criminalDossiers = new List<CriminalDossier>();

            dossierFabrik.AddCrime(crime);

            for (int i = 0; i < dossiersQuantity; i++)
                criminalDossiers.Add(dossierFabrik.CreateDossier());

            WriteDossierList("до", criminalDossiers);

            criminalDossiers.RemoveAll(dossier => dossier.Crime == crime);

            Console.WriteLine();
            WriteDossierList("после", criminalDossiers);
        }

        private static void WriteDossierList(string text, List<CriminalDossier> criminalDossiers)
        {
            Console.WriteLine($"Список преступников {text} амнистии:");
            criminalDossiers.ForEach(dossier => Console.WriteLine($"{dossier.FullName}. Преступление: {dossier.Crime}."));
        }
    }

    class CriminalDossier
    {
        public CriminalDossier(string fullName, string crime)
        {
            FullName = fullName;
            Crime = crime;
        }

        public string FullName { get; private set; }
        public string Crime { get; private set; }
    }

    class CriminalDossierFabrik
    {
        private List<string> _names;
        private List<string> _surnames;
        private List<string> _crimes;

        private Random _random = new Random();

        public CriminalDossierFabrik()
        {
            FillNames();
            FillSurnames();
            FillCrimes();
        }

        public CriminalDossier CreateDossier()
        {
            string name = _names[_random.Next(0, _names.Count)];
            string surname = _surnames[_random.Next(_surnames.Count)];
            string fullName = $"{name} {surname}";

            string crime = _crimes[_random.Next(0, _crimes.Count)];

            return new CriminalDossier(fullName, crime);
        }

        private void FillNames() =>
            _names = new List<string>
            {
                "Геннадий",
                "Дмитрий",
                "Максим",
                "Александр",
                "Валерий",
                "Михаил"
            };

        private void FillSurnames() =>
            _surnames = new List<string>
            {
                "Немичев",
                "Величко",
                "Андреев",
                "Кузнецов",
                "Емельянов",
                "Киррилов",
                "Мамонов"
            };

        private void FillCrimes() =>
            _crimes = new List<string>
            {
                "Коррупция",
                "Наркоторговля",
            };

        public void AddCrime(string crime) =>
            _crimes.Add(crime);
    }
}
