namespace DisposalAndGarbageCollection
{
    internal class EmailManager : IDisposable
    {
        private bool _disposedValue = false;
        private StreamReader? _streamReader;

        public string ReadFromFile(string fileName)
        {
            _streamReader = new StreamReader(fileName);
            return _streamReader.ReadToEnd();
        }
        public void Dispose()
        {
            if (!_disposedValue && _streamReader is not null)
            {
                _disposedValue = true;
                _streamReader.Dispose();
            }
        }
    }
}
