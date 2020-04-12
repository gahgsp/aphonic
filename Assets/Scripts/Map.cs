using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    
    [SerializeField] private Tilemap environmentTilemap;
    
    /// <summary>
    /// Checks if the parameter tile is an environment tile.
    /// Being an environment tile means that the player can't move to this tile.
    /// </summary>
    public bool IsEnvironmentTile(Vector3 tileWorldPosition)
    {
        return environmentTilemap.HasTile(environmentTilemap.WorldToCell(tileWorldPosition));
    }
    
}
