using System.Text;

namespace StringFormat.practice
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Выбор строки
            UserInput(out string myString);
            DisplayResult("Default string:", myString);

            // Строка без цифр Replace
            ReplaceString(myString, out string noNums);
            DisplayResult("String without nums:", noNums);

            // Строка после удаления лишних пробелов 
            DeleteWhiteSpaces(noNums, out string noWhiteSpaces);
            DisplayResult("Delete whitespaces:", noWhiteSpaces);

            // Инверсия нечетных слов
            ReverseWords(noWhiteSpaces, out string joinRevStr);
            DisplayResult("Reverse words:", joinRevStr);

            // Первые буквы заглавные
            BigFirstLetters(joinRevStr, out string joinFirstLetterStr);
            DisplayResult("Big First Letters:", joinFirstLetterStr);

            // Замена одной буквы в слове
            ChangeLetter(joinFirstLetterStr, out string changedLetterString);
            DisplayResult("Change one letter:", changedLetterString);

            // Методы
            // Ввод строки
            void UserInput(out string str)
            {
                str = string.Empty;
                while (true)
                {
                    Console.WriteLine("To input string press (1). To use default string press (2):");
                    string? choose = Console.ReadLine();
                    if (choose.Equals("1", StringComparison.InvariantCulture) || choose.Equals("2", StringComparison.InvariantCulture))
                    {
                        switch (choose)
                        {
                            case "1":
                                Console.WriteLine("Input your string with 5 words min:");
                                str = Console.ReadLine();
                                break;

                            case "2":
                                str = "1 55555London1 is an 4 capital of 5GReat britains! 22";
                                break;

                            default:
                                Console.WriteLine("Error input.");
                                break;
                        }

                        Console.WriteLine("Your string: " + str);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please choose 1 or 2");
                    }
                }
            }

            // Удаление цифр
            void ReplaceString(string userString, out string removedNums)
            {
                char[] digit = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                for (int i = 0; i < userString.Length; i++)
                {
                    for (int j = 0; j < digit.Length; j++)
                    {
                        if (userString[i] == digit[j])
                        {
                            userString = userString.Replace(userString[i], ' ');
                        }
                    }
                }

                removedNums = userString.Trim();
            }

            // Удаление лишних пробелов
            void DeleteWhiteSpaces(string str, out string deleteNums)
            {
                var sb = new StringBuilder(str.Length);
                int ind = 0;
                while (ind < str.Length)
                {
                    while (ind < str.Length && str[ind] != ' ')
                    {
                        sb.Append(str[ind++]);
                    }

                    if (ind < str.Length && str[ind] == ' ')
                    {
                        sb.Append(' ');
                    }

                    while (ind < str.Length && str[ind] == ' ')
                    {
                        ind++;
                    }
                }

                deleteNums = sb.ToString();
            }

            // Инверсия слов
            void ReverseWords(string str, out string revStr)
            {
                var arrayStr = str.Split(' ');
                for (int i = 0; i < arrayStr.Length; i++)
                {
                    if (i % 2 != 0)
                    {
                        var strRev = arrayStr[i].Reverse();
                        arrayStr[i] = new string(strRev.ToArray());
                    }
                }

                revStr = string.Join(' ', arrayStr);
            }

            // Занлавные буквы в словах
            void BigFirstLetters(string str, out string bigFirst)
            {
                string[] splitS = str.Split(' ');
                for (int i = 0; i < splitS.Length; i++)
                {
                    var temp = splitS[i].ToLower();
                    splitS[i] = temp;
                }

                for (int i = 0; i < splitS.Length; i++)
                {
                    var tempCharArray = splitS[i].ToCharArray();
                    var tempFirstSymbol = tempCharArray[0].ToString().ToUpper();
                    var tempRemovedSymbol = splitS[i].ToString().Remove(0, 1);
                    splitS[i] = tempFirstSymbol + tempRemovedSymbol;
                }
                bigFirst = string.Join(" ", splitS);
            }

            // Замена одной буквы в слове 
            void ChangeLetter(string str, out string changeLetterStr)
            {
                string[] splited = str.Split(' ');

                for (int i = 0; i < splited.Length; i++)
                {
                    if (splited[i].StartsWith("t", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var tempRemovedSymbol = splited[i].ToString().Remove(0, 1);
                        splited[i] = "H" + tempRemovedSymbol;
                    }

                    if (splited[i].EndsWith("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        var tempRemove = splited[i].Remove(splited[i].Length - 1, 1);
                        splited[i] = tempRemove + "O";
                    }
                }

                changeLetterStr = string.Join(" ", splited);
            }

            // Вывод строки на экран
            void DisplayResult(string message, string valueString)
            {
                Console.WriteLine(message);
                Console.WriteLine(valueString);
                Console.WriteLine();
            }
        }

    }
}