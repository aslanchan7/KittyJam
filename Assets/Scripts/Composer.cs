using UnityEngine;
using System.IO;

// This class will handle receiving a beatmap(txt) file and convert it into game objects 
public class Composer : MonoBehaviour
{
    public TextAsset beatmap;
    public GameObject[] ShortNotePrefabs;
    public GameObject[] LongNotePrefabs;
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
            if (float.Parse(components[2]) == 0f)
            {
                InstantiateShortNote(components[0]);
            }
            else
            {
                InstanstiateLongNote(components[0], float.Parse(components[2]));
            }
        }
    }

    void InstantiateShortNote(string noteDirs)
    {
        if (noteDirs.Contains('L'))
        {
            GameObject instantiated = Instantiate(ShortNotePrefabs[0], transform);
            instantiated.transform.localPosition = new(ShortNotePrefabs[0].transform.localPosition.x, currBeatOffset);
        }

        if (noteDirs.Contains('U'))
        {
            GameObject instantiated = Instantiate(ShortNotePrefabs[1], transform);
            instantiated.transform.localPosition = new(ShortNotePrefabs[1].transform.localPosition.x, currBeatOffset);
        }

        if (noteDirs.Contains('D'))
        {
            GameObject instantiated = Instantiate(ShortNotePrefabs[2], transform);
            instantiated.transform.localPosition = new(ShortNotePrefabs[2].transform.localPosition.x, currBeatOffset);
        }

        if (noteDirs.Contains('R'))
        {
            GameObject instantiated = Instantiate(ShortNotePrefabs[3], transform);
            instantiated.transform.localPosition = new(ShortNotePrefabs[3].transform.localPosition.x, currBeatOffset);
        }
    }

    void InstanstiateLongNote(string noteDirs, float noteDuration)
    {
        if (noteDirs.Contains('L'))
        {
            GameObject instantiated = Instantiate(LongNotePrefabs[0], transform);
            instantiated.transform.localPosition = new(LongNotePrefabs[0].transform.localPosition.x, currBeatOffset);
            Transform end = instantiated.transform.Find("End");
            SpriteRenderer filler = instantiated.transform.Find("LongNoteFiller").GetComponent<SpriteRenderer>();

            end.localPosition = new(end.localPosition.x, noteDuration);
            filler.size = new(filler.size.x, noteDuration);
        }

        if (noteDirs.Contains('U'))
        {
            GameObject instantiated = Instantiate(LongNotePrefabs[1], transform);
            instantiated.transform.localPosition = new(LongNotePrefabs[1].transform.localPosition.x, currBeatOffset);
            Transform end = instantiated.transform.Find("End");
            SpriteRenderer filler = instantiated.transform.Find("LongNoteFiller").GetComponent<SpriteRenderer>();

            end.localPosition = new(end.localPosition.x, noteDuration);
            filler.size = new(filler.size.x, noteDuration);
        }

        if (noteDirs.Contains('D'))
        {
            GameObject instantiated = Instantiate(LongNotePrefabs[2], transform);
            instantiated.transform.localPosition = new(LongNotePrefabs[2].transform.localPosition.x, currBeatOffset);
            Transform end = instantiated.transform.Find("End");
            SpriteRenderer filler = instantiated.transform.Find("LongNoteFiller").GetComponent<SpriteRenderer>();

            end.localPosition = new(end.localPosition.x, noteDuration);
            filler.size = new(filler.size.x, noteDuration);
        }

        if (noteDirs.Contains('R'))
        {
            GameObject instantiated = Instantiate(LongNotePrefabs[3], transform);
            instantiated.transform.localPosition = new(LongNotePrefabs[3].transform.localPosition.x, currBeatOffset);
            Transform end = instantiated.transform.Find("End");
            SpriteRenderer filler = instantiated.transform.Find("LongNoteFiller").GetComponent<SpriteRenderer>();

            end.localPosition = new(end.localPosition.x, noteDuration);
            filler.size = new(filler.size.x, noteDuration);
        }
    }

    float GetBeatOffset(string offset)
    {
        string[] fractionParts = offset.Split('/');

        if (fractionParts.Length == 2)
        {
            if (int.TryParse(fractionParts[0], out int numerator) && int.TryParse(fractionParts[1], out int denominator))
            {
                return numerator / (float)denominator;
            }
        }

        return float.Parse(offset);
    }
}
