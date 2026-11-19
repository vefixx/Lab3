namespace Part2;

public class Money
{
    private uint _rubles;
    private byte _kopeks;

    public Money(uint rubles, byte kopeks)
    {
        Rubles = rubles;
        Kopeks = kopeks;
    }

    public uint Rubles
    {
        get { return _rubles; }
        private set { _rubles = value; }
    }

    public byte Kopeks
    {
        get { return _kopeks; }
        private set
        {
            if (value > 99)
            {
                throw new ArgumentException("Копейки должны быть в диапазоне 0-99");
            }

            _kopeks = value;
        }
    }

    public Money AddKopeks(uint kopeksToAdd)
    {
        uint totalKopeks = (uint)(Rubles * 100 + Kopeks + kopeksToAdd);
        uint newRubles = totalKopeks / 100;
        byte newKopeks = (byte)(totalKopeks % 100);
        return new Money(newRubles, newKopeks);
    }

    public static Money operator --(Money m)
    {
        uint totalKopeks = m.Rubles * 100 + m.Kopeks;

        if (totalKopeks == 0)
        {
            throw new InvalidOperationException("Нельзя вычесть копейку из нулевой суммы");
        }

        totalKopeks--;
        return new Money(totalKopeks / 100, (byte)(totalKopeks % 100));
    }

    public static explicit operator uint(Money m)
    {
        return m.Rubles;
    }

    public static implicit operator double(Money m)
    {
        return m.Rubles + m.Kopeks / 100.0;
    }

    public static Money operator +(Money m, uint kopeks)
    {
        return m.AddKopeks(kopeks);
    }

    public static Money operator +(uint kopeks, Money m)
    {
        return m.AddKopeks(kopeks);
    }

    public static Money operator -(Money m, uint kopeks)
    {
        uint totalKopeks = m.Rubles * 100 + m.Kopeks;

        if (kopeks > totalKopeks)
        {
            throw new InvalidOperationException("Результат не может быть отрицательным");
        }

        totalKopeks -= kopeks;

        return new Money(totalKopeks / 100, (byte)(totalKopeks % 100));
    }

    public static Money operator -(uint kopeks, Money m)
    {
        uint totalKopeks = m.Rubles * 100 + m.Kopeks;

        if (totalKopeks > kopeks)
        {
            throw new InvalidOperationException("Результат не может быть отрицательным");
        }

        kopeks -= totalKopeks;

        return new Money(kopeks / 100, (byte)(kopeks % 100));
    }

    public override string ToString()
    {
        return $"{_rubles} руб. {_kopeks} коп.";
    }
}