using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MissingPartEnum
{
    Wheel = 1,
    Hood = 2,
    Cabin = 3,
    Boot = 4
}

public class MissingPartID : MonoBehaviour
{
    public MissingPartEnum missingPartenum;

    //public int thisPartID;

    Pickupable _carriedPart;
    GameObject _missingPart;
    GameObject _brokenPart;


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider entered by  " + other.gameObject.name);
        if (other.GetComponent<Pickupable>() != null)
        {
            _carriedPart = other.GetComponent<Pickupable>();
            Debug.Log("_carried part is " + _carriedPart.name);
            _missingPart = transform.GetChild(0).gameObject;
            Debug.Log("_missing part is " + _missingPart.name);

            if (transform.childCount > 1) _brokenPart = transform.GetChild(1).gameObject;
            else _brokenPart = null;

            switch (missingPartenum)
            {
                case MissingPartEnum.Wheel:
                    if (_carriedPart.itemID == 1) //Player is carrying a Wheel
                    {
                        if (_missingPart.activeSelf) break; //if the Wheel is not missing, don't do anything
                        else
                        {
                            _missingPart.SetActive(true);  //if the Wheel is missing, fix it (turn it on)
                            _carriedPart.gameObject.SetActive(false); //turn off the Wheel the player is carrying
                            print("Found missing part " + _carriedPart.itemName); 
                            //UpdateScore(1);
                        }
                    }
                    break;
                case MissingPartEnum.Hood:
                    if (_carriedPart.itemID == 2) //Player is carrying a Hood
                    {
                        if (_missingPart.activeSelf) break;
                        else
                        {
                            _missingPart.SetActive(true);
                            _brokenPart.SetActive(false);
                            _carriedPart.gameObject.SetActive(false);

                            print("Found missing part " + _carriedPart.itemName);
                            //UpdateScore(1);
                        }
                    }
                    break;
                case MissingPartEnum.Cabin:
                    if (_carriedPart.itemID == 3)
                    {
                        if (_missingPart.activeSelf) break;
                        else
                        {
                            _missingPart.SetActive(true);
                            _brokenPart.SetActive(false);
                            _carriedPart.gameObject.SetActive(false);

                            print("Found missing part " + _carriedPart.itemName);
                            //UpdateScore(1);
                        }
                    }
                    break;
                case MissingPartEnum.Boot:
                    if (_carriedPart.itemID == 4)
                    {
                        if (_missingPart.activeSelf) break;
                        else
                        {
                            _missingPart.SetActive(true);
                            _brokenPart.SetActive(false);
                            _carriedPart.gameObject.SetActive(false);
                            print("Found missing part " + _carriedPart.itemName);
                            //UpdateScore(1);
                        }
                    }
                    break;
                default:
                    Debug.LogError("Carried part does not one of the missing part enums" + _carriedPart.itemID);
                    break;
            }

        }

    }
}
