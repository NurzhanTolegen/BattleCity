using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyController : MonoBehaviour
{
    public static TileDestroyController instance;

    public Tilemap tilemap;

    private void Awake() {
        instance = this;
    }

    public static void DestroyTiles(ContactPoint2D[] contacts, float range) {
        Vector3 hitPosition = Vector3.zero;
        foreach (ContactPoint2D hit in contacts) {
            hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
            hitPosition.y = hit.point.y - 0.01f * hit.normal.y;

            Vector3Int pos = instance.tilemap.WorldToCell(hitPosition);
            instance.tilemap.SetTile(pos, null);
        }
    }

    void Update()
    {
        
    }
}
