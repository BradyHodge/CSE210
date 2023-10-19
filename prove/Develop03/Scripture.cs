// Purpose: Store the scripture, including both the reference and the
// text of the scripture. Handle the functionality of hiding words and
// displaying the scripture.

// Behaviors:  
//     Display the scripture
//     Hide random words
//     Check if all words are hidden

// Attributes:
//     List of words

// Data Types:
//     List of words: List<Word>

// Constructor with a list of words and a reference object.

using System;
using System.Collections.Generic;

public class Scripture
{
    public Reference ScriptureReference { get; private set; }
    public List<Word> Words { get; private set; }

    public Scripture(Reference reference, List<Word> words)
    {
        ScriptureReference = reference;
        Words = words;
    }

    public void HideRandomWords(int count = 1)
{
    Random random = new Random();
    for (int i = 0; i < count; i++)
    {
        var notHiddenIndices = Words.Select((word, index) => new { word, index })
                                    .Where(x => !x.word.IsHidden)
                                    .Select(x => x.index)
                                    .ToList();
        if (notHiddenIndices.Count == 0)
        {
            break; // All words are already hidden
        }
        int indexToHide = notHiddenIndices[random.Next(notHiddenIndices.Count)];
        Words[indexToHide].Hide();
    }
}


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
