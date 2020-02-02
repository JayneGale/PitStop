using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarPart
{
    Wheel,
    Hood,
    Cabin,
    Boot
}

public class PartPickup : MonoBehaviour
{
    public CarPart carPartEnum;
    PlayerPickUp _playerPU;

    private void OnTriggerEnter(Collider other)
    {
        _playerPU = other.GetComponent<PlayerPickUp>();
        if(_playerPU != null)
        {
            _playerPU.inTrigger = true;
            _playerPU.inTriggerObject = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _playerPU = other.GetComponent<PlayerPickUp>();
        if (_playerPU != null)
        {
            _playerPU.inTrigger = false;
            _playerPU.inTriggerObject = null;
        }
    }
}
