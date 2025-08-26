using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour
{
    [SerializeField] List<Transform> cards = new List<Transform>();
    [SerializeField] GameObject pfGoodBiscuit;
    [SerializeField] GameObject pfBadBiscuit;
    public GameObject GetPfGoodBiscuit { get => pfGoodBiscuit; }
    public GameObject GetPfBadBiscuit { get => pfBadBiscuit; }

    void Awake()
    {
        foreach (Transform card in transform) cards.Add(card);
    }

    // Start is called before the first frame update
    void Start()
    {
        pfGoodBiscuit.SetActive(false);
        pfBadBiscuit.SetActive(false);

        BiscuitCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BiscuitCard()
    {
        if (!pfGoodBiscuit || !pfBadBiscuit) return;

        foreach (Transform card in cards)
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
