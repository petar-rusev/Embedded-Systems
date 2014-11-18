using UnityEngine;
using System.Collections;
using SerialCommunication;

public class StartStopButtons :MonoBehaviour {

    
    private bool state;
    private GameObject testLight;

    public bool State
    {
        get
        {
            return this.state;
        }
        set
        {
            this.state = value;
        }
    }
    void Start () 
    {
        
        testLight = GameObject.Find("TestLight");
        
	}
    
    void ToggleLights()
    {
        if (this.State == false)
        {
            testLight.light.intensity=0;
        }
        else
        {
            testLight.light.intensity=2;
        }
        
    }
    void OnClick()
    {
        //Switching the states according to the pressed button
        string Button = gameObject.name;
        
        if (Button == "Start")
        {
            this.State = true;
            Connection.arduino.Sp.Write("S");
            ToggleLights();
        }
        if (Button == "Stop")
        {
            Connection.arduino.Sp.Write("F");
            this.State = false;
            ToggleLights();
        }
    }
   
}
