namespace DotNetScripting
{
    public class RunScriptData
    {
        public ScriptLanguage Language { get; set; }
        public ScriptScope Scope { get; set; }
        public string BeforeFileScript { get; set; }
        public string AfterFileScript { get; set; }
        public string LineScript { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as RunScriptData;
            if(other == null)
                return false;
            return Language == other.Language
                   && Scope == other.Scope
                   && BeforeFileScript == other.BeforeFileScript
                   && AfterFileScript == other.AfterFileScript
                   && LineScript == other.LineScript;
        }

        public override int GetHashCode()
        {
            return (BeforeFileScript + AfterFileScript + LineScript).GetHashCode();
        }
    }
}