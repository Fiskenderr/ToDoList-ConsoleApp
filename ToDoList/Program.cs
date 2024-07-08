using System;
using System.Reflection.Metadata.Ecma335;

namespace ToDoList
{
    class Program
    {
        static List<string> todolist = new List<string>();
        static List<bool> iscompleted = new List<bool>();
        static void Main(string[] args)
        {
            int islem;

            Console.WriteLine("To-Do List");
            Console.WriteLine("----------------------------");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Yapilacak islemi seciniz: ");
                Console.WriteLine("[1] - Listeye ekleme");
                Console.WriteLine("[2] - Listeyi görme");
                Console.WriteLine("[3] - Tamamlanmis olarak isaretleme");
                Console.WriteLine("[4] - Listeden cikarma");
                Console.WriteLine("[5] - Cikis");
                Console.Write("Seciminiz: ");
                islem = Convert.ToInt32(Console.ReadLine());
                if (islem < 1 || islem > 5)
                {
                    Console.WriteLine("Yanlis secim yaptiniz!");
                    Console.ReadKey();
                    continue;
                } 

                switch (islem)
                {
                    case 1:
                        ekle();
                        break;
                    case 2:
                        listele();
                        break;
                    case 3:
                        isaretle();
                        break;
                    case 4:
                        cikar();
                        break;
                    case 5:
                        return;
                }
            }
        }

        static void ekle()
        {
            Console.Write("Eklenecek olan isi giriniz: ");
            string a = Console.ReadLine();
            todolist.Add(a);
            iscompleted.Add(false);
            Console.WriteLine("Ekleme islemi basarili! Devam etmek icin bir tusa basiniz...");
            Console.ReadKey();
        }

        static void listele()
        {
            Console.WriteLine("Yapilacak Isler: ");
            for (int i = 0; i < todolist.Count; i++)
            {
                string durum = iscompleted[i] ? "[Tamamlandi]" : "[Yapilacak]";
                Console.WriteLine($"{i+1} - {todolist[i]} - {durum}");
            }
            Console.WriteLine("Listeleme islemi tamamlandi! Devam etmek icin bir tusa basiniz...");
            Console.ReadKey();
        }

        static void isaretle()
        {
            Console.Write("Tamamlandi olarak isaretlenecek islemin numarasi: ");
            if(!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > todolist.Count)
            {
                Console.WriteLine("Hatali giris yaptiniz!");
                Console.ReadKey();
                return;
            }
           
            iscompleted[index-1] = true;
            Console.WriteLine("Tamamlandi olarak isaretleme islemi basarili! Devam etmek icin bir tusa basiniz...");
            Console.ReadKey();
        }

        static void cikar()
        {
            Console.Write("Cikarilacak olan islemin numarasi: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > todolist.Count)
            {
                Console.WriteLine("Yanlis numara girisi yaptiniz!");
                Console.ReadKey(); 
                return;
            }
            
            todolist.RemoveAt(index - 1);
            iscompleted.RemoveAt(index - 1);
            Console.WriteLine("Cikarma islemi basarili! Devam etmek icin bir tusa basiniz...");
            Console.ReadKey();
        }
    }
}