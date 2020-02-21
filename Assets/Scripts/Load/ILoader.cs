using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoader 
{
    SavedStats LoadData(string fileName);
    void Save(SavedStats stats);
}
