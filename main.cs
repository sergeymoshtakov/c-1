using System;
using System.Text.RegularExpressions;
class Program {
  public static string reverse(string str)
  {
    char[] chars = str.ToCharArray();
    for(int i=0; i<chars.Length/2; i++)
    {
      char ch = chars[i];
      chars[i] = chars[chars.Length-i-1];
      chars[chars.Length-i-1] = ch;
    }
    return new string(chars);
  }
  public static void isPalidrom(string str)
  {
    str = str.ToLower().Replace(" ",string.Empty);
    str = Regex.Replace(str, "\\p{P}",string.Empty);
    if(str.Length==1 || string.IsNullOrEmpty(str) || str == reverse(str))
    {
      Console.WriteLine("Да, это палидром.");
    }
    else
    {
      Console.WriteLine("Нет, это не паледром.");
    }
  }
  public static bool isVouvel(char ch)
  {
    char[] vouvels = { 'а', 'е', 'ё', 'у', 'ы', 'я', 'и', 'о', 'ю', 'э', 'А', 'Е', 'Ё', 'У', 'Ы', 'Я', 'И', 'О', 'Ю', 'Э' };
    for(int i=0; i<vouvels.Length; i++)
    {
      if(ch==vouvels[i])
      {
        return true;
      }
    }
    return false;
  }
  public static void calculate(string str)
  {
    int ch=0, con=0, vou=0, sign=0, other=0;
    string [] words = str.Split(" ");
    char[] chars = str.ToCharArray();
    for(int i=0; i<chars.Length; i++)
    {
      if(Char.IsDigit(chars[i]))
      {
        ch++;
      }
      else if(Char.IsLetter(chars[i]))
      {
        if(isVouvel(chars[i]))
        {
          vou++;
        }
        else
        {
          con++;
        }
      }
      else if(Char.IsPunctuation(chars[i]))
      {
        sign++;
      }
      else
      {
        other++;
      }
    }
    Console.WriteLine($"Всего символов {str.Length} , из них:\nСлов: {words.Length}\nГласных: {vou}\nСогласных: {con}\nЗнаков пунктуации: {sign}\nЦифр: {ch}\nДр. знаков: {other}");
  }
  public static void isAnagramme(string str1, string str2)
  {
    str1 = str1.ToLower().Replace(" ",string.Empty);
    str1 = Regex.Replace(str1,"\\p{P}", string.Empty);
    str2 = str2.ToLower().Replace(" ",string.Empty);
    str2 = Regex.Replace(str2, "\\p{P}", string.Empty);
    if(str1.Length!=str2.Length)
    {
      Console.WriteLine("Это не анаграмма");
    }
    else
    {
      bool fl = true;
      char [] chars1 = str1.ToCharArray();
      char [] chars2 = str2.ToCharArray();
      Array.Sort(chars1);
      Array.Sort(chars2);
      for(int i=0; i<chars1.Length; i++)
      {
        if(chars1[i]!=chars2[i])
        {
          fl = false;
        }
      }
      if(fl)
      {
        Console.WriteLine("Да, это анаграмма");
      }
      else
      {
        Console.WriteLine("Нет, это не анаграмма");
      }
    }
  }
  public static void Main (string[] args) {
    // 1. Дана строка символов. Необходимо проверить, является ли эта строка палиндромом.
    Console.WriteLine ("Введите вашу строку: ");
    string str = Console.ReadLine();
    isPalidrom(str);
    // 2. Написать программу, подсчитывающую количество слов, гласных и согласных букв в строке, введёной пользователем. Дополнительно выводить количество знаков пунктуации, цифр и др. символов.
    Console.WriteLine ("Введите вашу строку: ");
    str = Console.ReadLine();
    calculate(str);
    // 3. Написать программу, проверяющую, является ли одна строка анаграммой для другой строки (строка может состоять из нескольких слов и символов пунктуации). Пробелы и пунктуация, разница в больших и маленьких буквах должны игнорироваться. Обе строки вводятся с клавиатуры.
    Console.WriteLine("Введите первую строку: ");
    string str1 = Console.ReadLine();
    Console.WriteLine("Введите вторую строку: ");
    string str2 = Console.ReadLine();
    isAnagramme(str1, str2);
  }
}