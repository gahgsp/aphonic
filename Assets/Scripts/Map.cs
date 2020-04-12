using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    
    [SerializeField] private Tilemap environmentTilemap;
    
    public bool IsEnvironmentTile(Vector3 tileWorldPosition)
    {
        return environmentTilemap.HasTile(environmentTilemap.WorldToCell(tileWorldPosition));
    }
    
}
