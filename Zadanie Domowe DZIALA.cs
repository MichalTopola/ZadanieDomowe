using System;

namespace Zadanie
{
    class Room
    {
        public double length, width;
        public string buffor;
        public double range;
        public string error = "Blad";
        public double Inf(double l, double w)//Metoda liczaca pole pomieszczenia
        {
            length = l;
            width = w;
            try
            {

                Console.WriteLine("Podaj dlugosc pomieszczenia: ");
                buffor = Console.ReadLine();
                l = double.Parse(buffor);
                Console.WriteLine("Podaj szerokosc pomieszczenia: ");
                buffor = Console.ReadLine();
                w = double.Parse(buffor);
                Console.WriteLine("Pole pomieszczenia to: ");
                range = w * l;
                Console.WriteLine(range);
                return range;
            }


            catch (FormatException)
            {

                Console.WriteLine("Podaj liczby w cyfrach!");
                Console.WriteLine("Podaj dlugosc pomieszczenia: ");
                buffor = Console.ReadLine();
                l = double.Parse(buffor);
                Console.WriteLine("Podaj szerokosc pomieszczenia: ");
                buffor = Console.ReadLine();
                w = double.Parse(buffor);
                Console.WriteLine("Pole pomieszczenia to: ");
                range = w * l;
                Console.WriteLine(range);
                return range;
            }
            catch
            {
                Console.WriteLine("Blad nastapi zamkniecie programu");
                Environment.Exit(0);
                return range;

            }
        }
    };
    class Tabula : Room
    {
        double size;
        double TileField;
        double TileRoom;
        double specialWidth;
        double specialLenght;
        public double Plate(double a) //Metoda liczaca pole plytki standardowej
        {
            size = a;
            return a * a;
        }
        public double Plate(double b, double c) //Przeciazona metoda liczaca pole plytki niestandardowej
        {
            specialWidth = b / 100;
            specialLenght = c / 100;

            return specialWidth * specialLenght;
        }
        public double Count(double a, double b)//Metoda liczaca ile potrzeba plytek na pomieszczenie z uwzglednieniem 1 plytki zapasu
        {

            TileField = a;
            TileRoom = b;

            return b / a; 
        }


    };
    public struct St
    {
        public string size;
        public int price;
    }
    class Program
    {
                        
    static void Main(string[] args)
        {


             St[] Tab = new St[3];
                Tab[0].size = "Dwadziescia na dwadziescia. Cena za opakowanie to: ";
                Tab[0].price = 94;
                Tab[1].size = "Trzydziesci na trzydziesci. Cena za opakowanie to: ";
                Tab[1].price = 105;
                Tab[2].size = "Dwadziescia na dwadziescia. Cena za opakowanie to: ";
                Tab[2].price = 125;
            

            int choice;
            string buf;
            double Pole;
            double score; //Zmienna przechowujaca ilosc potrzebnych plytek przed zaokragleniem
            double SquareS;//Przechowuje pole plytki niestandardowej
           
            Tabula p1 = new Tabula();
            Console.Beep();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Witam pomoge Ci dobrać i obliczyć ilosc potrzebnych plytek do twojej lazienki!");
            Room r1 = new Room();
            Pole = r1.Inf(0, 0);
            Console.WriteLine("Na skladzie mamy plytki o standardowcyh wymiarach ");
            Console.WriteLine("1 =20*20 ");
            Console.WriteLine("2 =30*30 ");
            Console.WriteLine("3 =40*40 ");
            Console.WriteLine("4 =Plytki niestandardowe ");

            try
            {
                buf = Console.ReadLine();
                choice = int.Parse(buf);
            }

            catch (FormatException)
            {
                Console.WriteLine("Sproboj jeszcze raz dokonac wyboru");
                buf = Console.ReadLine();
                choice = int.Parse(buf);
            }
            switch (choice)
            {
                case 1:

                    score = p1.Count(p1.Plate(0.2), Pole) / 12;
                    Console.WriteLine("Potrzebujesz " + Math.Ceiling(score) + " Opakowania");
                    Console.WriteLine(Tab[0].size+Tab[0].price);
                    Console.WriteLine("Calosc: " + Tab[0].price * Math.Ceiling(score) + " zl");
                    Console.ReadLine();
                    break;
                case 2:
                    score = p1.Count(p1.Plate(0.3), Pole) / 12;
                    Console.WriteLine("Potrzebujesz " + Math.Ceiling(score) + " Opakowania");
                    Console.WriteLine(Tab[1].size + Tab[1].price);
                    Console.WriteLine("Calosc: " + Tab[1].price * Math.Ceiling(score) + " zl");
                    Console.ReadLine();
                    break;
                case 3:
                    score = p1.Count(p1.Plate(0.4), Pole) / 12;
                    Console.WriteLine("Potrzebujesz " + Math.Ceiling(score) + " Opakowania");
                    Console.WriteLine(Tab[2].size + Tab[2].price);
                    Console.WriteLine("Calosc: " + Tab[2].price * Math.Ceiling(score) + " zl");
                    Console.ReadLine();
                    break;
                case 4:
                    double wysokoscNiestandardowej;
                    double szerokoscNiestandardowej;
                    Console.WriteLine("Podaj szerokosc swojej plytki: ");
                    buf = Console.ReadLine();
                    szerokoscNiestandardowej = Double.Parse(buf);
                    Console.WriteLine("Podaj wysokosc swojej plytki: ");
                    buf = Console.ReadLine();
                    wysokoscNiestandardowej = Double.Parse(buf);
                    SquareS = p1.Plate(wysokoscNiestandardowej, szerokoscNiestandardowej);// Pole plytki
                    Console.WriteLine("Pole plytki niestandardowej " + SquareS);
                    score = p1.Count(SquareS, Pole) / 12;                   
                    Console.WriteLine("Potrzebujesz " + Math.Ceiling(score) + " Opakowania");
                    Console.WriteLine("Cene ustal ze sprzedawca");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Zly przycisk nastepuje zamkniecie programu");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}