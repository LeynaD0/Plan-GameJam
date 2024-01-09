using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public static Points instance;
    [Header("Points")]
    [SerializeField] private int points;
    [Space(3)]
    [Header("PointsContainer")]
    [SerializeField] private GameObject _pointsContainer;
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI _pointsText;

    private void Awake()
    {
        if (Points.instance == null)
        {
            Points.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddPoints(int amount)
    {
        PointsLeans.Instance.ScaleUp(_pointsContainer);
        points += amount;
        _pointsText.text = points.ToString().PadLeft(5, '0');
    }

    // Start is called before the first frame update
    void Start()
    {
        _pointsText.text = points.ToString().PadLeft(5, '0');
    }

    // Update is called once per frame
    void Update()
    {
        //mostrar puntos
        
        //TEST -> ELIMINAR
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddPoints(1);
        }
    }
}
