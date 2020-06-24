using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.gameObject.GetComponent<SphereCollider>().enabled = (false);
            other.gameObject.GetComponent<PathFollow>().GetCons();

            Destroy(this.gameObject, 0.5f);

        }

    }
}
