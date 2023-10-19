// Purpose: Store and manage the scripture reference, such as "John 3:16" or "Proverbs 3:5-6".

// Behaviors:
//     Display the reference
//     Handle verse ranges (e.g., "Proverbs 3:5-6")

// Attributes: 
//     Book name (e.g., "John")
//     Chapter number
//     Verse number or range

// Data Types: 
//     Book name: String
//     Chapter number: Integer
//     Verse number or range: String or Tuple<Integer, Integer>

// Constructor with book name, chapter number, and verse number. Constructor with book name, chapter number, and verse range.

using System;

public class Reference
{
    public string BookName { get; private set; }
    public int ChapterNumber { get; private set; }
    public Tuple<int, int> VerseRange { get; private set; }
    
    // Constructor for single verse
    public Reference(string bookName, int chapterNumber, int verseNumber)
    {
        BookName = bookName;
        ChapterNumber = chapterNumber;
        VerseRange = new Tuple<int, int>(verseNumber, verseNumber);
    }

    // Constructor for verse range
    public Reference(string bookName, int chapterNumber, int startVerse, int endVerse)
    {
        BookName = bookName;
        ChapterNumber = chapterNumber;
        VerseRange = new Tuple<int, int>(startVerse, endVerse);
    }

    public override string ToString()
{
    if(VerseRange.Item1 == VerseRange.Item2)
    {
        return $"{BookName} {ChapterNumber}:{VerseRange.Item1}";
    }
    return $"{BookName} {ChapterNumber}:{VerseRange.Item1}-{VerseRange.Item2}";
}

}
