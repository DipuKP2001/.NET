using System.Diagnostics;

const string inputFiles = @"..\..\..\InputFiles";
const string outputFiles = @"..\..\..\OutputFiles";

var projectRoot = AppContext.BaseDirectory;

var inputDir = Path.Combine(projectRoot, inputFiles);
var outputDir = Path.Combine(projectRoot, outputFiles);
var files = Directory.GetFiles(inputDir, "*.txt");

Console.WriteLine("======================= Synchronous =======================");

var stopwatch = Stopwatch.StartNew();

foreach (var file in files)
{
    var fileName = Path.GetFileName(file);
    
    Console.WriteLine($"Processing {fileName}...");
    
    var content =  File.ReadAllText(file);
    
    var wordCount = content.Split(' ',  StringSplitOptions.RemoveEmptyEntries).Length;
    
    File.AppendAllText(Path.Combine(outputDir + "\\results.txt"), $"File: {fileName} words: {wordCount}");
    
    Console.WriteLine($"Done {fileName}... {Environment.NewLine}WordCount: {wordCount} words");
}

stopwatch.Stop();

Console.WriteLine($"{Environment.NewLine}Total time taken:  {stopwatch.ElapsedMilliseconds} ms");

Console.WriteLine("======================= Asynchronous =======================");

var stopWatch2 = Stopwatch.StartNew();
var tasks = new List<Task>();
var lockObject = new object();
foreach (var file in files)
{
    tasks.Add(ProcessFileAsync(file, lockObject));
}

await Task.WhenAll(tasks);

stopWatch2.Stop();
Console.WriteLine($"{Environment.NewLine}Total time taken:  {stopWatch2.ElapsedMilliseconds} ms");
return;

async Task ProcessFileAsync(string file, object lockObject)
{
    var fileName = Path.GetFileName(file);
    
    Console.WriteLine($"Processing {fileName}...");
    
    var content =  await File.ReadAllTextAsync(file);
    
    var wordCount = content.Split(' ',  StringSplitOptions.RemoveEmptyEntries).Length;
    
    lock (lockObject)
    {
        File.AppendAllText(Path.Combine(outputDir + "\\resultsAsync.txt"), $"File: {fileName} words: {wordCount}");
    }
    
    Console.WriteLine($"Done {fileName}... {Environment.NewLine}WordCount: {wordCount} words");
}