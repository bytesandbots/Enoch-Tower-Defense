using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowMouse : MonoBehaviour
{
    public Tilemap grid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int Coor = grid.WorldToCell(pos);
        pos.z = 0;
        transform.position = pos;
        if (grid.HasTile(Coor))
        {
            Vector3 location = grid.GetCellCenterWorld(Coor);
            transform.position = location;

        }

    }
}
