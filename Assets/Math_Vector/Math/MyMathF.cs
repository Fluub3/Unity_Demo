using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MyMathF
{
    public static float Lerp(float _a, float _b, float _t)
    {
        _t = _t >= 1.0f ? 1.0f : _t;
        _t = _t <= 0.0f ? 0.0f : _t;

        return (_t - 0) * (_b - _a) / (1 - 0) + _a;
    }

    public static float MoveTowards(float _current, float _target, float _maxDelta)
    {
        if (_target - _current <= _maxDelta)
            return _target;
        else return _current + (_target - _current) * _maxDelta;

    }


}
