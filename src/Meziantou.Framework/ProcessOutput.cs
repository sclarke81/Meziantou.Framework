using System;

namespace Meziantou.Framework
{
    public class ProcessOutput
    {
        internal ProcessOutput(ProcessOutputType type, string text)
        {
            Text = text ?? throw new ArgumentNullException(nameof(text));
            Type = type;            
        }

        public ProcessOutputType Type { get; }
        public string Text { get; }

        public void Desconstruct(out ProcessOutputType type, out string text)
        {
            type = Type;
            text = Text;
        }
    }
}
