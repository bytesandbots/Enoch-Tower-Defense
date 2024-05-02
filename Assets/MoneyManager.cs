using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MoneyManager : MonoBehaviour
{
    public float money = 10;
    public GameObject[] Towers;
    public GameObject Selection;
    public Tilemap grid;
    public int SelectedTower = -1;
    public LayerMask Layer;
    public void buy(float price)
    {
        if (money - price > 0)
        {

            money = money - price;
        }
    }
    public void SelectTower(int selection)
    {
        Selection.GetComponent<SpriteRenderer>().sprite = Towers[selection].GetComponent<Info>().pick;
        SelectedTower = selection;
    }
    public void GainMoney(float Gaining)
    {
        money = money + Gaining;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int Coor = grid.WorldToCell(pos);

        if (grid.HasTile(Coor))
        {
            Vector3 location = grid.GetCellCenterWorld(Coor);
            if (Input.GetMouseButtonDown(0))
            {
                if (SelectedTower >= 0)
                {
                    RaycastHit2D hit = Physics2D.Raycast(location, Vector3.forward, 10, Layer);
                    if (hit.collider == null)
                    {
                        Instantiate(Towers[SelectedTower], location, Quaternion.identity);

                    }


                }

            }
        }

    }
}
