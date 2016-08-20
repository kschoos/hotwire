using UnityEngine;
using System.Collections;

public class KillYourself : MonoBehaviour {

    public void destroyMe()
    {
        Destroy(gameObject);
    }
}
