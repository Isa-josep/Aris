using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class IngresarDatos{
    public static void AddData(){
        string num;
        Console.WriteLine("Ingresa los valores: ");
        List<double> datos = new List<double>();

        while ((num = Console.ReadLine()) != "f"){
            datos.Add(Convert.ToDouble(num));
        }

        datos.Sort();
        Dictionary<int, int> conteo = new Dictionary<int, int>();
        foreach (int elemento in datos){
            if (conteo.ContainsKey(elemento))
            {
                conteo[elemento]++;
            }
            else
            {
                conteo[elemento] = 1;
            }
        }

        if (datos.Count < 30)
        {
            Console.WriteLine(" ---- DATOS AGRUPADOS --- ");
            Console.WriteLine($"|{"Xi",6}|{"F",6}|{"Fr",8}|{"Fa",8}|{"Fra",8}|");
            Console.WriteLine(new string('-', 36));
            double Fa = 0;
            foreach (var par in conteo)
            {
                double b = datos.Count;
                double Fr = par.Value;
                Fa += par.Value;
                double Fra = Fa / b;

                Console.WriteLine($"|{par.Key,6}|{par.Value,6}|{Math.Round(Fr / b, 2),8}|{Math.Round(Fa),8}|{Math.Round(Fra, 2),8}|");
            }

            Console.WriteLine();
            Console.WriteLine("MEDIANA :" + CalcularMediana(datos) + "\tMODA : " + CalcularModa(datos) + "\tMEDIA : " + CalcularMedia(datos));
        }
        else
        {
            Console.WriteLine(" --- DATOS NO AGRUPADOS --- ");
            double maxCount = 0;
            double minCount;

            for (int i = 0; i < datos.Count; i++)
            {
                if (i > datos.Count)
                {
                    maxCount = datos[i];
                }
            }

            Console.WriteLine("| INTERVALOS | \t | Xi | \t | F | \t | Fr | \t | Fa | \t  ");
            Console.WriteLine("MEDIA : " + "\t MEDIANA: " + "\t MODA: ");
        }
    }

    private static double CalcularMedia(List<double> datos)
    {
        double suma = 0;
        foreach (var dato in datos)
        {
            suma += dato;
        }
        return suma / datos.Count;
    }

    private static double CalcularModa(List<double> datos)
    {
        Dictionary<double, int> conteo = new Dictionary<double, int>();
        foreach (double elemento in datos)
        {
            if (conteo.ContainsKey(elemento))
            {
                conteo[elemento]++;
            }
            else
            {
                conteo[elemento] = 1;
            }
        }

        double moda = 0;
        int maxFrecuencia = 0;
        foreach (var par in conteo)
        {
            if (par.Value > maxFrecuencia)
            {
                moda = par.Key;
                maxFrecuencia = par.Value;
            }
        }
        return moda;
    }

    private static double CalcularMediana(List<double> datos)
    {
        datos.Sort();
        int n = datos.Count;
        if (n % 2 == 0)
        {
            return (datos[n / 2 - 1] + datos[n / 2]) / 2.0;
        }
        else
        {
            return datos[(n - 1) / 2];
        }
    }
}

public class Consultar
{
    public static void Serch()
    {
        // Método vacío, se puede implementar según sea necesario
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Ingresa tú Nombre: ");
        string nomU = Console.ReadLine();
        TextWriter nombre;
        nombre = new StreamWriter(nomU + ".txt");

        do
        {
            Console.WriteLine("1.-Ingresar datos \n2.-Consultar movimiento de: " + (nomU));
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    IngresarDatos.AddData();
                    break;
                case 2:
                    Consultar.Serch();
                    break;
            }

        } while (true);
    }
}
