using System;
using System.IO;

namespace DocumentMerger2
{
    class Program
    {
        static void Main(string[] args)
        {
            int count=0;
            String abc ="";
            String newMerge = "Yes";

            Console.WriteLine("Welcome to the Document Merger!\n");

            while (newMerge=="Yes")
            {
                if (args.Length<3)
                {
                    Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2> ... <input_file_n> <output_file>");
                    Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as command line arguments");
                }
                else
                {
                    count = args.Length;
                    for (int i=0;i<args.Length-1;i++)
                    {
                        Console.WriteLine("Please enter a file name to be merged: " +args[i]);
                        while (!File.Exists(args[i]))
                        {
                            Console.WriteLine(args[i]+" does not exist! Please enter a valid file: ");
                            Console.ReadLine();
                        }
                        try
                        {
                        abc += System.IO.File.ReadAllText(args[i]);
                        }
                        catch (Exception ex)
                        { 
                            Console.WriteLine(ex); 
                        }
                    }
                    try
                    {
                        using(StreamWriter xyz = new StreamWriter(args[count-1]))
                        {
                            xyz.WriteLine(abc);
                        }
                    }
                    catch (Exception ex)
                    { 
                        Console.WriteLine(ex); 
                    }

                    Console.WriteLine("\nYour merged file has successfully been created.");
                    Console.ReadLine();
                    
                    Console.WriteLine("Would you like to merge two more documents? If so type 'Yes'");
                    newMerge=Console.ReadLine();
                }
            }
        }
    }
}