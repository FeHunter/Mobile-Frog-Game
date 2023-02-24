using System.Collections.Generic;
using UnityEngine;

public class PathNoCopys : MonoBehaviour
{

    public int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Plant")
        {
            // copys.Add (other.gameObject);

            // If this object has no PathManager = Generic Plant
            if (GetComponent<PathManager>() == null && other.GetComponent<PathManager>() == null)
            {
                GenericBehavior(other.gameObject);
            }
            // If other object has a Path... and This one not, off this
            else if (other.GetComponent<PathManager>() != null && GetComponent<PathManager>() == null)
            {
                gameObject.SetActive (false);
            }
            // If this and the other has a PathManager, so randomly choose one
            else if (other.GetComponent<PathManager>() != null && GetComponent<PathManager>() != null)
            {
                RandomChooseOne (other.gameObject);
            }
            // If this object has a Path... turn off the other
            else
            {
                other.gameObject.SetActive (false);
            }
        }    
    }

    void RandomID ()
    {
        id = Random.Range (0, 2);
    }

    void GenericBehavior (GameObject other)
    {
        if (other.GetComponent<PathNoCopys>().id == id)
        {
            RandomChooseOne (other);
        }
        else if (other.GetComponent<PathNoCopys>().id == 0 && id == 1 || other.GetComponent<PathNoCopys>().id != 0 && id == 0)
        {
            other.gameObject.SetActive (false);
        }
    }

    void RandomChooseOne (GameObject other)
    {
        do
            {
            RandomID ();
            if (other.GetComponent<PathNoCopys>().id == 0 && id != 0 || other.GetComponent<PathNoCopys>().id != 0 && id == 0)
            {
               other.gameObject.SetActive (false);
            }
        }while (other.GetComponent<PathNoCopys>().id == 1 && id == 1);
    }
}
