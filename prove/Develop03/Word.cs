// Represents a word (hidden or shown)
public class Word
{
    // The actual text of the word
    public string Text { get; private set; }

    // Indicates whether the word is currently hidden or not
    public bool IsHidden { get; private set; }

    // Constructor to initialize the word with its text and set its initial state to not hidden
    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    // Hides the word by setting the IsHidden property to true
    public void Hide()
    {
        IsHidden = true;
    }

    // Shows the word by setting the IsHidden property to false
    public void Show()
    {
        IsHidden = false;
    }
    public override string ToString()
    {
        return IsHidden ? "_____" : Text;
    }
}
