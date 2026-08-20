using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MirrorPair
{
    public Transform real;
    public Transform mirrored;
}

public class Mirror : MonoBehaviour
{
    [SerializeField] private List<MirrorPair> mirrorPairs;

    private void Update()
    {
        foreach (MirrorPair pair in mirrorPairs)
        {
            pair.mirrored.position = new Vector3(pair.real.position.x,pair.real.position.y, 2f * transform.position.z - pair.real.position.z );
            pair.mirrored.rotation = new Quaternion(pair.real.rotation.x,pair.real.rotation.y, -pair.real.rotation.z, -pair.real.rotation.w);
        }
    }
}
