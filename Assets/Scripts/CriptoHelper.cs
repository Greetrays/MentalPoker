using UnityEngine;
using System.Numerics;
using System.Collections.Generic;

public class CriptoHelper
{
    public BigInteger GetPrimeRandomNumber(int upBound = 2, int downBound = 5)
    {
        Random random = new Random();
        BigInteger number = Random.Range(upBound, (int)BigInteger.Pow(10, downBound));

        while (CheckForSimplicity(number) == false)
        {
            number = Random.Range(upBound, (int)BigInteger.Pow(10, downBound));
        }

        return number;
    }

    public bool CheckForSimplicity(BigInteger number)
    {
        for (BigInteger i = 2; i <= number - 1; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckForMutualSimplicity(BigInteger numberA, BigInteger numberB)
    {
        TrySwap(ref numberA, ref numberB);

        for (BigInteger i = 2; i <= numberA; i++)
        {
            if (numberA % i == 0)
            {
                if (numberB % i == 0)
                {
                    return false;
                }
            }

            if (numberB % i == 0)
            {
                if (numberA % i == 0)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void TrySwap(ref BigInteger numberA, ref BigInteger numberB)
    {
        if (numberB > numberA)
        {
            BigInteger temp = numberA;
            numberA = numberB;
            numberB = temp;
        }
    }

    public List<BigInteger> FindGCDEvklid(BigInteger numberA, BigInteger numberB)
    {
        TrySwap(ref numberA, ref numberB);
        List<BigInteger> U = new List<BigInteger> { numberA, 1, 0 };
        List<BigInteger> V = new List<BigInteger> { numberB, 0, 1 };
        List<BigInteger> T = new List<BigInteger>();
        BigInteger q;

        while (V[0] > 0)
        {
            q = U[0] / V[0];
            T = new List<BigInteger> { U[0] % V[0], U[1] - q * V[1], U[2] - q * V[2] };
            U = V;
            V = T;
        }

        return U;
    }
}
