using System;

public class DebugAttribute : Attribute
{
    public bool IsValid { get; set; }
    public DebugAttribute(bool _isValid = true) => IsValid = _isValid;
}
