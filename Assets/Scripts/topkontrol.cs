using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topkontrol : MonoBehaviour
{
    public UnityEngine.UI.Text Times,Cans,Case;
    public UnityEngine.UI.Button btn;
    private Rigidbody rg;
    public float hiz=1.7f;
    float timecounter=25;
    int Cancounter=3;
    bool isgamecontinues=true;
    bool gameOk=false;
    // Start is called before the first frame update
    void Start()
    {
        rg=GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        Cans.text=Cancounter+"";
        if(isgamecontinues && !gameOk){
        timecounter-=Time.deltaTime;
        Times.text=(int)timecounter+"";}
        else if(!gameOk){
            Case.text="Game Over";
            btn.gameObject.SetActive(true);
        }
        if(timecounter<0)
        {
            isgamecontinues=false;
        }
    }
    void FixedUpdate(){
       if(isgamecontinues && !gameOk){
        float yatay=Input.GetAxis("Horizontal");  //sag sol
        float dikey=Input.GetAxis("Vertical");
        Vector3 kuvvet=new Vector3(-dikey,0,yatay);
        rg.AddForce(kuvvet*hiz);}
        else{
            rg.velocity=Vector3.zero;
            rg.angularVelocity=Vector3.zero;
        }
    }
    void OnCollisionEnter(Collision cls){
        string objname=cls.gameObject.name;
        if(objname.Equals("final"))
        {
            gameOk=true;
            Case.text="tebrikler";
            btn.gameObject.SetActive(true);
        }
        else if(!objname.Equals("Plane") && !objname.Equals("plane1")){
            
                
                Cancounter-=1;
                Cans.text=Cancounter+"";
                if(Cancounter==0)
        {
                      isgamecontinues=false;
        }
            }
        
        
    }
}
