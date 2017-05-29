using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageMeter : MonoBehaviour
{

    public Slider meter; //set this in the Inspector
    public int damage; //the amount of damage done so far
    public string[] collisionTags; //what should count as "Collision"?

    // Use this for initialization
    void Start()
    {
        meter.value = meter.minValue;
    }

    // Update is called once per frame
    void Update()
    {
        meter.value = damage; //constantly set the visual damage of the meter

        //lose condition check
        if (damage >= meter.maxValue)
        {
            meter.value = meter.maxValue;
            //You would then handle whatever should happen once max damage is reached on this object...
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (collisionTags.Length == 0)
        {
            //consider EVERYTHING collidable to do damage...
            damage += 5;
        }

        else
        {
            for (int i = 0; i < collisionTags.Length; i++)
            {
                //only do damage if you collide with any collision tag...
                if (col.transform.tag == collisionTags[i])
                {
                    damage += 5; //fixed value damage, (basic impact damage would be calculated based on the RigidBody velocity and force/impact variable I believe...)

                    /*
                    //You can setup specific checks on certain objects if you want damage to be different based on what you hit like:
                     * if(col.transform.tag == "Wall") { damage += 10; } //if they hit a wall, on top of the 5 base damage, they also recieve 10 damage, so hitting walls do 15 damage... 
                     */

                    break; //we found A Collision, thats all we care about, so break out the loop/dont check the other tags
                }
            }
        }
    }
}
