using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    private string path = "Assets/Dbase/ARMolecules.txt";

    private void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();


        string[] lines = System.IO.File.ReadAllLines(path);
        //Debug.Log("Contents of ARMolecules.txt = ");
        int i = 0;
        int num_atoms = 0;
        foreach (string line in lines)
        {
            if (i < 14)
            {
                i++;
                continue;
            }
            if (i == 14)
            {
                num_atoms = Int32.Parse(line);
                Debug.Log(num_atoms);
                i++;
                continue;
            }
            //here means i>14
            string[] atom = line.Split(' ');
            foreach (string el in atom)
            {
                //Debug.Log(el);
                switch (el)
                {

                    case "Br":
                        Debug.Log("It is Br");
                        break;

                    case "H":
                        Debug.Log("It is H");
                        break;
                    case "O":
                        Debug.Log("It is O");
                        break;

                    case "C":
                        Debug.Log("It is C");
                        break;
                    case "N":
                        Debug.Log("It is N");
                        break;
                    default:
                        Debug.Log("Nothing");
                        break;
                }
            }
            Debug.Log("\n");
            i++;
            if (i == (15 + num_atoms))
            {
                i = 0;
                //continue;
                break;
            }
            //GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);

        }
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {

            GameObject obj = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
    }
}
