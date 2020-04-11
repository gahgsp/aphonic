using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterBoxController : MonoBehaviour
{

    private TextMeshProUGUI[] _textBoxes;
    
    private bool _isShowingLetterText;

    public bool IsShowingLetterText
    {
        get => _isShowingLetterText;
        set => _isShowingLetterText = value;
    }

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
        new TextToShow("Sometimes I hear people trying to speak, it is really", "strange", " seeing people struggling with this."),
        new TextToShow("I can not imagine what happened to", "foreign countries", " as well...")
    };

    private int _currText = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void HideText()
    {
        gameObject.SetActive(false);
        _isShowingLetterText = false;
        _currText++;
    }
}
