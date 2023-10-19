// Purpose: Represent a word in the scripture and manage its visibility (hidden or shown).

// Behaviors: 
//     Hide the word
//     Show the word
//     Check if the word is hidden

// Attributes
//     Text of the word
//     Visibility status (hidden or shown)

// Data Types:
//     Text of the word: String
//     Visibility status: Boolean

// Constructor with the text of the word.

public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public void Show()
    {
        IsHidden = false;
    }

    public override string ToString()
    {
        return IsHidden ? "_____" : Text;
    }
}
