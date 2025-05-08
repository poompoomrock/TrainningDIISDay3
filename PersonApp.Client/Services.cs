namespace PersonApp.Client
{
    public class SingletonService
    {
        public int Value { get; set; }
    }

    public class TransientService
    {
        public int Value { get; set; }
    }

    public class ScopeService
    {
        public int Value { get; set; }
    }
}