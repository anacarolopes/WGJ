using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalP_1 : MonoBehaviour
{
    public static bool pegouPortalP1;

    // Start is called before the first frame update
    void Start()
    {
        pegouPortalP1 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
        pegouPortalP1 = true;
    }
}
