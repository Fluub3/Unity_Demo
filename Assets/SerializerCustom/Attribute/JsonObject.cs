using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonObject<T>
{
    List<CommonSerialize<T>> allMembers = new List<CommonSerialize<T>>();

    public void Add(CommonSerialize<T> _member) => allMembers.Add(_member);

    string GetMemberJson()
    {
        string _tmp = "";
        for (int i = 0; i < allMembers.Count; i++)
        {
            _tmp += allMembers[i] + ((i < allMembers.Count - 1) ? ",\n" : "");
        }
        return _tmp;
    }

    public override string ToString()
    {
        return "{\n" + GetMemberJson() + "\n}";
    }
}
