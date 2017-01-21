using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TranspositionCipher3
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = "TRANSPOSITION";
            int sizeKey = key.Length;

            string text = "HEREISASECRETMESSAGEENCIPHEREDBYTRANSPOSITION";
            int sizeText = text.Length;

            char[] temp = new char[sizeKey - 1];          //tablica na klucz

            char[] plainText = new char[sizeText];     //tablica na wprowadzony tekst
            plainText = text.ToCharArray();

            char[,] temp2 = new char[7, sizeKey];        //macierz
            char[] encipherText = new char[sizeText];     //tablica na zaszyfrowany tekst

            temp = key.ToCharArray();

            int m = 0;
            int k = 0;
            int l = 0;

            for (int i = 65; i < 91; i++)                 //ASCII: A(65) - Z(90)
            {
                for (int j = 0; j < sizeKey; j++)
                {
                    if ((char)i == temp[j])
                    {
                            for (l = 0; l < sizeKey; l++)
                            {
                                if (l <= j && m < sizeText)
                                {
                                    temp2[k, l] = plainText[m];
                                    m += 1;
                                }
                                else
                                {
                                    k += 1;
                                    l = sizeKey - 1;        //wyjście z pętli l
                                }
                            }
                    if (l ==(j + 1))                        //przejście do nowego wiersza
                        k += 1;
                    }
                }
            }
            encipherText = new char[sizeText];        //tablica na zaszyfrowany tekst
            int z = 0;                                  //licznik tablicy

            for (int i = 65; i < 91; i++)                 //ASCII: A(65) - Z(90)
            {
                for (int j = 0; j < sizeKey; j++)
                {
                    if ((char)i == temp[j])
                    {
                            for (int y = 0; y < 7; y++)
                            {
                                if (temp2[y, j] != '\0')
                                {
                                    encipherText[z] = temp2[y, j];
                                    z += 1;
                                }
                        }
                    }
                }
            }           
            Console.WriteLine(encipherText);
            Console.ReadKey();
        }
    }
}
