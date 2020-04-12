using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterEffect : MonoBehaviour
{
    [TextArea] [SerializeField] private string text;

    [SerializeField] private GameObject soundManager;

    // Cached components references
    private TextMeshProUGUI _screenLabel;
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _screenLabel = GetComponent<TextMeshProUGUI>();
        _audioSource = soundManager.GetComponent<AudioSource>();
        StartCoroutine(ShowText());
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
        Invoke(nameof(LoadNextSceneAfterFinish), 2f);
    }

    private void LoadNextSceneAfterFinish()
    {
        var uiManager = FindObjectOfType<UIManager>();
        uiManager.LoadNextScene();
    }
}