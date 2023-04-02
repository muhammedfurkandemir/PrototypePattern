using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public Material material;
    public GameObject astroid;
    private void Start()
    {
        CreateAstroid();
    }

    public void CreateAstroid()
    {
        astroid = ProcAsteroid.Clone(this.transform.position);
        astroid.GetComponent<MeshRenderer>().sharedMaterial = material;
    }

   
}
