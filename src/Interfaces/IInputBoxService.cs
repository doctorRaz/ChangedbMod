using System.Runtime.CompilerServices;


namespace drz.ChangeDBmod.Abstractions.Interfaces
{
    public interface IInputBoxService
    {
        string GetTextByInputBox(string Message, string Title = null, string DefaultValue = null);

    }
}
