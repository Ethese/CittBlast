using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using CnControls;

namespace Cheche
{
    public class Movimiento : MonoBehaviour
    {
        public float maxSpeed;
        public float rotSpeed = 180f;
        public bool isDown;
        public Animator anim;
        public Vector3 pos;
        public Quaternion rot;
        public GameObject planeta;

        public GameObject joystick;
        public AudioClip shootSound;
        private AudioSource source;

        void Start()
        {
            anim = GetComponent<Animator>();
            source = GetComponent<AudioSource>();
        }

        void FixedUpdate()
        {
            shipMov();
        }
        void Update()
        {

        }

        void shipMov()
        {
            rot = transform.rotation;
            pos = transform.position;
            anim.SetBool("IsMoving", false);
            maxSpeed = 0;

            if (CnInputManager.GetAxis("Horizontal") != 0)
            {
                if (isDown == false)
                {
                    // ROTATE the ship.
                    // Grab our rotation quaternion
                    // Grab the Z euler angle
                    float z = rot.eulerAngles.z;
                    // Change the Z angle based on input
                    z -= CnInputManager.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
                    // Recreate the quaternion
                    rot = Quaternion.Euler(0, 0, z);
                    // Feed the quaternion into our rotation
                    transform.rotation = rot;
                    // Finally, update our position!!
                    transform.position = pos;
                }
            }

            if (CnInputManager.GetAxis("Vertical") == 0)
            {
                isDown = false;
                rot = Quaternion.Euler(0, 0, 0);
            }

            if (CnInputManager.GetButton("Boost"))
            {
                Debug.Log("wea");
                source.Play();
                maxSpeed = 5f;
                Vector3 velocity = new Vector3(maxSpeed * Time.deltaTime, 0, 0);

                pos += transform.rotation * velocity;

                transform.position = pos;
                anim.SetBool("IsMoving", true);
            }


            if (CnInputManager.GetButtonUp("Boost"))
            {
                source.Stop();
            }
        }
    }
}


