using UnityEngine;
using System.IO;

// This class will handle receiving a beatmap(txt) file and convert it into game objects 
public class Composer : MonoBehaviour
{
    public TextAsset beatmap;
    public GameObject[] NotePrefabs;
    private float currBeatOffset = 0f;

    void Awake()
    {
        if (beatmap == null)
        {
            Debug.LogError("Beatmap is assigned to Composer");
        }

        string[] lines = beatmap.text.Split('\n');

        foreach (var line in lines)
        {
            string[] components = line.Split(',');

            // Get beat offset from string
            currBeatOffset += GetBeatOffset(components[1]);

            // Check for which type of notes should appear
            if (int.Parse(components[2]) == 0)
            {

                InstantiateShortNote(components[0]);
            }
            else
            {
                InstanstiateLongNote();
            }
        }
    }

    void InstantiateShortNote(string noteDirs)
    {
        if (noteDirs.Contains('L'))
        {
            GameObject instantiated = Instantiate(NotePrefabs[0], transform);
            instantiated.transform.localPosition = new(NotePrefabs[0].transform.localPosition.x, currBeatOffset);
        }

        if (noteDirs.Contains('U'))
        {
            GameObject instantiated = Instantiate(NotePrefabs[1], transform);
            instantiated.transform.localPosition = new(NotePrefabs[1].transform.localPosition.x, currBeatOffset);
        }

        if (noteDirs.Contains('D'))
        {
            GameObject instantiated = Instantiate(NotePrefabs[2], transform);
            instantiated.transform.localPosition = new(NotePrefabs[2].transform.localPosition.x, currBeatOffset);
        }

        if (noteDirs.Contains('R'))
        {
            GameObject instantiated = Instantiate(NotePrefabs[3], transform);
            instantiated.transform.localPosition = new(NotePrefabs[3].transform.localPosition.x, currBeatOffset);            
        }
    }

    void InstanstiateLongNote()
    {

    }
    
    float GetBeatOffset(string offset)
    {
        string[] fractionParts = offset.Split('/');

        if(fractionParts.Length == 2)
        {
            if(int.TryParse(fractionParts[0], out int numerator) && int.TryParse(fractionParts[1], out int denominator))
            {
                return numerator / (float)denominator;
            }
        }

        return float.Parse(offset);
    }
}
