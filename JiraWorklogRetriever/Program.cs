// See https://aka.ms/new-console-template for more information

if (args.Length<4)
{
    Console.WriteLine($"usage: ProgramName baseUrl email token howManyDays");
        return;
}

var baseUrl = args[0];
var email = args[1];
var token = args[2];
int howManyDays;
if (int.TryParse(args[3], out howManyDays))
{
    try
    {
        await Jira.Jira.JiraApiGetWorkLog(baseUrl, email, token, howManyDays);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}
else
{ 
    Console.WriteLine($"Cannot parse howManyDays to int. Usage: ProgramName baseUrl email token howManyDays");
    return;
}
