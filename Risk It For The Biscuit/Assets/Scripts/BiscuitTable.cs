using System.Collections.Generic;
using UnityEngine;

public class BiscuitTable : MonoBehaviour
{
    [SerializeField] List<Transform> plates = new List<Transform>();
    [SerializeField] List<Transform> packets = new List<Transform>();
    [SerializeField] GameObject pfBiscuitPacket;
    [SerializeField] GameObject pfGoodBiscuit;
    [SerializeField] GameObject pfBadBiscuit;
    public GameObject GetPfGoodBiscuit { get => pfGoodBiscuit; }
    public GameObject GetPfBadBiscuit { get => pfBadBiscuit; }

    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            plates.Add(transform.GetChild(i));

            int packetNumber = i + 1;
            Transform biscuitPacket = Instantiate(pfBiscuitPacket, plates[i].position, Quaternion.identity).transform;
            biscuitPacket.name = $"{pfBiscuitPacket.name} ({packetNumber})";
            packets.Add(biscuitPacket);
        }

        foreach (Transform packet in packets)
        {
            packet.SetParent(transform);
        }
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

        foreach (Transform packet in packets)
        {
            Transform packetInScene = GameObject.Find(packet.name).transform;
            Transform badBiscuit;
            Transform goodBiscuit;

            int chance = Random.Range(0, 2);
            if (chance == 0)
            {
                badBiscuit = Instantiate(pfBadBiscuit, packetInScene).transform;
                badBiscuit.name = pfBadBiscuit.name;
            }
            else
            {
                goodBiscuit = Instantiate(pfGoodBiscuit, packetInScene).transform;
                goodBiscuit.name = pfGoodBiscuit.name;
            }
        }
    }
}
