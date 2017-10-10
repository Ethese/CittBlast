using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cheche
{
    public class BGScroll : MonoBehaviour
    {

        public Transform start;
        float scrollSpeed;
        public float tileSizeZ;
        GameObject ship;
        private Vector3 startPosition;

        void Start()
        {
            ship = GameObject.FindGameObjectWithTag("Player");
            
        }
        void FixedUpdate()
        {
            Movimiento mov = ship.GetComponent<Movimiento>();

            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
            startPosition = start.position;
            Movenemt();
            transform.position = startPosition - mov.pos * newPosition;

            if (ship.transform.rotation.z >= 0  && ship.transform.rotation.z <= 90)
            {
                mov.pos.x = 1;
                mov.pos.y = 0;
            }
            if (ship.transform.rotation.z >= 180 && ship.transform.rotation.z <= 270)
            {
                mov.pos.x = -1;
                mov.pos.y = 0;
            }
            if (ship.transform.rotation.z >= 90 && ship.transform.rotation.z <= 180)
            {
                mov.pos.x = 0;
                mov.pos.y = 1;
            }
            if (ship.transform.rotation.z >= 270 && ship.transform.rotation.z <= 359)
            {
                mov.pos.x = 0;
                mov.pos.y = -1;
            }
        }


        void Movenemt()
        {
            Movimiento mov = ship.GetComponent<Movimiento>();
            scrollSpeed = mov.maxSpeed;
        }
    }
}
