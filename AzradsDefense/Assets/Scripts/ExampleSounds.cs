using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSounds : MonoBehaviour
{
    private List<int> fireworkIdQueue;
    // Start is called before the first frame update
    void Start()
    {
        fireworkIdQueue = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        //Simple playing of a sound effect
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            SoundManager.instance.PlaySound("example_money");
        }

        //If you want to stop the sound based on in-game behavior, store its id somewhere.
        //In this example, i keep a queue of all the firework whistles, and use them to stop
        // whistles one by one as fireworks explode. There is room to be creative and adapt
        // this system to your required behavior here.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fireworkIdQueue.Add(SoundManager.instance.PlaySound("example_fireworkwhistle"));
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(fireworkIdQueue.Count > 0)
            {
                //stopping a sound using an id
                SoundManager.instance.StopSound(fireworkIdQueue[0]);
                fireworkIdQueue.RemoveAt(0);
                SoundManager.instance.PlaySound("example_fireworkblast");
            }
        }
    }
}
