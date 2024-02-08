using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject katanaPrefab;
    public Transform spawn;
  
    public void CreateWeapon()
    {
        Instantiate(katanaPrefab,spawn.position,spawn.rotation);
    }
}
