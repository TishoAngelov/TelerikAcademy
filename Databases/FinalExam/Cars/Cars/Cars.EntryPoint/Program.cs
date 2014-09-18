namespace Cars.EntryPoint
{
    using Cars.JsonImporter;
    using Cars.QueriesExecutor;

    public class Program
    {
        public static void Main()
        {
            // Task 6
            string jsonFilesDirectory = @"..\..\..\DataFiles\";
            Importer.ImportFromDir(jsonFilesDirectory);

            // Task 7
            string xmlQueryFilePath = @"..\..\..\DataFiles\Xml\Queries.xml";
            string dirPathToSaveResults = @"..\..\..\DataFiles\Xml\Output\";
            Executor.ExecuteAllFromFile(xmlQueryFilePath, dirPathToSaveResults);
        }
    }
}
