using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
       //låter spelaren bli en variabel kameran kan följa
        public Transform Player;


        void Update()
        //Följer spelarens x position. z-värdet är -11 så att den ligger över alla andra lager.
    {
            transform.position = new Vector3(Player.position.x, 0, -11);
        }
    }
