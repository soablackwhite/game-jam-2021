using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectRandom : MonoBehaviour
{
	public Sprite[] sprites;
	private int num;
    // Start is called before the first frame update
    void Start()
    {	
    	num=-1;
        if(sprites.Length>0){
        	num=Random.Range(0,sprites.Length);
    		GetComponent<SpriteRenderer>().sprite=sprites[num];
    		if(GetComponent<Animator>()!=null) GetComponent<Animator>().SetInteger("index",num);
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
