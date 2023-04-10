using System.Text;

class Tank : ICloneable
{
    private string _name;
    public string Name
    {
        get => _name;
        set => _name = (String.IsNullOrEmpty(value) 
                        || String.IsNullOrWhiteSpace(value) ? "без назви" : value);
    }

    private int _strength;
    public int Strength
    {
        get => _strength;
        set => _strength = value;
    }

    private int _protection;
    public int Protection
    {
        get => _protection;
        set => _protection = value;
    }

    private int _speed;
    public int Speed
    {
        get => _speed; 
        set => _speed = value;
    }

    private float _weight;
    public float Weight
    {
        get => _weight; 
        set => _weight = value;
    }

    public Tank()
    {
        _name = "без назви";
        _strength = 0;
        _protection = 0;
        _speed = 0;
        _weight = 0;
    }

    public Tank(string name, int strength, int protection, int speed, float weight)
    {
        if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name)) 
            _name = "без назви";
        
        _name = name;
        _strength = strength;
        _protection = protection;
        _speed = speed;
        _weight = weight;
    }

    public object Clone() => this.MemberwiseClone();

    public override string ToString()
    {
        return $"ТАНК {_name}:" +
            $"\nсила -> {_strength}" +
            $"\nзахист -> {_protection}" +
            $"\nшвидкість -> {_speed}" +
            $"\nвага -> {_weight}";
    }
}

internal static class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Tank Empty = new Tank();

        Tank NotEmpty = (Tank)Empty.Clone();

        Console.WriteLine($"ОРИГІНАЛ ТАНКУ:\n{Empty}" +
                          $"\n\n//--//--//\n//--//--//" +
                          $"\n\nКОПІЯ ТАНКУ ДО ЗМІНИ ІМ'Я:\n{NotEmpty}");

        NotEmpty.Name = "з назвою";

        Console.WriteLine($"\n//--//--//\n//--//--//" +
                          $"\n\nКОПІЯ ТАНКУ ПІСЛЯ ЗМІНИ ІМ'Я:\n{NotEmpty}" +
                          $"\n\n//--//--//\n//--//--//" +
                          $"\n\nОРИГІНАЛ ТАНКУ:\n{Empty}");

    }
}
