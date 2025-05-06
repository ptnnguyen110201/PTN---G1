using System;

public interface ISaveable
{
    string SaveKey { get; }
    object CaptureData();          
    void RestoreData(object data);

 
}
