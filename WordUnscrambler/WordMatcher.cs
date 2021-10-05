using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    //scrambledWord already matches word
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase)) {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {   //conerting scrambled words and the words in our list to Char so we can sort them by letter
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();


                        //sort the scrambled words
                        Array.Sort(scrambledWordArray);

                        //sort the unscrambled words
                        Array.Sort(wordArray);

                        //convert to strings after sorting so we can preform a String comparison
                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        //if successful match then call on BuildMatchedWord method below
                        if(sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }


                    }
                }
            }

            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                MatchedWord matchedWord = new MatchedWord
                {
                    ScrambledWord = scrambledWord,
                    Word = word
                };

                return matchedWord;
            }

            return matchedWords;
        } 
    }

}
