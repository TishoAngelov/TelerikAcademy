using System;
using System.IO;
using System.Text;

class ExtractFromXML
{
    /*
        Write a program that extracts from given XML file all the text without the tags.
            Example:
                <?xml version="1.0"><student><name>Pesho</name><age>21</age><interests count="3">
                <interest> Games</instrest><interest>C#</instrest><interest> Java</instrest>
                </interests></student>
            output: Pesho 21 Games C# Java
    */

    static void Main()
    {
        string filePath = "../../XMLFile.xml";
        StringBuilder extractedWords = new StringBuilder();

        StreamReader readXML = new StreamReader(filePath);
        using (readXML)
        {
            string singleLine = readXML.ReadLine();

            while (singleLine != null)
            {
                for (int i = 0; i < singleLine.Length; i++)
                {
                    if (singleLine[i].ToString() == ">")
                    {
                        // check if end of line reached
                        if (i == singleLine.Length - 1)
                        {
                            break;
                        }

                        i++;

                        while (singleLine[i].ToString() != "<")
                        {
                            // check if end of line reached
                            if (i == singleLine.Length - 1)
                            {
                                break;
                            }

                            extractedWords.Append(singleLine[i].ToString());
                            i++;
                        }

                        // add interval after each word
                        if (singleLine[i - 1].ToString() != ">")
                        {
                            extractedWords.Append(" ");
                        }
                    }
                }

                singleLine = readXML.ReadLine();
            }
        }

        Console.Write("Extracted words: {0}", extractedWords);
        Console.WriteLine();
        Console.WriteLine();
    }
}