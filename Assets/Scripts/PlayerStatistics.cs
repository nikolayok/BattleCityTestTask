using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    private int _points = 0;

    public void AddPoints()
    {
        _points += 100;
    }

    public int GetPoints()
    {
        return _points;
    }
}
