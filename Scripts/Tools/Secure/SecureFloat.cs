using System;
using UnityEngine;

public struct SecureFloat
{
    private int value;
    private int salt;

    public SecureFloat(float value)
    {
        salt = UnityEngine.Random.Range(int.MinValue / 4, int.MaxValue / 4);
        int intValue = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);
        this.value = intValue ^ salt;
    }

    public override string ToString()
    {
        return ((float)this).ToString();
    }

    public static implicit operator float(SecureFloat safeFloat)
    {
        return BitConverter.ToSingle(BitConverter.GetBytes(safeFloat.salt ^ safeFloat.value), 0);
    }

    public static implicit operator SecureFloat(float normalFloat)
    {
        return new SecureFloat(normalFloat);
    }
}
