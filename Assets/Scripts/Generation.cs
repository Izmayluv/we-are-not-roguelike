using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{

    public GameObject wall;
    public GameObject wall2;
    public GameObject floor;
    public GameObject wallR;
    public GameObject wallL;
    public GameObject wallU;
    public GameObject wallD;

    public GameObject wallI;
    public GameObject wall2I;
    public GameObject floorI;
    public GameObject wallRI;
    public GameObject wallLI;
    public GameObject wallUI;
    public GameObject wallDI;

    public Transform grid;
    public Transform gridI;

    public static int[,] rp=new int[32,32];
    public static int[,] sp = new int[32,32];

    public static int bossRoomX;
    public static int bossRoomY;

    public static int tpRoomX = 0;
    public static int tpRoomY = 0;

    public static int bossRoomXI;
    public static int bossRoomYI;

    public int TESTbossRoomX;
    public int TESTbossRoomY;

    public int TESTbossRoomXI;
    public int TESTbossRoomYI;



    // Start is called before the first frame update
    void Start()
    {
        int persx = 16;
        int persy = 16;

        
            for (int i = 0; i < 32; i++)
                for (int j = 0; j < 32; j++)
                    sp[i, j] = 0;
            
            sp[16, 16] = 1;
            //Random rnd = new Random();




        for (int i = 0; i < 25; i++)
        {

            if( i < 10 )
            {
                int r = 1;
                while (r == 1)
                {
                    int a = Random.Range(1, 4);
                    if (a == 1)
                        if (sp[persx, persy - 1] == 0)
                        {
                            persy -= 1;
                            sp[persx, persy] = 1;
                            r = 0;
                        }
                    if (a == 2)
                        if (sp[persx - 1, persy] == 0)
                        {
                            persx -= 1;
                            sp[persx, persy] = 1;
                            r = 0;
                        }
                    if (a == 3)
                        if (sp[persx, persy + 1] == 0)
                        {
                            persy += 1;
                            sp[persx, persy] = 1;
                            r = 0;
                        }
                    if (a == 4)
                        if (sp[persx + 1, persy] == 0)
                        {
                            persx += 1;
                            sp[persx, persy] = 1;
                            r = 0;
                        }
                }

                if (i == 9)
                {
                    bossRoomX = persx;
                    bossRoomY = persy; 
                }

                if (i == 10)
                {
                    tpRoomX = persx;
                    tpRoomY = persy;

                    TESTbossRoomX = persx;
                    TESTbossRoomY = persy;
                }
                
                GameObject newRoom = Instantiate(wall, grid);
                GameObject newRoom1 = Instantiate(wall2, grid);
                GameObject newRoom2 = Instantiate(floor, grid);

                newRoom.transform.position = new Vector3((persx - 16) * 23, (persy - 16) * 17, 0);
                newRoom1.transform.position = new Vector3((persx - 16) * 23, (persy - 16) * 17, -3);
                newRoom2.transform.position = new Vector3((persx - 16) * 23, (persy - 16) * 17, 0);
            }
                                ///////////////////////////ICE/////////////////////////////////////////

            else
            {
                int r = 1;
                while (r == 1)
                {
                    
                    int a = Random.Range(1, 4);
                    if (a == 1)
                        if (sp[persx, persy - 1] == 0)
                        {
                            persy -= 1;
                            sp[persx, persy] = 2;
                            r = 0;
                        }
                    if (a == 2)
                        if (sp[persx - 1, persy] == 0)
                        {
                            persx -= 1;
                            sp[persx, persy] = 2;
                            r = 0;
                        }
                    if (a == 3)
                        if (sp[persx, persy + 1] == 0)
                        {
                            persy += 1;
                            sp[persx, persy] = 2;
                            r = 0;
                        }
                    if (a == 4)
                        if (sp[persx + 1, persy] == 0)
                        {
                            persx += 1;
                            sp[persx, persy] = 2;
                            r = 0;
                        }
                }

                if (i == 24)
                {
                    bossRoomXI = persx;
                    bossRoomYI = persy;
                    TESTbossRoomXI = persx;
                    TESTbossRoomYI = persy;
                }
            
                GameObject newRoomI = Instantiate(wallI, gridI);
                GameObject newRoom1I = Instantiate(wall2I, gridI);
                GameObject newRoom2I = Instantiate(floorI, gridI);

                newRoomI.transform.position = new Vector3((persx - 16) * 23, (persy - 16) * 17, 0);
                newRoom1I.transform.position = new Vector3((persx - 16) * 23, (persy - 16) * 17, -3);
                newRoom2I.transform.position = new Vector3((persx - 16) * 23, (persy - 16) * 17, 0);
            }

            if (i == 10)
            {
                tpRoomX = persx;
                tpRoomY = persy;

                TESTbossRoomX = persx;
                TESTbossRoomY = persy;
            }
        }

        

        for(int i = 1;i<=31; i++)
        {
            for (int j=1;j<31;j++)
            {
                if (sp[i,j] == 1)
                {	
                    if(sp[i--,j] == 1)
                    {
                        rp[i,j]+=1000;
                    }

                    if(sp[i++,j] == 1)
                    {
                        rp[i,j] += 100;
                    }

                    if(sp[i,j--] == 1)
                    {
                        rp[i,j]+=10;
                    }

                    if(sp[i,j++] == 1)
                    {
                        rp[i,j] += 1;
                    }
                }
            }

        }

        for(int i = 1; i <= 31; i++) // ICE
        {
            for (int j = 1; j < 31;j++)
            {
                if (sp[i,j] == 2)
                {	
                    if(sp[i--,j] == 2)
                    {
                        rp[i,j] += 1000;
                    }

                    if(sp[i++,j] == 2)
                    {
                        rp[i,j] += 100;
                    }

                    if(sp[i,j--] == 2)
                    {
                        rp[i,j] += 10;
                    }

                    if(sp[i,j++] == 2)
                    {
                        rp[i,j] += 1;
                    }
                }
            }

        }

        GameObject newwallL;
        GameObject newwallR;
        GameObject newwallU;
        GameObject newwallD;

        GameObject newwallLI;
        GameObject newwallRI;
        GameObject newwallUI;
        GameObject newwallDI;

        for (int i = 1; i < 31; i++)
        {
            for (int j = 1; j < 31; j++)
            {
                if (sp[i,j] == 1)
                {
                    if (sp[i - 1, j] != 1)
                    {
                        newwallL = Instantiate(wallL, grid);
                        newwallL.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
                    }
                }

                if (sp[i,j] == 1)
                {
                    if (sp[i + 1, j] != 1)
                    {
                        newwallR = Instantiate(wallR, grid);
                        newwallR.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
                    }
                }

                if (sp[i,j] == 1)
                {
                    if (sp[i, j - 1] != 1)
                    {
                        newwallD = Instantiate(wallD, grid);
                        newwallD.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
                    }
                }

                if (sp[i,j] == 1)
                {
                    if (sp[i, j + 1] != 1)
                    {
                        newwallU = Instantiate(wallU, grid);
                        newwallU.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -1);
                    }
                }
            }
        }

        for (int i = 1; i < 31; i++)// ICE
        {
            for (int j = 1; j < 31; j++)
            {
                if (sp[i,j] == 2)
                {
                    if (sp[i - 1, j] != 2)
                    {
                        newwallLI = Instantiate(wallLI, gridI);
                        newwallLI.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
                    }
                }

                if (sp[i,j] == 2)
                {
                    if (sp[i + 1, j] != 2)
                    {
                        newwallRI = Instantiate(wallRI, gridI);
                        newwallRI.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
                    }
                }

                if (sp[i,j] == 2)
                {
                    if (sp[i, j - 1] != 2)
                    {
                        newwallDI = Instantiate(wallDI, gridI);
                        newwallDI.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -4);
                    }
                }

                if (sp[i,j] == 2)
                {
                    if (sp[i, j + 1] != 2)
                    {
                        newwallUI = Instantiate(wallUI, gridI);
                        newwallUI.transform.position = new Vector3((i - 16) * 23, (j - 16) * 17, -1);
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
