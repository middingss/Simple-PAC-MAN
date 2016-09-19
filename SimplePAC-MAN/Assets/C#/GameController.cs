using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private Transform _wrapper;

    private int _rowCount = 10;
    private int _colCount = 10;
    private CellComponent[,] cells = new CellComponent[10,10];

    private int _previosRow;
    private int _previosCol;

    private void GenerateField()
    {
        if (!_prefab || !_wrapper) return;

        for (int i = 0; i < _rowCount; i++)
        {
            for (int j = 0; j < _colCount; j++)
            {
                var item = _prefab.transform.GetClone();
                item.SetParent(_wrapper, false);
                //item.localScale = Vector3.one;
                cells[i,j] = item.GetComponent<CellComponent>();
                item.gameObject.name = "cell_" + i + "_" + j;

                cells[i, j].Row = i;
                cells[i, j].Colum = j;

                cells[i, j].OnItemClick += Item_OnClick;
            }
        }
    }

    private void Item_OnClick(int row, int col)
    {
       // print(row + " " + col);
        cells[_previosRow, _previosCol].IsSelect = false;
        cells[row, col].IsSelect = transform;
        _previosRow = row;
        _previosCol = col;
    }

    // Use this for initialization
    void Start () {
        GenerateField();

    }
	
	// Update is called once per frame
	void LateUpdate () {
	    if(Input.GetKey(KeyCode.UpArrow))
        {
            Item_OnClick(_previosRow <= 0 ? cells.GetLength(0)-1 : _previosRow - 1, _previosCol);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Item_OnClick(_previosRow >= cells.GetLength(0)-1? 0 : _previosRow + 1, _previosCol);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Item_OnClick(_previosRow, _previosCol <= 0 ? cells.GetLength(1)-1 : _previosCol-1);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Item_OnClick(_previosRow, _previosCol >= cells.GetLength(1)-1 ? 0 : _previosCol+1);
        }
       
    }
}
