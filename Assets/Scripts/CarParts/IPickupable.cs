using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable
{
    int ItemID { get; set; }
    void Unwieldy(int UnwieldyFactor);
}
