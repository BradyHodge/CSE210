using System;

// Represents a scripture reference, such as "John 3:16" or "John 3:16-17"
public class Reference
{
    // Name of the book (e.g., "John")
    public string BookName { get; private set; }

    // Chapter number (e.g., 3)
    public int ChapterNumber { get; private set; }

    // Represents a range of verses; both items will be the same for a single verse
    public Tuple<int, int> VerseRange { get; private set; }
    
    // VerseRange will have the same start and end verse number
    public Reference(string bookName, int chapterNumber, int verseNumber)
    {
        BookName = bookName;
        ChapterNumber = chapterNumber;
        VerseRange = new Tuple<int, int>(verseNumber, verseNumber);
    }

    // Constructor to create a reference for a range of verses
    public Reference(string bookName, int chapterNumber, int startVerse, int endVerse)
    {
        BookName = bookName;
        ChapterNumber = chapterNumber;
        VerseRange = new Tuple<int, int>(startVerse, endVerse);
    }

    // Overrides the default ToString method to provide a custom string representation
    // of the scripture reference (apparently this is the best way idk)
    public override string ToString()
    {
        if(VerseRange.Item1 == VerseRange.Item2)
        {
            // For a single verse reference, e.g., "John 3:16"
            return $"{BookName} {ChapterNumber}:{VerseRange.Item1}";
        }
        // For a verse range, e.g., "John 3:16-17"
        return $"{BookName} {ChapterNumber}:{VerseRange.Item1}-{VerseRange.Item2}";
    }
}
