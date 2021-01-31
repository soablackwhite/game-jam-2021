using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class gameManagerScript : MonoBehaviour
{
	public PlayerController sock1, sock2;
	public GameObject washingMachine;
	public float animationTime=1f;
	public float growthRate=0.5f;
	public float maxSize=7f;

	private Image washImage;
	private RectTransform rect;

	public string[] keys={"<Keyboard>/w","<Keyboard>/s","<Keyboard>/a","<Keyboard>/d","<Keyboard>/upArrow","<Keyboard>/downArrow","<Keyboard>/leftArrow","<Keyboard>/rightArrow"};


	private bool CRrunning=false;

    // Start is called before the first frame update
    void Start()
    {
        washImage=washingMachine.GetComponent<Image>();
        
        washImage.enabled=false;

        rect=washingMachine.GetComponent<RectTransform>();
        rect.localScale=new Vector3(0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard=Keyboard.current;
        if(keyboard.spaceKey.wasPressedThisFrame && !CRrunning) doingTheWash();
        if(keyboard.tKey.wasPressedThisFrame) print("key pressed");
    }

    void doingTheWash(){
    	StartCoroutine(machineAnimation(animationTime));
    	//change level layout
    	RandomizeKeys();
    }
    
    IEnumerator machineAnimation(float waitTime){
    	CRrunning=true;
    	washImage.enabled=true;
    	rect.localScale=Vector3.zero;
    	var scale=rect.localScale;
    	for(float i=0f;i<=waitTime*2/3;i+=Time.deltaTime){
    		scale=Vector3.Lerp(rect.localScale,new Vector3(maxSize,maxSize,maxSize),growthRate);
    		rect.localScale=scale;
    		yield return new WaitForSeconds(Time.deltaTime);
    	}
    	for(float i=0f;i<=waitTime/3;i+=Time.deltaTime){
    		scale=Vector3.Lerp(rect.localScale,Vector3.zero,growthRate*10);
    		rect.localScale=scale;
    		yield return new WaitForSeconds(Time.deltaTime);
    	}
    	washImage.enabled=false;
    	CRrunning=false;
    }

    void RandomizeKeys(){
    	Shuffle();
    	sock1.RandomizeKeys(keys);
    	sock2.RandomizeKeys(keys);
    }

   	public void Shuffle() { //https://answers.unity.com/questions/1189736/im-trying-to-shuffle-an-arrays-order.html
         string temp;
         for (int k = 0; k < keys.Length; k++) {
             int rnd = Random.Range(0, keys.Length);
             temp = keys[rnd];
             keys[rnd] = keys[k];
             keys[k] = temp;
         }
     }
}
