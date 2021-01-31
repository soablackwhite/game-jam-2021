using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileAssignment : MonoBehaviour
{
    int i = 0;
    int z = 0;
    int y = 0;
    int counter = 0;
    int cnt = 1;
    GameObject obj1;
    GameObject obj2;
    bool done = true;
    bool topleft = false;
    bool top = false;
    bool topright = false;
    bool left = false;
    bool right = false;
    bool botleft = false;
    bool bot = false;
    bool botright = false;
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
    public GameObject island_top;
    public GameObject island_right;
    public GameObject island_left;
    public GameObject island_bot;
    public GameObject out1;
    public GameObject[] names;

    public bool startCheck=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    void Update()
    {
        if (startCheck && GameObject.Find("floor" + i) != null)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("sock");
            for (int x = 0; x < temp.Length; x++)
            {
                temp[x].GetComponent<BoxCollider2D>().enabled = false;
            }
            obj1 = GameObject.Find("floor" + i);
            float obj1x = obj1.GetComponent<BoxCollider2D>().bounds.center.x;
            float obj1y = obj1.GetComponent<BoxCollider2D>().bounds.center.y;
            Vector2 check1 = new Vector2(obj1x - 1.6f, obj1y + 1.6f);
            Vector3 coord1 = new Vector3(obj1x - 1.6f, obj1y + 1.6f);
            Vector2 check2 = new Vector2(obj1x, obj1y + 1.6f);
            Vector2 check3 = new Vector2(obj1x + 1.6f, obj1y + 1.6f);
            Vector2 check4 = new Vector2(obj1x - 1.6f, obj1y);
            Vector2 check6 = new Vector2(obj1x + 1.6f, obj1y);
            Vector2 check7 = new Vector2(obj1x - 1.6f, obj1y - 1.6f);
            Vector2 check8 = new Vector2(obj1x, obj1y - 1.6f);
            Vector2 check9 = new Vector2(obj1x + 1.6f, obj1y - 1.6f);
            Collider2D temp1 = Physics2D.OverlapPoint(check1);
            Collider2D temp2 = Physics2D.OverlapPoint(check2);
            Collider2D temp3 = Physics2D.OverlapPoint(check3);
            Collider2D temp4 = Physics2D.OverlapPoint(check4);
            Collider2D temp6 = Physics2D.OverlapPoint(check6);
            Collider2D temp7 = Physics2D.OverlapPoint(check7);
            Collider2D temp8 = Physics2D.OverlapPoint(check8);
            Collider2D temp9 = Physics2D.OverlapPoint(check9);
            if (temp1 != null) topleft = true;
            if (temp2 != null) top = true;
            if (temp3 != null) topright = true;
            if (temp4 != null) left = true;
            if (temp6 != null) right = true;
            if (temp7 != null) botleft = true;
            if (temp8 != null) bot = true;
            if (temp9 != null) botright = true;

            //Debug.Log("floor" + i + "| 1" + topleft + " 2" + top + " 3" + topright + " 4" + left + " 6" + right + " 7" + botleft + " 8" + bot + " 9" + botright);
            if (top && right) obj1.GetComponent<SpriteRenderer>().sprite = corner_bottomleft.GetComponent<SpriteRenderer>().sprite;
            if (bot && left) obj1.GetComponent<SpriteRenderer>().sprite = corner_topright.GetComponent<SpriteRenderer>().sprite;
            if (top && left) obj1.GetComponent<SpriteRenderer>().sprite = corner_bottomright.GetComponent<SpriteRenderer>().sprite;
            if (bot && right) obj1.GetComponent<SpriteRenderer>().sprite = corner_topleft.GetComponent<SpriteRenderer>().sprite;
            if (bot && top) obj1.GetComponent<SpriteRenderer>().sprite = bridge_vertical.GetComponent<SpriteRenderer>().sprite;
            if (left && right) obj1.GetComponent<SpriteRenderer>().sprite = bridge_horizontal.GetComponent<SpriteRenderer>().sprite;
            if (left && right && bot) obj1.GetComponent<SpriteRenderer>().sprite = side_top.GetComponent<SpriteRenderer>().sprite;
            if (top && right && bot) obj1.GetComponent<SpriteRenderer>().sprite = side_left.GetComponent<SpriteRenderer>().sprite;
            if (left && top && bot) obj1.GetComponent<SpriteRenderer>().sprite = side_right.GetComponent<SpriteRenderer>().sprite;
            if (left && right && top) obj1.GetComponent<SpriteRenderer>().sprite = side_bottom.GetComponent<SpriteRenderer>().sprite;
            if (left && right && bot && top) obj1.GetComponent<SpriteRenderer>().sprite = middle1.GetComponent<SpriteRenderer>().sprite;
            if (left && !top && !bot && !right) obj1.GetComponent<SpriteRenderer>().sprite = island_right.GetComponent<SpriteRenderer>().sprite;
            if (right && !top && !bot && !left) obj1.GetComponent<SpriteRenderer>().sprite = island_left.GetComponent<SpriteRenderer>().sprite;
            if (top && !bot && !left && !right) obj1.GetComponent<SpriteRenderer>().sprite = island_bot.GetComponent<SpriteRenderer>().sprite;
            if (bot && !top && !left && !right) obj1.GetComponent<SpriteRenderer>().sprite = island_top.GetComponent<SpriteRenderer>().sprite;

            if (!topleft)
            {
                GameObject OutTile;
                OutTile = Instantiate(out1, new Vector3(check1.x, check1.y, 0), Quaternion.identity);
                OutTile.name = "out" + y;
                y++;
            }
            if (!top)
            {
                GameObject OutTile;
                OutTile = Instantiate(out1, new Vector3(check2.x, check2.y, 0), Quaternion.identity);
                OutTile.name = "out" + y;
                y++;
            }
            if (!topright)
            {
                GameObject OutTile;
                OutTile = Instantiate(out1, new Vector3(check3.x, check3.y, 0), Quaternion.identity);
                OutTile.name = "out" + y;
                y++;
            }
            if (!left)
            {
                GameObject OutTile;
                OutTile = Instantiate(out1, new Vector3(check4.x, check4.y, 0), Quaternion.identity);
                OutTile.name = "out" + y;
                y++;
            }
            if (!right)
            {
                GameObject OutTile;
                OutTile = Instantiate(out1, new Vector3(check6.x, check6.y, 0), Quaternion.identity);
                OutTile.name = "out" + y;
                y++;
            }
            if (!botleft)
            {
                GameObject OutTile;
                OutTile = Instantiate(out1, new Vector3(check7.x, check7.y, 0), Quaternion.identity);
                OutTile.name = "out" + y;
                y++;
            }
            if (!bot)
            {
                GameObject OutTile;
                OutTile = Instantiate(out1, new Vector3(check8.x, check8.y, 0), Quaternion.identity);
                OutTile.name = "out" + y;
                y++;
            }
            if (!botright)
            {
                GameObject OutTile;
                OutTile = Instantiate(out1, new Vector3(check9.x, check9.y, 0), Quaternion.identity);
                OutTile.name = "out" + y;
                y++;
            }










            i++;
            topleft = false;
            top = false;
            topright = false;
            left = false;
            right = false;
            botleft = false;
            bot = false;
            botright = false;
        }
        if (done && startCheck && GameObject.Find("floor" + i) == null)
        {
            done = false;
            Debug.Log(i);
            GameObject[] tmp = GameObject.FindGameObjectsWithTag("sock");
            for (int x = 0; x < tmp.Length; x++)
            {
                tmp[x].GetComponent<BoxCollider2D>().enabled = true;
            }
            tmp[0].GetComponent<Transform>().position = GameObject.Find("floor" + (i - 1)).GetComponent<Transform>().position;
            tmp[1].GetComponent<Transform>().position = GameObject.Find("floor0").GetComponent<Transform>().position;
            GameObject[] tmp1 = GameObject.FindGameObjectsWithTag("out");
            for (int x = 0; x < tmp1.Length; x++)
            {
                tmp1[x].GetComponent<BoxCollider2D>().enabled = true;
            }
            GameObject[] tmp2 = GameObject.FindGameObjectsWithTag("floorTile");
            for (int b = 0; b < tmp2.Length; b++)
            {
                if (cnt % 6 == 0)
                {
                    GameObject floor = GameObject.Find("floor" + b);
                    float tempx = floor.GetComponent<BoxCollider2D>().bounds.center.x;
                    float tempy = floor.GetComponent<BoxCollider2D>().bounds.center.y;
                    Vector2 temporary = new Vector2(tempx, tempy);
                    int randomIndex = Random.Range(0, 6);
                    
                    GameObject OBJ = Instantiate(names[randomIndex], new Vector3(temporary.x, temporary.y, 0), Quaternion.identity);
                    cnt++;
                }
                else
                {
                    cnt++;
                }
            }
        }
        
    }
}
