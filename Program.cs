using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        struct Proizvodi
        {
            public int id;
            public string kategorija;
            public string proizvodac;
            public string naziv;
            public int cijena;
            public int stanje;
        }

        struct Racuni
        {
            public DateTime datum;
            public int id_proizvoda;
            public int kolicina;
        }

        static void Main()
        {
            // Broj linija u dokumentu

            int br_linija = 0;

            using (StreamReader sr = File.OpenText("proizvodi.txt"))
            {
                string linija = "";
                while ((linija = sr.ReadLine()) != null)
                {
                    br_linija++;
                }
            }

            Proizvodi[] proizvod = new Proizvodi[br_linija];

            // Dodavanje u strukturu

            using (StreamReader sr = File.OpenText("proizvodi.txt"))
            {
                string linija = "";

                for (int i = 0; i < br_linija; i++)
                {
                    linija = sr.ReadLine();
                    string[] split = linija.Split(':');

                    proizvod[i].id = int.Parse(split[0]);
                    proizvod[i].kategorija = split[1];
                    proizvod[i].proizvodac = split[2];
                    proizvod[i].naziv = split[3];
                    proizvod[i].cijena = int.Parse(split[4]);
                    proizvod[i].stanje = int.Parse(split[5]);
                }
            }

            // Izoliranje kategorija

            string[] sveKategorije = new string[br_linija];

            for (int i = 0; i < br_linija; i++)
            {
                sveKategorije[i] = proizvod[i].kategorija;
            }

            string[] konacnoKategorije = sveKategorije.Distinct().ToArray();

            // Izoliranje proizvodaca

            string[] sviProizvodaci = new string[br_linija];

            for (int i = 0; i < br_linija; i++)
            {
                sviProizvodaci[i] = proizvod[i].proizvodac;
            }

            string[] konacnoProizvodaci = sviProizvodaci.Distinct().ToArray();

            //------------------------------------------------------------

            Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");
            Console.WriteLine("Odaberite opciju iz izbornika\n");

            Console.WriteLine("[1] - Pregledaj proizvode");
            Console.WriteLine("[2] - Unesi proizvod");
            Console.WriteLine("[3] - Azuriraj proizvod");
            Console.WriteLine("[4] - Izbrisi proizvod");
            Console.WriteLine("[5] - Izvjesce prodaje");

            Console.Write("\nVas odabir: ");
            int odabir = int.Parse(Console.ReadLine());

            //------------------------------------------------------------
            //------------------------------------------------------------
            // Odabir [1] - Pregledaj proizvode
            //------------------------------------------------------------
            //------------------------------------------------------------
            if (odabir == 1)
            {
                Console.Clear();
                Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");
                Console.WriteLine("Odaberite opciju iz izbornika\n");

                Console.WriteLine("[1] - Pregled svih proizvoda");
                Console.WriteLine("[2] - Pregled po kategoriji");
                Console.WriteLine("[3] - Pregled po proizvodacu");

                Console.Write("\nVas odabir: ");
                int odabir_1 = int.Parse(Console.ReadLine());

                //------------------------------------------------------------
                // Odabir [1.1] - Pregled svih proizvoda
                //------------------------------------------------------------
                if (odabir_1 == 1)
                {
                    Console.Clear();
                    Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");
                    Console.WriteLine("Pregled svih proizvoda - Odaberite vrstu sortiranja\n");

                    Console.WriteLine("[1] - Bez sortiranja");
                    Console.WriteLine("[2] - Sortiraj po kategoriji");
                    Console.WriteLine("[3] - Sortiraj po proizvodacu");
                    Console.WriteLine("[4] - Sortiraj po kategoriji i proizvodacu");
                    Console.WriteLine("[5] - Sortiraj po cijeni");
                    Console.WriteLine("[6] - Sortiraj po stanju");

                    Console.Write("\nVas odabir: ");
                    int odabir_1_sve = int.Parse(Console.ReadLine());

                    Console.WriteLine("\n----------------------------------------------------------------------");

                    //------------------------------------------------------------
                    // Odabir [1.1.1] - Pregled svih proizvoda - Bez sortiranja
                    if (odabir_1_sve == 1)
                    {
                        for (int i = 0; i < br_linija; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + proizvod[i].kategorija + ": " +
                                                               proizvod[i].proizvodac + ": " +
                                                               proizvod[i].naziv + " / " +
                                                               proizvod[i].cijena + "kn / " +
                                                               proizvod[i].stanje + " kom");
                        }
                        Console.WriteLine("----------------------------------------------------------------------");
                    }

                    //------------------------------------------------------------
                    // Odabir [1.1.2] - Pregled svih proizvoda - Sortiraj po kategoriji
                    else if (odabir_1_sve == 2)
                    {
                        for (int i = 0; i < konacnoKategorije.Length; i++)
                        {
                            Console.WriteLine(konacnoKategorije[i] + "\n");
                            for (int j = 0; j < br_linija; j++)
                            {
                                if (proizvod[j].kategorija == konacnoKategorije[i])
                                {
                                    Console.WriteLine("\t" + proizvod[j].proizvodac + ": " +
                                                             proizvod[j].naziv + " / " +
                                                             proizvod[j].cijena + "kn / " +
                                                             proizvod[j].stanje + " kom");
                                }
                            }
                            Console.WriteLine("----------------------------------------------------------------------");
                        }
                    }

                    //------------------------------------------------------------
                    // Odabir [1.1.3] - Pregled svih proizvoda - Sortiraj po proizvodacu
                    else if (odabir_1_sve == 3)
                    {
                        for (int i = 0; i < konacnoProizvodaci.Length; i++)
                        {
                            Console.WriteLine(konacnoProizvodaci[i] + "\n");
                            for (int j = 0; j < br_linija; j++)
                            {
                                if (proizvod[j].proizvodac == konacnoProizvodaci[i])
                                {
                                    Console.WriteLine("\t" + proizvod[j].kategorija + ": " +
                                                             proizvod[j].naziv + " / " +
                                                             proizvod[j].cijena + "kn / " +
                                                             proizvod[j].stanje + " kom");
                                }
                            }
                            Console.WriteLine("----------------------------------------------------------------------");
                        }
                    }

                    //------------------------------------------------------------
                    // Odabir [1.1.4] - Pregled svih proizvoda - Sortiraj po kategoriji i proizvodacu
                    else if (odabir_1_sve == 4)
                    {
                        for (int i = 0; i < konacnoKategorije.Length; i++)
                        {
                            Console.WriteLine(konacnoKategorije[i]);

                            for (int j = 0; j < konacnoProizvodaci.Length; j++)
                            {
                                int[] idProizvoda = new int[br_linija];
                                idProizvoda[0] = 0;
                                int k = 0;

                                // Provjera jel postoji proizvodac u toj kategoriji
                                for (int n = 0; n < br_linija; n++)
                                {
                                    if (proizvod[n].kategorija == konacnoKategorije[i] && proizvod[n].proizvodac == konacnoProizvodaci[j])
                                    {
                                        idProizvoda[k++] = proizvod[n].id;
                                    }
                                }

                                // Ispis proizvoda
                                if (idProizvoda[0] != 0)
                                {
                                    Console.WriteLine("\n  " + konacnoProizvodaci[j]);

                                    for (int n = 0; n < br_linija; n++)
                                    {
                                        if (idProizvoda.Contains(proizvod[n].id))
                                        {
                                            Console.WriteLine("\t" + proizvod[n].naziv + " / " +
                                                                     proizvod[n].cijena + "kn / " +
                                                                     proizvod[n].stanje + " kom");
                                        }
                                    }
                                }
                            }
                            Console.WriteLine("----------------------------------------------------------------------");
                        }
                    }

                    //------------------------------------------------------------
                    // Odabir [1.1.5] - Pregled svih proizvoda - Sortiraj po cijeni
                    else if (odabir_1_sve == 5)
                    {
                        var sortSveCijena = proizvod.OrderBy(x => x.cijena).ToList();

                        for (int i = 0; i < br_linija; i++)
                        {
                            Console.WriteLine(sortSveCijena[i].cijena + "kn - " +
                                              sortSveCijena[i].kategorija + ": " +
                                              sortSveCijena[i].proizvodac + ": " +
                                              sortSveCijena[i].naziv + " / " +
                                              sortSveCijena[i].stanje + " kom");
                        }
                        Console.WriteLine("----------------------------------------------------------------------");
                    }

                    //------------------------------------------------------------
                    // Odabir [1.1.6] - Pregled svih proizvoda - Sortiraj po stanju
                    else if (odabir_1_sve == 6)
                    {
                        var sortSveStanje = proizvod.OrderByDescending(x => x.stanje).ToList();

                        for (int i = 0; i < br_linija; i++)
                        {
                            Console.WriteLine(sortSveStanje[i].stanje + " kom - " +
                                              sortSveStanje[i].kategorija + ": " +
                                              sortSveStanje[i].proizvodac + ": " +
                                              sortSveStanje[i].naziv + " / " +
                                              sortSveStanje[i].cijena + "kn");
                        }
                        Console.WriteLine("----------------------------------------------------------------------");
                    }
                }


                //------------------------------------------------------------
                // Odabir [1.2] - Pregled po kategoriji
                //------------------------------------------------------------
                else if (odabir_1 == 2)
                {
                    Console.Clear();
                    Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");
                    Console.WriteLine("Pregled po kategoriji - Odaberite kategoriju\n");

                    for (int i = 0; i < konacnoKategorije.Length; i++)
                    {
                        Console.WriteLine("[" + (i + 1) + "] - " + konacnoKategorije[i]);
                    }

                    Console.Write("\nVas odabir: ");

                    int odabir_1_kat = int.Parse(Console.ReadLine());

                    string odabranaKategorija = konacnoKategorije[odabir_1_kat - 1];

                    Console.Clear();
                    Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");
                    Console.WriteLine("Pregled [" + odabranaKategorija + "] - Odaberite vrstu sortiranja\n");

                    Console.WriteLine("[1] - Bez sortiranja");
                    Console.WriteLine("[2] - Sortiraj po proizvodacu");
                    Console.WriteLine("[3] - Sortiraj po cijeni");
                    Console.WriteLine("[4] - Sortiraj po stanju");

                    Console.Write("\nVas odabir: ");

                    int odabir_1_kat_sort = int.Parse(Console.ReadLine());

                    Console.WriteLine("\n----------------------------------------------------------------------");
                    Console.WriteLine(odabranaKategorija);

                    //------------------------------------------------------------
                    // Odabir [1.2.x.1] - Bez sortiranja
                    if (odabir_1_kat_sort == 1)
                    {
                        Console.WriteLine();

                        for (int i = 0; i < br_linija; i++)
                        {
                            if (proizvod[i].kategorija == odabranaKategorija)
                            {
                                Console.WriteLine("  " + proizvod[i].proizvodac + ": " +
                                                         proizvod[i].naziv + " / " +
                                                         proizvod[i].cijena + "kn / " +
                                                         proizvod[i].stanje + " kom");
                            }
                        }
                    }

                    //------------------------------------------------------------
                    // Odabir [1.2.x.2] - Sortiraj po proizvodacu
                    else if (odabir_1_kat_sort == 2)
                    {
                        for (int i = 0; i < konacnoProizvodaci.Length; i++)
                        {
                            int[] idProizvoda = new int[br_linija];
                            idProizvoda[0] = 0;
                            int k = 0;

                            // Provjera jel postoji proizvodac u toj kategoriji
                            for (int j = 0; j < br_linija; j++)
                            {
                                if (proizvod[j].kategorija == odabranaKategorija && proizvod[j].proizvodac == konacnoProizvodaci[i])
                                {
                                    idProizvoda[k++] = proizvod[j].id;
                                }
                            }

                            // Ispis proizvoda
                            if (idProizvoda[0] != 0)
                            {
                                Console.WriteLine("\n  " + konacnoProizvodaci[i]);

                                for (int j = 0; j < br_linija; j++)
                                {
                                    if (idProizvoda.Contains(proizvod[j].id))
                                    {
                                        Console.WriteLine("\t" + proizvod[j].naziv + " / " +
                                                                 proizvod[j].cijena + "kn / " +
                                                                 proizvod[j].stanje + " kom");
                                    }
                                }
                            }
                        }
                    }

                    //------------------------------------------------------------
                    // Odabir [1.2.x.3] - Sortiraj po cijeni
                    else if (odabir_1_kat_sort == 3)
                    {
                        Console.WriteLine();
                        var sortKategorijaCijena = proizvod.OrderBy(x => x.cijena).ToList();

                        for (int i = 0; i < br_linija; i++)
                        {
                            if (sortKategorijaCijena[i].kategorija == odabranaKategorija)
                            {
                                Console.WriteLine("  " + sortKategorijaCijena[i].cijena + "kn - " +
                                                         sortKategorijaCijena[i].proizvodac + ": " +
                                                         sortKategorijaCijena[i].naziv + " / " +
                                                         sortKategorijaCijena[i].stanje + " kom");
                            }
                        }
                    }

                    //------------------------------------------------------------
                    // Odabir [1.2.x.4] - Sortiraj po stanju
                    else if (odabir_1_kat_sort == 4)
                    {
                        Console.WriteLine();
                        var sortKategorijaStanje = proizvod.OrderByDescending(x => x.stanje).ToList();

                        for (int i = 0; i < br_linija; i++)
                        {
                            if (sortKategorijaStanje[i].kategorija == odabranaKategorija)
                            {
                                Console.WriteLine("  " + sortKategorijaStanje[i].stanje + " kom - " +
                                                         sortKategorijaStanje[i].proizvodac + ": " +
                                                         sortKategorijaStanje[i].naziv + " / " +
                                                         sortKategorijaStanje[i].cijena + "kn");
                            }
                        }
                    }

                    Console.WriteLine("----------------------------------------------------------------------");
                }

                //------------------------------------------------------------
                // Odabir [1.3] - Pregled po proizvodacu
                //------------------------------------------------------------
                else if (odabir_1 == 3)
                {
                    Console.Clear();
                    Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");
                    Console.WriteLine("Pregled po proizvodacu - Odaberite proizvodaca\n");

                    for (int i = 0; i < konacnoProizvodaci.Length; i++)
                    {
                        Console.WriteLine("[" + (i + 1) + "] - " + konacnoProizvodaci[i]);
                    }

                    Console.Write("\nVas odabir: ");

                    int odabir_1_pro = int.Parse(Console.ReadLine());

                    string odabraniProizvodac = konacnoProizvodaci[odabir_1_pro - 1];

                    Console.Clear();
                    Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");
                    Console.WriteLine("Pregled [" + odabraniProizvodac + "] - Odaberite vrstu sortiranja\n");

                    Console.WriteLine("[1] - Bez sortiranja");
                    Console.WriteLine("[2] - Sortiraj po kategoriji");
                    Console.WriteLine("[3] - Sortiraj po cijeni");
                    Console.WriteLine("[4] - Sortiraj po stanju");

                    Console.Write("\nVas odabir: ");

                    int odabir_1_pro_sort = int.Parse(Console.ReadLine());

                    Console.WriteLine("\n----------------------------------------------------------------------");
                    Console.WriteLine(odabraniProizvodac);

                    //------------------------------------------------------------
                    // Odabir [1.3.x.1] - Bez sortiranja
                    if (odabir_1_pro_sort == 1)
                    {
                        Console.WriteLine();

                        for (int i = 0; i < br_linija; i++)
                        {
                            if (proizvod[i].proizvodac == odabraniProizvodac)
                            {
                                Console.WriteLine("  " + proizvod[i].kategorija + ": " +
                                                         proizvod[i].naziv + " / " +
                                                         proizvod[i].cijena + "kn / " +
                                                         proizvod[i].stanje + " kom");
                            }
                        }
                    }

                    //------------------------------------------------------------
                    // Odabir [1.3.x.2] - Sortiraj po kategoriji
                    else if (odabir_1_pro_sort == 2)
                    {
                        for (int i = 0; i < konacnoKategorije.Length; i++)
                        {
                            int[] idProizvoda = new int[br_linija];
                            idProizvoda[0] = 0;
                            int k = 0;

                            // Provjera jel postoji proizvodac u toj kategoriji
                            for (int j = 0; j < br_linija; j++)
                            {
                                if (proizvod[j].proizvodac == odabraniProizvodac && proizvod[j].kategorija == konacnoKategorije[i])
                                {
                                    idProizvoda[k++] = proizvod[j].id;
                                }
                            }

                            // Ispis proizvoda
                            if (idProizvoda[0] != 0)
                            {
                                Console.WriteLine("\n  " + konacnoKategorije[i]);

                                for (int j = 0; j < br_linija; j++)
                                {
                                    if (idProizvoda.Contains(proizvod[j].id))
                                    {
                                        Console.WriteLine("\t" + proizvod[j].naziv + " / " +
                                                                 proizvod[j].cijena + "kn / " +
                                                                 proizvod[j].stanje + " kom");
                                    }
                                }
                            }
                        }
                    }

                    //------------------------------------------------------------
                    // Odabir [1.3.x.3] - Sortiraj po cijeni
                    else if (odabir_1_pro_sort == 3)
                    {
                        Console.WriteLine();
                        var sortProizvodacCijena = proizvod.OrderBy(x => x.cijena).ToList();

                        for (int i = 0; i < br_linija; i++)
                        {
                            if (sortProizvodacCijena[i].proizvodac == odabraniProizvodac)
                            {
                                Console.WriteLine("  " + sortProizvodacCijena[i].cijena + "kn - " +
                                                         sortProizvodacCijena[i].kategorija + ": " +
                                                         sortProizvodacCijena[i].naziv + " / " +
                                                         sortProizvodacCijena[i].stanje + " kom");
                            }
                        }
                    }

                    //------------------------------------------------------------
                    // Odabir [1.3.x.4] - Sortiraj po stanju
                    else if (odabir_1_pro_sort == 4)
                    {
                        Console.WriteLine();
                        var sortProizvodacStanje = proizvod.OrderByDescending(x => x.stanje).ToList();

                        for (int i = 0; i < br_linija; i++)
                        {
                            if (sortProizvodacStanje[i].proizvodac == odabraniProizvodac)
                            {
                                Console.WriteLine("  " + sortProizvodacStanje[i].stanje + " kom - " +
                                                         sortProizvodacStanje[i].kategorija + ": " +
                                                         sortProizvodacStanje[i].naziv + " / " +
                                                         sortProizvodacStanje[i].cijena + "kn");
                            }
                        }
                    }
                    Console.WriteLine("----------------------------------------------------------------------");
                }
            }

            //------------------------------------------------------------
            //------------------------------------------------------------
            // Odabir [2] , [3] ili [4]
            //------------------------------------------------------------
            //------------------------------------------------------------
            else if (odabir == 2 || odabir == 3 || odabir == 4)
            {
                // Treba da bi mogli ispisati naziv kad zelimo izbrisati ili azurirati proizvod
                int idEditProizvod = 0;
                int listaEditProizvod = 0;

                //------------------------------------------------------------
                // Odabir [3] Azuriraj ili [4] Izbrisi
                //------------------------------------------------------------
                // Ako brisemo ili azuriramo prvo ispisujemo da korisnik odabere koji proizvod zeli
                if (odabir == 3 || odabir == 4)
                {
                    Console.Clear();
                    Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");
                    Console.WriteLine("----------------------------------------------------------------------");

                    for (int i = 0; i < konacnoKategorije.Length; i++)
                    {
                        Console.WriteLine(konacnoKategorije[i]);

                        for (int j = 0; j < konacnoProizvodaci.Length; j++)
                        {
                            int[] idProizvoda = new int[br_linija];
                            idProizvoda[0] = 0;
                            int k = 0;

                            // Provjera jel postoji proizvodac u toj kategoriji
                            for (int n = 0; n < br_linija; n++)
                            {
                                if (proizvod[n].kategorija == konacnoKategorije[i] && proizvod[n].proizvodac == konacnoProizvodaci[j])
                                {
                                    idProizvoda[k++] = proizvod[n].id;
                                }
                            }

                            // Ispis proizvoda
                            if (idProizvoda[0] != 0)
                            {
                                Console.WriteLine("\n  " + konacnoProizvodaci[j]);

                                for (int n = 0; n < br_linija; n++)
                                {
                                    if (idProizvoda.Contains(proizvod[n].id))
                                    {
                                        Console.WriteLine("    ID[" + proizvod[n].id + "] - " +
                                                                      proizvod[n].naziv + " / " +
                                                                      proizvod[n].cijena + "kn / " +
                                                                      proizvod[n].stanje + " kom");
                                    }
                                }
                            }
                        }
                        Console.WriteLine("----------------------------------------------------------------------");
                    }

                    Console.WriteLine();

                    if (odabir == 3)
                    {
                        Console.Write("Unesite ID proizvoda koji zelite azurirati: ");
                    }
                    else if (odabir == 4)
                    {
                        Console.Write("Unesite ID proizvoda koji zelite izbrisati: ");
                    }
                    idEditProizvod = int.Parse(Console.ReadLine());

                    // Dohvacamo naziv proizvoda preko ID
                    for (int i = 0; i < br_linija; i++)
                    {
                        if (proizvod[i].id == idEditProizvod)
                        {
                            listaEditProizvod = i;
                        }
                    }
                }

                //------------------------------------------------------------
                // Odabir [2] Unesi ili [3] Azuriraj
                //------------------------------------------------------------
                Proizvodi noviProizvod = new Proizvodi(); // Treba za unos ili brisanje na kraju

                if (odabir == 2 || odabir == 3)
                {
                    Console.Clear();
                    Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");

                    // Ako azuriramo ispisemo koji proizvod ispisujemo
                    if (odabir == 3)
                    {
                        Console.WriteLine("Azurirate podatke za [" +
                                           proizvod[listaEditProizvod].kategorija + ": " +
                                           proizvod[listaEditProizvod].proizvodac + ": " +
                                           proizvod[listaEditProizvod].naziv + " / " +
                                           proizvod[listaEditProizvod].cijena + "kn / " +
                                           proizvod[listaEditProizvod].stanje + " kom]\n");
                    }
                    else
                    {
                        Console.WriteLine("Unos podataka za novi proizvod\n");
                        noviProizvod.id = proizvod[br_linija - 1].id + 1; // ID se nece ponavljati nego ide sve veci i veci
                        Console.Write("Unesite kategoriju proizvoda: ");
                        noviProizvod.kategorija = Console.ReadLine();
                        Console.Write("Unesite proizvodaca proizvoda: ");
                        noviProizvod.proizvodac = Console.ReadLine();
                        Console.Write("Unesite naziv proizvoda: ");
                        noviProizvod.naziv = Console.ReadLine();
                    }

                    Console.Write("Unesite cijenu proizvoda: ");
                    noviProizvod.cijena = int.Parse(Console.ReadLine());
                    Console.Write("Unesite kolicinu proizvoda na stanju: ");
                    noviProizvod.stanje = int.Parse(Console.ReadLine());
                }

                //------------------------------------------------------------
                // Odabir [4] - Izbrisi
                //------------------------------------------------------------
                if (odabir == 4)
                {
                    Console.Clear();
                    Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");

                    Console.WriteLine("Jeste li sigurni da zelite izbrisati [" +
                                       proizvod[listaEditProizvod].kategorija + ": " +
                                       proizvod[listaEditProizvod].proizvodac + ": " +
                                       proizvod[listaEditProizvod].naziv + "] ?\n");

                    Console.WriteLine("[0] - NE\n[1] - DA");
                    Console.Write("\nVas odabir: ");
                    int da_ne = int.Parse(Console.ReadLine());
                    if (da_ne == 0)
                    {
                        Environment.Exit(0);
                    }
                }

                using (StreamWriter sw = File.CreateText("proizvodi.txt"))
                {
                    for (int i = 0; i < br_linija; i++)
                    {
                        if (odabir == 3 && idEditProizvod == proizvod[i].id)
                        {
                            sw.WriteLine(proizvod[i].id + ":" +
                                         proizvod[i].kategorija + ":" +
                                         proizvod[i].proizvodac + ":" +
                                         proizvod[i].naziv + ":" +
                                         noviProizvod.cijena + ":" +
                                         noviProizvod.stanje);
                        }
                        else if (odabir == 4 && idEditProizvod == proizvod[i].id) { }
                        else
                        {
                            sw.WriteLine(proizvod[i].id + ":" +
                                         proizvod[i].kategorija + ":" +
                                         proizvod[i].proizvodac + ":" +
                                         proizvod[i].naziv + ":" +
                                         proizvod[i].cijena + ":" +
                                         proizvod[i].stanje);
                        }
                    }

                    if (odabir == 2)
                    {
                        sw.WriteLine(noviProizvod.id + ":" +
                                     noviProizvod.kategorija + ":" +
                                     noviProizvod.proizvodac + ":" +
                                     noviProizvod.naziv + ":" +
                                     noviProizvod.cijena + ":" +
                                     noviProizvod.stanje);
                    }
                }
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine("Operacija uspjesno odradena");
                Console.WriteLine("----------------------------------------------------------------------");
            }

            //------------------------------------------------------------
            //------------------------------------------------------------
            // Odabir [5] Izvjesce
            //------------------------------------------------------------
            //------------------------------------------------------------
            else if (odabir == 5)
            {
                // Broj racuna
                int br_racuna = 0;

                using (StreamReader sr = File.OpenText("prodaja.txt"))
                {
                    string linija = "";
                    while ((linija = sr.ReadLine()) != null)
                    {
                        br_racuna++;
                    }
                }

                Racuni[] racun = new Racuni[br_racuna];

                // Dodavanje u strukturu
                using (StreamReader sr = File.OpenText("prodaja.txt"))
                {
                    string linija = "";

                    for (int i = 0; i < br_racuna; i++)
                    {
                        linija = sr.ReadLine();
                        string[] split = linija.Split(':');
                        racun[i].datum = DateTime.Parse(split[0]);
                        racun[i].id_proizvoda = int.Parse(split[1]);
                        racun[i].kolicina = int.Parse(split[2]);
                    }
                }

                //------------------------------------------------------------
                // Odabir [5] - Izvjesce prodaje
                //------------------------------------------------------------
                
                Console.Clear();
                Console.WriteLine("PROGRAM ZA VODENJE TRGOVINE RACUNALNE OPREME\n");
                Console.WriteLine("Odaberite opciju iz izbornika\n");

                Console.WriteLine("[1] - Sveukupna prodaja"); // ispis, zarada, broj proizvoda
                Console.WriteLine("[2] - Pregled po godinama"); // po godinama, datum, proizvod, kolicina = ukupna cijena

                Console.Write("\nVas odabir: ");
                int odabir_izvjesce = int.Parse(Console.ReadLine());

                Console.WriteLine("\nZelite li takoder ispis u datoteku?\n");
                Console.WriteLine("[0] - NE\n[1] - DA");
                Console.Write("\nVas odabir: ");

                int ispis = int.Parse(Console.ReadLine());

                Console.WriteLine("\n----------------------------------------------------------------------");

                //------------------------------------------------------------
                // Odabir [5.1] - Sveukupno
                if (odabir_izvjesce == 1)
                {
                    int ukupnaKolicina = 0;
                    int ukupanPromet = 0;

                    using (StreamWriter sw = File.CreateText("Izvjesce.txt"))
                    {
                        for (int i = 0; i < br_racuna; i++)
                        {
                            // Datum u string za dobar ispis
                            string datumRacuna = racun[i].datum.ToString("dd.MM.yyyy");

                            // Dohvacanje naziva artikla i cijenu
                            string proizvodRacun = "Nepoznat proizvod"; // Ako je mozda izbrisan
                            int cijenaProizvoda = 0;
                            for (int j = 0; j < br_linija; j++)
                            {
                                if (proizvod[j].id == racun[i].id_proizvoda)
                                {
                                    proizvodRacun = proizvod[j].naziv;
                                    cijenaProizvoda = proizvod[j].cijena;
                                }
                            }

                            Console.WriteLine(datumRacuna + " - " +
                                              proizvodRacun + " (x" +
                                              racun[i].kolicina + ") = " +
                                              (racun[i].kolicina * cijenaProizvoda) + "kn");
                            if (ispis == 1)
                            {
                                if (i == 0)
                                {
                                    sw.WriteLine("----------------------------------------------------------------------");
                                }
                                sw.WriteLine(datumRacuna + " - " +
                                             proizvodRacun + " (x" +
                                             racun[i].kolicina + ") = " +
                                             (racun[i].kolicina * cijenaProizvoda) + "kn");
                            }

                            ukupnaKolicina += racun[i].kolicina;
                            ukupanPromet += (racun[i].kolicina * cijenaProizvoda);
                        }
                        if (ispis == 1)
                        {
                            sw.WriteLine("----------------------------------------------------------------------");
                            sw.WriteLine("Ukupno proizvoda: " + ukupnaKolicina + " kom");
                            sw.WriteLine("Ukupan promet : " + ukupanPromet + "kn");
                            sw.WriteLine("----------------------------------------------------------------------");
                        }
                    }
                    Console.WriteLine("----------------------------------------------------------------------");
                    Console.WriteLine("Ukupno proizvoda: " + ukupnaKolicina + " kom");
                    Console.WriteLine("Ukupan promet : " + ukupanPromet + "kn");
                    Console.WriteLine("----------------------------------------------------------------------");
                    if (ispis == 0)
                    {
                        File.Delete("Izvjesce.txt");
                    }
                    else
                    {
                        Console.WriteLine("\nIzvjesce je uspjesno izvezeno u \"Izvjesce.txt\"\n");
                    }
                }
                //------------------------------------------------------------
                // Odabir [5.2] - Godisnje
                else if (odabir_izvjesce == 2)
                {
                    // Izoliranje godina
                    int[] sveGodine = new int[br_racuna];
                    for (int i = 0; i < br_racuna; i++)
                    {
                        sveGodine[i] = racun[i].datum.Year;
                    }
                    int[] konacnoGodine = sveGodine.Distinct().ToArray();

                    // Ispis
                    using (StreamWriter sw = File.CreateText("Izvjesce.txt"))
                    {
                        for (int i = 0; i < konacnoGodine.Length; i++)
                        {
                            
                            int godisnjaKolicina = 0;
                            int godisnjiPromet = 0;

                            Console.WriteLine("GODINA: " + konacnoGodine[i] + "\n");
                            if (ispis == 1)
                            {
                                if (i == 0)
                                {
                                    sw.WriteLine("----------------------------------------------------------------------");
                                }
                                sw.WriteLine("GODINA: " + konacnoGodine[i] + "\n");
                            }

                            for (int j = 0; j < br_racuna; j++)
                            {
                                if (racun[j].datum.Year == konacnoGodine[i])
                                {
                                    // Datum u string za dobar ispis
                                    string datumRacuna = racun[j].datum.ToString("dd.MM.");

                                    // Dohvacanje naziva artikla i cijenu
                                    string proizvodRacun = "Nepoznat proizvod"; // Ako je mozda izbrisan
                                    int cijenaProizvoda = 0;
                                    for (int k = 0; k < br_linija; k++)
                                    {
                                        if (proizvod[k].id == racun[j].id_proizvoda)
                                        {
                                            proizvodRacun = proizvod[k].naziv;
                                            cijenaProizvoda = proizvod[k].cijena;
                                        }
                                    }

                                    Console.WriteLine("  " + datumRacuna + " - " +
                                                             proizvodRacun + " (x" +
                                                             racun[j].kolicina + ") = " +
                                                             (racun[j].kolicina * cijenaProizvoda) + "kn");
                                    if (ispis == 1)
                                    {
                                        sw.WriteLine("  " + datumRacuna + " - " +
                                                            proizvodRacun + " (x" +
                                                            racun[j].kolicina + ") = " +
                                                            (racun[j].kolicina * cijenaProizvoda) + "kn");
                                    }

                                    godisnjaKolicina += racun[j].kolicina;
                                    godisnjiPromet += (racun[j].kolicina * cijenaProizvoda);
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Prodanih proizvoda: " + godisnjaKolicina + " kom");
                            Console.WriteLine("Promet: " + godisnjiPromet + "kn\n");
                            Console.WriteLine("----------------------------------------------------------------------");
                            if (ispis == 1)
                            {
                                sw.WriteLine();
                                sw.WriteLine("Prodanih proizvoda: " + godisnjaKolicina + " kom");
                                sw.WriteLine("Promet: " + godisnjiPromet + "kn\n");
                                sw.WriteLine("----------------------------------------------------------------------");

                            }
                        }
                    }
                    if (ispis == 0)
                    {
                        File.Delete("Izvjesce.txt");
                    }
                    else
                    {
                        Console.WriteLine("\nIzvjesce je uspjesno izvezeno u \"Izvjesce.txt\"\n");
                    }
                }
            }
        }
    }
}
