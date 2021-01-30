using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class events : MonoBehaviour
{
    bool sqTouch = false;
    public Transform hehe;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("touched "+collision.gameObject.name);
        sqTouch = true;
        
        // if touch square make a boolean true
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("stopped touching "+collision.gameObject.name);
        sqTouch = false;
        //if stopped touching square make boolean false (or make it false ofter doing smth)
    }

    IEnumerator flip_screen()
    {
        hehe = gameObject.transform.GetChild(0);
        var rotationVector = hehe.transform.rotation.eulerAngles;
        rotationVector.z = 180;
        hehe.transform.rotation = Quaternion.Euler(rotationVector);
        yield return new WaitForSeconds(5f);
        rotationVector.z = 0;
        hehe.transform.rotation = Quaternion.Euler(rotationVector);

    }

    void Update()
    {
        if (sqTouch==true)
        {
            StartCoroutine("flip_screen");
            sqTouch = false;
        }
    }

}
