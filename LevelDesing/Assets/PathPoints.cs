using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoints : MonoBehaviour
{
    public PathPoints Up;
    public PathPoints Left;
    public PathPoints Right;
    public bool Passed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Direction(other.gameObject.GetComponent<PathFollow>());
            //if (other.gameObject.GetComponent<PathFollow>().Position != this.transform)
            //{
            //    if (Input.GetKeyDown(KeyCode.D) && Right != null)
            //    {
            //        other.gameObject.GetComponent<PathFollow>().SetValors(Right.transform, 'D', this.transform);
            //    }
            //    else if (Input.GetKeyDown(KeyCode.A) && Left != null)
            //    {
            //        other.gameObject.GetComponent<PathFollow>().SetValors(Left.transform, 'A', this.transform);
            //    }
            //    else if (Input.GetKeyDown(KeyCode.Space) && Up != null)
            //    {
            //        other.gameObject.GetComponent<PathFollow>().SetValors(Up.transform, 'S', this.transform);
            //    }
            //}

        }
    }


    public bool Direction(PathFollow other)
    {
        if (other.Orientation == 'D' && Right != null)
        {
            other.SetValors(Right.transform, 'D', this.transform);
            return true;
        }
        else if (other.Orientation == 'A' && Left != null)
        {
            other.SetValors(Left.transform, 'A', this.transform);
            return true;
        }
        else if (other.Orientation == 'S' && Up != null)
        {
            other.SetValors(Up.transform, 'S', this.transform);
            return true;
        }
        return false;
    }

    void OnDrawGizmosSelected()
    {
        if (Up != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, Up.transform.position);
        }
        if (Left != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, Left.transform.position);
        }
        if (Right != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, Right.transform.position);
        }
    }
}
