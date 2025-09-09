public class GPU
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public int VramGb { get; set; }
    public string VramType { get; set; } = null!;
    public int LengthMm { get; set; }
    public int PowerConsumptionW { get; set; }
    public int TdpW { get; set; } 
    public string Interface { get; set; } = null!;
}

public class NvidiaGpu : GPU
{
    public int CudaCores { get; set; }
    public int TensorCores { get; set; }
}

public class AmdGpu : GPU
{
    public int StreamProcessors { get; set; }
    public bool InfinityCache { get; set; }
}
