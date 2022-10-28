using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyVector3
{
    public static Vector3 Lerp(Vector3 _a, Vector3 _b, float _t)
    {
        _t = _t >= 1.0f ? 1.0f : _t;
        _t = _t <= 0.0f ? 0.0f : _t;

        return _a + (_b - _a) * _t;
    }

    public static Vector3 MoveTowards(Vector3 _current, Vector3 _target, float _maxDelta)
    {
        if (_target.magnitude - _current.magnitude <= _maxDelta)
            return _target;
        else return _current + (_target - _current) * _maxDelta;

    }

    public static float Dot(Vector3 _vec1, Vector3 _vec2)
    {
        return (_vec1.magnitude * _vec2.magnitude) * Mathf.Cos(Vector3.Angle(_vec1, _vec2));
    }

    public static Vector3 Cross(Vector3 _vec1, Vector3 _vec2)
    {
        return new Vector3();
    }

    public static float Distance(Vector3 _a, Vector3 _b)
    {
        return .0f;
    }

    public static Vector3 Normalize(Vector3 value)
    {
        return new Vector3();

    }
}
