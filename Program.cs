using System;

class SistemaCalificacionesUniv
{
    static void Main()
    {
        int numEstudiantes, numMaterias;
        double notaMinima = 70;
        double suma;

        //Prueba
        do
        {
            Console.Write("Ingrese cantidad de estudiantes: ");
            numEstudiantes = Convert.ToInt32(Console.ReadLine());
        } while (numEstudiantes <= 0);

        
        do
        {
            Console.Write("Ingrese cantidad de materias: ");
            numMaterias = Convert.ToInt32(Console.ReadLine());
        } while (numMaterias <= 0);

        
        string[] nombres = new string[numEstudiantes];
        string[] matriculas = new string[numEstudiantes];
        double[,] notas = new double[numEstudiantes, numMaterias];
        double[] promedios = new double[numEstudiantes];
        string[] estados = new string[numEstudiantes];

        
        for (int i = 0; i < numEstudiantes; i++)
        {
            Console.Write($"Ingrese nombre del estudiante {i + 1}: ");
            nombres[i] = Console.ReadLine();
            Console.Write("Ingrese matrícula: ");
            matriculas[i] = Console.ReadLine();
        }

        
        for (int i = 0; i < numEstudiantes; i++)
        {
            Console.WriteLine($"\nIngrese notas para {nombres[i]}:");
            for (int j = 0; j < numMaterias; j++)
            {
                do
                {
                    Console.Write($"Nota materia {j + 1} (0-100): ");
                    notas[i, j] = Convert.ToDouble(Console.ReadLine());
                } while (notas[i, j] < 0 || notas[i, j] > 100);
            }
        }

        
        for (int i = 0; i < numEstudiantes; i++)
        {
            promedios[i] = CalcularPromedio(notas, i, numMaterias);
            estados[i] = VerificarEstado(promedios[i], notaMinima);
        }

        
        Console.WriteLine("\n=== REPORTE DE CALIFICACIONES ===");
        for (int i = 0; i < numEstudiantes; i++)
        {
            Console.WriteLine($"Estudiante {i + 1}: {nombres[i]}");
            Console.WriteLine($"Matrícula: {matriculas[i]}");
            Console.WriteLine("Notas:");

            for (int j = 0; j < numMaterias; j++)
            {
                Console.WriteLine($"  - Materia {j + 1}: {notas[i, j]}");
            }

            Console.WriteLine($"Promedio: {promedios[i]:F2}");
            Console.WriteLine($"Estado: {estados[i]}");
            Console.WriteLine("-----------------------------");
        }
    }

    static double CalcularPromedio(double[,] notas, int estudiante, int cantidadMaterias)
    {
        double suma = 0;
        for (int j = 0; j < cantidadMaterias; j++)
        {
            suma += notas[estudiante, j];
        }
        return suma / cantidadMaterias;
    }

    static string VerificarEstado(double promedio, double notaMin)
    {
        return promedio >= notaMin ? "APROBADO" : "REPROBADO";
    }
}