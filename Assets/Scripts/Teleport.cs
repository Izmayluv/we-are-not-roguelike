using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class Teleport : MonoBehaviour
{

    public GameObject player;
    public GameObject camera;

    public GameObject doorR;
    public GameObject doorL;
    public GameObject doorU;
    public GameObject doorD;

    public GameObject doorRI;
    public GameObject doorLI;
    public GameObject doorUI;
    public GameObject doorDI;

    public Transform grid;
    public Transform gridI;

    public static int countEnemys = 0;

    public int TESTcountEnemys = 0;
    
    public int TESTX;
    public int TESTY;

    public GameObject TP;
    GameObject newTP;

    int tpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 32; i++)
                for (int j = 0; j < 32; j++)
                    logspawn[i, j] = 0;

        logspawn[16, 16] = 1;
    }

    public GameObject GreenSlime;
    GameObject newGreenSlime;

    int[,] logspawn =  new int[32, 32];

    public void SpawnGreenSlime(int Xplayer, int Yplayer)
    {

        int greenSlimeCount = Random.Range(3, 7);
        for (int i = 0; i < greenSlimeCount; i++)
        {
            if (logspawn[Xplayer, Yplayer] == 0) 
            {
                newGreenSlime = Instantiate(GreenSlime);

                int x = Random.Range(-7, 7);
                int y = Random.Range(-3, 3);

                newGreenSlime.transform.position =  new Vector3(((float)Xplayer - 16) * 23 + (float)x, ((float)Yplayer - 16) * 17 + (float)y, -2);

                countEnemys++;
            }
        }

        //countEnemys += greenSlimeCount;
    }

    public GameObject BlueSlime;
    GameObject newBlueSlime;

    public void SpawnBlueSlime(int Xplayer, int Yplayer)
    {

        int blueSlimeCount = Random.Range(0, 3);

        for (int i = 0; i < blueSlimeCount; i++)
        {
            if (logspawn[Xplayer, Yplayer] == 0) 
            {
                newBlueSlime = Instantiate(BlueSlime);

                int x = Random.Range(-7, 7);
                int y = Random.Range(-3, 3);

                countEnemys++;

                newBlueSlime.transform.position =  new Vector3(((float)Xplayer - 16) * 23 + (float)x, ((float)Yplayer - 16) * 17 + (float)y, (float) -2.5);
            }   
        }
    }

    public GameObject RedSlime;
    GameObject newRedSlime;

    public void SpawnRedSlime(int Xplayer, int Yplayer)
    {

        int redSlimeCount = 1;

        for (int i = 0; i < redSlimeCount; i++)
        {
            if (logspawn[Xplayer, Yplayer] == 0) 
            {
                newRedSlime = Instantiate(RedSlime);

                int x = Random.Range(-7, 7);
                int y = Random.Range(-3, 3);

                countEnemys++;
                

                newRedSlime.transform.position =  new Vector3(((float)Xplayer - 16) * 23 + (float)x, ((float)Yplayer - 16) * 17 + (float)y, (float) -2.5);
            }   
        }
    }

    int Yplayer = 16;
    int Xplayer = 16;

    GameObject newDoorR;
    GameObject newDoorL;
    GameObject newDoorU;
    GameObject newDoorD;

    GameObject newDoorRI;
    GameObject newDoorLI;
    GameObject newDoorUI;
    GameObject newDoorDI;

    public void DoorPlace(int i, int j)
    {

        if (Generation.sp[i, j] == 1)
        {
            if(Generation.rp[i,j] >= 1000)
            {
                newDoorR = Instantiate(doorR, grid);
                newDoorR.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
            }

            if(Generation.rp[i,j]%1000 >= 100)
            {
                newDoorL = Instantiate(doorL, grid);
                newDoorL.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
            }

            if(Generation.rp[i,j]%100 >= 10)
            {
                newDoorU = Instantiate(doorU, grid);
                newDoorU.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, (float)-0.5);
            }

            if(Generation.rp[i,j]%10 >= 1)
            {
                newDoorD = Instantiate(doorD, grid);
                newDoorD.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
            }
        }

        else
        {
            if(Generation.rp[i,j] >= 1000) // ice
            {
                newDoorRI = Instantiate(doorRI, gridI);
                newDoorRI.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
            }

            if(Generation.rp[i,j]%1000 >= 100)
            {
                newDoorLI = Instantiate(doorLI, gridI);
                newDoorLI.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
            }

            if(Generation.rp[i,j]%100 >= 10)
            {
                newDoorUI = Instantiate(doorUI, gridI);
                newDoorUI.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, (float)-0.5);
            }

            if(Generation.rp[i,j]%10 >= 1)
            {
                newDoorDI = Instantiate(doorDI, gridI);
                newDoorDI.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
            }
        }

        d = 1;

    }

    int d = 0;

    public void DoorDestroy()
    {
        if (countEnemys == 0 && d == 1)
        {
            Destroy(newDoorD);
            Destroy(newDoorU);
            Destroy(newDoorL);
            Destroy(newDoorR);

            Destroy(newDoorDI);
            Destroy(newDoorUI);
            Destroy(newDoorLI);
            Destroy(newDoorRI);

            d = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        float y = player.transform.position.y;
        float x = player.transform.position.x;

        DoorDestroy();

        for (int i = -16; i <= 16; i++)
        {
            
            if (y < i * 17 + 7.2 && y > i * 17 + 7.0)
            {
                player.transform.position =  new Vector3(player.transform.position.x, player.transform.position.y + 4, player.transform.position.z);
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + 17, camera.transform.position.z);

                Yplayer++;

                if ((Generation.bossRoomX == Xplayer && Generation.bossRoomY == Yplayer) || (Generation.bossRoomXI == Xplayer && Generation.bossRoomYI == Yplayer)) 
                {
                    SpawnRedSlime(Xplayer, Yplayer);
                }
                else
                {
                    SpawnGreenSlime(Xplayer, Yplayer);
                    SpawnBlueSlime(Xplayer, Yplayer);
                }

                if (countEnemys > 0 && d == 0)
                {
                    DoorPlace(Xplayer, Yplayer);
                    d = 1;
                }
                

            }

            if (y < i * 17 -6.9 && y > i * 17 -7.0 )
            {
                player.transform.position =  new Vector3(player.transform.position.x, player.transform.position.y - 7, player.transform.position.z);
                camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 17, camera.transform.position.z);

                Yplayer--;

                if ((Generation.bossRoomX == Xplayer && Generation.bossRoomY == Yplayer) || (Generation.bossRoomXI == Xplayer && Generation.bossRoomYI == Yplayer))
                {
                    SpawnRedSlime(Xplayer, Yplayer);
                }
                else
                {
                    SpawnGreenSlime(Xplayer, Yplayer);
                    SpawnBlueSlime(Xplayer, Yplayer);
                }

                if (countEnemys > 0 && d == 0)
                {
                    DoorPlace(Xplayer, Yplayer);
                    d = 1;
                }
            }

            if (x < i * 23 -10.4 && x > i * 23 -10.6 )
            {
                player.transform.position =  new Vector3(player.transform.position.x - 4, player.transform.position.y, player.transform.position.z);
                camera.transform.position = new Vector3(camera.transform.position.x - 23, camera.transform.position.y, camera.transform.position.z);

                Xplayer--;

                if ((Generation.bossRoomX == Xplayer && Generation.bossRoomY == Yplayer) || (Generation.bossRoomXI == Xplayer && Generation.bossRoomYI == Yplayer))
                {
                    SpawnRedSlime(Xplayer, Yplayer);
                }
                else
                {
                    SpawnGreenSlime(Xplayer, Yplayer);
                    SpawnBlueSlime(Xplayer, Yplayer);
                }

                if (countEnemys > 0 && d == 0)
                {
                    DoorPlace(Xplayer, Yplayer);
                    d = 1;
                }
            }

            if (x < i * 23 -12.5 && x > i * 23 -12.6)
            {
                player.transform.position =  new Vector3(player.transform.position.x + 4, player.transform.position.y, player.transform.position.z);
                camera.transform.position = new Vector3(camera.transform.position.x + 23, camera.transform.position.y, camera.transform.position.z);

                Xplayer++;

                if ((Generation.bossRoomX == Xplayer && Generation.bossRoomY == Yplayer) || (Generation.bossRoomXI == Xplayer && Generation.bossRoomYI == Yplayer))
                {
                    SpawnRedSlime(Xplayer, Yplayer);
                }
                else
                {
                    SpawnGreenSlime(Xplayer, Yplayer);
                    SpawnBlueSlime(Xplayer, Yplayer);
                }

                if (countEnemys > 0 && d == 0)
                {
                    DoorPlace(Xplayer, Yplayer);
                    d = 1;
                }
            }
        }
        
        TESTcountEnemys = countEnemys;
        if ((Generation.bossRoomX == Xplayer && Generation.bossRoomY == Yplayer) || (Generation.bossRoomXI == Xplayer && Generation.bossRoomYI == Yplayer))
        {
            if (countEnemys == 0 && d == 0 && tpCount == 0)
            {
                d = 1;
                tpCount = 1;

                newTP = Instantiate(TP, grid);
                newTP.transform.position = new Vector3((Xplayer-16) * 23, (Yplayer-16) * 17, -1);
            }

            if(tpCount == 1)
            {
                if (x < newTP.transform.position.x + 1.0 && x > newTP.transform.position.x - 1.0)
                {
                    if (y < newTP.transform.position.y + 1.0 && y > newTP.transform.position.y - 1.0)
                    {
                        player.transform.position =  new Vector3((Generation.tpRoomX - 16) * 23,  (Generation.tpRoomY - 16) * 17, player.transform.position.z);
                        camera.transform.position = new Vector3((Generation.tpRoomX - 16) * 23,  (Generation.tpRoomY - 16) * 17, camera.transform.position.z);

                        Xplayer = Generation.tpRoomX;
                        Yplayer = Generation.tpRoomY;
                    }
                }
            }
            
        }

        

        DoorDestroy();
        logspawn[Xplayer, Yplayer] = 1;

        TESTX = Xplayer;
        TESTY = Yplayer;
    }
}
