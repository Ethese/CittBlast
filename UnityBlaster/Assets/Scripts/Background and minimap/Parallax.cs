using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Cheche
{
    public class Parallax : MonoBehaviour
    {
        void FixedUpdate()
        {
            MeshRenderer mr = GetComponent<MeshRenderer>();
            Material mat = mr.material;
            Vector2 offset = mat.mainTextureOffset;

            offset.x += Time.deltaTime / 5;
            mat.mainTextureOffset = offset;
            //parallax();
        }

        /*void parallax()
        {
            material = mr.material;
            Vector2 offset = material.mainTextureOffset;

            offset.x += Time.deltaTime;
            //offset.y = Time.deltaTime;
        }*/
    }
}
