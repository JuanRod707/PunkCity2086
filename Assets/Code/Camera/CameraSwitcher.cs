using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject PlayerCarPf;

    private bool isChase;
    private Vector3 startingLocal;
    private Transform startingParent;
    private Transform traffic;
    private Chasecam chaseCam;
    private HovercarAnchor player;

    void Start()
    {
        startingLocal = this.transform.localPosition;
        startingParent = this.transform.parent;
        traffic = GameObject.Find("Traffic").transform;
        chaseCam = this.GetComponent<Chasecam>();
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isChase)
            {
                isChase = true;
                chaseCam.enabled = true;
                this.transform.SetParent(null);
                chaseCam.AttachToAnchor(traffic.GetComponentsInChildren<HovercarAnchor>().PickOne());
            }
            else
            {
                isChase = false;
                chaseCam.enabled = false;
                this.transform.SetParent(startingParent);
                this.transform.localPosition = startingLocal;
                this.transform.LookAt(Vector3.up);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) && isChase)
        {
            chaseCam.AttachToAnchor(traffic.GetComponentsInChildren<HovercarAnchor>().PickOne());
        }

        if(Input.GetKeyDown(KeyCode.P) && isChase)
        {
            if (player == null)
            {
                var car = Instantiate(PlayerCarPf, new Vector3(0f, 300f, -3000f), Quaternion.identity)
                    .GetComponent<HovercarAnchor>();
                player = car;
            }

            chaseCam.AttachToAnchor(player);
        }
    }
}
