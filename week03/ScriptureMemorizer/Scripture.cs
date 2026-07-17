using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        ParseText(text);
    }

    private void ParseText(string text)
    {
        string[] splitWords = text.Split(' ');
        foreach (string wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<int> visibleIndices = GetVisibleWordIndices();
        int actualToHide = Math.Min(numberToHide, visibleIndices.Count);
        Random random = new Random();

        for (int i = 0; i < actualToHide; i++)
        {
            int randomIndex = random.Next(0, visibleIndices.Count);
            int wordIndexToHide = visibleIndices[randomIndex];
            
            _words[wordIndexToHide].Hide();
            visibleIndices.RemoveAt(randomIndex);
        }
    }

    private List<int> GetVisibleWordIndices()
    {
        List<int> indices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                indices.Add(i);
            }
        }
        return indices;
    }

    public string GetDisplayText()
    {
        List<string> renderedWords = new List<string>();
        foreach (Word word in _words)
        {
            renderedWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()} - {string.Join(" ", renderedWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}