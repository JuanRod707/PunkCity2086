using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject Explosion;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}


