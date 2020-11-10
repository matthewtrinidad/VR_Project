using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHARACTERTYPE
{
    _none = -1,
    Player1,
    Player2
    
}
public class GameManager : MonoBehaviour
{
    Vector3 headsetPos;
    GameObject centerEye;
    int interval = 1;
    float nextTime = 0;
    public static GameManager instance;
    [SerializeField] private CharacterData[] characterData;
    [SerializeField] private CHARACTERTYPE[] characters;
    private CharacterData[] currentCharacters;
    [System.Serializable]
    public struct CharacterData
    {
        public string name;
        public string gender;
        public float x;
        public float y;
        public float z;

    }
     void Awake()
    {
        centerEye =GameObject.Find("VRCamera");
        instance = this;
        currentCharacters = new CharacterData[characters.Length];
        for (int i = 0; i < currentCharacters.Length;i++)
        {
            currentCharacters[i] = characterData[(int)characters[i]];
        }
    }

    // Update is called once per frame
    void Update()
    {
            if(Time.time >= nextTime)
            {
            getposition();
            CSVManager.AppendToReport(GetReportLine());
            Debug.Log("<color=green>Report updated successfully!</color>");
            nextTime += interval;
            }
            
            
        
    }
    void getposition()
    {
        headsetPos = centerEye.transform.position;
        currentCharacters[0].x = (float)headsetPos.x ;
        currentCharacters[0].y = (float)headsetPos.y ;
        currentCharacters[0].z = (float)headsetPos.z ;

        //currentCharacters[1].position = headsetPos ;

    }
    string[] GetReportLine()
    {
        string[] returnable = new string[5];
        returnable[0] = currentCharacters[0].name ;
        returnable[1] = currentCharacters[0].gender;
        returnable[2] = currentCharacters[0].x.ToString("F2");
        returnable[3] = currentCharacters[0].y.ToString("F2");
        returnable[4] = currentCharacters[0].z.ToString("F2");
        return returnable;

    }
}
