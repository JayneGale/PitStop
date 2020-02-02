using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public Button menuButtons;

    void OnEnable()
    {
        Invoke("Highlight", 0.3f);
    }

    void Highlight()
    {
        menuButtons.Select();
    }
}
