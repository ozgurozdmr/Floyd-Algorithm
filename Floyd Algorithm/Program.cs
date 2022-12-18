using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloydWarshall
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //Console.WriteLine("---Floyd algoritmasını kullanan parogram için uyulması gereken kurallar---\n");
            //Console.WriteLine("1_) Her hangi iki düğüm arasındaki en kısa mesafesi bulunmak istenen Graf matrise dönüştürülür.\n");
            //Console.WriteLine("2_) Düğümlerin kendilerine uzaklıkları olmadığı için '0' olarak matriste gösterilmeli.\n");
            //Console.WriteLine("3_) Matristki iki düğüm arasında doğrudan bağlantı yoksa sonsuz kabul edilir ve bu değeri kullanıcı kendi belirler.\n");
            //Console.WriteLine("4_) İşlemlerde kolaylık olsun diye düğüm isimleri pozitif tam sayı olarak kullanıldı, graftaki düğümlerinizi buna göre isimlendiriniz.\n");
            //Console.WriteLine("Grafın matri gösterimindeki değerleri doğru şekilde ve eksiksiz girilmelidir aksi taktirde progran yanlış değer üretir.\n");
            //Console.WriteLine("________________________________________________________________________________\n\n");

            //Console.Write("Grafınızda bulunan düğüm sayısını doğru bir şekilde giriniz= ");
            //N = Convert.ToInt32(Console.ReadLine());

            //Console.Write("Graf üzerinde sonsuz değer tanımı değerini gir= ");
            //sonsuz = Convert.ToInt32(Console.ReadLine());

            //int[,] D = new int[N, N]; // İki boyutlu 'D' matrisini tutan dizi.
            #endregion
            int N = 5;
            int sonsuz = 11;
            int K = 0;
            int INF = 999999;


            int[,] D = { { 0,3,8,INF,-4},
                         { INF,0,INF,1,7},
                         { INF,4,0,INF,INF},
                         { 2,INF,-5,0,INF},
                         { INF,INF,INF,6,0},};

            //int[,] D = { { 0  ,  4, INF, 5  , INF, INF, 2 , INF,INF },
            //             { 4  ,  0, INF, INF, INF, 3  , 1 , 5  ,INF },
            //             { INF,INF, 0  , 2  ,1   ,3   ,INF,INF ,3   },
            //             { 5  ,INF, 2  , 0  ,INF ,2   ,1  ,INF ,INF },
            //             { INF,INF, 1  , INF,0   ,INF ,INF,1   ,2   },
            //             { INF,3  , 3  , 2  ,INF ,0   ,INF,2   ,INF },
            //             { 2  ,1  , INF, 1  ,INF ,INF ,0  ,INF ,INF },
            //             { INF,5  , INF,INF ,1   ,2   ,INF,0   ,1   },
            //             { INF,INF, 3  , INF,2   ,INF ,INF,1   ,0   },};

            // Bu for bloğu içerisinde kullanıcının verdiği matrise göre floyd ile hedef matris oluşturulur.iç içe 3 döngü ile gerçeklendi.
            while (K <= (N - 1))
            {
                for (int i = 0; i < N; i++)
                {
                    if (K == i)
                    {
                        continue;
                    }

                    for (int j = 0; j < N; j++)
                    {
                        if (K == j)
                        {
                            continue;
                        }

                        int hucre = D[i, j]; // O iterasyonda matrisin işlem yapılan hücresi. 
                        int karsilastirilanDeger = D[i, K] + D[K, j]; // En iyi yol için hücrenin kıyaslandığı yolu belirtir.

                        if (karsilastirilanDeger < hucre)
                        {
                            D[i, j] = karsilastirilanDeger;
                            // S matrisi içinde yapılacak işlem buraya girilecek(En Son Adım Olarak).
                        }
                    }
                }
                K++;// Matris her iterasyonda bir defa baştan sona taranınca K değeri 1 arttırılır.
            }


            Console.WriteLine("Verilen matrise Floyd uygulandıktan sonra elde edilen matrisi; ");
            Console.WriteLine("Hesaplanan matrisin boyutu= " + N + "x" + N + " ve Graftaki sonsuz uzaklık değeri= " + sonsuz + " seçilmiştri!");
            Console.WriteLine("<______________________________________________________________>");
            // Floyd uygulanmış sonuç matrisi ekrana bastırılıyor. 
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(D[i, j] + "| ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("<______________________________________________________________>");



            // Bu kısımda kullanıcının hangi düğümler arasındaki en kısa yolu bulmak istiyorsa gereken işlemler yapılır.

            char tercih = 'E';

            do
            {
                int baslangicDogumu;
                int varisDugumu;

                Console.Write("Aralarındaki en kısa yolu bulmak istediğiniz Başlangıç düğümünü gir= ");
                baslangicDogumu = Convert.ToInt32(Console.ReadLine());

                Console.Write("Aralarındaki en kısa yolu bulmak istediğiniz Varış düğümünü gir= ");
                varisDugumu = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("*________________________________________________________________________________*");
                Console.Write(baslangicDogumu + ". düğümden " + varisDugumu + ". düğüme en kısa yol= ");
                Console.WriteLine(D[baslangicDogumu - 1, varisDugumu - 1]);
                Console.WriteLine("*________________________________________________________________________________*");

                Console.WriteLine("Başka iki düğüm arası uzaklık bulmak istermisiniz?(Birdaha için 'E' yada 'e')");
                Console.WriteLine("________________________________________________________________________________\n\n");
                tercih = Convert.ToChar(Console.ReadLine());
            } while (tercih == 'E' || tercih == 'e');

            Console.ReadKey();
        }
    }
}


//__________________________________________________________________________________________________________________________

