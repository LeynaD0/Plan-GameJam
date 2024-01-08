using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public static Points instance;
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

    private int points;

    public void AddPoints(int amount)
    {
        points += amount;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //mostrar puntos
    }
}
