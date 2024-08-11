using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using extOSC;

public class displayHint : MonoBehaviour
{
    private double endTime;
    private bool hintIsVisible;
    public TextMeshProUGUI hintTextComp;
    public OSCReceiver Receiver;
    public string hintAddress = "/hint";

     void Start() {
        Receiver.Bind(hintAddress, displayHintOSC);
     }

    // Update is called once per frame
    void Update()
    {
        if (hintIsVisible) {
            if(Time.time > endTime) {
                hintTextComp.text = "";
                hintIsVisible = false;
            }
        }
        
    }

    public void displayHintOSC(OSCMessage message){
        endTime = Time.time + message.Values[1].IntValue;
        Debug.Log(endTime);
        hintTextComp.text = message.Values[0].StringValue;
        hintIsVisible = true;
    }
}
