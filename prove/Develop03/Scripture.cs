using System;
using System.Collections.Generic;

// Represents a scripture with its reference and words
public class Scripture
{
    // Holds the reference to the scripture
    public Reference ScriptureReference { get; private set; }

    // List of words that make up the scripture
    public List<Word> Words { get; private set; }

    // Initialize the scripture with its reference and words
    public Scripture(Reference reference, List<Word> words)
    {
        ScriptureReference = reference;
        Words = words;
    }

    // Hides a specified number of random words from the scripture (IDK how many words to hide, I assume one)
    public void HideRandomWords(int count = 1)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            // Get indices of words that are not yet hidden 
            var notHiddenIndices = Words.Select((word, index) => new { word, index })
                                        .Where(x => !x.word.IsHidden)
                                        .Select(x => x.index)
                                        .ToList();
                                        // why ಥ_ಥ

            // If all words are hidden, exit the loop
            if (notHiddenIndices.Count == 0)
            {
                break;
            }

            // Randomly choose an index from the notHiddenIndices list and hide the word at that index
            int indexToHide = notHiddenIndices[random.Next(notHiddenIndices.Count)];
            Words[indexToHide].Hide();
        }
    }

    // Checks if all words in the scripture are hidden
    public bool AreAllWordsHidden()
    {
        foreach (var word in Words)
        {
            if (!word.IsHidden) return false;
        }
        return true;
    }

    public override string ToString()
    {
        return $"{ScriptureReference}\n{string.Join(" ", Words)}";
    }
}

