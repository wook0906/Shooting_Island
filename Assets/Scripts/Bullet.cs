using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LayerMask targetLayer;

    [HideInInspector]
    public Stat attakerStat;

    public void Init(Stat attakerStat, LayerMask targetLayer, Vector3 lockOnPosition)
    {
        this.attakerStat = attakerStat;
        this.targetLayer = targetLayer;

        gameObject.AddComponent<Rigidbody>().AddForce((lockOnPosition - transform.position).normalized * 30f + Vector3.up * 3f, ForceMode.Impulse);
    }
    public void OnTriggerEnter(Collider coll)
    {
        Debug.Log(coll.gameObject.name);
        if ((targetLayer & (1 << coll.gameObject.layer)) != 0)
        {
            //Debug.Log(coll.gameObject.name);
            coll.gameObject.SendMessage("OnAttacked",attakerStat,SendMessageOptions.DontRequireReceiver);
            Destroy();
        }
    }
    void Destroy()
    {
        Destroy(GetComponent<Rigidbody>());
        Managers.Resource.Destroy(this.gameObject);
    }

}
