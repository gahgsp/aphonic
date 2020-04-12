using System;
using TMPro;
using UnityEngine;

public class LetterBoxController : MonoBehaviour
{

    private TextMeshProUGUI[] _textBoxes;
    
    private int _currText = 0;
    private int _lettersToDeliver = 5;

    private bool _isShowingLetterText;
    public bool IsShowingLetterText
    {
        get => _isShowingLetterText;
        set => _isShowingLetterText = value;
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
    
    private TextToShow[] _textsToShow =
    {
        new TextToShow("This gibberish that I hear from inside the house is so ", "STRANGE", "The struggle is more than real..."),
        new TextToShow("I can not imagine the ", "EFFORT", " that people are putting into writing letters again..."),
        new TextToShow("I have never thought that I would live in a world without a ", "LANGUAGE", " to speak. What a nightmare!"),
        new TextToShow("Wish I could read these letter and see how people ", "TALK", " right now."),
        new TextToShow("In this changed world, you need to ", "LEARN", " and adapt. I am really leaving my comfort zone.")
    };
    
    #endregion
    
    /// <summary>
    /// Displays a text structure in the text box.
    /// </summary>
    public void ShowText()
    {
        gameObject.SetActive(true);
        _textBoxes = GetComponentInChildren<Transform>().GetChild(0).GetChild(0)
            .GetComponentsInChildren<TextMeshProUGUI>();
        _textBoxes[0].text = _textsToShow[_currText].UpperText;
        _textBoxes[1].text = _textsToShow[_currText].MagicWord;
        _textBoxes[2].text = _textsToShow[_currText].BottomText;
        _isShowingLetterText = true;
    }

    /// <summary>
    /// Makes the text box invisible to the player.
    /// </summary>
    public void HideText()
    {
        gameObject.SetActive(false);
        _isShowingLetterText = false;
        _currText++;
    }

    /// <summary>
    /// Checks if the player has already delivered all the letters.
    /// </summary>
    public bool HasDeliveredAllLetters()
    {
        return _currText == _lettersToDeliver;
    }
}
