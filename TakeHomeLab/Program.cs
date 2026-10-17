using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManager
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PropertyAsset> assets = new List<PropertyAsset>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("==============================================================");
                Console.WriteLine("           URBAN PARCEL & BUILDING ASSET MANAGER             ");
                Console.WriteLine("==============================================================");
                Console.WriteLine("1. Add Residential Lot");
                Console.WriteLine("2. Add Circular Storage Depot");
                Console.WriteLine("3. Add Triangular Park");
                Console.WriteLine("4. View All Assets & Total Tax");
                Console.WriteLine("5. Exit");
                Console.WriteLine("==============================================================");
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Property Code: ");
                        string resCode = Console.ReadLine();
                        Console.Write("Enter Tax Rate Per Unit Area: ");
                        double resTax = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Frontage: ");
                        double frontage = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Depth: ");
                        double depth = Convert.ToDouble(Console.ReadLine());
                        assets.Add(new ResidentialLot(resCode, resTax, frontage, depth));
                        Console.WriteLine("\n[Success] Residential Lot added!\n");
                        break;

                    case "2":
                        Console.Write("Enter Property Code: ");
                        string depCode = Console.ReadLine();
                        Console.Write("Enter Tax Rate Per Unit Area: ");
                        double depTax = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Radius: ");
                        double radius = Convert.ToDouble(Console.ReadLine());

                        assets.Add(new CircularStorageDepot(depCode, depTax, radius));
                        Console.WriteLine("\n[Success] Circular Storage Depot added!\n");
                        break;

                    case "3":
                        Console.Write("Enter Property Code: ");
                        string parkCode = Console.ReadLine();
                        Console.Write("Enter Tax Rate Per Unit Area: ");
                        double parkTax = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Base Span: ");
                        double baseSpan = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Height: ");
                        double height = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Side 1: ");
                        double s1 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Side 2: ");
                        double s2 = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Enter Side 3: ");
                        double s3 = Convert.ToDouble(Console.ReadLine());

                        assets.Add(new TriangularPark(parkCode, parkTax, baseSpan, height, s1, s2, s3));
                        Console.WriteLine("\n[Success] Triangular Park added!\n");
                        break;

                    case "4":
                        Console.WriteLine("==============================================================");
                        Console.WriteLine("                   REGISTERED ASSET REPORT                   ");
                        Console.WriteLine("==============================================================");

                        if (assets.Count == 0)
                        {
                            Console.WriteLine("No assets recorded yet.\n");
                        }
                        else
                        {
                            double totalCombinedTax = 0.0;

                            foreach (PropertyAsset asset in assets)
                            {
                                double area = asset.ComputeFootprintArea();
                                double perimeter = asset.ComputeEnclosurePerimeter();
                                double tax = asset.ComputeEstimatedTax();

                                Console.WriteLine($"Code: {asset.PropertyCode,-10} | Area: {area,8:F2} | Perimeter: {perimeter,8:F2} | Tax: ${tax,8:F2}");
                                totalCombinedTax += tax; 
                            }

                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine($"TOTAL COMBINED TAX: ${totalCombinedTax,35:F2}");
                            Console.WriteLine("==============================================================\n");
                        }
                        break;
                        

                    case "5":
                        running = false;
                        Console.WriteLine("Exiting program. Goodbye!");
                        break;
                       
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.\n");
                        break;

                        
                        


                }
            }
        }

        private static double isValidInput()
        {
            double _input = 0;
            bool isValid = false;

            while (!isValid)
            {
                string input = Console.ReadLine() ?? string.Empty;

                Console.ForegroundColor = ConsoleColor.Red;
                if (!string.IsNullOrEmpty(input))
                {
                    if (!double.TryParse(input, out _input) || _input <= 0)
                    {
                        Console.WriteLine("Input should not be 0 and below.");
                        isValid = false;
                    }
                    else
                    {
                        isValid = true;
                    }

                }
                else
                {
                    Console.WriteLine("Input should not be empty.");
                    isValid = false;
                }
                Console.ResetColor();

                if (isValid)
                    break;
                Console.Write(" > ");
            }
            return _input;
        }
    }
}

