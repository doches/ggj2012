using UnityEngine;
using System.Collections;

public class ScoreObject : System.IComparable {

    public string Name { get; set; }
    public int Score { get; set; }


    public int Compare(object x, object y)
    {
        return ((int)x).CompareTo((int)y);
    }

    public int CompareTo(object obj)
    {



        if (obj is ScoreObject)
        {
            //supposed to check if we're actually comparing to another score object but for the sake of TIEM
            return Score.CompareTo(((ScoreObject)obj).Score);
        }
        else
        {
            return 1;
        }
    }
}
