using UnityEngine;
using System.Collections;
using SerialCommunication;

public class ButtonSendCommands :MonoBehaviour {

    
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
        UILabel lbl = GameObject.Find("Label").GetComponent<UILabel>();
        lbl.text = "Start";
        lbl.color = Color.green;
        testLight = GameObject.Find("TestLight");
        
	}
    void Update()
    {
        ToggleLights();
    }
    void ToggleButton()
    {
       
        if (this.State == false)
        {

            Connection.arduino.Sp.Write("F");  
        }
        else
        {
            Connection.arduino.Sp.Write("S");
            
        }
    }
    void ToggleText()
    {
        string start = "Start";
        string stop = "Stop";
        UILabel lbl = GameObject.Find("Label").GetComponent<UILabel>();
        if (this.State == false)
        {
            lbl.text = start;
            lbl.color = Color.green;
        }
        else
        {
            lbl.text = stop;
            lbl.color = Color.red;
        }
    }
    void ToggleLights()
    {
        if (this.State == false)
        {
            testLight.SetActive(false);
        }
        else
        {
            testLight.SetActive(true);
        }
        
    }
    void OnClick()
    {
        //Switching the states according to the pressed button
        string Button = gameObject.name;

        if (Button == "PushButton")
        {
            if (this.State == false)
            {
                this.State = true;
                ToggleButton();
                ToggleText();
                
            }
            else
            {
                this.State = false;
                ToggleButton();
                ToggleText();
                                              
            }
        }
    }
   
}
