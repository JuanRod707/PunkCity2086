using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingAutoDispose : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag.Equals("Street"))
        {
            GlobalAccess.GetCity().Buildings.Remove(this.GetComponent<Building>());
            GameObject.Destroy(this.gameObject);
        }
    }
}
