using UnityEngine;

public class LetterSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] houses;
    
    public delegate void NewLetterSpawned(Letter spawnedLetter);
    public static event NewLetterSpawned OnNewLetterSpawned;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnLetter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnLetter()
    {
        // TODO: Here it will get random houses...
        var l = new Letter {FromHouse = houses[0], ToHouse = houses[1]};
        OnNewLetterSpawned?.Invoke(l);
    }
}
