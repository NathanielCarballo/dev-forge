using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;

namespace MoshTest
{
    class Exercise5
    {
        static string book = @"c:\Users\ncarballo\Documents\Test\Sorcerer's Stone.txt";

        public static void CountWords()
        {
            string filePath =  book;
            int chunkSize = 1024;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int wordCount = 0;
            string previousChunkRemainder = string.Empty;

            using (FileStream stream = File.OpenRead(filePath))
            {
                byte[] buffer = new byte[chunkSize];
                int bytesRead;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {

                    string chunk = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    chunk = previousChunkRemainder + chunk;

                    int i = 0;

                    while (i< chunk.Length)
                    {
                        while (i < chunk.Length && (char.IsWhiteSpace(chunk[i]) || chunk[i] == '\r'
                            || chunk[i] == '\n'))
                            i++;

                        if (i < chunk.Length)
                        {
                            wordCount++;

                            while (i < chunk.Length && !(char.IsWhiteSpace(chunk[i]) || chunk[i] == '\r'
                                || chunk[i] == '\n'))
                                i++;
                        }
                    }
                    //string[] words = chunk.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    //wordCount += words.Length;

                    previousChunkRemainder = chunk.Substring(chunk.LastIndexOfAny(new[] { ' ', '\r', '\n' }) + 1);
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}:{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("The file contains {0} words. RunTime: {1}", wordCount, elapsedTime);


/*
            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            string lines = null;
            int secWordCount = 0;

            Console.WriteLine($"{lines = File.ReadAllText(filePath)} \n = {secWordCount = lines.Split(' ').Count()} words");
            stopWatch2.Stop();
            ts = stopWatch2.Elapsed;
            Console.WriteLine("RunTime " + elapsedTime);
*/      
        
        }

        public static void FindLongestWord()
        {
            string filePath = @"c:\Users\ncarballo\Documents\Test\Sorcerer's Stone.txt";
            string longestWord = string.Empty;
            string currentWord = string.Empty;

            using (var streamReader = new StreamReader(filePath))
            {
                int character;

                while ((character = streamReader.Read()) != -1)
                {
                    if (char.IsWhiteSpace((char)character))
                    {
                        if (currentWord.Length > longestWord.Length)
                        {
                            longestWord = currentWord;
                        }

                        currentWord = string.Empty;
                    }
                    else
                    {
                        currentWord += (char)character;
                    }
                }

                if (currentWord.Length > longestWord.Length)
                {
                    longestWord = currentWord;
                }
            }

            Console.WriteLine($"{longestWord}");
        }

        public static void FileWordSearch()
        {
            string filePath = @"c:\Users\ncarballo\Documents\Test\Sorcerer's Stone.txt";

            Console.WriteLine("Enter the word you would like to find within the text document: ");

            string userWord = Console.ReadLine();

            string wordToSearchLowercase = userWord.ToLower();
            string wordToSearchUppercase = userWord.ToUpper();
            string wordToSearchCapitalized = char.ToUpper(userWord[0]) + userWord.Substring(1);

            string pattern = $@"\b({Regex.Escape(wordToSearchCapitalized)}|{Regex.Escape(wordToSearchLowercase)}|{Regex.Escape(wordToSearchUppercase)})\b";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            using (var streamReader = new StreamReader(filePath))
            {
                int lineNumber = 0;
                string line;

                while((line = streamReader.ReadLine()) != null)
                {
                    lineNumber++;

                    if(regex.IsMatch(line))
                    {
                        string[] sentences = line.Split(new[] {".","!","?"},
                            StringSplitOptions.RemoveEmptyEntries);

                        foreach(string sentence in sentences)
                        {
                            if(regex.IsMatch(sentence))
                            {
                                //string highlightedSentence = regex.Replace(sentence, match => $"\u001b[43m{match.Value}\u001b[0m");

                                Console.Write($"Line {lineNumber}: ");

                                string highlightedSentence = regex.Replace(sentence, match => $"{match.Value}");

                                string[] words = Regex.Split(highlightedSentence, @"(\b)");

                                foreach (string word in words)
                                {
                                    if (word == userWord || word == wordToSearchCapitalized || word == wordToSearchUppercase || word == wordToSearchLowercase)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.Write(word);
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.Write(word);
                                    }
                                }
                                    Console.WriteLine();
                                }
                                //Console.Write($"Line {lineNumber}: {highlightedSentence.Trim()}");
                            }
                        }
                    }
                }
            }
        }
    }
