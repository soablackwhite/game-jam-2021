using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileAssignment : MonoBehaviour
{
    int i = 0;
    int z = 0;
    int counter = 0;
    GameObject obj1;
    GameObject obj2;
    bool right = false;
    bool left = false;
    bool up = false;
    bool down = false;
    public GameObject corner_bottomleft;
    public GameObject corner_bottomright;
    public GameObject corner_topright;
    public GameObject corner_topleft;
    public GameObject side_top;
    public GameObject side_left;
    public GameObject side_bottom;
    public GameObject side_right;
    public GameObject bridge_horizontal;
    public GameObject bridge_vertical;
    public GameObject no_adjecent;
    public GameObject middle1;
    public GameObject middle2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //void assignTile()
    //{
    //
    //    if (counter == 0)
    //    {
    //        obj1 = no_adjecent;
    //    }
    //    if (counter == 2)
    //    {
    //        if (up == true && right == true)
    //        {
    //            obj1 = corner_bottomleft;
    //        }
    //        if (down == true && right == true)
    //        {
    //            obj1 = corner_topleft;
    //        }
    //        if (down == true && left == true)
    //        {
    //            obj1 = corner_topright;
    //        }
    //        if (up == true && left == true)
    //        {
    //            obj1 = corner_bottomright;
    //        }
    //        if (right == true && left == true)
    //        {
    //            obj1 = bridge_vertical;
    //        }
    //        if (up == true && down == true)
    //        {
    //            obj1 = bridge_horizontal;
    //        }
    //
    //    }
    //
    //    counter = 0;
    //    left = false;
    //    down = false;
    //    up = false;
    //    right = false;
    //    i++;
    //
    //}
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("floor" + i) != null)
        {
            
            obj1 = GameObject.Find("floor" + i);
            float obj1x = obj1.GetComponent<Transform>().position.x;
            float obj1y = obj1.GetComponent<Transform>().position.y;
            Debug.Log("floor"+i+" |obj1x = " + obj1x + " | obj1y = " + obj1y);
            
            Vector2 check = new Vector2(obj1x+1.6f, obj1y);
            Debug.Log("Checking: "+check.x+" "+check.y);
            Collider2D temp = Physics2D.OverlapPoint(check);
            Debug.Log("floor" + i + "|" + temp);
            i++;
        }
        
    }
}
