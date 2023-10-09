using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Transactions;
using System.Xml;

namespace TodoApp
{
    internal class Program
    {

       static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "todo.txt");



        // Object list
        static List<string> todoList = new List<string>();
       
        

        



        




        static void Main(string[] args)
        {

            







            //herhangi bir işlem bittiğinde konsolu temizle
            Console.Clear();

            //txt dosyasını listeye yükle
            LoadData();

           

            




            //döngü boyunca

            while (true)
            {


            

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("--- todo application ---");

                Console.ResetColor();

                Console.WriteLine("enter the process number");



                string option1 = "1. View Tasks";
                string option2 = "2. Delete Task";
                string option3 = "3. Add Task";
                string option4 = "4. Mark As Completed";
                string option5 = "5. Exit";














                RenkliYaz(option1);
                RenkliYaz(option2);
                RenkliYaz(option3);
                RenkliYaz(option4);
                RenkliYaz(option5);

                string secim = Console.ReadLine();





                switch (secim)
                {
                    case "1":
                        ViewTasks();
                        break;

                    case "2":
                        DeleteTask();
                        break;

                    case "3":
                        AddTask();
                        break;
                    case "4":
                        MarkAsCompleted();
                        break;
                    case "5":
                        SaveData();
                        return;
                    defalt:
                        Console.WriteLine("yanlış numara");
                        break;
                       
                }




            }





























            static void RenkliYaz(string yazi)
            {
               for (int i = 0; i < yazi.Length; i++)
                {
                    if (i < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;

                    }
                    else
                    {
                        Console.ResetColor();
                    }


                    Console.Write(yazi[i]);
                }
                Console.WriteLine("");
            }



             //View Task

            static void ViewTasks()
            {
                Console.Clear();



                if (IsListEmpty(todoList))
                {
                    Console.WriteLine("Your list is empty");
                    Console.WriteLine("\n\n\n\n\n\n");
                }

              


                for (int i= 0; i < todoList.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {todoList[i]}");
                    Console.WriteLine("\n\n\n\n\n\n");
                }



            }





             //Delete Task
             
            static void DeleteTask()
            {
                ViewTasks();
                Console.WriteLine("enter id of the note you want to delete");

                int silme = int.Parse(Console.ReadLine());


                if (silme >= 1 && silme <= todoList.Count)
                {
                    todoList.RemoveAt(silme - 1);
                    Console.WriteLine("başarıyla silindi");
                }
                else
                {
                    Console.WriteLine("Invalid number. ");
                }

                ViewTasks();




                    
                    
              }



             // Add new Task
             
            static void AddTask()
            {
                ViewTasks();

                Console.WriteLine("Enter the note you want to add to list");


                string newNote = Console.ReadLine();


                todoList.Add(newNote);

                Console.WriteLine("notunuz eklendi");

                ViewTasks();
            }




            // Mark As completed
          static void MarkAsCompleted()
            {

                Console.Clear();

                ViewTasks();
                
                Console.WriteLine("Tamamlandı olarak işaretlemek istediğiniz notun numarasını giriniz");

                                 
                int taskNumber = int.Parse(Console.ReadLine()) -1;

                if (todoList[taskNumber].Contains("(Completed)"))
                {
                    Console.WriteLine("hatalı yazı");
                    Console.Clear();
                    return;
                    
                }


                if (taskNumber >= 0 && taskNumber <= todoList.Count)
                {

                    todoList[taskNumber] += "(Completed)";

                    
                    ViewTasks();
                    Console.WriteLine("\n Task marked as completed \n\n");

                }
                else
                {
                    Console.WriteLine("\nInvalid task number");
                }





           
            }


        }



        //listin boş olup olmamasını kontrol et
        static bool IsListEmpty<T>(List<T> list)
        {
            return list.Count == 0;
        }




        // list'i txt dosyasına kaydet
        static void SaveData()
        {
            File.WriteAllLines(filePath,todoList);
        }






        //txt dosyasındaki değerleri liste aktar.
        static void LoadData()
        {
            if (File.Exists(filePath))
            {
                todoList = new List<string>(File.ReadAllLines(filePath));
            }
        }


    }
}