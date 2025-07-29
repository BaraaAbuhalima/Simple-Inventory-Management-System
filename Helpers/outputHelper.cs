struct OutputChoice
{
    public string Message;
    public Action CallBack;
}
static class OutputHelper
{
    public static void DisplayOutputChoices(List<OutputChoice> outputChoicesList)
    {
        for (int i = 0; i < outputChoicesList.Count; i++)
        {
            Console.WriteLine($"{i+1}.  {outputChoicesList[i].Message}");
        }
        int index = InputHelper.ReadChoice(1, outputChoicesList.Count)-1;
        outputChoicesList[index].CallBack();

    }
}