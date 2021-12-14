using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lab3zad4 : MonoBehaviour
{
    public GameObject cube;
    void Start()
    {
         int[,] tablica=new int[10,2];
         for(int i=0;i<10;)
         {
             int a=Random.Range(1,10);
             int b=Random.Range(1,10);
             tablica[i,0]=a-5;
             tablica[i,1]=b-5;
             for (int j=0;j<i;j++)
             {
                if(tablica[j,0]==tablica[i,0])
                    if(tablica[j,1]==tablica[i,1])
                        continue;
             }
             Instantiate(cube, new Vector3(tablica[i,0], 12, tablica[i,1]), Quaternion.identity);
             i++;
         }
    }

    void Update()
    {
        
    }
}