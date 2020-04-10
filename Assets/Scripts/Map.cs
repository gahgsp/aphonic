using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    
    [SerializeField] private Tilemap environmentTilemap;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsEnvironmentTile(Vector3 tileWorldPosition)
    {
        return environmentTilemap.HasTile(environmentTilemap.WorldToCell(tileWorldPosition));
    }
    
}
