namespace JesterDotNet.Model
{
    public class TestResult
    {
        protected readonly string _name;

        public TestResult(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}