using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int n;
    public static int hp = 6;

    public Sprite heartFull;
    public Sprite heartHalf;
    public Sprite heartEmpty;

    private SpriteRenderer spriteRender;


    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    int dead = 0;
    public GameObject player;
    public GameObject camera;
    
    // Update is called once per frame
    void Update()
    {

        switch(hp)
        {
            case 0: switch(n)
            {
                case 1: spriteRender.sprite = heartEmpty;
                break;

                case 2: spriteRender.sprite = heartEmpty;
                break;

                case 3: spriteRender.sprite = heartEmpty;
                break;
            }
            
            if (dead == 0)
            {
                player.transform.position =  new Vector3((float)-1000, (float)-1000, player.transform.position.z);
                camera.transform.position = new Vector3(-1000, (float)-1000, camera.transform.position.z);
                dead = 1;
            }
            break;

            case 1: switch(n)
            {
                case 1: spriteRender.sprite = heartHalf;
                break;

                case 2: spriteRender.sprite = heartEmpty;
                break;

                case 3: spriteRender.sprite = heartEmpty;
                break;
            }
            break;

            case 2: switch(n)
            {
                case 1: spriteRender.sprite = heartFull;
                break;

                case 2: spriteRender.sprite = heartEmpty;
                break;

                case 3: spriteRender.sprite = heartEmpty;
                break;
            }
            break;

            case 3: switch(n)
            {
                case 1: spriteRender.sprite = heartFull;
                break;

                case 2: spriteRender.sprite = heartHalf;
                break;

                case 3: spriteRender.sprite = heartEmpty;
                break;
            }
            break;

            case 4: switch(n)
            {
                case 1: spriteRender.sprite = heartFull;
                break;

                case 2: spriteRender.sprite = heartFull;
                break;

                case 3: spriteRender.sprite = heartEmpty;
                break;
            }
            break;

            case 5: switch(n)
            {
                case 1: spriteRender.sprite = heartFull;
                break;

                case 2: spriteRender.sprite = heartFull;
                break;

                case 3: spriteRender.sprite = heartHalf;
                break;
            }
            break;

            case 6: switch(n)
            {
                case 1: spriteRender.sprite = heartFull;
                break;

                case 2: spriteRender.sprite = heartFull;
                break;

                case 3: spriteRender.sprite = heartFull;
                break;
            }
            break;

        }
    }
}
