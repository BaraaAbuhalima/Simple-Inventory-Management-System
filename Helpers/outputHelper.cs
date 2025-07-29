public struct OutputChoice
{
    public string Message;
    public Action CallBack;
}
public class OutputHelper
{
    public static void DisplayOutputChoices(List<OutputChoice> outputChoicesList)
    {
        for (var i = 0; i < outputChoicesList.Count; i++)
        {
            Console.WriteLine($"{i+1}.  {outputChoicesList[i].Message}");
        }
        var index = InputHelper.ReadChoice(1, outputChoicesList.Count)-1;
        outputChoicesList[index].CallBack();

    }
}