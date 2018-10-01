namespace NorthWNDSuppliersV2
{
    using NorthWNDSuppliers_DAL.Models;
    using NorthWNDSuppliersV2.Models;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Threading;
    using System.Reflection;
    using System.IO;

    class Program
    {
        private static readonly string filePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        private static readonly string logsPath = filePath + @"\Log Files\Error Log.txt";

        private readonly static string connectionString = ConfigurationManager.ConnectionStrings["dataSource"].ConnectionString;

        private static void ViewSuppliers(SupplierPO supplier)
        {
            Console.WriteLine("Supplier ID : {0}", supplier.SupplierID);
            Console.WriteLine("CompanyName : {0}", supplier.CompanyName);
            Console.WriteLine("ContactName : {0}", supplier.ContactName);
            Console.WriteLine("ContactTitle: {0}", supplier.ContactTitle);
            Console.WriteLine("Address     : {0}", supplier.Address);
            Console.WriteLine("City        : {0}", supplier.City);
            Console.WriteLine("Region      : {0}", supplier.Region);
            Console.WriteLine("PostalCode  : {0}", supplier.PostalCode);
            Console.WriteLine("Country     : {0}", supplier.Country);
            Console.WriteLine("Phone       : {0}", supplier.Phone);
            Console.WriteLine("Fax         : {0}", supplier.Fax);
            Console.WriteLine("HomePage    : {0}", supplier.HomePage);
            Console.WriteLine();

        }

        private static SupplierPO ObtainUpdatedInformation(SupplierPO supplierInfo)
        {
            int menuChoice = 0;
            bool exit = true;
            bool wrongNum = false;
            do
            {
                if (wrongNum)
                {
                    Console.WriteLine("\nInput number 1-5:");
                    wrongNum = false;
                }
                menuChoice = GetIntInput("What would you like to change?" +
                     "\n\t1) CompanyName" +
                     "\n\t2) ContactName" +
                     "\n\t3) ContactTitle" +
                     "\n\t4) Address" +
                     "\n\t5) City" +
                     "\n\t6) Region" +
                     "\n\t7) PostalCode" +
                     "\n\t8) Country" +
                     "\n\t9) Phone" +
                     "\n\t10) Fax" +
                     "\n\t11) HomePage" +
                     "\n\t12) Exit");

                switch (menuChoice)
                {
                    case 1:
                        Console.Write("Company name was: {0}\nPlease enter a new Company Name: ", supplierInfo.CompanyName);
                        supplierInfo.CompanyName = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Company Contact Name was: {0}\nPlease enter a new Contact Name: ", supplierInfo.ContactName);
                        supplierInfo.ContactName = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Company Contact Title was: {0}\nPlease enter a new Contact Title: ", supplierInfo.ContactTitle);
                        supplierInfo.ContactTitle = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Company Address was: {0}\nPlease enter a new Address: ", supplierInfo.Address);
                        supplierInfo.Address = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("City was: {0}\nPlease enter a new City: ", supplierInfo.City);
                        supplierInfo.City = Console.ReadLine();
                        break;
                    case 6:
                        Console.Write("Company Region was: {0}\nPlease enter a new Region: ", supplierInfo.Region);
                        supplierInfo.Region = Console.ReadLine();
                        break;
                    case 7:
                        Console.Write("Company Postal Code was: {0}\nPlease enter a new Postal Code: ", supplierInfo.PostalCode);
                        supplierInfo.PostalCode = Console.ReadLine();
                        break;
                    case 8:
                        Console.Write("Company Country Location was: {0}\nPlease enter a new Country: ", supplierInfo.Country);
                        supplierInfo.Country = Console.ReadLine();
                        break;
                    case 9:
                        Console.Write("Company Phone was: {0}\nPlease enter a new Phone number: ", supplierInfo.Phone);
                        supplierInfo.Phone = Console.ReadLine();
                        break;
                    case 10:
                        Console.Write("Company Fax was: {0}\nPlease enter a new Fax number: ", supplierInfo.Fax);
                        supplierInfo.Fax = Console.ReadLine();
                        break;
                    case 11:
                        Console.Write("Company Home Page was: {0}\nPlease enter a new Home Page: ", supplierInfo.HomePage);
                        supplierInfo.HomePage = Console.ReadLine();
                        break;
                    case 12:
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        wrongNum = true;
                        break;
                }

                exit = true;
                menuChoice = GetIntInput("Would you like to change another property?" +
                    "\n\t1) Yes" +
                    "\n\t2) No");
                if (menuChoice == 1)
                    exit = false;

            } while (!exit);

            return supplierInfo;
        }

        private static SupplierPO ObtainNewSupplierInfo()
        {
            SupplierPO supplierInfo = new SupplierPO();

            Console.WriteLine("Creating New Supplier, please enter the following information.");
            Console.Write("Enter Company name: ");
            supplierInfo.CompanyName = Console.ReadLine();

            Console.Write("Enter Company Contact Name: ");
            supplierInfo.ContactName = Console.ReadLine();

            Console.Write("Enter Company Contact Title: ");
            supplierInfo.ContactTitle = Console.ReadLine();

            Console.Write("Enter Company Address: ");
            supplierInfo.Address = Console.ReadLine();

            Console.Write("Enter City: ");
            supplierInfo.City = Console.ReadLine();

            Console.Write("Enter Company Region: ");
            supplierInfo.Region = Console.ReadLine();

            Console.Write("Enter Company Postal Code: ");
            supplierInfo.PostalCode = Console.ReadLine();

            Console.Write("Enter Company Country Location: ");
            supplierInfo.Country = Console.ReadLine();

            Console.Write("Enter Company Phone: ");
            supplierInfo.Phone = Console.ReadLine();

            Console.Write("Enter Company Fax: ");
            supplierInfo.Fax = Console.ReadLine();

            Console.Write("Enter Company Home Page: ");
            supplierInfo.HomePage = Console.ReadLine();

            return supplierInfo;
        }

        private static int GetIntInput(string message)
        {
            int input = 0;
            bool valid = true;

            do
            {
                Console.WriteLine(message);
                valid = int.TryParse(Console.ReadLine(), out input);
            } while (!valid);

            return input;
        }

        static void Main(string[] args)
        {
            try
            {
                SupplierDAO dao = new SupplierDAO(connectionString, logsPath);

                Console.BufferHeight = 500;
                Console.WindowHeight = 30;

                bool exit = false;

                do
                {
                    bool wrongNum = false;
                    int ID = 0;
                    int rowsAffected;

                    Console.WriteLine("We are in the Supplier table of NORTHWIND. \nWould you like to: \n\t" +
                        "1) View all suppliers.\n\t" +
                        "2) Update an existing supplier information.\n\t" +
                        "3) Create a new supplier.\n\t" +
                        "4) Delete a supplier.\n\t" +
                        "5) Exit this program.");

                    //Ask to put 1-5, if not.
                    if (wrongNum)
                    {
                        Console.WriteLine("\nInput number 1-5:");
                        wrongNum = false;
                    }

                    int menuChoice = GetIntInput("Please enter a number between 1 and 5");
                    switch (menuChoice)
                    {
                        case 1:
                            //view all suppliers
                            List<SupplierDO> supInfoDO = dao.ObtainTableInfo();

                            List<SupplierPO> supplierInfo = Mapper.DOListToPOList(supInfoDO);

                            for (int i = 0; i < supplierInfo.Count; i++)
                            {
                                ViewSuppliers(supplierInfo[i]);
                            }

                            Console.WriteLine("Press any key to return to menu...");
                            Console.ReadKey();
                            break;
                        case 2:
                            //Update supplier
                            ID = GetIntInput("Input supplier ID");
                            Console.Clear();
                            //obtains single supplier based on id
                            SupplierDO suppDO = dao.ObtainSupplierSingle(ID);
                            //converts supplier to Presentation layer object
                            SupplierPO suppPO = Mapper.SupplierDOtoSupplierPO(suppDO);
                            //checks to see if the supplier exists, cannot have an id of 0 in the DB
                            if (suppPO.SupplierID != 0)
                            {
                                ViewSuppliers(suppPO);

                                suppPO = ObtainUpdatedInformation(suppPO);
                                suppDO = Mapper.SupplierPOtoSupplierDO(suppPO);
                                dao.UpdateInformation(suppDO);
                                Console.Clear();
                            }
                            //If Supplier does not exist this will be displayed
                            else
                            {
                                Console.WriteLine("The provided Supplier ID does not exist.\n" +
                                    "If you would like to create a new Supplier please select menu option 3.\n\n");
                            }

                            break;
                        case 3:
                            //Create New Supplier
                            Console.Clear();
                            //Obtains supplier table
                            SupplierPO newSupplier = ObtainNewSupplierInfo();
                            //converts from a Data layer Object to a presentation layer object
                            SupplierDO newDOSupplier = Mapper.SupplierPOtoSupplierDO(newSupplier);
                            //checks to see if supplier was added
                            rowsAffected = dao.CreateNewSupplier(newDOSupplier);
                            Console.Clear();
                            //if no rows affected, supplier was not added, print the following
                            if (rowsAffected == 0)
                            {
                                Console.WriteLine("Failed to create new Supplier.\n\n");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("New supplier has been created.\n\n");
                                Console.ResetColor();
                                Console.WriteLine("Press any key to Return to menu...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 4:
                            //Delete Supplier
                            ID = GetIntInput("Input supplier ID");
                            Console.Clear();

                            Console.WriteLine("\nThis row will be deleted: ");
                            suppDO = dao.ObtainSupplierSingle(ID);
                            SupplierPO suppPo = Mapper.SupplierDOtoSupplierPO(suppDO);
                            ViewSuppliers(suppPo);
                            if (GetIntInput("\nAre you sure you wish to delete this supplier?\n1) Yes 2)No") == 1)
                            {
                                //checks to see if the indicated supplier was deleted
                                rowsAffected = dao.DeleteSupplier(ID);
                                //prints failure or success message
                                if (rowsAffected == 0)
                                {
                                    Console.WriteLine("Failed to Delete Supplier.\n\n");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Supplier Deleted\n\n");
                                    Console.ResetColor();
                                }
                            }
                            Console.Clear();
                            break;
                        case 5:
                            exit = true;
                            break;
                        default:
                            Console.Clear();
                            wrongNum = true;
                            break;
                    }
                } while (exit == false);
            }
            catch (SqlException sqlEx)
            {
                Logger.errorLogPath= logsPath;
                Logger.ExceptionMessage(sqlEx);

                if (!(sqlEx.Data.Contains("Logged")&&(bool)sqlEx.Data["Logged"]==true))
                {
                    Logger.SqlExceptionLog(sqlEx);
                }

                Console.WriteLine("\npress any key to close");
                Console.ReadKey();
            }
            catch (Exception exception)
            {
                Logger.errorLogPath = logsPath;
                Logger.ExceptionMessage(exception);

                if (!(exception.Data.Contains("Logged") && (bool)exception.Data["Logged"] == true))
                {
                    Logger.ExceptionLog(exception, "");
                }

                Console.WriteLine("\npress any key to close");
                Console.ReadKey();
            }
            finally
            {
                Console.Write("Closing Program...");
                Thread.Sleep(2500);
            }
        }
    }
}
