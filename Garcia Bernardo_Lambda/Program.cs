using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garcia_Bernardo_Lambda
{
    class Program
    {
        static Turista[] turistas = {
            new Turista(123,"Elias Andrade","TA",4),
            new Turista(234,"Moira Alen","TA",2),
            new Turista(345,"Lony Labbe","TG",8),
            new Turista(456,"Sidney Sommer","TA",3),
            new Turista(567,"Ari Hass","TG",8),
            new Turista(678,"Rita Asis","TC",5),
            new Turista(789,"Marco Esteves","TA",3),
            new Turista(890,"Julia Lang","TG",6),
            new Turista(901,"Ingrid RamosAsis","TC",5),
            new Turista(012,"Erick Kolbe", "TP",1)
        };

        static Tour[] excursiones = {
            new Tour("TA","Turismo Aventura","Magic Tours"),
            new Tour("TG","Turismo Gastronómico","Turismo Kronos"),
            new Tour("TC","Turismo Compras","Eva's Tours Co."),
            new Tour("TP","Turismo Paseos","Alex Tours")
        };

        static Lugar[] lugares = {
             new Lugar("PV","Puerto Varas",4),
             new Lugar("BRLCH","Bariloche",3),
             new Lugar("BRA","Rio de Janeiro",3),
             new Lugar("CHLT","Chalten",1),
             new Lugar("PA","Punta Arenas",5),
             new Lugar("PN","Puerto Natales",8),
             new Lugar("VAL","Valdivia",6),
             new Lugar("BA","Buenos Aires",2),
             new Lugar("SP","San Pablo",1),
             new Lugar("FLO","Florianópolis",2)
        };

        static Turista_Lugar[] turista_visita = {
             new Turista_Lugar(123,"BRLCH"),
             new Turista_Lugar(123,"PV"),
             new Turista_Lugar(123,"BRA"),
             new Turista_Lugar(123,"FLO"),
             new Turista_Lugar(234,"SP"),
             new Turista_Lugar(234,"BA"),
             new Turista_Lugar(345,"PN"),
             new Turista_Lugar(345,"VAL"),
             new Turista_Lugar(456,"BRA"),
             new Turista_Lugar(456,"BA"),
             new Turista_Lugar(567,"PN"),
             new Turista_Lugar(678,"PA"),
             new Turista_Lugar(678,"PV"),
             new Turista_Lugar(789,"BRA"),
             new Turista_Lugar(789,"SP"),
             new Turista_Lugar(789,"FLO"),
             new Turista_Lugar(890,"VAL"),
             new Turista_Lugar(890,"BRLCH"),
             new Turista_Lugar(901,"PA"),
             new Turista_Lugar(012,"CHLT")
        };

        static Paquete[] paquetes = {
             new Paquete(1,"Básico"),
             new Paquete(2,"Económico"),
             new Paquete(3,"Estandar"),
             new Paquete(4,"Jubilados"),
             new Paquete(5,"Familiar"),
             new Paquete(6,"Todo incluido"),
             new Paquete(7,"Extra"),
             new Paquete(8,"Vip")
        };


        static void Main(string[] args)
        {
            //ejercicio1();
            //ejercicio2("Bariloche");
            //ejercicio3("Familiar");
            //ejercicio4("Elias Andrade");
            //ejercicio5();
            //ejercicio6();
            //ejercicio7();
            //ejercicio8();
            //ejercicio9();
            ejercicio10();

            Console.ReadKey();
        }

        static void ejercicio1()
        {
            Console.WriteLine("1. Listar todos los turistas agrupados por tour.");
            var listTourists = turistas.GroupBy((x) => x.CodTour);

            foreach (var item in listTourists)
            {
                Console.WriteLine("Tour: " + item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine("  " + i.NomTurista);
                }
            }
        }

        static void ejercicio2(string place)
        {
            Console.WriteLine("2. Dado el nombre de un lugar, listar los nombres de los turistas que visitarán ese lugar.");

            var listTourists2 = turista_visita
                .Join(
                    turistas, 
                    (l1 => l1.CI), 
                    (l2 => l2.CI), 
                    ((l1, l2) => new { idlugar = l1.IdLugar, nombreTurista = l2.NomTurista }))
                .Join(
                    lugares.Where(x => x.NomLugar == place), 
                    l1 => l1.idlugar, 
                    l2 => l2.CodLugar, 
                    (l1, l2) => new { l1.nombreTurista });

            Console.WriteLine("Lugar: " + place);
            foreach (var item in listTourists2)
            {
                Console.WriteLine("  " + item.nombreTurista);
            }  
        }

        static void ejercicio3(string paquete)
        {
            Console.WriteLine("3. Dado el nombre de un paquete indicar que lugares son visitados conese paquete.");

            var listTourists3 = turistas
                .Join(
                    paquetes,
                    (l1 => l1.CodPaquete),
                    (l2 => l2.CodPaquete),
                    ((l1, l2) => new { nombrePaquete = l2.NomPaquete, nombreTurista = l1.NomTurista }))
                .Where(x => x.nombrePaquete == paquete);

            Console.WriteLine("Paquete: " + paquete);
            foreach (var item in listTourists3)
            {
                Console.WriteLine("   " + item.nombreTurista);
            }
        }

        static void ejercicio4(string turista)
        {
            Console.WriteLine("4. Dado un turista mostrar el nombre del responsable de su tour.");

            var listTourist4 = turistas
                .Join(
                    excursiones,
                    l1 => l1.CodTour,
                    l2 => l2.CodTour,
                    (l1, l2) => new { nombreTurista = l1.NomTurista, nombreRes = l2.Responsable })
                .Where(x => x.nombreTurista == turista);

            Console.WriteLine("Turista: " + turista);
            foreach (var item in listTourist4)
            {
                Console.WriteLine("   Su representante es: " + item.nombreRes);
            }
        }

        static void ejercicio5()
        {
            Console.WriteLine("5. Mostrar los nombres de turistas junto a su responsable de tour.");

            var listTourist5 = turistas
                .Join(
                    excursiones,
                    (l1 => l1.CodTour),
                    (l2 => l2.CodTour),
                    (l1, l2) => new { nombreTurista = l1.NomTurista, nombreResponsable = l2.Responsable })
                .GroupBy(x => x.nombreResponsable);

            foreach (var item in listTourist5)
            {
                Console.WriteLine("Responsable de Tour: " + item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine("   " + i.nombreTurista);
                }
            }
        }

        static void ejercicio6()
        {
            Console.WriteLine("6. Mostrar los turistas por cada lugar a visitar.");

            var listTourist6 = turistas
                .Join(
                    turista_visita,
                    l1 => l1.CI,
                    l2 => l2.CI,
                    (l1, l2) => new { nombreTurista = l1.NomTurista, idLugar = l2.IdLugar })
                .Join(
                    lugares,
                    l1 => l1.idLugar,
                    l2 => l2.CodLugar,
                    (l1, l2) => new { nombreLugar = l2.NomLugar, l1.nombreTurista })
                .GroupBy(x => x.nombreLugar);

            foreach (var item in listTourist6)
            {
                Console.WriteLine("Lugar: *" + item.Key + "*");
                foreach (var i in item)
                {
                    Console.WriteLine("   " + i.nombreTurista);
                }
            }
        }

        static void ejercicio7()
        {
            Console.WriteLine("7. Cantidad de turistas que habrá en cada lugar a visitar.");

            var listTourist7 = turistas
                .Join(
                    turista_visita,
                    l1 => l1.CI,
                    l2 => l2.CI,
                    (l1, l2) => new { turistas = l1.CI, idLugar = l2.IdLugar })
                .Join(
                    lugares,
                    l1 => l1.idLugar,
                    l2 => l2.CodLugar,
                    (l1, l2) => new { l1.turistas, nombreLugar = l2.NomLugar })
                .GroupBy(x => x.nombreLugar);

            foreach (var item in listTourist7)
            {
                Console.WriteLine("Cantitad de turistas en: " + item.Key);
                Console.WriteLine(item.Count());
            }
        }

        static void ejercicio8()
        {
            Console.WriteLine("8. Nombres de turistas agrupados por (nombre de) paquete.");
            var listTourists8 = turistas.GroupBy((x) => x.CodPaquete);

            foreach (var item in listTourists8)
            {
                Console.WriteLine("Tour: " + item.Key);
                foreach (var i in item)
                {
                    Console.WriteLine("  " + i.NomTurista);
                }
            }
        }

        static void ejercicio9()
        {
            Console.WriteLine("9. Turistas registrados en más de un paquete.");

            var listTourist9 = turistas
                .Join(
                    paquetes,
                    l1 => l1.CodPaquete,
                    l2 => l2.CodPaquete,
                    (l1, l2) => new { nombrePaquete = l2.NomPaquete })
                .GroupBy(x => x.nombrePaquete)
                .Where(x => x.Count() > 1);

            foreach (var item in listTourist9)
            {
                Console.WriteLine("Paquete: " + item.Key + ": " + item.Count() + " turistas.");
            }
        }

        static void ejercicio10()
        {
            Console.WriteLine("10. Mostrar la cantidad de turistas por cada tour en forma descendente.");

            var listTourist10 = turistas
                .Join(
                    excursiones,
                    l1 => l1.CodTour,
                    l2 => l2.CodTour,
                    (l1, l2) => new { codTour = l2.CodTour, turistas = l1.CI })
                .GroupBy(x => x.codTour);

            foreach (var item in listTourist10)
            {
                Console.WriteLine("Cantidad de Turistas en: " + item.Key);
                Console.WriteLine(item.Count());
            }
        }
    }
}
