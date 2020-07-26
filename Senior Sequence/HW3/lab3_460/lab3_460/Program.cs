using System;
using System.IO;
using System.Text.RegularExpressions;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace lab3_460
{
    class Program {
        private static void PrintUsage() {
            Console.WriteLine("Usage is:\n" +
            "\t C# Main C inputfile outputfile\n\n" +
            "Where:" +
            "  C is the column number to fit to\n" +
            "  inputfile is the input text file \n" +
            "  outputfile is the new output file base name containing the wrapped text.\n" +
            "e.g. C# Main 72 myfile.txt myfile_wrapped.txt");
        }
        static void Main(string[] args) {


            int C = 72;     //test variable
            string inputFilename;
            string outputFilename = "output.txt";
            StreamReader Scanner = null;

            if (args.Length != 3) {
                PrintUsage();
                Environment.Exit(0);
            }


            try {
                C = int.Parse(args[0]);
                inputFilename = args[1];
                outputFilename = args[2];
                Scanner = new StreamReader(inputFilename);
            }

            catch (FileNotFoundException e) {
                Console.WriteLine("Could not find the input file");
                Environment.Exit(0);
                throw e;
            }
            catch (IOException e) {
                Console.WriteLine("Something is wrong with the input");
                Environment.Exit(0);
                throw e;
            }
            catch (Exception) {
                Console.WriteLine("Random exception caught.");
            }

            IQueueInterface<string> Words = new LinkedQueue<string>();
            string[] inputText = Scanner.ReadToEnd().Split(' ', '\n', '\t', '\r');
            
            for (int i = 0; i < inputText.Length; i++) {
                if (inputText[i] != "") {
                    Words.Push(inputText[i]);
                }
            }

            Scanner.Close();

            int spacesRemaining = WrapSimply(Words, C, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);
        }

    /******************************************************************************
     *      Here is where the wrap goes 
     *****************************************************************************/

    private static int WrapSimply(IQueueInterface<String> parsedString, int colLength, String outputFileName) {
            StreamWriter output;

            try {
                output = new StreamWriter(outputFileName);
            }

            catch (FileNotFoundException e) {
                Console.WriteLine("Cannot create or open " + outputFileName + " for writing. Using standard output instead.");
                output = new StreamWriter(Console.OpenStandardOutput());

                throw e;
            }

            int col = 1;
            int remainingSpaces = 0;
            while (!parsedString.IsEmpty()) {
                string pushString = parsedString.Peek();
                int stringLength = pushString.Length;

                if (col == 1) {
                    output.Write(pushString);
                    col += stringLength;
                    parsedString.Pop();
                }

                else if ( (col + stringLength) >= colLength) {
                    output.Write("\n");
                    remainingSpaces += (colLength - col) + 1;
                    col = 1;
                }

                else {
                    output.Write(" ");
                    output.Write(pushString);
                    col += (stringLength + 1);
                    parsedString.Pop();
                }
            }
            output.WriteLine();
            output.Flush();
            output.Close();

            return remainingSpaces;
            
        }
    }
}
