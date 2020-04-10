using UnityEngine;

public class House : MonoBehaviour
{
    public Letter CurrSendingLetter
    {
        get => _currSendingLetter;
        set => _currSendingLetter = value;
    }

    // TODO: We need different sprites from receiving / sending a letter.
    [SerializeField] private GameObject letterSign;

    private bool _isReceivingLetter;
    private bool _isSendingLetter;
    private Letter _currSendingLetter;

    private void Awake()
    {
        LetterSpawner.OnNewLetterSpawned += UpdateHouse;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHouse(Letter spawnedLetter)
    {
        if (spawnedLetter.FromHouse.Equals(gameObject))
        {
            letterSign.SetActive(true);
            _currSendingLetter = spawnedLetter;
        }
    }

    public void CollectLetter()
    {
        letterSign.SetActive(false);
        _currSendingLetter.ToHouse.GetComponent<House>().letterSign.SetActive(true);
        _currSendingLetter = null;
    }
}
