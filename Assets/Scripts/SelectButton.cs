using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Highlight", 0.1f);
    }

    void Highlight()
    {
        gameObject.GetComponent<Button>().Select();
    }
}
