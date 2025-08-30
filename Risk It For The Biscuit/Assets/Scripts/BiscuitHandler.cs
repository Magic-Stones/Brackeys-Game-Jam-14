using System.Collections.Generic;
using UnityEngine;

public class BiscuitHandler : MonoBehaviour
{
    [SerializeField] List<Transform> packets = new List<Transform>();
    [SerializeField] GameObject pfGoodBiscuit;
    [SerializeField] GameObject pfBadBiscuit;
    public GameObject GetPfGoodBiscuit { get => pfGoodBiscuit; }
    public GameObject GetPfBadBiscuit { get => pfBadBiscuit; }

    void Awake()
    {
        foreach (Transform packet in transform) packets.Add(packet);
    }

    // Start is called before the first frame update
    void Start()
    {
        pfGoodBiscuit.SetActive(false);
        pfBadBiscuit.SetActive(false);

        SetBiscuitType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetBiscuitType()
    {
        if (!pfGoodBiscuit || !pfBadBiscuit) return;

        foreach (Transform card in packets)
        {
            Transform cardInScene = GameObject.Find(card.name).transform;
            Transform badBiscuit;
            Transform goodBiscuit;

            int chance = Random.Range(0, 2);
            if (chance == 0)
            {
                badBiscuit = Instantiate(pfBadBiscuit, cardInScene).transform;
                badBiscuit.name = pfBadBiscuit.name;
            }
            else
            {
                goodBiscuit = Instantiate(pfGoodBiscuit, cardInScene).transform;
                goodBiscuit.name = pfGoodBiscuit.name;
            }
        }
    }
}
