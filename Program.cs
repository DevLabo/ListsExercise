using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace ListsExercise
{
    class Program
    {
        private const string greeting = "abababab";
        private const int QuantityLetters = 256;

        //private const string greeting = "Hello World!";

        static void Main(string[] args)
        {
            Console.WriteLine(greeting);
            Console.WriteLine($"{ReverseStr(greeting)}");
            Console.WriteLine($"MY {String.Concat(MyReverseStr(greeting))}");
            Console.WriteLine($"{String.Concat(RemoveDuplicateChar(greeting))}");
            Console.WriteLine($"{String.Concat(IsAnagram("abcabcdddd", "aabbfdccdd"))}");
            Console.WriteLine($"{MyReplace(null, 'a', "%0%")}");

            var pilaToTest = new Stack<int>();
            pilaToTest.Push(4);
            pilaToTest.Push(3);
            pilaToTest.Push(1);
            pilaToTest.Push(2);

            var pilaToTestOrdered = PilaOperation.Instance.OrderStack(pilaToTest);
            foreach (var item in pilaToTestOrdered)
            {
                Console.Write($"{item}->");
            }

            var binaryArray = new int[]
            {
                1,4,6,8,9,10,88,88,65464,234243,234245,546541165
            };

            var valueToFind = 88; 
            var findBinaryIndex = TreesOperation.Instance.BinarySearch(binaryArray, valueToFind);
            Console.Write($"From 1,4,6,8,9,10,88,88,65464,234243,234245,546541165-> the {valueToFind} is index {findBinaryIndex}");

            TreesOperation.Instance.Root = new Node(
                new Node(null, 20, 20, null), 
                10, 10, 
                new Node(null, 50, 50, null));
         
            var node = TreesOperation.Instance.Root;
            var findNode = TreesOperation.Instance.FindNode(500, node);
         
            node = TreesOperation.Instance.InsertNode(node, 21, 21);
            node = TreesOperation.Instance.InsertNode(node, 33, 33);
            node = TreesOperation.Instance.InsertNode(node, 201, 201);
            node = TreesOperation.Instance.InsertNode(node, 5, 5);

        }


        public static string ReverseStr(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            var arrayStr = str.ToCharArray();
            return String.Concat(arrayStr.Reverse());
        }

        public static IEnumerable<char> MyReverseStr(string str)
        {
            if (string.IsNullOrEmpty(str)) yield break; 
            var arrayStr = str.ToCharArray();
            var c = arrayStr.Length;

            do {
                yield return arrayStr[--c];
            } while (c > 0) ;
        }

        public static string RemoveDuplicateChar(string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length < 2) return str;

            var arrayChar = str.ToCharArray();
            var punteroCadena = 1;
            for (int contadorCadena = 1; contadorCadena < str.Length; contadorCadena++)
            {
                int contadorPuntero;
                for (contadorPuntero = 0; contadorPuntero < punteroCadena; contadorPuntero++)
                {
                    if (arrayChar[contadorCadena] == arrayChar[contadorPuntero]) break;
                }

                if(contadorPuntero == punteroCadena)
                {
                    arrayChar[punteroCadena] = arrayChar[contadorCadena];
                    punteroCadena++;
                }
            }
             
            return String.Concat(arrayChar.Take(punteroCadena));
        }

        public static bool IsAnagram(string source, string target)
        {
            if (source.Length != target.Length) return false;

            var arraySrc = source.ToCharArray();
            var arraySTrg = target.ToCharArray();

            var lettersSrc = GetLettersAccount(arraySrc);
            var lettersTrg = GetLettersAccount(arraySTrg);

            return LettersAreEqual(lettersSrc, lettersTrg);
        }

        private static bool LettersAreEqual(int[] lettersSrc, int[] lettersTrg)
        {
            for (int counter = 0; counter < QuantityLetters; counter++)
            {
                if (lettersSrc[counter] != lettersTrg[counter]) return false;
            }
            return true;
        }

        private static int[] GetLettersAccount(char[] arrayStr)
        {
            var result = new int[256];

            for (int counter = 0; counter < arrayStr.Length; counter++)
            {
                var charIndex = (int)arrayStr[counter];
                result[charIndex]++;
            }

            return result;
        }

        public static string MyReplace(string str, char letterToReplace, string substituteStr)
        {
            if (string.IsNullOrEmpty(str)) return str;
             
            var countSpaces = CountCharacter(str, letterToReplace);
            var newLenghtStr = str.Length + (countSpaces * substituteStr.Length);
            var newStr = new char[newLenghtStr];
            var arrayStr = str.ToCharArray();
            var counterNewStr = 0;

            for (int counter = 0; counter < str.Length; counter++)
            {
                var currentLetter = arrayStr[counter];
                if (currentLetter == letterToReplace)
                {
                    var arraySubstituteStr = substituteStr.ToCharArray();
                    for (int counterSubstitute = 0; counterSubstitute < arraySubstituteStr.Length; counterSubstitute++)
                    {
                        newStr[counterNewStr++] = arraySubstituteStr[counterSubstitute];
                    }
                    continue;
                }
                newStr[counterNewStr++] = currentLetter;
            }
            return String.Concat(newStr);
        }

        private static int CountCharacter(string str, char charToSeek)
        {
            var letterIndex = (int)charToSeek;
            var arrayStr = str.ToCharArray();
            var result = 0;

            for (int counter = 0; counter < arrayStr.Length; counter++)
            {
                var currentIndexLetter = arrayStr[counter];
                if (currentIndexLetter == letterIndex) result++;
            }

            return result;
        }
    }
}
