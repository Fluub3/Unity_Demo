using UnityEngine;

public class SerializerMono : MonoBehaviour
{
    [SerializeField] ClassTestJson testJson = null;
    [SerializeField, TextArea] string result = "";
    [SerializeField] ClassTestJson testDeserialize = null;

    private void Start()
    {
        result = Serializer<ClassTestJson>.Serialize(testJson);
        Debug.Log(result);
        testDeserialize = Serializer<ClassTestJson>.Deserialize(result);
    }
}
