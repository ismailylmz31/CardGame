using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartOyunuödevdeneme2
{
    class gamer
    {
        public string name; //İSİM VE KARTLARI TUTACAĞIMIZ LİSTE
        public List<string> cards = new List<string>();


        public gamer() //OYUNCU ADLARINI TUTAN FONKSİYON
        {
            this.name = null;
        }



        public gamer(string name)
        {
            this.name = name;

        }

        public Boolean İsCardExist(string input)
        {
            for (int i = 0; i < this.cards.Count; i++)
            {
                if (input == this.cards[i])
                {
                    return true;
                }
            }
            return false;
        } 
        public Boolean isFull()   // OYUNCULARA DAĞITILAN 6 KARTIN TAMAMININ DAĞITILIP DAĞITIMADIĞINI KONTROL EDİYOR
        {
            if (this.cards.Count == 6)
            {
                return true;
            }
            return false;
        }
        public Boolean isEmpty() // KAZANANI BELİRTMEK İÇİN OYUNCULARIN KART LİSTELERİNİN BOŞ OLUP OLMADIĞINI KONTROL EDEN FONKSİYON
        {
            if (this.cards.Count == 0)
            {
                Console.WriteLine("WİNNER  İS:{0}",this.name );
                return true;
            }
            return false;
        }




        public void show()   //KARTLARI GÖSTEREN FONKSİYON
        {
            Console.WriteLine("{0} CARDS: ",this.name);
            foreach (string item in cards)
            {
                
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public string LotColour()   // ELİMİZDE EN ÇOK HANGİ RENKTEN KART OLDUĞUNU BULMAYA YARAYAN FONKSİYON
        {


            int m = 0, k = 0, s = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].StartsWith("M"))    // HANGİSİNİN ÇOK OLDUĞUNU BULMAK İÇİN YUKARDA TANIMLANMIŞ SAYILARI ARTTIRIYOR
                {
                    m++;
                }
                else if (cards[i].StartsWith("K"))
                {
                    k++;
                }
                else if (cards[i].StartsWith("S"))
                {
                    s++;

                }


            }
            if (k >= m && k >= s)   //ÇOK OLAN KARTI DÖNDÜREN KOŞULLAR
            {
                return "K";
            }
            else if (m >= k && m >= s)
            {
                return "M";
            }
            else if (s >= m && s >= k)
            {
                return "S";
                
            }

            return "K";
        }


        public string givecard()  // KART ATMA FONKSİYONUMUZ
        {
            if (Program.opencard == "") //en çok bulunan kartı atar ortada kart yokkende elde bulunan en fazla aynı renkte kartı döndürür
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    if (cards[i].StartsWith(LotColour()))  //MAANTIKLI OLMASI İÇİN EN BİLGİSAYARIN KONTROL ETTİĞİ LİSTELERDEN EN ÇÇOK OLAN KARRTI  İLK ATMASI İÇİN KOŞUL 
                    {
                        string cd = cards[i];
                        cards.Remove(cards[i]);
                        return cd;
                    }
                }
            }
            else // yerdeki karta göre kart atma
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    if (Program.opencard.Substring(1,1) ==cards[i].Substring(1,1))  //OPEN CARD İLK DEFA GÖRÜNTÜLENMİYORSA ÖNCELİKLE SONDAKİ SAYILARA GÖRE KART ATTIRAN KOŞUL
                    {
                        string cd = cards[i];
                        cards.Remove(cards[i]);
                        return cd;
                    }
                   
                    
                }
                for (int i = 0; i < cards.Count; i++)
                {
                   
                    if (Program.opencard.Substring(0, 1) == cards[i].Substring(0, 1))
                    {
                        string cd = cards[i];
                        cards.Remove(cards[i]);
                        return cd;
                    }
                   

                }
                for (int i = 0; i < cards.Count; i++)
                {

                   
                    if(cards[i]=="RD")   //RENK DEĞİŞTİR KARTINI ÖNCEKİ KARTI VE YENİ SEÇİLEN RENKTEKİ KARTLARI GÖSTEREN KOŞULLAR
                    {
                        Console.WriteLine(this.name + "  Changed opencard " +Program.opencard + "  As " + LotColour() + Program.opencard.Substring(1, 1));
                        Program.opencard = LotColour() + Program.opencard.Substring(1, 1);
                        cards.Remove(cards[i]);
                        return Program.opencard;
                        
                    }

                }

                Console.WriteLine("PAS GEÇİLDİ");
            }
            return Program.opencard;
        }
        
        
    }
}
