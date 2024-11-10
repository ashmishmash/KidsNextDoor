using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foresttings : MonoBehaviour
{
    public float Xaxis;
    public float Yaxis;
    public float Zaxis;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player.transform.eulerAngles = new Vector3(Xaxis, Yaxis, Zaxis);
    }
}
