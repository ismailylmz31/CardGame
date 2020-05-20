using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunuödevdeneme2
{
    class Program
    {
       public static Boolean İsCardOkey(string input)
        {
            if (input.Length !=2)
            {
                Console.WriteLine("Wrong İnput pick your card from cardlist!! ");
                return false;

            }
           else if (!(input.StartsWith("K")) && !(input.StartsWith("M")) && !(input.StartsWith("S")) && !(input.StartsWith("R")))
            {
                Console.WriteLine("Wrong İnput pick your card from cardlist!! ");
                return false;
            }
            else if (!(input.EndsWith("1")) && !(input.EndsWith("2")) && !(input.EndsWith("3")) && !(input.EndsWith("4")) && !(input.EndsWith("5")) && !(input.EndsWith("D")) )
            {
                Console.WriteLine("Wrong İnput pick your card from cardlist!! ");
                return false;
            }
            else if (opencard != ""&& input != "RD"&&input.Substring(0,1) != opencard.Substring(0,1) && input.Substring(1,1) !=opencard.Substring(1,1)  )
            {
                Console.WriteLine("Wrong İnput pick your card from cardlist!! ");
                return false;
            }
            return true;
        }
        public static string opencard = "";  //YERDEKİ KARTI GÖSTEREBİLMEMİZ İÇİN YAZILMIŞ STATİK FONKSİYON YERDEKİ KARTI VERİR
        static void Main(string[] args)
        {
           
            string[] card =
            {"K1","K2", "K3", "K4", "K5", "M1", "M2", "M3", "M4", "M5", "S1", "S2", "S3", "S4", "S5", "RD", "RD", "RD"}; //KART ARRAYİ
            List<string> card2 = new List<string>();
            for (int i = 0; i < 18; i++)
            {
                card2.Add(card[i]);    //ARRAYDAKİ KARTLARI LİSTE ATAN DÖNGÜ
            }
            Random random = new Random();
            gamer Gamer1 = new gamer("gamer1");      // OYUNCU LİSTELERİ İÇİN PARAMETRELER
            gamer Gamer2 = new gamer("gamer2");
            gamer Gamer3 = new gamer("gamer3");
            List<gamer> GamerList = new List<gamer>();
            GamerList.Add(Gamer1);       //OYUNCU LİSTELERİNE EKLENEN OYUNCULAR
            GamerList.Add(Gamer2);
            GamerList.Add(Gamer3);
            
            foreach (gamer Gamer in GamerList)
            {
                for (int i = 0; i <6 ; i++)
                {
                    int r = random.Next(0, card2.Count);    //OYUNCULARA RASTGELE 6 KART ATAN DÖNGÜ ÜST FOREACH DÖNGÜSÜ GAMERLERİ SIRALIYOR İÇ FOR DÖNGÜSÜ KARTLARI DAĞITIYOR
                    Gamer.cards.Add(card2[r]);
                    card2.Remove(card2[r]);
                }
                
            }
            
            Gamer3.show();
            Console.WriteLine();     //BİZDEKİ KARTLARI GÖSTEREN KODLAR
            int a = random.Next(0,3);
            
            if (a==0) //
            {
                Console.WriteLine("open lap/ turn gamer1:");  //AÇILIŞ TURUNDA KİMİN BAŞŞLAYACAĞINA KARAR VEREN RANDOM KOŞULLARI
                opencard = Gamer1.givecard();
            }
            else if (a==1)
            {
                Console.WriteLine("open lap/ turn gamer2:");
                opencard = Gamer2.givecard();
            }
            else
            {
                Console.WriteLine("open lap/ turn gamer3:");
                string input = "-1";
                while (opencard != input)
                {
                    Console.WriteLine("Please select your cards:(First card cant be 'RD' ) (Forexample: M5 /S4 /K3) ");    
                   input = Console.ReadLine();
                    if (input != "RD" &&Program.İsCardOkey(input))
                    {
                        for (int i = 0; i < Gamer3.cards.Count; i++)
                        {

                            if (Gamer3.cards[i] == input) // GAMER 3 BİZİZ BİZ GİRİŞ YAPARAK OYNUYORUZ ,YERE ATTIĞIMIZ KARTI DA LİSTEDEN SİLEN KOŞUL
                            {
                                opencard = input;
                                Gamer3.cards.Remove(input);
                                break;

                            }

                        }
                    }

                }
                
            }
            Console.WriteLine("open card: {0}",opencard);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("---------------------------------------------------------");
            int draw = 0;
            string oldopencard = opencard;
            while (true)//system exit kodu burda
            {
                if (draw>=3)
                {
                    
                    Console.WriteLine("Result :Draw");
                    break;
                    
                }
                Gamer3.show();
                Console.WriteLine("Old open card is: "+opencard); //BİZİM DİĞER TURLARI OYNAMAMIZ İÇİN GİRİŞ ALAN WHİLE DÖNGÜSÜ
                a++; 
                if (a>2) //OYUNCULARIN SIRAYLA OYNAMASINI SAĞLAYAN KOŞUL
                {
                    a = 0;
                }
                if (Gamer1.isEmpty() || Gamer2.isEmpty() || Gamer3.isEmpty()) //EĞER BİRİNDE KART BİTERSE KAZANIR  BU KOŞUL SAĞLANIRSA OYUN BİTER
                {
                    break;
                }
                
                if (a==2) //SIRANIN BİZE GELDİĞİNİ BİLDİREN KOŞUL
                {
                    Console.WriteLine("Your turn gamer3:");

                    string input = "-1";
                    while (opencard != input)
                    {
                        Console.WriteLine("Please  select your cards: (Forexample: K3 /M5 /S2) ");
                        input = Console.ReadLine();
                        if (input =="PAS" ) // EĞER ELİMİZDE YERE ATACAK DOĞRU KART YOKSA PPAS GEÇMEE KOŞULUMUZ
                        {
                            break;
                        }

                        if (input == opencard&&GamerList[a].İsCardExist(input)==false)
                        {
                            input = "-1";
                            continue;
                        }
                        
                        
                        if (Program.İsCardOkey(input))
                        {
                            for (int i = 0; i < Gamer3.cards.Count; i++)
                            {

                                if (Gamer3.cards[i] == input) //GİRİŞ YAPTIĞIMIZ KART KOŞULU
                                {
                                    if (input == "RD") // GİRDİĞİMİZ KART RD KARTIYSA YENİ RENK SEÇMEMİZE YARAYAAN KOŞUL
                                    {
                                        Console.WriteLine("Please choose new colour: (Forexample: K / S / M)  ");
                                        string input2 = Console.ReadLine();
                                        while (true)
                                        {
                                            if (input2 =="K" || input2 == "S" || input2 == "M")
                                            {
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("chosen colour did not found!!");
                                                Console.WriteLine("Please choose new colour: (Forexample: K / S / M)  ");
                                                input2 = Console.ReadLine();
                                            }
                                        }
                                        opencard = input2 + opencard.Substring(1, 1);
                                        input = opencard;
                                        Console.WriteLine("RD card is used now:");
                                        Gamer3.cards.Remove(Gamer3.cards[i]);
                                        break;
                                    }
                                    opencard = input; //EĞER GİRİLEN KART RD DEĞİLSE  SEÇTİĞİMİZ KARTI YENİ YERDEKİ KART YAPAR YERE ATTIĞIMIZ KARTI LİSTEMİZDDEN SİLER
                                    Gamer3.cards.Remove(input);
                                    Console.WriteLine("open card: {0}", opencard);
                                    break;  // EĞER GİRİŞ YAPTIYSAK  VE GİRİŞ KABUL EDİLMİŞSE TEKRAR TEKRAR GİRİŞ İSTEMEMESİ İÇİN BİZİ DÖNGÜDEN ÇIKARIR

                                }

                            }
                        }
                        else
                        {
                            continue;
                        }

                    }

                }
                else
                {
                   Console.WriteLine("Your turn: "+GamerList[a].name); //SIRA BİZDE OLMAYINCA SIRANIN KİMDE OLDUĞUNU GÖSTEREN VE O AN OYUNU OYNAYAN KULLANICININ KARTLARINI GÖSTEREN KODLAR
                  // GamerList[a].show();
                    
                    opencard = GamerList[a].givecard();
                    Console.WriteLine("open card: {0}", opencard);
                }
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");

                if (oldopencard==opencard)
                {
                    draw++;
                }
            }


            Console.WriteLine("GAME FİNİSHED");
            Console.ReadLine();

        }
    }
}
