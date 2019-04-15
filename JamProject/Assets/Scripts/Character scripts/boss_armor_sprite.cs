using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_armor_sprite : MonoBehaviour
{
    public GameObject morbid_morbier;
    public GameObject boss;
    public GameObject spatula_L;
    public GameObject spatula_R;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Attack(){
        Debug.Log("sprite calls Attack()");
        boss.SendMessage("StartAttack");
    }
    public void GoStandbyPos(){
        Debug.Log("sprite calls GoStandbyPos()");
        boss.SendMessage("MoveToOppositeStandbyLocation");
    }
    public void EndSpatula(){
        Debug.Log("sprite calls EndSpatula()");
        boss.GetComponent<boss_script>().ResetAttackSelection();
        boss.SendMessage("MoveToOppositeStandbyLocation");
    }
    public void Damage()
    {
        Debug.Log("spatula damage");
        if (boss.GetComponent<boss_script>().OnLeft())
        {
            spatula_R.SendMessage("InflictDamage");
        }
        else if (boss.GetComponent<boss_script>().OnRight())
        {
            spatula_L.SendMessage("InflictDamage");
        }
    }
    public void BossFall(){
        morbid_morbier.SendMessage("Fall");
    }
}
