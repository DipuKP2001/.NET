namespace Device_Manager.Services;

public class SingletonGuidGenerator : IGuidGenerator
{
    private readonly Guid _guid = Guid.NewGuid();
    
    public Guid Generate() => _guid;
}

public class ScopedGuidGenerator : IGuidGenerator
{
    private readonly Guid _guid = Guid.NewGuid();
    
    public Guid Generate() => _guid;
}

public class TransientGuidGenerator : IGuidGenerator
{
    private readonly Guid _guid = Guid.NewGuid();
    
    public Guid Generate() => _guid;
}