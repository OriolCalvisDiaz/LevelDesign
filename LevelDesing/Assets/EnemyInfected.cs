using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfected : MonoBehaviour
{

    public PathPoints StartPoint;
    public PathPoints EndPoint;
    public Transform PlayerBody;
    public Transform Position;
    public Transform ActualDestination;
    public char Orientation = 'D';
    public float t;
    public bool infected;
    public GameObject Pills;
    public GameObject Healed;
    // Start is called before the first frame update
    void Start()
    {
        Position = StartPoint.transform;
        ActualDestination = StartPoint.Right.transform;
        this.transform.position = StartPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, ActualDestination.position, t * Time.deltaTime);
        float dist = Vector3.Distance(transform.position, ActualDestination.position);
        if (dist < 0.5f)
        {
            ActualDestination.gameObject.GetComponent<PathPoints>().DirectionE(this);
            if (Orientation == 'D')
                Orientation = 'A';
            else
                Orientation = 'D';
        }


        if (infected)
        {
            Pills.gameObject.SetActive(true);
            Healed.gameObject.SetActive(false);
        }
        else
        {
            Pills.gameObject.SetActive(false);
            Healed.gameObject.SetActive(true);
        }
    }

    public void SetValors(Transform a, char b, Transform c)
    {
        ActualDestination = a.transform;
        if (b == 'A')
        {
            Vector3 movement = new Vector3(-1, 0.0f, 0.0f);
            PlayerBody.transform.rotation = Quaternion.LookRotation(movement);
        }
        if (b == 'D')
        {
            Vector3 movement = new Vector3(1, 0.0f, 0.0f);
            PlayerBody.transform.rotation = Quaternion.LookRotation(movement);
        }
        Orientation = b;
        Position = c;
    }
}
