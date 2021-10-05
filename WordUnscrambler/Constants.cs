using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Constants
    {
        public const string ProgramOptionsFileOrManual = "Enter scrambled word(s) manually or as a file: F - file / M - manual";
        public const string UserChoiceFile = "F";
        public const string FileNameWordList = "wordList.txt";
        public const string UserChoiceManual ="M";

        public const string UserInvalidOption = "The entered option was not recognized.";
        public const string ProgramOptionsContinueRunning = "Would you like to continue? (Y/N)";
        public const string UserChoiceYes = "Y";
        public const string UserChoiceNo = "N";


        public const string ProgramOptionFile = "Enter full path including the file name: ";

        public const string ProgramOptionManual = "Enter word(s) manually (separated by commas and spaces if multiple): ";


        public const string MatchesFound = "MATCH FOUND -> {0} = {1} ";
        public const string NoMatchesFound = "0 MATCHES FOUND";

        public const string ErrorProgramClose = "The program will be terminated.";

    }
}
