using UnityEngine;
using System.Collections;
using SerialCommunication;

public class Connection : MonoBehaviour {

    public static ArduinoTalk arduino = new ArduinoTalk("COM3", 12000);

   
	void Start () {
        arduino.OpenPort(arduino.Sp, 20);
	}
	
}
