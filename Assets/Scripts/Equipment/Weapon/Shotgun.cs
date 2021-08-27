using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shotgun : Weapon
{
    public int numOfBulletPerBurst = 0;
    public float spreadForce = 0f;

    public override void Shoot(LayerMask targetLayerMask, Vector3 to)
    {
        for (int i = 0; i < numOfBulletPerBurst; i++)
        {
            Bullet bulletInstance = Managers.Resource.Instantiate("Bullet").gameObject.GetOrAddComponent<Bullet>();
            bulletInstance.transform.position = weaponInfo.launchPos.position;
            bulletInstance.Init(GetOwner().Stat, targetLayerMask, to + new Vector3(Random.Range(-1f,1f), Random.Range(-0.5f, 1f), Random.Range(0f, 1f)) * spreadForce);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
