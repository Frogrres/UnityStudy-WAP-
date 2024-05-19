using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dongle lastDongle;
    public GameObject donglePrefab;
    public Transform dongleGroup;
    public GameObject effectPrefab;
    public Transform effectGroup;

    public int maxLevel;
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        NextDongle();
    }

    Dongle GetDongle()
    {
        //이펙트생성
        GameObject instantEffectObj = Instantiate(effectPrefab, effectGroup);
        ParticleSystem instantEffect = instantEffectObj.GetComponent<ParticleSystem>();
        //동글생성
        GameObject instantDongleObj = Instantiate(donglePrefab, dongleGroup);
        Dongle instantDongle = instantDongleObj.GetComponent<Dongle>();
        instantDongle.effect = instantEffect;
        return instantDongle;
    }
    void NextDongle()
    {
        Dongle newDongle = GetDongle();
        lastDongle = newDongle;
        lastDongle.manager = this;
        lastDongle.level = Random.Range(0, maxLevel);
        lastDongle.gameObject.SetActive(true);
        StartCoroutine("WaitNext");
    }

    IEnumerator WaitNext()
    {
        while (lastDongle != null)
        {
            yield return null;
        }

        yield return new WaitForSeconds(2.5f);

        NextDongle();
    }
 
    public void TouchDown()
    {
        if (lastDongle == null)
            return;     

        lastDongle.Drag();
    }

    public void TouchUp()
    {
        if (lastDongle == null)
            return;

        lastDongle.Drop();
        lastDongle = null;
    }


}
