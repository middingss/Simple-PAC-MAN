using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class CellComponent : MonoBehaviour {

    public event Action<int, int> OnItemClick;

    private  void OnItemClickHandler()
    {
        if (OnItemClick != null) OnItemClick(Row, Colum);
    }

    public int Colum
    {
        get;
        set;
    }

    public int Row
    {
        get; set;
    }

    [SerializeField]
    private Image _image;

    [SerializeField]
    private Color _selectColor;

    [SerializeField]
    private Color _unselectColor;

    private float _delay = 0.25f;
    private bool _isSelect; 

    public bool IsSelect
    {
        set
        {
            _isSelect = value;

            CancelInvoke();
            //if (value) InvokeRepeating("SwichColor", 0, Random.Range(_delay/2, _delay*2));
            if (value) InvokeRepeating("SwichColor", 0, _delay);
            else if(_image) _image.color = _unselectColor;
        }

        get
        {
            return _isSelect;
        }
    }

    private void SwichColor()
    {
        if (!_image) return;

        //_image.color = _image.color == _unselectColor ? _selectColor : _unselectColor;
        _image.color = new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f));

       
    }

	// Use this for initialization
	void Start () {
        if (_image)
            _image.color = _unselectColor;
       // IsSelect = !IsSelect;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Select()
    {
        IsSelect = !IsSelect;
    }

    public void OnSelected()
    {
        OnItemClickHandler();
    }
}
