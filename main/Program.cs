using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Collections.Generic;



public class ingresarDatos{ 
      
     public static void addData(){
         string num; 
         Console.WriteLine("Ingresa los valores: ");
         List<double>datos = new List<double>();  //TODO: lista     
         while ((num=Console.ReadLine())!="f")
        {
           
            datos.Add(Convert.ToInt32(num)); 
        }
        datos.Sort();
        Dictionary<int, int> conteo = new Dictionary<int, int>();
        foreach (int elemento in datos)
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
        if (datos.Count<30){ 
            Console.WriteLine(" ---- DATOS AGRUPADOS --- ");
            Console.WriteLine($" | Xi | \t| F | \t  | Fr |\t \t | Fa | \t | Fra |  ");
            double Fa=0;
            foreach (var par in conteo)
            { 
                double b = datos.Count;    
                double Fr= (par.Value);
                Fa+=par.Value;
                double Fra= Fa/b;
                
               
            Console.WriteLine($" { par.Key }\t\t { par.Value }\t{ Math.Round(Fr/b,2) } \t  {Math.Round(Fa)} \t  {Math.Round(Fra,2)}");
            }

            Console.WriteLine();
            
            Console.WriteLine("MEDIANA :"+ CalcularMediana(datos) );
            
        }
        else{   
            Console.WriteLine(" --- DATOS NO AGRUPADOS --- ");
            double maxCount=0;
            double minCount; 
            for(int i = 0;i<datos.Count;i++)
            {
                if (i>datos.Count)
                {
                  maxCount=datos[i];
                }    
            }
            // DETERMINACION DEL RANGO MAX-MIN DATOS
            // K == CLASES 
            // CALCULAR EL INTERVALO I = R/K
            
            Console.WriteLine("| INTERVALOS | \t | Xi | \t | F | \t | Fr | \t | Fa | \t  ");
            Console.WriteLine("MEDIA : "+ "\t MEDIANA: " + "\t MODA: ");

        } 
    }  
    
    private static double CalcularMedia(List<double>datos ){
        double suma = 0;
        foreach (int dato in datos)
        {
            suma += dato;
        }
        return suma / datos.Count;
    }
    private static double CalcularMediana(List<double>datos){
        datos.Sort();
        int n = datos.Count; // 1 2 3 4 5 6 7 8 => 8
        int tmp= (n+1) / 2; //=> 4
        if(tmp % 2 == 0){
            return datos[tmp];
        }
        else{
            return datos[tmp-1]+datos[tmp];
        }
    } 
}   

public class Consultar{
    public static void serch(){

    }

}

public class main{
    
    public static void Main(string[] args){
        Console.WriteLine("Ingresa tú Nombre: ");
        string nomU = Console.ReadLine();
        TextWriter nombre ;
        nombre = new StreamWriter(nomU+".txt");  
          //falta almacenar la informacion en el archivo   
    
        do
        {
            Console.WriteLine("1.-Ingresar datos \n2.-Consultar movimiento de: " + (nomU) );
            int options=Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1 :
                ingresarDatos.addData();
                break;   
                case 2 :
                Consultar.serch();
                break;
            }

         } while (true);        
    }
}