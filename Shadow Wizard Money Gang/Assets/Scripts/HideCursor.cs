using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.visible = false;
    }


}
