using UnityEngine;

public interface IJsonObjectReader
{
    void SetRow(int index);

    string LoadString(string key);
    int LoadInt(string key);
    float LoadFloat(string key);
    bool LoadBool(string key);

    Vector3 LoadVector3(string keyX, string keyY, string keyZ);
    bool HasKey(string key);
}
