using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    [TextArea]
    [SerializeField] String  text;
    
    [SerializeField] private GameObject soundManager;

    // Cached components references.
    private TextMeshProUGUI _screenLabel;
    private AudioSource _audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        _screenLabel = GetComponent<TextMeshProUGUI>();
        _audioSource = soundManager.GetComponent<AudioSource>();
        StartCoroutine(ShowText());
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ShowText()
    {
        var timeBetweenDigits = new WaitForSeconds(0.15f); // Avoid massive GC callings
        var sentences = text.Split('\n');
        foreach (var sentence in sentences)
        {
            foreach (var character in sentence.ToCharArray())
            {
                if (character != ' ')
                {
                   _audioSource.PlayOneShot(_audioSource.clip);
                }
                _screenLabel.text += character;
                yield return timeBetweenDigits;
            }
            // After each sentence, we break the line.
            _screenLabel.text += "<br>";
        }
    }
}
