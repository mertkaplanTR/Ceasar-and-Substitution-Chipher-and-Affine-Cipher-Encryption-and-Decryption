using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networksecurityweek2mert
{
    class Program
    {
        static void Main(string[] args)
        {
            string enteredString, enteredDecryption, defaultKey = "jfkgotmyvhspcandxlrwebquiz", substutionString, cryptedSubstitutionString, getStringForDecSubt, mod26String, mod26dec;
            int shift, backshift, a, b;
            Console.WriteLine("Please enter your string for Ceaser Cipher: ");
            enteredString = Console.ReadLine();
            Console.WriteLine("Please enter shift INT value: ");
            shift = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Crypted string is: " + Ceasar(enteredString, shift));
            Console.WriteLine("Please enter string for decryption: ");
            enteredDecryption = Console.ReadLine();
            Console.WriteLine("Please enter shift INT value: ");
            backshift = -1 * Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Your decrypted string is: " + Ceasar(enteredDecryption, backshift));


            Console.Write("Please enter your string for Substution Chipter: ");
            substutionString = Console.ReadLine();
            cryptedSubstitutionString = SubstitutionChipher(substutionString, defaultKey);
            Console.WriteLine("Your crypted string with Substution Chipter is: " + cryptedSubstitutionString);
            Console.WriteLine("Please enter your string for subtution chipter decryption: ");
            getStringForDecSubt = Console.ReadLine();
            Console.WriteLine("Your decrypted string is: " + DecrypteSubstitutionChipher(getStringForDecSubt, defaultKey));


            Console.WriteLine("Please enter your mod26 string: ");
            mod26String = Console.ReadLine();
            Console.Write("Please enter your mod26 string's a INT value: ");
            a = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please enter your mod26 string's b INT value:");
            b = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Your crypted text is from mod26: "+AffineEncrypt(mod26String,a,b));

            Console.WriteLine("Please enter your mod26 string: ");
            mod26dec = Console.ReadLine();
            Console.WriteLine("Please enter your mod26 string's a INT value:");
            a = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Please enter your mod26 string's b INT value:");
            b = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Your decrypted text is from mod26: " + AffineDecrypt(mod26String, a, b));

        }
        static string Ceasar(string _string, int _shift)
        {
            char[] buffer = _string.ToArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letter = buffer[i];
                letter = (char)(letter + _shift);
                if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }
                else 
                    if( letter<'a')
                {
                    letter = (char)(letter + 26);
                }
                buffer[i] = letter;
            }
            return new string(buffer);
        }

        static string SubstitutionChipher(string _string, string _key)
        {
            char[] _char = _string.ToArray();
            for (int i = 0; i < _string.Length; i++)
            {
                if (_string[i] == ' ')
                {
                    _char[i] = ' ';
                }
                else
                {
                    int calculateWithSubstition97 = _string[i] - 97;
                    _char[i] = _key[calculateWithSubstition97];
                }
            }
            return new string(_char);
        }

        static string DecrypteSubstitutionChipher(string _string, string _key)
        {
            char[] _char2 = _string.ToArray();
            for (int i=0; i<_string.Length;i++)
            {
                if(_string[i] == ' ')
                {
                    _char2[i] = ' ';
                }
                else
                {
                    int decrypte = _key.IndexOf(_string[i] )+97;
                    _char2[i] = (char)decrypte;
                }
            }
            return new string(_char2);
        }


        public static string AffineEncrypt(string plainText, int a, int b)
        {

            string cipherText = "";
            char[] chars = plainText.ToUpper().ToCharArray();
            foreach (char c in chars)
            {
                int x = Convert.ToInt32(c - 65);
                cipherText += Convert.ToChar(((a * x + b) % 26) + 65);
            }

            return cipherText;
        }


        public static string AffineDecrypt(string cipherText, int a, int b)
        {
            string plainText = "";

            int aInverse = MultiplicativeInverse(a);

            char[] chars = cipherText.ToUpper().ToCharArray();

            foreach (char c in chars)
            {
                int x = Convert.ToInt32(c - 65);
                if (x - b < 0) x = Convert.ToInt32(x) + 26;
                plainText += Convert.ToChar(((aInverse * (x - b)) % 26) + 65);
            }

            return plainText;
        }

 
        public static int MultiplicativeInverse(int a)
        {
            for (int x = 1; x < 27; x++)
            {
                if ((a * x) % 26 == 1)
                    return x;
            }

            throw new Exception("No multiplicative inverse found!");
        }

    }
}
