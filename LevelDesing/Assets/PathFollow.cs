using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathFollow : MonoBehaviour
{
    public PathPoints StartPoint;
    public PathPoints EndPoint;
    public Transform PlayerBody;
    public Transform Position;
    public Transform ActualDestination;
    public Text money;
    public Text superMoney;
    public Text canvasMedicine;
    public Image lifeBar;

    public char Orientation = 'D';
    public float t;

    public int coins;
    public int superCoins;
    public int medicine;
    public float life;

    void Start()
    {
        Position = StartPoint.transform;
        ActualDestination = StartPoint.Right.transform;
        this.transform.position = StartPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            char oldOr = Orientation;
            Orientation = 'D';
            if (!(ActualDestination.gameObject.GetComponent<PathPoints>().Direction(this)))
            {
                Orientation = oldOr;
            }

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            char oldOr = Orientation;

            Orientation = 'A';
            if (!(ActualDestination.gameObject.GetComponent<PathPoints>().Direction(this)))
            {
                Orientation = oldOr;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            char oldOr = Orientation;

            Orientation = 'S';
            if (!(ActualDestination.gameObject.GetComponent<PathPoints>().Direction(this)))
            {
                Orientation = oldOr;
            }

            if (oldOr != 'S')
                Orientation = oldOr;
            else
                Orientation = 'D';
        }

        transform.position = Vector3.MoveTowards(transform.position, ActualDestination.position, t * Time.deltaTime);
        float dist = Vector3.Distance(transform.position, ActualDestination.position);
        if (dist < 0.5f)
        {
            ActualDestination.gameObject.GetComponent<PathPoints>().Direction(this);
        }
        
    }

    public void SetValors(Transform a, char b, Transform c)
    {
        ActualDestination = a.transform;
        if(b == 'A')
        {
            Vector3 movement = new Vector3(-1, 0.0f, 0.0f);
            PlayerBody.transform.rotation = Quaternion.LookRotation(movement);
        }
        if(b == 'D')
        {
            Vector3 movement = new Vector3(1, 0.0f, 0.0f);
            PlayerBody.transform.rotation = Quaternion.LookRotation(movement);
        }
        Orientation = b;
        Position = c;
    }

    public void GetCons()
    {
        coins++;
    }
    
    public void GetInfected()
    {
        lifeBar.fillAmount += 1.0f / 100.0f;
    }
}
