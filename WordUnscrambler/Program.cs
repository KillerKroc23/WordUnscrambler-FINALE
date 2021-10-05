using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            try
            {
                bool continueProgramRun = true;

                do
                {
                    Console.WriteLine(Constants.ProgramOptionsFileOrManual);
                    var option = Console.ReadLine() ?? string.Empty;

                    switch (option.ToUpper())
                    {
                        case Constants.UserChoiceFile:
                            Console.WriteLine(Constants.ProgramOptionFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case Constants.UserChoiceManual:
                            Console.WriteLine(Constants.ProgramOptionManual);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constants.UserInvalidOption);
                            break;
                    }




                    var continueProgramRunDecision = string.Empty;
                    do
                    {
                        Console.WriteLine(Constants.ProgramOptionsContinueRunning);
                        continueProgramRunDecision = Console.ReadLine() ?? string.Empty;

                    }
                    while (
                          continueProgramRunDecision.Equals(Constants.UserChoiceYes, StringComparison.OrdinalIgnoreCase) &&
                          
                          continueProgramRunDecision.Equals(Constants.UserChoiceNo, StringComparison.OrdinalIgnoreCase));


                    continueProgramRun = continueProgramRunDecision.Equals(Constants.UserChoiceYes, StringComparison.OrdinalIgnoreCase);





                } while (continueProgramRun);
                        }
                    

                


            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramClose + ex.Message);

            }

        }

    
    



        private static void ExecuteScrambledWordsInFileScenario()
        {
            try
            {
                var filename = Console.ReadLine();
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            var manualEntry = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualEntry.Split(',', ' ');
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            //read the list of words from the system file. 
            string[] wordList = _fileReader.Read(Constants.FileNameWordList);

            //call a word matcher method to get a list of structs of matched words.
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.MatchesFound, matchedWord.ScrambledWord, matchedWord.Word);

                }
            }
            else
            {

                Console.WriteLine(Constants.NoMatchesFound);

            }

        }
    }
}
        
    
