using System.Diagnostics;

Console.WriteLine("============================START============================");

Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
Console.WriteLine(Environment.CurrentDirectory);
Console.WriteLine(Environment.Is64BitOperatingSystem);
Console.WriteLine(Environment.Is64BitProcess);
Console.WriteLine(Environment.ProcessorCount);
Console.WriteLine(Environment.IsPrivilegedProcess);
Console.WriteLine(Environment.Version);
Console.WriteLine(Environment.OSVersion);

Console.WriteLine("============================END============================");




void TestWithoutAsync(string name, int delay)
{
    Console.WriteLine($"---------------");
    var stopwatch = Stopwatch.StartNew();
    Console.WriteLine($"{name} started at {stopwatch.ElapsedMilliseconds} ms on thread {Environment.CurrentManagedThreadId}");
    Thread.Sleep(delay);
    stopwatch.Stop();
    Console.WriteLine($"{name} finished at {stopwatch.ElapsedMilliseconds} ms");
    Console.WriteLine($"---------------");
}

async Task TestWithAsync(string name, int delay)
{
    Console.WriteLine($"---------------");
    var stopwatch = Stopwatch.StartNew();
    Console.WriteLine($"{name} started at {stopwatch.ElapsedMilliseconds} ms on thread {Environment.CurrentManagedThreadId}");
    await Task.Delay(delay);
    stopwatch.Stop();
    Console.WriteLine($"{name} finished at {stopwatch.ElapsedMilliseconds} ms");
    Console.WriteLine($"---------------");
}

var stopwatch =  Stopwatch.StartNew();
Console.WriteLine("============================Without Async============================");
Console.WriteLine($"Started 3 tasks at {stopwatch.ElapsedMilliseconds} ms");
TestWithoutAsync("Task1", 1000);
TestWithoutAsync("Task2", 2000);
TestWithoutAsync("Task3", 1000);
TestWithoutAsync("Task4", 1000);
TestWithoutAsync("Task5", 5000);
TestWithoutAsync("Task6", 6000);
stopwatch.Stop();
Console.WriteLine($"Total time taken for 3 tasks: {stopwatch.ElapsedMilliseconds} ms");

Console.WriteLine("============================Using Async Await=============================");

stopwatch.Restart();
Console.WriteLine($"Started 6 tasks at {stopwatch.ElapsedMilliseconds} ms");
var task1 = TestWithAsync("Task1", 1000);
var task2 = TestWithAsync("Task2", 2000);
var task3 = TestWithAsync("Task3", 1000);
var task4 = TestWithAsync("Task4", 1000);
var task5 = TestWithAsync("Task5", 5000);
var task6 = TestWithAsync("Task6", 6000);

Task.WaitAll(task1, task2, task3, task4, task5, task6);

stopwatch.Stop();
Console.WriteLine($"Total time taken for 6 tasks: {stopwatch.ElapsedMilliseconds} ms");



Console.WriteLine("============================Thread Safety============================");

const int expected = 1000 * 1000;
var counter = 0;
var semaphore = new SemaphoreSlim(1, 1);
// object lockObject = new();
// var tasks = new List<Task>();
//
// for (var i = 0; i < 1000; i++)
// {
//     tasks.Add(Task.Run(() =>
//     {
//         for (var j = 0; j < 1000; j++)
//         {
//             lock (lockObject)
//             {
//                 counter++;
//             }
//             // Interlocked.Increment(ref counter); Only for increment/decrement
//         }
//     }));
// }

var tasks = Enumerable.Range(0, 1000).Select(async _ =>
{
    for (var j = 0; j < 1000; j++)
    {
        await semaphore.WaitAsync();

        try
        {
            counter++;
        }
        finally
        {
            semaphore.Release();
        }
    }
});

await Task.WhenAll(tasks);
Console.WriteLine($"Expected counter: {expected}");
Console.WriteLine($"Actual counter (semaphore) : {counter}");

Console.WriteLine("============================END============================");

