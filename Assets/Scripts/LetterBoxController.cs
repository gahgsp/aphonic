using System;
using TMPro;
using UnityEngine;

public class LetterBoxController : MonoBehaviour
{

    private TextMeshProUGUI[] _textBoxes;
    
    private int _currLetterText = 0;
    private int _currNPCText = 0;
    private int _lettersToDeliver = 5;

    private bool _isShowingText;
    public bool IsShowingText
    {
        get => _isShowingText;
        set => _isShowingText = value;
    }

    #region TextPool
    
    private struct TextToShow
    {
        private String _upperText;
        private String _magicWord;
        private String _bottomText;

        public TextToShow(string upperText, string magicWord, string bottomText)
        {
            _upperText = upperText;
            _magicWord = magicWord;
            _bottomText = bottomText;
        }

        public string UpperText
        {
            get => _upperText;
            set => _upperText = value;
        }

        public string MagicWord
        {
            get => _magicWord;
            set => _magicWord = value;
        }

        public string BottomText
        {
            get => _bottomText;
            set => _bottomText = value;
        }
    }
    
    private TextToShow[] _textsFromLettersToShow =
    {
        new TextToShow("This gibberish that I hear from inside the house is so ", "STRANGE", "The struggle is more than real..."),
        new TextToShow("All the voices and I can not hear what they ", "SPEAK", " and this makes me feel really bad."),
        new TextToShow("I have never thought that I would live in a world without a ", "LANGUAGE", " to speak. What a nightmare!"),
        new TextToShow("I wish I could read what is ", "WRITTEN", " in these letters."),
        new TextToShow("In this changed world, you need to ", "LEARN", " and adapt. I am really leaving my comfort zone.")
    };

    private TextToShow[] _textsFromNPCToShow =
    {
        new TextToShow("? ? ? ? ? ? ? ? ?", "ANOTHER", "? ? ? ? ? ? ? ? ?"),
        new TextToShow("? ? ? ? ? ? ? ? ?", "FAR", "? ? ? ? ? ? ? ? ?"),
        new TextToShow("? ? ? ? ? ? ? ? ?", "BOUNDARY", "? ? ? ? ? ? ? ? ?")
    };
    
    #endregion
    
    /// <summary>
    /// Displays a text structure in the text box.
    /// </summary>
    public void ShowLetterText()
    {
        gameObject.SetActive(true);
        _textBoxes = GetComponentInChildren<Transform>().GetChild(0).GetChild(0)
            .GetComponentsInChildren<TextMeshProUGUI>();
        _textBoxes[0].text = _textsFromLettersToShow[_currLetterText].UpperText;
        _textBoxes[1].text = _textsFromLettersToShow[_currLetterText].MagicWord;
        _textBoxes[2].text = _textsFromLettersToShow[_currLetterText].BottomText;
        _isShowingText = true;
        _currLetterText++;
    }

    public void ShowNPCText()
    {
        gameObject.SetActive(true);
        _textBoxes = GetComponentInChildren<Transform>().GetChild(0).GetChild(0)
            .GetComponentsInChildren<TextMeshProUGUI>();
        _textBoxes[0].text = _textsFromNPCToShow[_currNPCText].UpperText;
        _textBoxes[1].text = _textsFromNPCToShow[_currNPCText].MagicWord;
        _textBoxes[2].text = _textsFromNPCToShow[_currNPCText].BottomText;
        _isShowingText = true;
        _currNPCText++;
    }

    /// <summary>
    /// Makes the text box invisible to the player.
    /// </summary>
    public void HideText()
    {
        gameObject.SetActive(false);
        _isShowingText = false;
    }

    /// <summary>
    /// Checks if the player has already delivered all the letters.
    /// </summary>
    public bool HasDeliveredAllLetters()
    {
        return _currLetterText == _lettersToDeliver;
    }
}
