try
{
    Dictionary<string, int> people = new();
    Console.WriteLine("Put a path to archive .txt");
    var path = Console.ReadLine();

    if (path == null)
    {
        throw new ArgumentNullException("This path is null");
    }

    using StreamReader sr = new(new FileStream(path, FileMode.Open));
    while (!sr.EndOfStream)
    {
        var vet = sr.ReadLine()?.Split(',');
        if (vet == null) throw new ArgumentNullException("Archive don't be empty");

        var candidate = vet[0];
        var votes = int.Parse(vet[1]);

        if (people.ContainsKey(candidate))
        {
            people[candidate] += votes;
        }
        else
        {
            people[candidate] = votes;
        }
    }

    Console.WriteLine("Candidates: ");
    foreach(var item in people.OrderByDescending(c => c.Value))
    {
		Console.WriteLine(item.Key + ": " + item.Value);
    }

}
catch(IOException ex)
{
	Console.WriteLine(ex.Message);
}
catch(Exception ex)
{
	Console.WriteLine(ex.Message);
}