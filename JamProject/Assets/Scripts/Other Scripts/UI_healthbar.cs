using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_healthbar : MonoBehaviour
{

    public GameObject dialogue_box;
    public GameObject conversation_indicator;
    public GameObject interaction_indicator;
    public GameObject health_bar;
    public GameObject boss_health_bar;
    public GameObject gauge_bar;
    public Text ability_text;
    public Text CT_count;
    public GameObject passive_icon1;
    public GameObject passive_icon2;
    private GameObject player;
    private GameObject boss;
    private Scr_PlayerControl player_script;
    private Slider actual_bar;
    private Slider actual_boss_HP_bar;
    private Slider actual_gauge;
    public Text Crouton_count;
    public int sceneid;

    public Sprite[] abilitylist;
    public Sprite[] abilityfilllist;
    public GameObject ability;
    public GameObject abilityfill;

    public GameObject panel;


    private master_script ms;
    // Use this for initialization
    void Start()
    {
        if (passive_icon1 != null)
        {
            passive_icon1.SetActive(false);
        }
        if (passive_icon2 != null)
        {
            passive_icon2.SetActive(false);
        }
        boss_health_bar.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        player_script = player.GetComponent<Scr_PlayerControl>();
        actual_bar = health_bar.GetComponent<Slider>();
        actual_gauge = gauge_bar.GetComponent<Slider>();
        actual_boss_HP_bar = boss_health_bar.GetComponent<Slider>();
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        dialogue_box.SetActive(false);
        conversation_indicator.SetActive(false);

        abilityfill.SetActive(false);
        panel.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player_script = player.GetComponent<Scr_PlayerControl>();
        }
        if(boss != null){
            actual_boss_HP_bar.value = boss.GetComponent<boss_script>().health;
        }
        actual_bar.value = player_script.health;
        actual_gauge.value = player_script.Ability_gauge();
        CT_count.text = ms.getCT().ToString();
        Crouton_count.text = ms.getCrouton(sceneid).ToString() + ms.gettotcrouton(sceneid);

    }
    public void SetAbilityText(int num)
    {
        ability_text.text = "Ability #" + num;
    }

    public void SetAbilityBar(int num)
    {
        if(num == 0)
        {
            abilityfill.SetActive(false);
        }
        else
        {
            abilityfill.SetActive(true);
        }
        abilityfill.GetComponent<Image>().sprite = abilityfilllist[num];
        ability.GetComponent<Image>().sprite = abilitylist[num];

    }

    public void ShowConvIndicator()
    {
        conversation_indicator.SetActive(true);
    }
    public void HideConvIndicator()
    {
        conversation_indicator.SetActive(false);
    }
    public void ShowDialogueBox()
    {
        dialogue_box.SetActive(true);
    }
    public void HideDialogueBox()
    {
        dialogue_box.SetActive(false);
    }
    public void ShowInterIndicator()
    {
        interaction_indicator.SetActive(true);
    }
    public void HideInterIndicator()
    {
        interaction_indicator.SetActive(false);
    }
    public void HidePassive1()
    {
        passive_icon1.SetActive(false);
    }
    public void ShowPassive1()
    {
        passive_icon1.SetActive(true);
    }
    public void HidePassive2()
    {
        passive_icon2.SetActive(false);
    }
    public void ShowPassive2()
    {
        passive_icon2.SetActive(true);
    }
    public void ShowBossHP()
    {
        boss_health_bar.SetActive(true);
    }
    public void HideBossHP(){
        boss_health_bar.SetActive(false);
    }
}
