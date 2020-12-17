using System;

namespace ParallelPrograming.MpiDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            MPI.Environment.Run(ref args, comm =>
            {
                if (comm.Size < 2)
                {
                    Console.WriteLine("The Ring example must be run with at least two processes.");
                    Console.WriteLine("mpiexec -n 8 .\\ParallelPrograming.MpiDotNet.exe");
                }
                else if (comm.Rank == 0)
                {
                    string data = "Main Process with rank 0";
                    comm.Send(data, (comm.Rank + 1) % comm.Size, 0);
                    comm.Receive((comm.Rank + comm.Size - 1) % comm.Size, 0, out data);
                    data += " 0";
                    Console.WriteLine(data);
                }
                else
                {
                    String data;
                    comm.Receive((comm.Rank + comm.Size - 1) % comm.Size, 0, out data);
                    data = data + " " + comm.Rank.ToString() + ",";
                    comm.Send(data, (comm.Rank + 1) % comm.Size, 0);
                }
            });
        }

    }
}

// TODO List
// Tworzymy ziarno i wysyłamy do wszystkich elementów, wraz z rozmiarami ile ma zawierać chunk
// elementy są zainicjalizowane
// ITERACJE - processy
// każdy proces ma własne dane, na których wykonuje obliczenia
// na koniec iteracji wysyła do 0 wszystkie komórki które się zmieniły z obrzeża 
// ITERACJE SERWER 
// oblicza wszystkie elementy na obrzerzach
// odbiera wszystkie dane, 
// wysyła wszystkim dane zmienione

